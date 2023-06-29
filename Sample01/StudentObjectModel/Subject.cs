using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjectModel {
    public class Subject {
        private string code;
        private string name;
        // TODO add a list of currently enrolled students

        public Subject(string initialCode, string initialName) {
            Code = initialCode;
            Name = initialName;
        }

        public override string ToString() {
            return $"{code},{name}";
        }

        /// <summary>
        /// Validate and update the subject code.
        /// </summary>
        public string Code {
            get {
                return code;
            }
            set {
                if ( ! IsValidCode(value) ) {
                    throw new ArgumentException($"'{value}' is not a valid subject code.");
                }

                code = value;
            }
        }

        /// <summary>
        /// Validate and update the subject name.
        /// </summary>
        public string Name {
            get {
                return name;
            }
            set {
                if ( ! IsValidName(value) ) {
                    throw new ArgumentException($"'{value}' is not a valid subject name.");
                }

                name = value;
            }
        }

        /// <summary>
        /// Returns true if and only if the supplied argument is a valid subject code.
        /// </summary>
        /// <param name="code">The subject code.</param>
        /// <returns>True if code is valid. False otherwise.</returns>
        public static bool IsValidCode( string code ) {
            if( code.Length == 6 
                && code.Take(3).All( c => Char.IsLetter(c) ) 
                && code.Skip(3).All( c => Char.IsDigit(c) ) 
            ) {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Determine if a subject name is valid.
        /// </summary>
        /// <param name="name">The subject name to test.</param>
        /// <returns>True if and only if the subject name is valid.</returns>
        public static bool IsValidName( string name ) {
            if (!string.IsNullOrWhiteSpace(name)
                && name.All(c => c != '\t' && c != '\f' && c != '\r' && c != '\n')
            ) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
