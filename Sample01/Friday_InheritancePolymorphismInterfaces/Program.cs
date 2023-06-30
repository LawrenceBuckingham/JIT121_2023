namespace Friday_InheritancePolymorphismInterfaces {
    internal class Program {
        static void Main(string[] args) {
            Util.ReadInt("Please enter the display width:", out int columns);
            Util.ReadInt("Please enter the display height:", out int rows);
            Graphics gfx = new(rows, columns);

            gfx.DrawText(gfx.Height / 2, gfx.Width / 2 - 3, "Hello!");
            gfx.Display();
        }
    }

    static class Util {
        public static bool ReadInt(string prompt, out int value) {
            while (true) {
                Console.WriteLine(prompt);
                string? userInput = Console.ReadLine();

                if (userInput == null) {
                    value = 0;
                    return false;
                }

                if (int.TryParse(userInput, out value)) {
                    return true;
                }
                else {
                    Console.WriteLine($"'{userInput}' is not a valid integer value. Please try again.");
                }
            }
        }

        public static bool ReadDouble(string prompt, out double value) {
            while (true) {
                Console.WriteLine(prompt);
                string? userInput = Console.ReadLine();

                if (userInput == null) {
                    value = 0;
                    return false;
                }

                if (double.TryParse(userInput, out value)) {
                    return true;
                }
                else {
                    Console.WriteLine($"'{userInput}' is not a valid integer value. Please try again.");
                }
            }
        }
    }

    class Graphics {
        private char[,] canvas;
        public int Width => canvas.GetLength(1);
        public int Height => canvas.GetLength(0);

        public Graphics(int rows, int cols )
        {
            canvas = new char [rows,cols];
            Clear();
        }

        public void Clear() {
            for (int i = 0; i < canvas.GetLength(0); i++) {
                for (int j = 0; j < canvas.GetLength(1); j++) {
                    canvas[i, j] = ' ';
                }
            }
        }

        public void Display() {
            var prevVisibility = Console.CursorVisible;
            Console.CursorVisible = false;
            for (int i = 0; i < canvas.GetLength(0); i++) {
                Console.SetCursorPosition(0, i);

                for (int j = 0; j < canvas.GetLength(1); j++) {
                    Console.Write(canvas[i, j]);
                }
            }

            Console.WriteLine();
            Console.CursorVisible = prevVisibility;
        }

        public void DrawPoint(int row, int col, char symbol) {
            if (row < 0 || row >= canvas.GetLength(0)) return;
            if (col < 0 || col >= canvas.GetLength(1)) return;

            canvas[row, col] = symbol;
        }

        public void DrawText(int row, int col, string text) {
            for (int i = 0; i < text.Length; i++) {
                DrawPoint(row, col + i, text[i]);
            }
        }

        public void DrawLine(int r0, int c0, int r1, int c1, char symbol) {
            int dr = r1 - r0;
            int abs_dr = Math.Abs(dr);
            int dc = c1 - c0;
            int abs_dc = Math.Abs(dc);
            int numSteps = Math.Max(abs_dr, abs_dc);

            for (int step = 0; step <= numSteps; step++) {
                double row = Math.Round(r0 + step * (double) dr / numSteps);
                double col = Math.Round(c0 + step * (double) dc / numSteps);
                DrawPoint((int) row, (int) col, symbol);
            }
        }
    }
}