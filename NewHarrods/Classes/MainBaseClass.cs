using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
//using OpenQA.Selenium.PhantomJS;
using AventStack.ExtentReports;
using NewHarrods.Configuration;
using NewHarrods.PageObjects;
using OpenQA.Selenium.Safari;
using System;
using System.Drawing;
using TechTalk.SpecFlow;
using NewHarrods.Settings;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Gherkin.Model;
using System.Configuration;
using System.IO;
using System.Web;

namespace NewHarrods.Classes
{
    [Binding]
    public class MainBaseClass : BaseTestClass
    {
        BasePage basemethod = new BasePage();

        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        private static String teststep = null;
        public static string path = "\\TestResults";
        public static string time = DateTime.Now.ToString("yyyyMMddHHmmss");
        private static string filename = $"\\Test_Report_ { time }.html";

        [BeforeTestRun]
        public static void BeforeRun()
        {
            htmlReporter = new ExtentHtmlReporter(TestContext.CurrentContext.TestDirectory + path + filename);
            extent = new ExtentReports();

            htmlReporter.Configuration().Theme = Theme.Dark;
            htmlReporter.Configuration().DocumentTitle = "Test Report | Harrods";
            htmlReporter.Configuration().ReportName = "Test Report | Harrods";

            extent.AttachReporter(htmlReporter);
        }

        [BeforeScenario]
        private void BrowserStamp()
        {
            scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            BrowserInfo BrowserDetails = new BrowserInfo();
            BrowserDetails.GetBrowserDetails();
            try { basemethod.RemoveCookieBar(); }
            catch { }

            WaitElementUntil(By.XPath("//*[@class='header-account_link header-account_link--sign-in']"));
        }

        [AfterScenario]
        public void Logout()
        {
            Screenshot screenshotdriver = ((ITakesScreenshot)ObjectRepository.Driver).GetScreenshot();
            string name = $"\\{ScenarioContext.Current.ScenarioInfo.Title}";
            if (ScenarioContext.Current.ScenarioExecutionStatus.ToString() == "OK")
            {
                screenshotdriver.SaveAsFile(TestContext.CurrentContext.TestDirectory + path + "\\Passes" + name + ".png", ScreenshotImageFormat.Png);
            }
            else if(ScenarioContext.Current.ScenarioExecutionStatus.ToString() == "TestError")
            {
                screenshotdriver.SaveAsFile(TestContext.CurrentContext.TestDirectory + path + "\\Fails" + name + ".png", ScreenshotImageFormat.Png);
            }

            ObjectRepository.Driver.Manage().Cookies.DeleteAllCookies();
            basemethod.GoToHompage();
            basemethod.Logout();
        }


