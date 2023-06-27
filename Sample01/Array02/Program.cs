using static System.Console;

namespace Array02 {
    internal class Program {
        static void Main(string[] args) {
            // Demo String.Split and array processing with strings.
            WriteLine("Please enter some words separated by spaces:");
            string? userInput = ReadLine();

            string[] words = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //dddd      dd  d  d 

            WriteLine($"The input sequence contains {words.Length} words.");

            for (int i = 0; i < words.Length; i++) {
                WriteLine($"Word {i + 1} = '{words[i]}'");
            }

            string[] copy = (string[]) words.Clone();
            Array.Sort(copy);

            WriteLine($"After sorting, copy = [{String.Join(",", copy)}]");

            CountDistinctWords(words);
        }

        // How many occurrences of each distinct word might there be?
        static void CountDistinctWords(string[] words) {
            // Make a copy only because I intend to sort the array data
            // If we don't want to sort the array, we can just work with the original array.
            string[] wordsCopy = (string[]) words.Clone();
            Array.Sort( wordsCopy );

            string currentWord = "";
            int currentCount = 0;

            for (int i = 0; i < words.Length; i++) {
                if (wordsCopy[i] == currentWord) {
                    currentCount++;
                }
                else {
                    if (i > 0) {
                        WriteLine($"{currentWord} appears {currentCount} times");
                    }
                    currentWord = wordsCopy[i];
                    currentCount = 1;
                }
            }

            WriteLine($"{currentWord} appears {currentCount} times");
        }
    }
}