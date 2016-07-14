using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Base2.Mantis.SeleniumWebdriverTest
{
    public class SeleniumMetodosGet : SeleniumUteis
    {

        public static string GetText(IWebElement elemento)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 10)
                {
                    SeleniumUteis.gravarLogStacktrace(".");
                    Assert.Fail("O elemento: '" + SeleniumMetodosSet.UltimoErro + "' não apareceu");
                }
                try
                {
                    if (elemento.Displayed) break;

                }
                catch (Exception e)
                {
                    SeleniumMetodosSet.UltimoErro = e.Message;
                }
                Thread.Sleep(1000);
            }

            return (elemento).GetAttribute("value");
        }

        public static string GetTextFromDDL(IWebElement elemento)
        {
            return new SelectElement((elemento)).AllSelectedOptions.SingleOrDefault().Text;

        }

        public static string GetTitle()
        {
            return SeleniumBase.driver.Title;
        }
        public static string GetLabel(IWebElement elemento)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 10)
                {
                    SeleniumUteis.gravarLogStacktrace(".");
                    Assert.Fail("O elemento: '" + SeleniumMetodosSet.UltimoErro + "' não apareceu");
                }
                try
                {
                    if (elemento.Displayed) break;

                }
                catch (Exception e)
                {
                    SeleniumMetodosSet.UltimoErro = e.Message;
                }
                Thread.Sleep(1000);
            }
            return (elemento).Text;
        }
    }
}

