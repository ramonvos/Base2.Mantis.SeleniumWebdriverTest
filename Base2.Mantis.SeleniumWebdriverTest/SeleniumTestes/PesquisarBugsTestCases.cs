using Base2.Mantis.SeleniumWebdriverTest.SeleniumPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base2.Mantis.SeleniumWebdriverTest.SeleniumTestes
{
    class PesquisarBugsTestCases
    {
        BugViewPageObjects pesquisa = new BugViewPageObjects(); 

        [Test]
        public void CT011_pesquisarBugPorId()
        {
            SeleniumUteis.acessarContexto(pesquisa.linkViewIssues);

            pesquisa.pesquisaBugPorId();

            SeleniumMetodosSet.validaMensagemEsperada(pesquisa.tableVerBug, Resources.Mensagens.msgVerBug); 

        }
    }
}
