namespace Wed02_StudentExample {
    internal class Program {
        /*
        _Students_ will be enrolled in _subjects_ at _university_.
        Each student has an _academic history_: the set of subjects they are currently enrolled in, and 
        have previously been enrolled.
        Students have an enrolment status - Enrolled, Complete, Withdrawn - in each subject in their academic history.
        Subjects have a subject code and a description, and a set of teaching staff.
        Teaching staff may be lecturers, or tutors in a give subject.
        Teaching staff may teach multiple subjects, and they may have different roles in each subject.
        */
        static void Main(string[] args) {
            Console.WriteLine("Hello, Student World!");
            
            University uni = new();
            Student student = uni.RecruitStudent("Larry");
            Subject cab201 = uni.OfferSubject("CAB201", "Programming Principles");
            Subject ifb102 = uni.OfferSubject("IFB201", "Introduction to Computer Systems");
            Subject ifn557 = uni.OfferSubject("IFN557", "Rapid Web Development");

            uni.Enrol(student, cab201);
            uni.Enrol(student, ifn557);
        }
    }
}