        [AfterStep]
        public static void AfterSteps()
        {
            teststep = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            //Test passes
            if (ScenarioContext.Current.ScenarioExecutionStatus.ToString() == "OK")
            {
                if (teststep == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (teststep == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (teststep == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                else if (teststep == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
            }

            //Test fails
            else if (ScenarioContext.Current.ScenarioExecutionStatus.ToString() == "TestError")
            {
                var stacktrace = string.Format("<pre>{0}</pre>", $"{ ScenarioContext.Current.TestError.Message} \n \n {ScenarioContext.Current.TestError.StackTrace}");

                if (teststep == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(stacktrace);
                else if (teststep == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(stacktrace);
                else if (teststep == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(stacktrace);
                else if (teststep == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(stacktrace);
            }

            //pending status
            else if (ScenarioContext.Current.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (teststep == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("step definition pending");
                else if (teststep == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("step definition pending");
                else if (teststep == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("step definition pending");
                else if (teststep == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("step definition pending");
            }
        }

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = EnvURL;
            //driver.Navigate().GoToUrl(EnvURL);
            return driver;
        }
        private static IWebDriver GetFirefoxDriver()
        {
            //FirefoxOptions options = new FirefoxOptions();
            //options.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";


            FirefoxOptions options = new FirefoxOptions();

            options.AcceptInsecureCertificates = true;
            options.SetPreference("dom.w3c_touch_events.enabled",0);
            options.SetPreference("browser.privatebrowsing.autostart", true);
  
            _driver = new FirefoxDriver(options);
            _driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(EnvURL);
            _driver.Url = EnvURL;
            return _driver;
        }
        private static IWebDriver GetIEDriver()
        {
            InternetExplorerOptions options = new InternetExplorerOptions
            {
                //RequireWindowFocus = true,
                //EnablePersistentHover= true,
                EnsureCleanSession = true             
            };
            _driver = new InternetExplorerDriver(options);
            _driver.Url = EnvURL;
            //driver.Navigate().GoToUrl(EnvURL);
            return _driver;
        }
        private static IWebDriver GetSafariDriver()
        {
            IWebDriver driver = new SafariDriver();
            driver.Navigate().GoToUrl(EnvURL);
            return driver;
        }
        //private static IWebDriver GetHeadlessDriver()
        //{
        //    IWebDriver driver = new PhantomJSDriver();
        //    driver.Navigate().GoToUrl(EnvURL);
        //    return driver;
        //}
        private static IWebDriver GetMultiDrivers()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(EnvURL);
            return driver;
        }

        public static string EnvURL;
 
        [BeforeFeature]
        public static void InitEnvironment()
        {
            ObjectRepository.Config = new AppConfigReader();

            EnvURL = "https://www.qa.harrods.com/en-gb";

            //EnvURL = "https://www.4860.dev.harrods.com/en-gb";

            //switch (ObjectRepository.Config.GetEnvironment())
            //{
            //    case EnvironmentType.DEV:
            //        EnvURL = "https://www.dev.harrods.com/en-gb";
            //        break;
            //    case EnvironmentType.DEVLOCAL:
            //        EnvURL = "http://www.local.harrods.com:81";
            //        break;
            //    case EnvironmentType.QA:
            //        EnvURL = "https://www.qa.harrods.com/en-gb";
            //        break;
            //    case EnvironmentType.QALOCAL:
            //        EnvURL = "http://www.qa.harrods.com:81";
            //        break;
            //    case EnvironmentType.PP:
            //        EnvURL = "https://www.pp.harrods.com/en-gb";
            //        break;
            //    case EnvironmentType.STAGING:
            //        EnvURL = "https://www.staging.harrods.com/en-gb";
            //        break;
            //    case EnvironmentType.PROD:
            //        EnvURL = "https://www.prod.harrods.com/en-gb";
            //        break;
            //    case EnvironmentType.LIVE:
            //        EnvURL = "https://www.harrods.com/en-gb";
            //        break;
            //    default:
            //        throw new InvalidEnvironmentSpecified("Environment Not Found" + ObjectRepository.Config.GetEnvironment().ToString());
            //}


            ObjectRepository.Driver = GetFirefoxDriver();

            //ObjectRepository.Driver = GetIEDriver();


            //switch (ObjectRepository.Config.GetBrowser())
            //{
            //    case BrowserType.Chrome:
            //        ObjectRepository.Driver = GetChromeDriver();
            //        break;
            //    case BrowserType.Firefox:
            //        ObjectRepository.Driver = GetFirefoxDriver();
            //        break;
            //    case BrowserType.IE:
            //        ObjectRepository.Driver = GetIEDriver();
            //        break;
            //    //case BrowserType.Headless:
            //    //    ObjectRepository.Driver = GetHeadlessDriver();
            //    //    break;
            //    default:
            //        throw new InvalidDriverSpecified("Driver Not Found" + ObjectRepository.Config.GetBrowser().ToString());
            //}
            //IWindow ScreSize = ObjectRepository.Driver.Manage().Window;
            //switch (ObjectRepository.Config.GetScreenSize())
            //{
            //    case ScreenSizeType.Desktop:
            //        ScreSize.Maximize();
            //        break;
            //    case ScreenSizeType.iPad:
            //        ScreSize.Size = new Size(768, 1024);
            //        break;
            //    case ScreenSizeType.iPhone6:
            //        ScreSize.Size = new Size(375, 667);
            //        break;
            //    case ScreenSizeType.iPhone5:
            //        ScreSize.Size = new Size(320, 568);
            //        break;
            //    default:
            //        throw new InvalidScreenSizeSpecified("Screen Size Not Found" + ObjectRepository.Config.GetScreenSize().ToString());
            //}

            feature = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
        [AfterFeature]
        public static void TearDown()
        {
            //if (ObjectRepository.Driver != null)
            //{
            //    ObjectRepository.Driver.Close();
            //    ObjectRepository.Driver.Quit();
            //}
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }

            extent.Flush();
        }
    }
}
