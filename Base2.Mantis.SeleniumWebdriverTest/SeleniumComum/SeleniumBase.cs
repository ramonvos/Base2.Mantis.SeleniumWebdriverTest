using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base2.Mantis.SeleniumWebdriverTest
{
    public class SeleniumBase
    {

        public static IWebDriver driver { get; set; }

        static void Main(String[] args)
        {

        }

        public class MySetUpBrowser
        {
            public void Browser(string browser)
            {
                if (browser == "firefox")
                {
                    //driver = new FirefoxDriver();
                    //driver = new FirefoxDriver(new FirefoxOptions());
                
                }
                if (browser == "chrome")
                {
                    driver = new ChromeDriver();
                }

            }

        }

        // Inicializa e fecha o webdriver (Configurações de inicialização)
        [SetUpFixture]
        public class MySetUpClass
        {
            public StringBuilder verificationErrors;
            [OneTimeSetUp]
            public void Initialize()
            {
                try
                {
                    if (driver == null)
                    {

                        MySetUpBrowser b = new MySetUpBrowser();

                        b.Browser(SeleniumConstantes.BrowserExecucao);

                    }

                    verificationErrors = new StringBuilder();


                    //Maximizar o browser, executor javascript e navegar para a tela de login
                    driver.Manage().Window.Maximize();
                    IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

                    //Setar o browser que ira inicializar

                    driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlLogin);


                    /* Grava log no cabeçalho do arquivo
                    SeleniumUteis.GravarLogTxt(SeleniumConstantes.quebraLinha);
                    SeleniumUteis.GravarLogTxt("Sistema: " + SeleniumConstantes.Contexto + " - URL: " + SeleniumConstantes.UrlBase + SeleniumConstantes.Contexto);
                    sw.Start();
                    SeleniumUteis.GravarLogTxt("Início da execução: " + DateTime.Now);
                    SeleniumUteis.GravarLogTxt(SeleniumConstantes.quebraLinha);*/

                }

                catch (Exception a)
                {   
                    Console.WriteLine("Ocorreu um erro ao inicializar o browser");
                }

            }

            [OneTimeTearDown]
            public void CleanUp()
            {
                try
                {
                    /*String versao = "";
                    SeleniumUteis.GravarLogTxt(SeleniumConstantes.quebraLinha);
                    if (SeleniumBase.driver.Title != Resources.MsgLogin.msg_login_title)
                    {
                        versao = SeleniumBase.driver.FindElement(By.CssSelector("div.page-footer-inner")).Text;
                        SeleniumUteis.GravarLogTxt("Versão do sistema: " + versao);
                    }
                    else
                    {
                        SeleniumUteis.GravarLogTxt("Versão do sistema: Não foi possível obter a versão.");
                    }
                    ;
                    String line = "";
                    SeleniumUteis.GravarLogTxt("Fim da execução: " + DateTime.Now);
                    sw.Stop();
                    TimeSpan timeSpan = sw.Elapsed;
                    line = string.Format("Tempo total de execução: {0}h {1}m {2}s ", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                    SeleniumUteis.GravarLogTxt(line);
                    SeleniumUteis.GravarLogTxt(SeleniumConstantes.quebraLinha);*/


                }
                catch (Exception)
                {
                    //SeleniumUteis.GravarLogTxt(SeleniumConstantes.quebraLinha);
                    //SeleniumUteis.GravarLogTxt("Erro ao obter versão so sistema ");
                    // Ignore errors if unable to close the browser
                }
                finally
                {
                    //SeleniumUteis.EnviarEmail();

                    driver.Close();


                }
                Assert.AreEqual("", verificationErrors.ToString());

            }
        }
    }
}
