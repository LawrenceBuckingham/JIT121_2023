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
using System.Windows.Shapes;

namespace StudentApplication
{
    /// <summary>
    /// Interaction logic for SubjectEditor.xaml
    /// </summary>
    public partial class SubjectEditor : Window
    {
        public SubjectEditor()
        {
            InitializeComponent();
            DataContext = this;
        }

        public bool Result { get; set; }
        public string SubjectCode { get; set; } = "";
        public string SubjectName { get; set; } = "";

        private void OkButton_Click(object sender, RoutedEventArgs e) {
            Result = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            Result = false;
            Close();
        }
    }
}
