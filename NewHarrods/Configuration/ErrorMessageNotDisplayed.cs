using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.Configuration
{
    public class ErrorMessageNotDisplayed : Exception
    {
        public ErrorMessageNotDisplayed(string msg) : base(msg)
        {
            msg = "Error Message Was Not Found";
        }
    }
}
