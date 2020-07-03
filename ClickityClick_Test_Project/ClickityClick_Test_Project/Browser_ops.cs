using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClickityClick_Test_Project
{
    class Browser_ops
    {
        IWebDriver webDriver;

        public void Init_Browser()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        public string Title
        {
            get { return webDriver.Title; }
        }
        public void Goto(string url)
        {
            webDriver.Url = url;
        }
        public void Close()
        {
            webDriver.Quit();

        }
        public IWebDriver getDriver
        {
            get { return webDriver; }
        }
    }
}
