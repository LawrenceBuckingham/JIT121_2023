using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wed02_StudentExample {
    public class Subject {
        private string code;
        private string name;
        // TODO add a list of currently enrolled students

        public Subject(string initialCode, string initialName) {
            code = initialCode;
            name = initialName;
        }

        public override string ToString() {
            return $"{code},{name}";
        }
    }
}
