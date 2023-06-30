namespace Friday_InheritancePolymorphismInterfaces {
    internal class Program {
        static void Main(string[] args) {
            Util.ReadInt("Please enter the display width:", out int columns);
            Util.ReadInt("Please enter the display height:", out int rows);
            Graphics gfx = new(rows, columns);

            var line = new UpdateableBox(5, 5, 15, 15, '@', columns, rows);

            Scene scene = new(
                new Line(12, 12, 0, -12),
                new Line(12, 12, 0, +12),
                new Line(12, 12, -12, 0),
                new Line(12, 12, +12, 0),
                new Box(3, 3, 5, 3),
                new Box(7, 11, 4, 4),
                new Diamond(13, 13, 16, 14),
                new Diamond(17, 11, 10, 10),
                line
            );

            gfx.DrawText(gfx.Height / 2, gfx.Width / 2 - 3, "Hello!");
            while (true) {
                gfx.Clear();
                gfx.Draw(scene);
                gfx.Display();
                line.Update();
                Thread.Sleep(100);
            }
        }
    }

    interface IDrawable {
        void Draw(Graphics gfx);
    }

    interface IUpdateable {
        void Update();
    }

    class Shape : IDrawable {
        public int Col { get; set; }
        public int Row { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public char Symbol { get; }

        public Shape(int col, int row, int width, int height, char symbol = '*') {
            Col = col; Row = row; Width = width; Height = height;
            Symbol = symbol;
        }

        public virtual void Draw(Graphics gfx) {
            // Does nothing
        }

        public override string ToString() {
            return $"{GetType().Name}({Col},{Row},{Width},{Height},{Symbol})";
        }

    }

    class Line : Shape {
        public Line(int x, int y, int dx, int dy, char symbol = '*')
            : base(x, y, dx, dy, symbol) {
        }

        public override void Draw(Graphics gfx) {
            gfx.DrawLine(Col, Row, Col + Width, Row + Height, Symbol);
        }
    }

    class Box : Shape {
        public Box(int x, int y, int dx, int dy, char symbol = '*')
            : base(x, y, dx, dy, symbol) { }

        public override void Draw(Graphics gfx) {
            gfx.DrawLine(Row, Col, Row         , Col + Width, Symbol);
            gfx.DrawLine(Row, Col, Row + Height, Col        , Symbol);

            gfx.DrawLine(Row + Height, Col        , Row + Height, Col + Width, Symbol);
            gfx.DrawLine(Row         , Col + Width, Row + Height, Col + Width, Symbol);
        }
    }

    class Diamond : Shape {
        public Diamond(int x, int y, int dx, int dy, char symbol = '*')
            : base(x, y, dx, dy, symbol) { }

        public override void Draw(Graphics gfx) {
            gfx.DrawLine(Row, Col + Width / 2, Row + Height / 2, Col + Width, Symbol);
            gfx.DrawLine(Row, Col + Width / 2, Row + Height / 2, Col        , Symbol);

            gfx.DrawLine(Row + Height / 2, Col        , Row + Height, Col + Width / 2, Symbol);
            gfx.DrawLine(Row + Height / 2, Col + Width, Row + Height, Col + Width / 2, Symbol);
        }
    }

    class UpdateableBox : Box, IUpdateable {
        int dx = Util.Random(3) - 1;
        int dy = Util.Random(3) - 1;
        int w;
        int h;

        public UpdateableBox(int x, int y, int dx, int dy, char symbol, int w, int h)
            : base(x, y, dx, dy, symbol) {
            this.w = w;
            this.h = h;
        }

        public override void Draw(Graphics gfx) {
            base.Draw(gfx);
            // System.Diagnostics.Debug.WriteLine($"{this}");
        }

        public void Update() {
            if (Col + dx < 0) dx = -dx;
            else if (Col + Width + dx >= w) dx = -dx;
            else Col = Col + dx; 

            if (Row + dy < 0) dy = -dy;
            else if (Row + Height + dy >= h) dy = -dy;
            else Row = Row + dy; 
        }

        public override string ToString() {
            return base.ToString() + $" ({dx},{dy})";
        }
    }

    class Scene : IDrawable {
        private List<IDrawable> Children = new();

        public void Draw(Graphics gfx) {
            foreach (var child in Children) {
                child.Draw(gfx);
            }
        }

        public Scene(params IDrawable[] children) {
            Children.AddRange(children);
        }

        public void Add(IDrawable child) {
            Children.Add(child);
        }

        public void Remove(IDrawable child) {
            Children.Remove(child);
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

        static Random rand = new(42);

        internal static int Random(int upperLimit) {
            return rand.Next(upperLimit);
        }
    }

    class Graphics {
        private char[,] canvas;
        public int Width => canvas.GetLength(1);
        public int Height => canvas.GetLength(0);

        public Graphics(int rows, int cols) {
            canvas = new char[rows, cols];
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

        public void Draw(IDrawable drawableObject) {
            drawableObject.Draw(this);
        }
    }
}