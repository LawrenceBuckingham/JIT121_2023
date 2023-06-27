using static System.Console;

namespace Collections01_List_SentinelControlledInput {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, List and Sentinel Controlled Input World!");
            // Sentinel controlled input --> we detect the end of input data when we read a "special value" which
            // is not "normal" input value.
            // e.g. Reading strings, we detect end of input when a null string is entered.
            // e.g. Reading numeric values, detect a magic number, e.g. -1.

            // List is a predefined class from standard C# library which behaves like an array in some ways, but
            // can conveniently and automatically resize.

            // int[] arrayData = new int[12];
            // Use an array when we know the element type and the number of elements ahead of time.
            // Maybe ask the user... but that requires the user to know how many elements they want to process.

            const int SENTINEL = 999999;
            // const -> value is assigned at compile time, and never changes.

            List<int> data = new();
            // List is more flexible than an array; the list will grow as we add data to it.

            while ( true ) {
                // Mid-tested loop to read and accumulate data

                int currentItem;

                if ( ReadInt($"Please enter an integer, or {SENTINEL} to finish:", out currentItem) 
                    && currentItem != SENTINEL 
                ) {
                    data.Add(currentItem);
                }
                else {
                    break;
                }
            }

            WriteLine($"The data is [{String.Join(", ", data)}].");
            // List<int> is "IEnumerable", so we can use it as an argument for String.Join.
            // int [] is also "IEnumerable", so we can use an array as the argument for String.Join.

            PrintList("Original data", data);
            
            List<int> oddNumbers = new();
            FilterOddNumbers(data, oddNumbers);
            PrintList("Odd numbers:", oddNumbers);
            
            // Violating the DRY principle.
            List<int> evenNumbers = new();
            FilterEvenNumbers(data, evenNumbers);
            PrintList("Even numbers:", evenNumbers);

            Console.WriteLine($"Average of original data is {Average(data)}");
            Console.WriteLine($"Average of odd numbers is {Average(oddNumbers)}");
            Console.WriteLine($"Average of even numbers is {Average(evenNumbers)}");
        }

        static double Average(List<int> x) {
            // Violation of DRY principle.... we copied and pasted code, then edited it.
            double sum = 0;

            for (int i = 0; i < x.Count; i++) {
                sum += x[i];
            }

            return sum / x.Count;
        }

        static void PrintList( string title, List<int> data ) {
            WriteLine(title); 
            for ( int i = 0; i < data.Count; i++ ) {
                WriteLine($"element[{i}] is {data[i]}");
            }
        }

        /// <summary>
        /// Find the odd numbers in the list.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="results"></param>
        static void FilterOddNumbers ( List<int> data, List<int> results ) {
            // List is IEnumerable, so we can use "foreach"
            // No concern for the internal data organisation.

            foreach ( int item in data ) {
                if (item % 2 != 0)
                    results.Add(item);
            } 
        }

        /// <summary>
        /// Find the even numbers in the list.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="results"></param>
        static void FilterEvenNumbers ( List<int> data, List<int> results ) {
            foreach ( int item in data ) {
                if (item % 2 == 0)
                    results.Add(item);
            } 
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