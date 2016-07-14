using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base2.Mantis.SeleniumWebdriverTest
{
    public class LoginPageObjects : SeleniumBase
    {
        public LoginPageObjects()
        {
            PageFactory.InitElements(SeleniumBase.driver, this);

        }

        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement txtUsuario { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement txtSenha { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.button")]
        public IWebElement btnLogin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "font")]
        public IWebElement msgFalhaLogin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td.login-info-left")]
        public IWebElement msgSucessoLogin { get; set; }



        public void realizarLogin(string usuario, string senha)
        {
            SeleniumMetodosSet.preencherTexto(txtUsuario, usuario);
            SeleniumMetodosSet.preencherTexto(txtSenha, senha);

            SeleniumMetodosSet.clicarElemento(btnLogin);
        }

    }
}
