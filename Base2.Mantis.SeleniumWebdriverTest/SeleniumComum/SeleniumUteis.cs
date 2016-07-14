using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Base2.Mantis.SeleniumWebdriverTest
{
    public class SeleniumUteis
    {
        public bool acceptNextAlert = true;

        // Especificar o diretorio do windows para salvar logs.

        public static string arquivo = SeleniumConstantes.diretorioFolderLog + "SeleniumLog " + DateTime.Now.ToString("dd-MM-yyyy HH-mm") + ".txt";
        /// <summary>
        /// ramon.souza
        /// </summary>
        /// Método para gravar linha de mensagem no arquivo de texto enviado por email 
        public static void gravarLogTxt(string msg)
        {
            try
            {
                // Verificar se o repositório já existe.
                if (Directory.Exists(SeleniumConstantes.diretorioLogsRaiz))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                // Criar o repositório.
                DirectoryInfo di1 = Directory.CreateDirectory(SeleniumConstantes.diretorioLogsRaiz);
                DirectoryInfo di2 = Directory.CreateDirectory(SeleniumConstantes.diretorioFolderLog);
                DirectoryInfo di3 = Directory.CreateDirectory(SeleniumConstantes.diretorioFolderPrint);

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {
                StreamWriter wr = new StreamWriter(arquivo, true);
                wr.WriteLine(msg);
                wr.Close();
            }
        }

        // Método para gerar log de exceção e gravar no arquivo de texto
        public static void gravarLogStacktrace(string parametro)
        {
            StackTrace stackTrace = new StackTrace(true);
            MethodBase methodBasePO = stackTrace.GetFrame(2).GetMethod();
            string fullfileNamePO = stackTrace.GetFrame(2).GetFileName();
            var fileNamePO = new FileInfo(fullfileNamePO).Name;
            int lineNoPO = stackTrace.GetFrame(2).GetFileLineNumber();

            MethodBase methodBaseTC = stackTrace.GetFrame(3).GetMethod();
            string fileNameTC = stackTrace.GetFrame(3).GetFileName();
            int lineNoTC = stackTrace.GetFrame(3).GetFileLineNumber();
            
            SeleniumUteis.gravarLogTxt("FALHA - Ocorreu um erro no teste: '" + methodBaseTC.Name + " | " + methodBasePO.Name + "'\n>>>>>> Método: '" + methodBasePO.Name + "' - Classe: '" + fileNamePO + "' - Linha: '" + lineNoPO + "'\n>>>>>> Causa: O elemento: '" + SeleniumMetodosSet.UltimoErro + "' não apareceu." + parametro);
            
        }
        // Método para capturar tela - Screenshot
        public static void gerarPrintscreen()
        {
            try
            {
                // Verificar se o repositório já existe.
                if (Directory.Exists(SeleniumConstantes.diretorioLogsRaiz))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Criar o repositório.
                DirectoryInfo di1 = Directory.CreateDirectory(SeleniumConstantes.diretorioLogsRaiz);
                DirectoryInfo di2 = Directory.CreateDirectory(SeleniumConstantes.diretorioFolderLog);
                DirectoryInfo di3 = Directory.CreateDirectory(SeleniumConstantes.diretorioFolderPrint);

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {
                Screenshot ss = ((ITakesScreenshot)SeleniumBase.driver).GetScreenshot();
                string screenshot = ss.AsBase64EncodedString;
                byte[] screenshotAsByteArray = ss.AsByteArray;
                ss.SaveAsFile(SeleniumConstantes.diretorioFolderPrint + "SeleniumPrintscreen" + GetCurrentDate() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                ss.ToString();
            }

        }

        //Obter data corrente
        public static String GetCurrentDate()
        {
            DateTime time = DateTime.Now;
            string format = "_dd-MM-yyyy HH-mm-ss";
            return time.ToString(format);
        }

        public static String GetCurrentDateTime()
        {
            DateTime time = DateTime.Now;
            return time.ToString();
        }

        // Direrório de arquivos datadriven

        public static String getPathDataDriven()
        {
            String strAppDir = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            String strAppFolderData = Path.Combine(strAppDir, "\\DataDriven\\Arquivos");
            return strAppDir + strAppFolderData;
        }

        public static String getPathSeleniumDriver()
        {
            String strAppDir = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            String strAppFolderData = Path.Combine(strAppDir, "\\SeleniumComum\\Drivers");
            return strAppDir + strAppFolderData;
        }

        public static void acessarContexto(IWebElement elemento)
        {
            SeleniumBase.driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlHomePage);
            if (SeleniumBase.driver.Title == "My View - MantisBT")
            {
                SeleniumMetodosSet.clicarElemento(elemento);
            }
            else
            {
                SeleniumBase.driver.Manage().Cookies.DeleteAllCookies();
                SeleniumBase.driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlLogin);
                LoginPageObjects login = new LoginPageObjects();
                login.realizarLogin(SeleniumConstantes.mantisUsername, SeleniumConstantes.mantisPassword);
                SeleniumMetodosSet.clicarElemento(elemento);

                // Abrir e Carregar os dados do excel (arquivo .xlsx)
                //ExcelUtil.PopulateInCollection(SeleniumUteis.getPathDataDriven() + "\\bugReportData.xlsx");
            }
        }



        //Verificar alertas presentes
        public bool IsAlertPresent()
        {
            try
            {
                SeleniumBase.driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        //Iteragir com alertas presentes
        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = SeleniumBase.driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

    }
}




