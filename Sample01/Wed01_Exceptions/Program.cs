namespace Wed01_Exceptions {
    internal class Program {
        enum Status { Ok, NotOk }

        static void Main(string[] args) {
            Console.WriteLine("Hello, Exception World!");

            string fileName = "F1.txt";
            Status status = Status.NotOk;

            try {
                PrintFile(fileName);
                ProcessNumericData(fileName);
                status = Status.Ok;
            }
            catch ( FileNotFoundException ex ) {
                Console.WriteLine($"File '{fileName}' was not found!");
            }
            catch ( IOException ex ) {
                Console.WriteLine( $"We are unable to access '{fileName}' for the following reason: {ex.Message}" );
                Console.WriteLine( "If you are using the file in another program, please close it an try again." );
            }
            catch (Exception ex) {
                Console.WriteLine($"Error processing file '{fileName}': {ex.Message}");
            }
            finally {
                Console.WriteLine( $"After processing, everything is {status}" );
            }
        }

        static void ProcessNumericData( string fileName ) {
            using var reader = OpenFile(fileName);

            while (true) {
                string? s = reader.ReadLine();

                if (s == null) break;

                var fields = s.Split(new char[] { ' ', '\t', ',', '.', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

                bool foundNumericData = false;
                
                foreach ( var f in fields ) {
                    if ( double.TryParse( f, out double t ) ) {
                        foundNumericData = true;
                    }
                }

                if (foundNumericData == false) {
                    throw new Exception("Could not find any numeric data!!!");
                }
            }
        }

        static void PrintFile( string fileName ) {
            using var reader = OpenFile(fileName);
            PrintFileContents(reader);
        }

        private static void PrintFileContents(TextReader reader) {
            var fileContents = reader.ReadToEnd();
            Console.WriteLine("The file contains:");
            Console.WriteLine(fileContents);
        }

        private static TextReader OpenFile(string fileName) {
            return new StreamReader(fileName);
        }
    }
}