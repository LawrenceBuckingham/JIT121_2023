using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjectModel {
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

        public IEnumerable<Subject> CurrentSubjects {
            get {
                return history
                    .Where(er => er.Status == EnrolmentStatus.Enrolled)
                    .Select(er => er.Subject);
            }
        }

        public IEnumerable<EnrolmentRecord> EnrolmentHistory {
            get {
                return history;
            }
        }

        public void Add(Student student, Subject subject, Semester semester) {
            EnrolmentRecord enrolment = new(subject, semester);
            history.Add(enrolment);
        }

        internal void CompleteCurrentSemester() {
            foreach ( EnrolmentRecord er in history ) {
                if ( er.Status == EnrolmentStatus.Enrolled ) {
                    er.Status = EnrolmentStatus.Complete;
                }
            }
        }

        internal void Parse(string[] fields, IEnumerable<Subject> subjects) {
            history.Add(EnrolmentRecord.Parse(fields, subjects));            
        }

        internal void SetGrade(Subject subject, int grade) {
            EnrolmentRecord ? er = history
                .Where(e => e.Status == EnrolmentStatus.Enrolled && e.Subject == subject )
                .FirstOrDefault();

            if ( er != null ) {
                er.Grade = grade;
                // equivalent to er.SetGrade( grade )
            }
        }

        internal void Withdraw(Subject subject) {
            EnrolmentRecord ? er = history
                .Where(e => e.Status == EnrolmentStatus.Enrolled && e.Subject == subject)
                .FirstOrDefault();

            if ( er != null ) {
                er.Status = EnrolmentStatus.Withdrawn;
                // equivalent to er.SetGrade( grade )
            }
            
        }
    }
}
