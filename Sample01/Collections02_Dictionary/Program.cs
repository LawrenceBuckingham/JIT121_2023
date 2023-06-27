using static System.Console;

namespace Collections02_Dictionary {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello,     Dictionary World!");

            Dictionary<int,     string> MonthNames = new () {
                [1] = "January",    
                [2] = "February",    
                [3] = "March",    
                [4] = "April",    
                [5] = "May",    
                [6] = "June",    
                [7] = "July",    
                [8] = "August",    
                [9] = "September",    
                [10] = "October",    
                [11] = "November",    
                [12] = "December",    
            };

            Dictionary<string, int> MonthNumbers = new () {
                ["January"]  =   1,    
                ["February"] =   2, 
                ["March"]    =   3, 
                ["April"]    =   4, 
                ["May"]      =   5, 
                ["June"]     =   6, 
                ["July"]     =   7, 
                ["August"]    =  8,  
                ["September"] =  9,  
                ["October"]   =  10,  
                ["November"]  =  11,  
                ["December"]  =  12,  
            };

            WriteLine("Please enter the name of a month:");
            string? monthName = ReadLine();

            if (monthName != null && MonthNumbers.ContainsKey(monthName)) {
                WriteLine($"Month '{monthName}' is number {MonthNumbers[monthName]}");
            }
            else {
                WriteLine($"Month '{monthName}' is not a valid month name.");
            }

        }
    }
}