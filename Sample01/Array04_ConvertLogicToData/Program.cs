using static System.Console;

namespace Array04_ConvertLogicToData {
    internal class Program {
        static string[] MonthNames = { 
            "Invalid", // MonthNames[0]
            "January", // MonthNames[1]
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December", // MonthNames[12]
        };

        static void Main(string[] args) {
            Console.WriteLine("Hello, Alternate MonthName World!");

            string monthName = "Invalid month";

            int month;
            ReadInt("Please enter the number of the month, between 1 and 12", out month);

            if (0 < month && month < MonthNames.Length)
                monthName = MonthNames[month];

            WriteLine($"The name of month {month} is '{monthName}'");
        }

        static bool ReadInt(string prompt, out int value) {
            while (true) {
                WriteLine(prompt);
                string? userInput = ReadLine();

                if (userInput == null) {
                    value = 0;
                    return false;
                }

                if (int.TryParse(userInput, out value)) {
                    return true;
                }
                else {
                    WriteLine($"'{userInput}' is not a valid integer value. Please try again.");
                }
            }
        }
    }
}