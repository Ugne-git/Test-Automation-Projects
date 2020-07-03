using NUnit.Framework;
using System;
using OpenQA.Selenium;
using System.Threading;

namespace ClickityClick_Test_Project
{
    class Page
    {
        Browser_ops brow = new Browser_ops();
        string test_url = "file:///C:/Users/Ugn%C4%97/Documents/QA%20Home%20Task%20.html";
        IWebDriver driver;

        //page elements
        IWebElement PlayGroundElement => driver.FindElement(By.CssSelector("body > div > h1"));
        IWebElement PuzzleElement1 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(1) > div:nth-child(1)"));
        IWebElement PuzzleElement2 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(1) > div:nth-child(2)"));
        IWebElement PuzzleElement3 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(1) > div:nth-child(3)"));
        IWebElement PuzzleElement4 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(1) > div:nth-child(4)"));
        IWebElement PuzzleElement99 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(1) > div:nth-child(9)"));
        IWebElement PuzzleElement5 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(2) > div:nth-child(1)"));
        IWebElement PuzzleElement6 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(2) > div:nth-child(2)"));
        IWebElement PuzzleElement8 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(2) > div:nth-child(4)"));
        IWebElement PuzzleElement9 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(3) > div:nth-child(1)"));
        IWebElement PuzzleElement12 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(3) > div:nth-child(4)"));
        IWebElement PuzzleElement13 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(4) > div:nth-child(1)"));
        IWebElement PuzzleElement14 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(4) > div:nth-child(2)"));
        IWebElement PuzzleElement15 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(4) > div:nth-child(3)"));
        IWebElement PuzzleElement16 => driver.FindElement(By.CssSelector("body > div > div.mainGrid > div:nth-child(4) > div:nth-child(4)"));
        IAlert simpleAlert => driver.SwitchTo().Alert();

        //page methods
        public void start_Browser()
        {
            brow.Init_Browser();
            brow.Goto(test_url);
            driver = brow.getDriver;
        }

        public void test_Browserops()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.IsTrue(PlayGroundElement.Displayed, "Fail");
            Thread.Sleep(1000);
        }

        public void click_InitialElements()
        {
            PuzzleElement1.Click();
            PuzzleElement2.Click();
            PuzzleElement3.Click();
            PuzzleElement4.Click();
            PuzzleElement5.Click();
            PuzzleElement8.Click();
            PuzzleElement9.Click();
            PuzzleElement12.Click();
            PuzzleElement13.Click();
            PuzzleElement14.Click();
            PuzzleElement15.Click();
            PuzzleElement16.Click();
            Thread.Sleep(1000);
        }

        public void close_Browser()
        {
            brow.Close();
        }

        public void assert_DialogIsVisible()
        {
            Assert.AreEqual("Done! Ready for the next try? Give me a size [3-9]:", simpleAlert.Text);
            Assert.IsTrue(is_AlertPresented());
            Thread.Sleep(1000);
        }

        public void assert_PuzzleSizeChangesTo3x3()
        {
            simpleAlert.SendKeys("3");
            simpleAlert.Accept();
            Assert.IsFalse(PuzzleElement4.Displayed);
            Thread.Sleep(1000);
        }

        public void assert_PuzzleSizeChangesTo9x9()
        {
            simpleAlert.SendKeys("9");
            simpleAlert.Accept();
            Assert.IsTrue(PuzzleElement99.Displayed);
            Thread.Sleep(1000);
        }
        public void assert_InputBelowMinIsNotAccepted()
        {
            simpleAlert.SendKeys("2");
            simpleAlert.Accept();
            Assert.AreEqual("Not a good size!", simpleAlert.Text);
            Thread.Sleep(1000);
        }

        public void assert_InputAboveMaxIsNotAccepted()
        {
            simpleAlert.SendKeys("10");
            simpleAlert.Accept();
            Assert.AreEqual("Not a good size!", simpleAlert.Text);
            Thread.Sleep(1000);
        }

        public void click_WrongElement()
        {
            PuzzleElement6.Click();
            Thread.Sleep(1000);
        }

        public bool is_AlertPresented()
        {
            try
            {
                simpleAlert.Accept();
                return true;
            }
            catch (NoAlertPresentException e)
            {
                return false;
            }
        }

        public void assert_DialogIsNotPresented()
        {
            Assert.IsFalse(is_AlertPresented());
        }
    }
}
