using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentObjectModel {
    public class Semester {
        static List<Semester> allSemesters = new();

        static readonly string[] TeachingPeriods  = { "Semester 1", "Semester 2", "Summer" };

        string teachingPeriod;
        int year;

        private Semester(string teachingPeriod, int year) {
            if (! TeachingPeriods.Contains(teachingPeriod) ) {
                throw new ArgumentException($"'teachingPeriod' is not a valid teaching period.");
            }

            this.teachingPeriod = teachingPeriod;
            this.year = year;

            allSemesters.Add(this);
        }

        public string TabSeparated {
            get {
                return $"Semester\t{teachingPeriod}\t{year}";
            }
        }

        public Semester Advance() { 
            for ( int i = 0; i < TeachingPeriods.Length; i++ ) {
                if (TeachingPeriods[i] == teachingPeriod) {
                    if ( i == TeachingPeriods.Length - 1 ) {
                        return GetSemester(TeachingPeriods[0], year + 1);
                    }
                    else {
                        return GetSemester(TeachingPeriods[i + 1], year);
                    }
                }
            }

            throw new Exception("Teaching period is damaged.");
        }

        internal static Semester Parse(string[] fields) {
            string tp = fields[1];
            int year = int.Parse(fields[2]);
            return GetSemester(tp, year);
        }

        public static Semester GetSemester(string tp, int year) {
            return allSemesters
                .Where(s => s.teachingPeriod == tp && s.year == year)
                .DefaultIfEmpty(new Semester(tp, year))
                .First();
        }
    }
}