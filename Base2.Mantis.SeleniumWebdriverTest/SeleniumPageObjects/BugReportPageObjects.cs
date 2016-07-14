using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Base2.Mantis.SeleniumWebdriverTest.SeleniumPageObjects
{
    class BugReportPageObjects
    {
        public BugReportPageObjects()
        {
            PageFactory.InitElements(SeleniumBase.driver, this);

        }
        // Campos de preenchimento
        [FindsBy(How = How.Name, Using = "category_id")]
        public IWebElement ddlCategory { get; set; }

        [FindsBy(How = How.Name, Using = "reproducibility")]
        public IWebElement ddlReproducibility { get; set; }

        [FindsBy(How = How.Name, Using = "severity")]
        public IWebElement ddlSeverity { get; set; }

        [FindsBy(How = How.Name, Using = "priority")]
        public IWebElement ddlPriority { get; set; }

        [FindsBy(How = How.Name, Using = "profile_id")]
        public IWebElement ddlSelectProfile { get; set; }

        [FindsBy(How = How.Id, Using = "platform")]
        public IWebElement txtPlatform { get; set; }

        [FindsBy(How = How.Id, Using = "os")]
        public IWebElement txtOS { get; set; }

        [FindsBy(How = How.Id, Using = "os_build")]
        public IWebElement txtOSVersion { get; set; }

        [FindsBy(How = How.Name, Using = "handler_id")]
        public IWebElement ddlAssignTo { get; set; }

        [FindsBy(How = How.Name, Using = "summary")]
        public IWebElement txtSummary { get; set; }

        [FindsBy(How = How.Name, Using = "description")]
        public IWebElement txtDescription { get; set; }

        [FindsBy(How = How.Name, Using = "steps_to_reproduce")]
        public IWebElement txtStepsToReproduce { get; set; }

        [FindsBy(How = How.Name, Using = "additional_info")]
        public IWebElement txtAdditionalInformation { get; set; }

        // Salvar reporte de bug
        [FindsBy(How = How.CssSelector, Using = "input.button")]
        public IWebElement btnSalvar { get; set; }

        // Mensagens 
        [FindsBy(How = How.CssSelector, Using = "p.center")]
        public IWebElement msgErroCampoObrig { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[2]")]
        public IWebElement msgSucesso { get; set; }

        [FindsBy(How = How.LinkText, Using = "Report Issue")]
        public IWebElement linkReport { get; set; }

        // Acessar o contexto do teste ( Verifica se o usuário está logado, isso garante que os testes rodem de forma indepente
        public void acessarContexto()
        {
            SeleniumBase.driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlHomePage);
            if (SeleniumBase.driver.Title == "My View - MantisBT")
            {
                SeleniumMetodosSet.clicarElemento(linkReport);
            }
            else
            {
                SeleniumBase.driver.Manage().Cookies.DeleteAllCookies();
                SeleniumBase.driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlLogin);
                LoginPageObjects login = new LoginPageObjects();
                login.realizarLogin(SeleniumConstantes.mantisUsername, SeleniumConstantes.mantisPassword);
                SeleniumMetodosSet.clicarElemento(linkReport);
                
                // Abrir e Carregar os dados do excel (arquivo .xlsx)
                ExcelUtil.PopulateInCollection(SeleniumUteis.getPathDataDriven() + "\\bugReportData.xlsx");
            }
        }
        // Médoto para preencher todos os  campos do bug e clicar em salvar
        public void preencherNewBug(string  categ, string reprod, string sever, string prior, string perf, string plataf, string os, string osvers, string resp, string sumar, string desc, string passos, string add) {

            SeleniumMetodosSet.preencherTexto(txtSummary, sumar);
            SeleniumMetodosSet.preencherTexto(txtDescription, desc);
            SeleniumMetodosSet.preencherTexto(txtStepsToReproduce, passos);
            SeleniumMetodosSet.preencherTexto(txtAdditionalInformation, add);

            SeleniumMetodosSet.selecionarElemento(ddlCategory, categ);
            SeleniumMetodosSet.selecionarElemento(ddlReproducibility, reprod);
            SeleniumMetodosSet.selecionarElemento(ddlSeverity, sever);
            SeleniumMetodosSet.selecionarElemento(ddlPriority, prior);
            SeleniumMetodosSet.selecionarElemento(ddlSelectProfile, perf);

            SeleniumMetodosSet.preencherTexto(txtPlatform, plataf);
            SeleniumMetodosSet.preencherTexto(txtOS, os);
            SeleniumMetodosSet.preencherTexto(txtOSVersion, osvers);

            //Salvar
            SeleniumMetodosSet.clicarElemento(btnSalvar);

        }

    }
}
