using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base2.Mantis.SeleniumWebdriverTest
{
    public class SeleniumConstantes
    {
        /// <summary>
        /// ramon.souza
        /// Classe de constantes para parametrizar URL, dados de login, diretórios...
        /// </summary>
        /// 

        // Urls do sistema
        public const string urlBase = "http://mantis-prova.base2.com.br";
        public const string urlLogin = "/login_page.php?return=%2Fmy_view_page.php";
        public const string urlHomePage = "/my_view_page.php";

        // Dados de login
        public const string mantisUsername = "ramon.souza";
        public const string mantisPassword = "rmn@123";


        //Diretórios
        public const string BrowserExecucao = "chrome";

        public const string DirChrome = "./ChromeDriver/chromedriver";
        public const string DirPhantom = "";
        public const string DirIE = "./";





    }
}
