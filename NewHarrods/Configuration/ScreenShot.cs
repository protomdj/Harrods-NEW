using NewHarrods.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.Configuration
{
   public class ScreenShot
    {
        public void TakeScreenShot(string fileName)
        {
            Screenshot ss = ((ITakesScreenshot)ObjectRepository.Driver).GetScreenshot();
            
                string filelocation = "C:\\workspace\\Automation\\Harrods\\NewTestFramework-JM Copy\\screenshots\\" + DateTime.UtcNow.ToString("dd - MM - yyyy")+"\\";     
                Directory.CreateDirectory(filelocation);               
                ss.SaveAsFile(filelocation +fileName + " "+ DateTime.UtcNow.ToString("ss - mm - dd - MM - yyyy") + ".png" , ScreenshotImageFormat.Png);
                return;            
        }
    }
}
