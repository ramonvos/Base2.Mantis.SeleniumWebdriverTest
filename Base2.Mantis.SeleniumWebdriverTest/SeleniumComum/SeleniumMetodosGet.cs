using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Base2.Mantis.SeleniumWebdriverTest
{
    class SeleniumMetodosGet
    {
        public static string GetLabel(IWebElement element)
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
                    if (element.Displayed) break;

                }
                catch (Exception e)
                {
                    SeleniumMetodosSet.UltimoErro = e.Message;
                }
                Thread.Sleep(1000);
            }
            return (element).Text;
        }
    }
}
