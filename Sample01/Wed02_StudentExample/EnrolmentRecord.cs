using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wed02_StudentExample {
    internal class EnrolmentRecord {
        Student student;
        Subject subject;
        Semester semester;
        EnrolmentStatus status;
        int ? grade;

        public EnrolmentRecord(Student student, Subject subject, Semester semester) {
            this.student = student;
            this.subject = subject;
            this.semester = semester;
            status = EnrolmentStatus.Enrolled;
        }
    }
}
