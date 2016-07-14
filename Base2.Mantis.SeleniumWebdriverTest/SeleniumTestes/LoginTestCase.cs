using Base2.Mantis.SeleniumWebdriverTest.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Base2.Mantis.SeleniumWebdriverTest
{
    public class LoginTestCase
    {
        LoginPageObjects login = new LoginPageObjects();

        [Test]
        public void CT001_realizarLoginFalhaUsuarioNaoInformado()
        {
            
            login.realizarLogin("", "123456");

            SeleniumMetodosSet.validaMensagemEsperada(login.msgFalhaLogin, Mensagens.msgLoginInvalido);

        }
        [Test]
        public void CT002_realizarLoginFalhaSenhaNaoInformada()
        {
                     
            login.realizarLogin("nao.existe", "");

            SeleniumMetodosSet.validaMensagemEsperada(login.msgFalhaLogin, Mensagens.msgLoginInvalido);

        }
        [Test]
        public void CT003_realizarLoginFalhaUsuarioESenhaNaoInformado()
        {
            
            login.realizarLogin("", "");

            SeleniumMetodosSet.validaMensagemEsperada(login.msgFalhaLogin, Mensagens.msgLoginInvalido);

        }
        [Test]
        public void CT004_realizarLoginSucesso()
        {

            login.realizarLogin("ramon.souza", "rmn@123");

            SeleniumMetodosSet.validaMensagemEsperada(login.msgSucessoLogin, Mensagens.msgLoginSucesso);

        }

        /*
          [Test]
        public void LoginTest2() {
            LoginPageObject page = new LoginPageObject();

            VerificarContexto();

            ExcelUtil.PopulateInCollection(@"C:\DataFile.xlsx");
            
            
            page.PreencheLogin(ExcelUtil.ReadData(1, "User"), ExcelUtil.ReadData(1, "Pass"));
                        
            //Submit
            page.ClickLogin();

            SeleniumUteis.GravarLogTxt("Seja bem vindo!");
                           
        }*/


    }
}
