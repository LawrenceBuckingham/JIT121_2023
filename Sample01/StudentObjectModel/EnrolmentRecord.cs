using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjectModel {
    public class EnrolmentRecord {
        Subject subject;
        Semester semester;
        EnrolmentStatus status;
        int grade;

        public EnrolmentRecord(Subject subject, Semester semester) {
            this.subject = subject;
            this.semester = semester;
            status = EnrolmentStatus.Enrolled;
        }

        public Subject Subject => subject;

        public Semester Semester => semester;

        public EnrolmentStatus Status {
            get {
                return status;
            }
            set {
                if (value == EnrolmentStatus.Enrolled || status != EnrolmentStatus.Enrolled) {
                    throw new ArgumentException($"Cannot withdraw or complete a subject unless enrolled.");
                }

                status = value;
            }
        }

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

        /// <summary>
        /// Gets a tab-separated serialised copy of the content of the object.
        /// </summary>
        public string TabSeparated {
            get {
                return $"EnrolmentRecord\t{subject.Code}\t{status}\t{grade}\t{semester.TabSeparated}";
            }
        }

        internal static EnrolmentRecord Parse(string[] fields, IEnumerable<Subject> subjects) {
            string subjectCode = fields[1];
            EnrolmentStatus status = Enum.Parse<EnrolmentStatus>(fields[2]);
            int grade = int.Parse(fields[3]);
            Semester semester = Semester.Parse(fields.Skip(4).ToArray());
            Subject subject = subjects.Where(s => s.Code == subjectCode).First();
            EnrolmentRecord er = new(subject, semester);
            er.Status = status;
            er.grade = grade;
            return er;
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
