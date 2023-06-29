using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjectModel {
    public class University {
        StudentCollection students = new();

        List<Subject> subjects = new();
        private Semester currentSemester = new Semester( "Semester 2", 2023 );

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
    }
}
