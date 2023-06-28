using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wed02_StudentExample {
    internal class Student {
        private string name;
        private int idNumber;
        private AcademicHistory history = new();

        public Student(string initialName, int initialIdNumber) {
            name = initialName;
            idNumber = initialIdNumber;
        }

        public void Enrol( Subject subject, Semester semester ) {
            history.Add(this, subject, semester);
        }
    }
}
