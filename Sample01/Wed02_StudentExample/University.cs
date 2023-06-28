using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wed02_StudentExample {
    public class University {
        List<Student> students = new();
        List<Subject> subjects = new();
        int nextStudent = 1000000;
        private Semester currentSemester = new Semester( "Semester 2", 2023 );

        public Student RecruitStudent( string name ) {
            int newId = nextStudent++;
            Student student = new Student(name, newId);
            students.Add(student);
            return student;
        }

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
                return students.Where(s => s.CurrentSubjects.Count() > 0); 
            }
        }

        public override string ToString() {
            return $"{EnrolledStudents.Count()} currently enrolled students, {subjects.Count()} subjects";
        }
    }
}
