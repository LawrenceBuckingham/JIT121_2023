using static System.Console;

namespace Array01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Array demo 01");

            int numElements;
            ReadInt("How many elements will there be in the array?", out numElements);

            double[] inputData = new double[numElements];

            for( int i = 0; i < numElements; i++ ) {
                ReadDouble($"Please enter element {i}:", out inputData[i]);
            }

            double avg = Average(inputData);
            WriteLine($"Average of [{ToString(inputData)}] = {avg}.");

            double median = Median(inputData);
            WriteLine($"Median of [{ToString(inputData)}] = {median}");

            if (IsAscending(inputData))
                WriteLine($"{ToString(inputData)} is in ascending order");
            else
                WriteLine($"{ToString(inputData)} is not in ascending order");
        }

        static bool IsAscending( double[] x ) {
            for ( int i = 0; i < x.Length - 1; i++ ) {
                if (x[i] > x[i + 1]) return false;
            }

            return true;
        }

        static string ToString( double[] x ) {
            string s = "";

            for ( int i = 0; i < x.Length; i++ ) {
                if (s.Length > 0) s += ",";
                s += x[i];
            }

            return s;
        }

        static double Average ( double[] x ) {
            double sum = 0;

            for( int i = 0; i < x.Length; i++) {
                sum += x[i];
            }

            return sum / x.Length;
        }

        static double Median ( double[] x ) {
            // double [] xCopy = (double[]) x.Clone();

            int n = x.Length;

            // Copy original array.
            double[] xCopy = new double[n];

            for( int i = 0; i < n; i++) {
                xCopy[i] = x[i];
            }

            Array.Sort(xCopy);

            if (n % 2 != 0) {
                return xCopy[n / 2];
            }
            else {
                return (xCopy[n / 2] + xCopy[n / 2 - 1]) / 2;
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

        static bool ReadDouble(string prompt, out double value) {
            while (true) {
                WriteLine(prompt);
                string? userInput = ReadLine();

                if (userInput == null) {
                    value = 0;
                    return false;
                }

                if (double.TryParse(userInput, out value)) {
                    return true;
                }
                else {
                    WriteLine($"'{userInput}' is not a valid integer value. Please try again.");
                }
            }
        }
    }
}