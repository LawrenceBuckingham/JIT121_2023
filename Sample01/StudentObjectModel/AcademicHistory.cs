using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wed02_StudentExample {
    public class AcademicHistory {
        List<EnrolmentRecord> history = new();

        public double GPA {
            get {
                return history
                    .Where(er => er.Status == EnrolmentStatus.Complete)
                    .Select(er => er.Grade)
                    .DefaultIfEmpty(0)
                    .Average();
            }
        }

        // Equivalent to GPA property above.
        public double GetGPA() {
            return history
                .Where(er => er.Status == EnrolmentStatus.Complete)
                .Select(er => er.Grade)
                .DefaultIfEmpty(0)
                .Average();
        }

        public IEnumerable<Subject> Current {
            get {
                return history
                    .Where(er => er.Status == EnrolmentStatus.Enrolled)
                    .Select(er => er.Subject);
            }
        }

        public void Add(Student student, Subject subject, Semester semester) {
            EnrolmentRecord enrolment = new(student, subject, semester);
            history.Add(enrolment);
        }

        internal void SetGrade(Subject subject, int grade) {
            EnrolmentRecord ? er = history
                .Where(e => e.Status == EnrolmentStatus.Enrolled)
                .FirstOrDefault();

            if ( er != null ) {
                er.Grade = grade;
                // equivalent to er.SetGrade( grade )
            }
        }
    }
}
