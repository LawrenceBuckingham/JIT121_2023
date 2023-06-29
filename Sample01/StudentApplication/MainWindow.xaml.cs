using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Win32;

using StudentObjectModel;

namespace StudentApplication {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = this;

            // Delete this when File Open has been implemented.
            var sub = university.OfferSubject("JIT121", "Software Principles");
            var stu = university.Students.Recruit("Larry");
            university.Enrol(stu, sub);

            SubjectTable.ItemsSource = Subjects;
            StudentTable.ItemsSource = Students;

            Refresh(SubjectTable);
            Refresh(StudentTable);
        }

        private const string Filters = "Text files|*.txt|All files|*.*";

        University university = new();

        IEnumerable<Subject> Subjects {
            get {
                return university.Subjects;
            }
        }

        IEnumerable<Student> Students {
            get {
                return university.Students.All;
            }
        }

        void Refresh(DataGrid table) {
            var prevItemsSource = table.ItemsSource;
            table.ItemsSource = null;
            table.ItemsSource = prevItemsSource;
            //table.Items.Refresh();
        }

        void Refresh() {
            Refresh(SubjectTable);
            Refresh(StudentTable);
        }

        bool somethingChanged = true;
        string currentFileName = "";

        private void FileNew_Click(object sender, RoutedEventArgs e) {
            // MessageBox.Show("Clicked!!!");

            if (somethingChanged) {
                var result = MessageBox.Show("You have unsaved changes, do you really want to trash them?", "Lose unsaved changes?", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes) {
                    university.Reset();
                    Refresh();
                    somethingChanged = false;
                }
            }
        }

        private void FileOpen_Click(object sender, RoutedEventArgs e) {
            if (somethingChanged) {
                var result = MessageBox.Show("You have unsaved changes, do you really want to trash them?", "Lose unsaved changes?", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes) {
                    LoadData();
                    Refresh();
                    somethingChanged = false;
                }
            }
        }

        private void LoadData() {
            OpenFileDialog dlg = new();
            dlg.Title = "Open results dataset";
            dlg.Filter = Filters;

            var result = dlg.ShowDialog();

            if (result == true) {
                try {
                    currentFileName = dlg.FileName;
                    university.Load(currentFileName);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Error while trying to open file: {ex.Message}");
                }
            }
        }

        private void FileSave_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(currentFileName)) {
                FileSaveAs_Click(null, null);
            }
            else {
                SaveData();
            }
        }

        private void FileSaveAs_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog dlg = new();
            dlg.Title = "Save results dataset";
            dlg.Filter = Filters;

            var result = dlg.ShowDialog();

            if (result == true) {
                currentFileName = dlg.FileName;
                SaveData();
            }
        }

        private void SaveData() {
            try {
                university.SaveAs(currentFileName);
                somethingChanged = false;
            }
            catch (Exception ex) {
                MessageBox.Show($"Error saving file '{currentFileName}': {ex.Message}");
            }
        }

        private void FileClose_Click(object sender, RoutedEventArgs e) {
            if (somethingChanged) {
                var result = MessageBox.Show("You have unsaved changes, do you really want to trash them?", "Lose unsaved changes?", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes) {
                    App.Current.Shutdown();
                }
            }
        }

        private void SubjectNew_Click(object sender, RoutedEventArgs e) {
            SubjectEditor dlg = new();
            dlg.Title = "New subject";
            dlg.ShowDialog();

            if (dlg.Result == true) {
                try {
                    university.OfferSubject(dlg.SubjectCode, dlg.SubjectName);
                    somethingChanged = true;
                    Refresh();
                }
                catch (Exception ex) {
                    MessageBox.Show($"Unable to create new subject ({dlg.SubjectCode},{dlg.SubjectName}): {ex.Message}");
                }
            }
        }

        private void SubjectEdit_Click(object sender, RoutedEventArgs e) {
            if (SubjectTable.SelectedItem == null) {
                MessageBox.Show("Please select a subject to edit (click on it in the table).");
            }
            else {
                Subject selectedSubject = (Subject) SubjectTable.SelectedItem;
                SubjectEditor dlg = new();
                dlg.Title = "Edit subject";
                dlg.SubjectCode = selectedSubject.Code;
                dlg.SubjectName = selectedSubject.Name;
                dlg.ShowDialog();

                if (dlg.Result == true) {
                    string code = dlg.SubjectCode;
                    string name = dlg.SubjectName;

                    if (Subjects.Any(
                            sub => sub != selectedSubject
                            && string.Equals(sub.Code, code, StringComparison.CurrentCultureIgnoreCase)
                         )
                    ) {
                        MessageBox.Show($"Subject code {code} is already in use.");
                    }
                    else {
                        try {
                            selectedSubject.Code = code;
                            selectedSubject.Name = name;
                            somethingChanged = true;
                            Refresh();
                        }
                        catch (Exception ex) {
                            MessageBox.Show($"Unable to create new subject ({dlg.SubjectCode},{dlg.SubjectName}): {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}
