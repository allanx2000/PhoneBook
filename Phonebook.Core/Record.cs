using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core
{
    public class Record
    {
        public string FName { get; set; }
        public string LName { get; set; }

        public string FullName
        {
            get
            {
                return LName + ", " + FName;
            }
        }

        public bool Match(string query)
        {
            return FullName.Contains(query);
        }
    }
}
