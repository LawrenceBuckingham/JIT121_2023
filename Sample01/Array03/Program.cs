using System.Globalization;

using static System.Console;

namespace Array03 {
    internal class Program {
        static Random rand = new(42);

        static void Main(string[] args) {
            // Ragged array, also called "jagged" arrays
            double[][] numbers = GenerateNumbers();
            PrintRowAverages(numbers);
            double avg = OverallAverage(numbers);
            WriteLine($"The overall average is {avg}.");
            ;
        }

        static double[][] GenerateNumbers() {
            double[][] numbers = new double[rand.Next(20) + 1][];

            for (int i = 0; i < numbers.Length; i++) {
                numbers[i] = new double[5 + rand.Next(6)];

                for (int j = 0; j < numbers[i].Length; j++) {
                    numbers[i][j] = rand.NextDouble() * 25 + 15;
                }
            }

            return numbers;
        }

        static void PrintRowAverages( double[][] numbers ) {
            for (int i = 0; i < numbers.Length; i++) {
                WriteLine($"The average of row {i} is {Average(numbers[i])}");
            }
        }

        static double Average(double[] x) {
            double sum = 0;

            for (int i = 0; i < x.Length; i++) {
                sum += x[i];
            }

            return sum / x.Length;
        }

        static double OverallAverage(double[][] x) {
            double sum = 0;
            int count = 0;

            for( int i = 0; i < x.Length; i++ ) {
                for ( int j = 0; j < x[i].Length; j++ ) {
                    sum += x[i][j];
                    count++;
                }
            }

            return sum / count;
        }
    }
}