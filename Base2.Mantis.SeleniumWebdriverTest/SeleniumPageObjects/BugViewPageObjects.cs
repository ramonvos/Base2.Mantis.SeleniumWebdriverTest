using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base2.Mantis.SeleniumWebdriverTest.SeleniumPageObjects
{
    class BugViewPageObjects
    {   
        public BugViewPageObjects()
        {
            PageFactory.InitElements(SeleniumBase.driver, this);
        }

        [FindsBy(How =How.Name, Using ="bug_id")]
        public IWebElement txtIdBug { get; set; }

        [FindsBy(How =How.CssSelector, Using = "input.button-small")]
        public IWebElement btnJump { get; set; }

        [FindsBy(How = How.LinkText, Using = "View Issues")]
        public IWebElement linkViewIssues { get; set; }




    }
}
