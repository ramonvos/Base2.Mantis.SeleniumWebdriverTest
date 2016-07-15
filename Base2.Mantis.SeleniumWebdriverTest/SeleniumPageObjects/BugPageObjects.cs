using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace Base2.Mantis.SeleniumWebdriverTest.SeleniumPageObjects
{
    class BugPageObjects
    {
        public BugPageObjects()
        {
            PageFactory.InitElements(SeleniumBase.driver, this);

        }
        #region Campos de preenchimento novo bug
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
        #endregion
        
        #region Mensagens
        // Mensagens 
        [FindsBy(How = How.CssSelector, Using = "p.center")]
        public IWebElement msgErroCampoObrig { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[2]")]
        public IWebElement msgSucesso { get; set; }
        #endregion

        #region Menu superior home links e botões
        [FindsBy(How = How.LinkText, Using = "Report Issue")]
        public IWebElement linkReport { get; set; }
                
        [FindsBy(How = How.Name, Using = "bug_id")]
        public IWebElement txtIdBug { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.button-small")]
        public IWebElement btnJump { get; set; }

        [FindsBy(How = How.LinkText, Using = "View Issues")]
        public IWebElement linkViewIssues { get; set; }
        #endregion

        #region tabelas de listagem

        [FindsBy(How = How.XPath, Using = "//table[@id='buglist']/tbody/tr[4]/td[4]")]
        public IWebElement tableListBug { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td.form-title")]
        public IWebElement tableVerBug { get; set; }
                
        
        [FindsBy(How = How.CssSelector, Using = "td.left")]
        public IWebElement tblAlteracaoSumario { get; set; }

        [FindsBy(How = How.XPath, Using = "//tr[8]/td[2]")]
        public IWebElement tblAlteracaoStatus { get; set; }

        #endregion

        #region Botões
        // Salvar novo de bug
        [FindsBy(How = How.CssSelector, Using = "input.button")]
        public IWebElement btnSalvar { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td.center > form > input.button")]
        public IWebElement btnEditarBug { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Clone']")]
        public IWebElement btnClonarBug { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Change Status To:']")]
        public IWebElement btnAlterarStatusBug { get; set; }

        [FindsBy(How = How.Name, Using = "new_status")]
        public IWebElement ddlStatus { get; set; }

        [FindsBy(How = How.Name, Using = "bugnote_text")]
        public IWebElement txtAddNota { get; set; }

        #endregion
        [FindsBy(How = How.Name, Using = "bug_arr[]")]
        public IWebElement checkSelecionarBug { get; set; }

        [FindsBy(How = How.Name, Using = "all_bugs")]
        public IWebElement checkSelecionarTodos { get; set; }

        [FindsBy(How = How.Name, Using = "action")]
        public IWebElement ddlAcao { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td.category")]
        public IWebElement msgConfirmExcluirBug { get; set; }
        

        #region Metodo para verificar se está logado

        // Acessar o contexto do teste ( Verifica se o usuário está logado, solução para que os testes rodem de forma independente)
        public void acessarContexto()
        {
            SeleniumBase.driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlHomePage);

            if (SeleniumBase.driver.Title == "My View - MantisBT")
            {
                SeleniumMetodosSet.clicarElemento(linkReport);
                // Abrir e Carregar os dados do excel (arquivo .xlsx)

            }

            else
            {
                SeleniumBase.driver.Manage().Cookies.DeleteAllCookies();
                SeleniumBase.driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlLogin);
                LoginPageObjects login = new LoginPageObjects();
                login.realizarLogin(SeleniumConstantes.mantisUsername, SeleniumConstantes.mantisPassword);
                SeleniumMetodosSet.clicarElemento(linkReport);
            }

        }

        // Acessar o contexto do teste ( Verifica se o usuário está logado, solução para que os testes rodem de forma independente)
        public void acessarContextoListarBug()
        {
            SeleniumBase.driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlHomePage);
            if (SeleniumBase.driver.Title == "My View - MantisBT")
            {
                SeleniumMetodosSet.clicarElemento(linkViewIssues);
                
            }
            else
            {
                SeleniumBase.driver.Manage().Cookies.DeleteAllCookies();
                SeleniumBase.driver.Navigate().GoToUrl(SeleniumConstantes.urlBase + SeleniumConstantes.urlLogin);
                LoginPageObjects login = new LoginPageObjects();
                login.realizarLogin(SeleniumConstantes.mantisUsername, SeleniumConstantes.mantisPassword);
                SeleniumMetodosSet.clicarElemento(linkViewIssues);
                

            }
        }

        #endregion

        #region Metodos de preenchimento de campos e clicar em botões
        // Médoto para preencher todos os  campos do bug e clicar em salvar
        public void preencherNovoBug(string  categ, string reprod, string sever, string prior, string perf, string plataf, string os, string osvers, string resp, string sumar, string desc, string passos, string add) {

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
        public void preencherAlteracaoBug(string sumario)
        {
            SeleniumMetodosSet.preencherTexto(txtSummary, sumario);
            SeleniumMetodosSet.clicarElemento(btnSalvar);
            Thread.Sleep(3);
            SeleniumMetodosSet.clicarElemento(linkViewIssues);

        }
        public void clonarBug(string sumario)
        {
            SeleniumMetodosSet.preencherTexto(txtSummary, sumario);
        }
               
        public void pesquisaBugPorId(string num)
        {
            var numBug = SeleniumMetodosGet.GetLabel(tableListBug);
            SeleniumMetodosSet.preencherTexto(txtIdBug, numBug + num);
            SeleniumMetodosSet.clicarElemento(btnJump);
        }
        public void alteraStatusBug(string status, string nota)
        {
            SeleniumMetodosSet.selecionarElemento(ddlStatus, status);
            SeleniumMetodosSet.clicarElemento(btnAlterarStatusBug);
            SeleniumMetodosSet.preencherTexto(txtAddNota, nota);
            SeleniumMetodosSet.clicarElemento(btnSalvar);
                

        }

        public void clicarEditarBug()
        {
            SeleniumMetodosSet.clicarElemento(btnEditarBug);
            
            
        }

        public void clicarClonarBug()
        {
            SeleniumMetodosSet.clicarElemento(btnClonarBug);
            
        }

        public void excluirBugs(string parametro) {
            string valor = "Delete";
            if (parametro == "todos")
            {
                SeleniumMetodosSet.clicarElemento(checkSelecionarTodos);
                SeleniumMetodosSet.selecionarElemento(ddlAcao,valor);
                SeleniumMetodosSet.clicarElemento(btnSalvar);
                
            }
            if (parametro == "1")
            {
                SeleniumMetodosSet.clicarElemento(checkSelecionarBug);
                SeleniumMetodosSet.selecionarElemento(ddlAcao, valor);
                SeleniumMetodosSet.clicarElemento(btnSalvar);
                
            }

        }

        #endregion

    }
}
