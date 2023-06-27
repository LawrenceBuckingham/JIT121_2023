using static System.Console;

namespace Array04_MultiDimensionalArray {
    internal class Program {
        static void Main(string[] args) {
            int rows, columns;

            ReadInt("Please enter the number of rows in the array:", out rows);
            ReadInt("Please enter the number of columns in the array:", out columns);

            char[,] canvas = new char[rows, columns];

            Console.Clear();
            Clear(canvas);
            DrawPoint(canvas, 5, 5, '*');
            DrawPoint(canvas, 10, 10, '*');
            DrawLine(canvas, 1, 3, 9, 9, '#');
            DrawText(canvas, 8, 8, "Hello");
            Display(canvas);
        }

        static void Clear( char [,] canvas ) {
            for ( int i = 0; i < canvas.GetLength(0); i++ ) {
                for ( int j = 0; j < canvas.GetLength(1); j++) {
                    canvas[i, j] = ' ';
                }
            }
        }

        static void Display(char[,] canvas) {
            for (int i = 0; i < canvas.GetLength(0); i++) {
                Console.SetCursorPosition(0, i);

                for (int j = 0; j < canvas.GetLength(1); j++) {
                    Console.Write( canvas[i, j] );
                }
            }

            Console.WriteLine();
        }

        static void DrawPoint(char[,] canvas, int row, int col, char symbol ) {
            if (row < 0 || row >= canvas.GetLength(0)) return;
            if (col < 0 || col >= canvas.GetLength(1)) return;

            canvas[row, col] = symbol;
        }

        static void DrawText( char [,] canvas, int row, int col, string text ) {
            for( int i = 0; i < text.Length; i++ ) {
                DrawPoint(canvas, row, col + i, text[i]);
            }
        }

        static void DrawLine( char[,] canvas, int r0, int c0, int r1, int c1, char symbol ) {
            int dr = r1 - r0;
            int abs_dr = Math.Abs(dr);
            int dc = c1 - c0;
            int abs_dc = Math.Abs(dc);
            int numSteps = Math.Max(abs_dr, abs_dc);

            for ( int step = 0; step <= numSteps; step ++ ) {
                double row = Math.Round(r0 + step * (double) dr / numSteps);
                double col = Math.Round(c0 + step * (double) dc / numSteps);
                DrawPoint(canvas, (int) row, (int) col, symbol);
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