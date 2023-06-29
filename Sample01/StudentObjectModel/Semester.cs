using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentObjectModel {
    public class Semester {
        string teachingPeriod;
        int year;

        public Semester(string teachingPeriod, int year) {
            this.teachingPeriod = teachingPeriod;
            this.year = year;
        }
    }
}