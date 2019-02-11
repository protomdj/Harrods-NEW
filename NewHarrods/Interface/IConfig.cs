using NewHarrods.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.Interface
{
   public  interface IConfig
    {
        BrowserType GetBrowser();
        EnvironmentType GetEnvironment();
        ScreenSizeType GetScreenSize();
        string GetUsername();
        string GetPassword();
    }
}
