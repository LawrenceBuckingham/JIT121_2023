using static System.Console;

namespace Sample01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, JIT World!");

            // Temperature conversion exercise.
            // Prompt user for temperature in fahrenheit degrees.
            bool ok = false;

            while (!ok) {
                WriteLine("Please enter the temperature in Fahrenheit degrees:");
                string? userInput = ReadLine();
                double f;
                if (double.TryParse(userInput, out f)) {
                    // Convert to Celsius
                    double c = (f - 32) * 5 / 9;

                    // display the results.
                    WriteLine($"A temperature of {f:f2} degrees Fahrenheit is the same as {c:f2} degrees Celsius.");

                    ok = true;
                }
                else {
                    // The input was corrupt so display an error message.
                    WriteLine($"The value '{userInput}' is not a valid temperature.");
                }
            }
        }

        static void Main01(string[] args) {
            Console.WriteLine("Hello, JIT World!");

            // Temperature conversion exercise.
            // Prompt user for temperature in fahrenheit degrees.
            WriteLine("Please enter the temperature in Fahrenheit degrees:");
            string? userInput = ReadLine();
            double f;
            if (double.TryParse(userInput, out f)) {
                // Convert to Celsius
                double c = (f - 32) * 5 / 9;

                // display the results.
                WriteLine($"A temperature of {f:f2} degrees Fahrenheit is the same as {c:f2} degrees Celsius.");
            }
            else {
                // The input was corrupt so display an error message.
                WriteLine($"The value '{userInput}' is not a valid temperature.");
            }
        }
    }
}