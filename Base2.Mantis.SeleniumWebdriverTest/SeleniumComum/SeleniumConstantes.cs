namespace Base2.Mantis.SeleniumWebdriverTest
{
    public class SeleniumConstantes
    {
        /// <summary>
        /// ramon.souza
        /// Classe de constantes para parametrizar URL, dados de login, diretórios...
        /// </summary>
        /// 


        //Setar a string do browser que será executado ( chrome ou phantom)
        
        public const string BrowserExecucao = "chrome";


        // Urls do sistema
        public const string contexto = "MantisBR";
        public const string urlBase = "http://mantis-prova.base2.com.br";
        public const string urlLogin = "/login_page.php?return=%2Fmy_view_page.php";
        public const string urlHomePage = "/my_view_page.php";

        // Dados de login
        public const string mantisUsername = "ramon.souza";
        public const string mantisPassword = "rmn@123";




        // Especificar o diretorio do windows para salvar logs.
        public static string diretorioLogsRaiz = @"c:\LogsSeleniumB2\";
        public static string diretorioFolderLog = @"c:\LogsSeleniumB2\Log\";
        public static string diretorioFolderPrint = @"c:\LogsSeleniumB2\Printscreen\";

        // cabeçalho e rodapé do arquivo de logs
        public const string quebraLinha = "****************************************************************************************************************************";


    }
}
