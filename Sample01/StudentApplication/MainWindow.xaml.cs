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

            if ( somethingChanged ) {
                var result = MessageBox.Show("You have unsaved changes, do you really want to trash them?", "Lose unsaved changes?", MessageBoxButton.YesNo);

                if ( result == MessageBoxResult.Yes ) {
                    university.Reset();
                    Refresh();
                    somethingChanged = false;
                }
            }
        }

        private void FileOpen_Click(object sender, RoutedEventArgs e) {
            if ( somethingChanged ) {
                var result = MessageBox.Show("You have unsaved changes, do you really want to trash them?", "Lose unsaved changes?", MessageBoxButton.YesNo);

                if ( result == MessageBoxResult.Yes ) {
                    LoadData();
                    Refresh();
                    somethingChanged = false;
                }
            }
        }

        private void LoadData() {
            OpenFileDialog dlg = new();
            dlg.Title = "Open results dataset";
            dlg.Filter = "Text files|*.txt|All files|*.*";

            var result = dlg.ShowDialog();

            if ( result == true ) {
                try {
                    currentFileName = dlg.FileName;
                    university.Load(currentFileName);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Error while trying to open file: {ex.Message}");
                }
            }
        }
    }
}
