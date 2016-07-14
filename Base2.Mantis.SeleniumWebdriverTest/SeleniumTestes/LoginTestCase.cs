using Base2.Mantis.SeleniumWebdriverTest.Resources;
using NUnit.Framework;

namespace Base2.Mantis.SeleniumWebdriverTest
{
    public class LoginTestCase
    {
        LoginPageObjects login = new LoginPageObjects();

        [Test]
        public void CT001_realizarLoginFalhaSenhaInvalida()
        {
            
            login.realizarLogin(SeleniumConstantes.mantisUsername, "123456");

            SeleniumMetodosSet.validaMensagemEsperada(login.msgFalhaLogin, Mensagens.msgLoginInvalido);

        }
        [Test]
        public void CT002_realizarLoginFalhaUsuarioInvalido()
        {
                     
            login.realizarLogin("nao.existe", SeleniumConstantes.mantisPassword);

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

            login.realizarLogin(SeleniumConstantes.mantisUsername, SeleniumConstantes.mantisPassword);

            SeleniumMetodosSet.validaMensagemEsperada(login.msgSucessoLogin, Mensagens.msgLoginSucesso);

        }

        [Test]
        public void CT005_realizarLogoutSucesso()
        {
            login.realizarLogout();

            SeleniumMetodosSet.validaMensagemEsperada(login.linkForgot, "Lost your password?");

        }
        
    }
}
