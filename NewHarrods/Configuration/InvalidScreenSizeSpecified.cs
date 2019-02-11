using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.Configuration
{
    public class InvalidScreenSizeSpecified : Exception
    {
        public InvalidScreenSizeSpecified(string msg) : base(msg)
        {

        }
    }
}
