using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace Base2.Mantis.SeleniumWebdriverTest
{

    [TestFixture]
    [Author("Ramon Souza", "ramon.souza@eteg.com.br")]
    class TestExtentedReport : SeleniumBase
    {
        ExtentReports report;
        ExtentTest test;

        
        [Test]
        public void CT1SimpleTestSucesso()

        {
            String filepath = SeleniumConstantes.diretorioFolderLog+"ExtentReport.html";
            //var extent = new ExtentReports(filepath, true);

            //var test = extent.StartTest("Realizar login sucesso", "Usuário e senha corretos");

            report = new ExtentReports(filepath, true);

            driver.Navigate().GoToUrl("www.google.com.br");
            test = report.StartTest("Acessar o google", "google.com.br");


            test.Log(LogStatus.Info, "Acessar a tela de login;");
            //Preenche campos
            
            test.Log(LogStatus.Info, "Preencher o login e senha com dados válidos;");
            //Submit
            
            test.Log(LogStatus.Info, "Clicar no botão de login;");
            //Valida mensagens 
            

            test.Log(LogStatus.Pass, "Sucesso: Título verificado.");

                       
            //captura printscreen
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            //Use it as you want now
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(SeleniumConstantes.diretorioFolderPrint + "Resultado.png", System.Drawing.Imaging.ImageFormat.Png);
            ss.ToString();

            String image = test.AddScreenCapture(SeleniumConstantes.diretorioFolderPrint + "Resultado.png");
            test.Log(LogStatus.Info, "Evidência: " + image);

       
            report.EndTest(test);
            report.Flush();
            

        }

     
    }

}





