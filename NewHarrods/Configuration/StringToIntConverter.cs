using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.Configuration
{
    class StringToIntConverter
    {
        public int GetNumber(string myString)
        {          

            return int.Parse(new string(myString.Where(c => char.IsDigit(c)).ToArray()));
        }
    }
}
