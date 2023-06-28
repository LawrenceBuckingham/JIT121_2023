using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wed02_StudentExample {
    public class Student {
        // Private visibility means code in the same class where the field or property is defined can access it.
        // Public visibility means that code in any class which can access the Student class can also access the
        //     relevant field or property.

        // private is the most restrictive
        // internal ... any code in the same assembly can access.
        // protected ... only code in the class or a subclass can access
        // public is the least restrictive ... any code can access

        // Assembly approximately corresponds to a C# project

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

        // This is a property. It can be used to Get a computed result from an object, or to get
        // the value of a private field
        public double GPA {
            get {
                return history.GPA;
            }
        }

        // The property GPA above is equivalent to a method...
        // Properties behave like methods, but they look like fields, because they do not have parentheses ()
        // and they have simpler names.
        // We use properties because they allow us to protect the values of fields from accidental corruption.
        public double GetGPA() {
            return history.GetGPA();
        }

        public IEnumerable<Subject> CurrentSubjects { get {
                return history.Current;
        } }

        public override string ToString() {
            return $"{name},{idNumber},{GPA}";
            // return $"{name},{idNumber},{GetGPA()}";
        }

        public void SetGrade(Subject subject, int grade) {
            history.SetGrade(subject, grade);
        }
    }
}
