using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjectModel {
    public class University {
        static readonly Semester startingSemester = Semester.GetSemester("Semester 2", 2023);

        StudentCollection students = new();

        List<Subject> subjects = new();
        private Semester currentSemester = startingSemester;

        public Subject OfferSubject( string code, string description ) {
            Subject newSubject = new Subject(code, description);
            subjects.Add(newSubject);
            return newSubject;
        }

        public void Enrol(Student student, Subject subject) {
            student.Enrol(subject, currentSemester);
        }

        public IEnumerable<Student> EnrolledStudents {
            get {
                return students.Enrolled; 
            }
        }

        public override string ToString() {
            return $"{EnrolledStudents.Count()} currently enrolled students, {subjects.Count()} subjects";
        }

        public StudentCollection Students {
            get {
                return students;
            }
        }

        public void FinaliseCurrentSemester () {
            foreach ( Student student in EnrolledStudents ) {
                student.CompleteCurrentSemester();
            }

            currentSemester = currentSemester.Advance();
        }

        public void SaveAs( string fileName ) {
            using StreamWriter writer = new(fileName);

            writer.WriteLine(currentSemester.TabSeparated);

            foreach ( Subject subject in subjects) {
                writer.WriteLine(subject.TabSeparated);
            }

            foreach( Student student in Students.All) {
                writer.WriteLine(student.TabSeparated);
            }
        }

        public void Load( string fileName ) {
            using StreamReader reader = new(fileName);

            subjects.Clear();
            students.Reset();
            Student ? currentStudent = null;

            while( true ) {
                string? currentLine = reader.ReadLine();

                if (currentLine == null) break;

                string[] fields = currentLine.Split('\t');

                switch (fields[0]) {
                    case "Semester":
                        currentSemester = Semester.Parse(fields);
                        break;
                    case "Subject":
                        subjects.Add(Subject.Parse(fields));
                        break;
                    case "Student":
                        currentStudent = students.Parse(fields);
                        break;
                    case "EnrolmentRecord":
                        currentStudent!.AcademicHistory.Parse(fields, subjects);
                        break;
                    default:
                        // ignore other lines.
                        break;
                }
            }
        }

        public void Reset() {
            subjects.Clear();
            students.Reset();
            currentSemester = startingSemester;
        }

        public IEnumerable<Subject> Subjects {
            get {
                return subjects;
            }
        }
    }
}
