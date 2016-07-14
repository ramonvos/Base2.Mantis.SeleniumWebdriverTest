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
        public const string numBug = "";

        public BugViewPageObjects()
        {
            PageFactory.InitElements(SeleniumBase.driver, this);
        }
        // Menu Superior
        [FindsBy(How =How.Name, Using ="bug_id")]
        public IWebElement txtIdBug { get; set; }

        [FindsBy(How =How.CssSelector, Using = "input.button-small")]
        public IWebElement btnJump { get; set; }

        [FindsBy(How = How.LinkText, Using = "View Issues")]
        public IWebElement linkViewIssues { get; set; }


        [FindsBy(How = How.XPath, Using = "//table[@id='buglist']/tbody/tr[4]/td[4]")]
        public IWebElement tableListBug { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td.form-title")]
        public IWebElement tableVerBug { get; set; }


        // Filtros de pesquisa 




        // Acessar o contexto do teste ( Verifica se o usuário está logado, isso garante que os testes rodem de forma indepente
        

        public void pesquisaBugPorId()
        {
            SeleniumMetodosSet.clicarElemento(linkViewIssues);


            var numBug = SeleniumMetodosGet.GetLabel(tableListBug);

            SeleniumMetodosSet.preencherTexto(txtIdBug, numBug);

            SeleniumMetodosSet.clicarElemento(btnJump);


        }
        
        




    }
}
