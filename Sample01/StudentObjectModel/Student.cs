using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjectModel {
    public class Student {
        // Private visibility means code in the same class where the field or property is defined can access it.
        // Public visibility means that code in any class which can access the Student class can also access the
        //     relevant field or property.

        // private is the most restrictive
        // internal ... any code in the same assembly can access.
        // protected ... only code in the class or a subclass can access
        // public is the least restrictive ... any code can access

        // Assembly approximately corresponds to a C# project

        private string name = "";
        private int idNumber;
        private AcademicHistory history = new();

        public Student(string initialName, int initialIdNumber) {
            Name = initialName;
            IdNumber = initialIdNumber;
        }

        public void Enrol(Subject subject, Semester semester) {
            history.Add(this, subject, semester);
        }

        public int IdNumber {
            get {
                return idNumber;
            }
            private set {
                if (value <= 0) {
                    throw new ArgumentException($"{value} is not a valid student id.");
                }

                idNumber = value;
            }
        }

        public string Name {
            get {
                return name;
            }
            set {
                if (!IsValidName(value)) {
                    throw new ArgumentException($"'{value}' is not a valid student name");
                }

                name = value;
            }
        }

        public double GPA {
            get {
                return history.GPA;
            }
        }

        public IEnumerable<Subject> CurrentSubjects {
            get {
                return history.CurrentSubjects;
            }
        }

        public string TabSeparated {
            get {
                StringWriter writer = new StringWriter();
                writer.WriteLine($"Student\t{IdNumber}\t{name}");

                foreach (EnrolmentRecord er in history.EnrolmentHistory) {
                    writer.WriteLine(er.TabSeparated);
                }

                return writer.ToString();
            }
        }

        internal static Student Parse(string[] fields) {
            return new(fields[2], int.Parse(fields[1]));
        }

        public AcademicHistory AcademicHistory {
            get {
                return history;
            }
        }

        public override string ToString() {
            return $"{name},{idNumber},{GPA}";
        }

        /// <summary>
        /// Determine if a student name is valid.
        /// </summary>
        /// <param name="name">The subject name to test.</param>
        /// <returns>True if and only if the subject name is valid.</returns>
        public static bool IsValidName(string name) {
            if (!string.IsNullOrWhiteSpace(name)
                && name.All(c => c != '\t' && c != '\f' && c != '\r' && c != '\n')
            ) {
                return true;
            }
            else {
                return false;
            }
        }

        public void SetGrade(Subject subject, int grade) {
            history.SetGrade(subject, grade);
        }

        public void Withdraw(Subject subject) {
            history.Withdraw(subject);
        }

        internal void CompleteCurrentSemester() {
            history.CompleteCurrentSemester();
        }
    }
}
