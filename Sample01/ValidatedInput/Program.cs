using static System.Console;

namespace ValidatedInput {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            int fahrenheit;
            if ( ReadInt("Please enter the temperature in Fahrenheit degrees:", out fahrenheit) ) {
                double celsius = (fahrenheit - 32) * 5 / 9;
                WriteLine($"{fahrenheit} degrees Fahrenheit = {celsius} degrees Celsius.");
            }
            else {
                WriteLine("No input is available.");
            }
        }

        static bool ReadInt( string prompt, out int value ) {
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

        static bool ReadDouble( string prompt, out double value ) {
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