using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Diagnostics;
using System.Text;

namespace Base2.Mantis.SeleniumWebdriverTest
{
    public class SeleniumBase
    {
        public static IWebDriver driver { get; set; }
        public static Stopwatch sw = new Stopwatch();
        public class MySetUpBrowser
        {
            public void Browser(string browser)
            {
                /*
                if (browser == "firefox")
                {
                    //driver = new FirefoxDriver();
                    //driver = new FirefoxDriver(new FirefoxOptions());
              
                }*/
                if (browser == "chrome")
                {
                    driver = new ChromeDriver(SeleniumUteis.getPathSeleniumDriver());
                }
                if (browser == "phantom")
                {
                    driver = new PhantomJSDriver(SeleniumUteis.getPathSeleniumDriver());
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
                        //Setar o browser que ira inicializar
                        b.Browser(SeleniumConstantes.BrowserExecucao);

                    }
                    verificationErrors = new StringBuilder();

                    //Maximizar o browser, executor javascript e navegar para a tela de login

                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlLogin);


                    // Grava log no cabeçalho do arquivo
                    SeleniumUteis.gravarLogTxt(SeleniumConstantes.quebraLinha);
                    SeleniumUteis.gravarLogTxt("Sistema: " + SeleniumConstantes.contexto + " - URL: " + SeleniumConstantes.urlBase);
                    sw.Start();
                    SeleniumUteis.gravarLogTxt("Início da execução: " + DateTime.Now);
                    SeleniumUteis.gravarLogTxt(SeleniumConstantes.quebraLinha);

                }

                catch (Exception a)
                {   
                    Console.WriteLine("Ocorreu um erro ao inicializar o browser");
                }

            }

            [OneTimeTearDown]
            public void CleanUp()
            {
                SeleniumUteis.gravarLogTxt(SeleniumConstantes.quebraLinha);
                String tmp = "";
                SeleniumUteis.gravarLogTxt("Fim da execução: " + DateTime.Now);
                sw.Stop();
                TimeSpan timeSpan = sw.Elapsed;
                tmp = string.Format("Tempo total de execução: {0}h {1}m {2}s ", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                SeleniumUteis.gravarLogTxt(tmp);
                SeleniumUteis.gravarLogTxt(SeleniumConstantes.quebraLinha);

                driver.Dispose();
                Process.Start(SeleniumConstantes.diretorioLogsRaiz);
                driver.Close();
                

            }
        }
    }
}
