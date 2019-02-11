using NewHarrods.Classes;
using NewHarrods.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NewHarrods.Definitions
{
    [Binding]
    public class PdpDefinition : BaseTestClass
    {
        PDP pdp = new PDP();


        [When(@"I validate Section on PDP")]
        public void ThenIValidateSectionOnPDP()
        {
            pdp.ValidatePdpSection();          
        }







    }
}
