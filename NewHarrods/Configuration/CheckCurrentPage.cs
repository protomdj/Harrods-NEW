using NewHarrods.Settings;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harrods.Testing.Tools
{
    public class CheckCurrentPage
    {
        public void MyCurrentPageCheck(string urlSegment)
        {
            string currentuRL = ObjectRepository.Driver.Url;
            Assert.True(currentuRL.Contains(urlSegment));
        }
    }
}
