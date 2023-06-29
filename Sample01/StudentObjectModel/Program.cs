namespace StudentObjectModel {
    internal class Program {
        /*
        _Students_ will be enrolled in _subjects_ at _university_.
        Each student has an _academic history_: the set of subjects they are currently enrolled in, and 
        have previously been enrolled.
        Students have an enrolment status - Enrolled, Complete, Withdrawn - in each subject in their academic history.
        Subjects have a subject code and a description, and a set of teaching staff.
        Teaching staff may be lecturers, or tutors in a give subject.
        Teaching staff may teach multiple subjects, and they may have different roles in each subject.
        At the end of each semester we record a grade for each student in their currently enrolled subjects.
        At the beginning of each new semester, the current semester changes.
        Semesters rotate through a cycle "Semester 1", "Semester 2", "Summer".
        */
        static void Main(string[] args) {
            Console.WriteLine("Hello, Student World!");
            
            University uni = new();
            Student student = uni.Students.Recruit("Larry");

            Subject cab201 = uni.OfferSubject("CAB201", "Programming Principles");
            Subject ifb102 = uni.OfferSubject("IFB201", "Introduction to Computer Systems");
            Subject ifn557 = uni.OfferSubject("IFN557", "Rapid Web Development");

            uni.Enrol(student, cab201);
            uni.Enrol(student, ifn557);

            student.SetGrade(cab201, 7); // AT QUT, grades run from 1,2,...,7.
            student.SetGrade(ifn557, 5);

            student = uni.Students.Recruit("Curly");
            uni.Enrol(student, ifb102);
            student.SetGrade(ifb102, 6);

            uni.FinaliseCurrentSemester();
            uni.SaveAs("uni.txt");

            University uni2 = new University();
            uni2.Load("uni.txt");
            uni2.SaveAs("uni2.txt");
        }
    }
}