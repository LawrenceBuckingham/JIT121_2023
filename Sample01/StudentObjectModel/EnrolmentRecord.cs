using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjectModel {
    public class EnrolmentRecord {
        Student student;
        Subject subject;
        Semester semester;
        EnrolmentStatus status;
        int grade;

        public EnrolmentRecord(Student student, Subject subject, Semester semester) {
            this.student = student;
            this.subject = subject;
            this.semester = semester;
            status = EnrolmentStatus.Enrolled;
        }

        public Student Student => student;

        public Subject Subject => subject;

        public Semester Semester => semester;

        public EnrolmentStatus Status => status;

        /// <summary>
        /// Get or set the grade for a student in this subject.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if value is outside the valid range.</exception>
        public int Grade {
            get { return grade; }
            set {
                // Any set property has an automatically generated parameter 'value'
                if (value < 1 || value > 7) {
                    throw new ArgumentException($"{value} is invalid for Grade", "Grade");
                }

                grade = value;
            }
        }

        // The set part of Grade property is equivalent to the following method:
        public void SetGrade(int value) {
            if (value < 1 || value > 7) {
                throw new ArgumentException($"{value} is invalid for Grade", "Grade");
            }

            grade = value;
        }
    }
}
