using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjectModel {
    public class StudentCollection {
        List<Student> students = new();
        int nextStudent = InitialStudentId;
        const int InitialStudentId = 1000000;

        /// <summary>
        /// Return the collection of enrolled students.
        /// </summary>
        public IEnumerable<Student> Enrolled {
            get {
                return students.Where(s => s.CurrentSubjects.Count() > 0);
            }
        }

        /// <summary>
        /// Get the collection of "all" students.
        /// </summary>
        public IEnumerable<Student> All {
            get {
                return students;
            }
        }

        public Student Recruit(string name) {
            int newId = nextStudent++;
            Student student = new Student(name, newId);
            students.Add(student);
            return student;
        }

        public override string ToString() {
            return $"{Enrolled.Count()} enrolled, {All.Count()} altogether";
        }

        internal Student Parse(string[] fields) {
            Student student = Student.Parse( fields );
            nextStudent = Math.Max(student.IdNumber + 1, nextStudent);
            students.Add(student);
            return student;
        }

        internal void Reset() {
            nextStudent = InitialStudentId;
            students.Clear();
        }
    }
}
