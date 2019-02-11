using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.Configuration
{
    public class InvalidDriverSpecified : Exception
    {
        public InvalidDriverSpecified(string msg) : base(msg)
        {

        }
    }
}
