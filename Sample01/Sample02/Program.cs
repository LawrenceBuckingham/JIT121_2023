using static System.Console;

namespace Sample02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, Switch and If World!");

            bool ok = false;
            int month = 0;
            string monthName = "Invalid month";

            while (!ok) {
                Console.WriteLine("Please enter the number of a month, between 1 and 12");
                string? userInput = ReadLine();

                if (int.TryParse(userInput, out month)) {
                    // Example using a switch statement
                    switch (month) {
                        case 1: monthName = "January"; break;
                        case 2: monthName = "February"; break;
                        case 3: monthName = "March"; break;
                        case 4: monthName = "April"; break;
                        case 5: monthName = "May"; break;
                        case 6: monthName = "June"; break;
                        case 7: monthName = "July"; break;
                        case 8: monthName = "August"; break;
                        case 9: monthName = "September"; break;
                        case 10: monthName = "October"; break;
                        case 11: monthName = "November"; break;
                        case 12: monthName = "December"; break;
                        default: // there is no special action for default case in this program
                            break; 
                    }
                    ok = true;
                }
                else {
                    WriteLine($"'{userInput}' is not a valid month number. Please try again");
                }
            }

            WriteLine($"The name of month {month} is '{monthName}'");
        }

        static void Main_Cascading_If(string[] args) {
            Console.WriteLine("Hello, Switch and If World!");

            bool ok = false;
            int month = 0;
            string monthName = "Invalid month";

            while (!ok) {
                Console.WriteLine("Please enter the number of a month, between 1 and 12");
                string? userInput = ReadLine();

                if (int.TryParse(userInput, out month)) {
                    // Example using a cascading if statement
                    if (month == 1) monthName = "January";
                    else if (month == 2) monthName = "February";
                    else if (month == 3) monthName = "March";
                    else if (month == 4) monthName = "April";
                    else if (month == 5) monthName = "May";
                    else if (month == 6) monthName = "June";
                    else if (month == 7) monthName = "July";
                    else if (month == 8) monthName = "August";
                    else if (month == 9) monthName = "September";
                    else if (month == 10) monthName = "October";
                    else if (month == 11) monthName = "November";
                    else if (month == 12) monthName = "December";

                    ok = true;
                }
                else {
                    WriteLine($"'{userInput}' is not a valid month number. Please try again");
                }
            }

            WriteLine($"The name of month {month} is '{monthName}'");
        }
    }
}