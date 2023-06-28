using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wed02_StudentExample {
    internal class AcademicHistory {
        List<EnrolmentRecord> history = new();

        public void Add( Student student, Subject subject, Semester semester ) {
            EnrolmentRecord enrolment = new(student, subject, semester);
            history.Add(enrolment);
        }
    }
}
