using Base2.Mantis.SeleniumWebdriverTest.SeleniumPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base2.Mantis.SeleniumWebdriverTest.SeleniumTestes
{
    class AtualizarBugsTestCase
    {
        
        BugPageObjects bug = new BugPageObjects();
        [Test]
        public void CT009_editarBugSucesso()
        {
            bug.acessarContextoListarBug();
            bug.pesquisaBugPorId(null);
            bug.clicarEditarBug();

            bug.preencherAlteracaoBug("Bug Alterado em: " + SeleniumUteis.GetCurrentDateTime());
            
            SeleniumMetodosSet.validaMensagemEsperada(bug.tblAlteracaoSumario, "Bug Alterado em:");

        }
        [Test]
        public void CT010_clonarBugSucesso()
       {
            bug.acessarContextoListarBug();
            bug.pesquisaBugPorId(null);
            bug.clicarClonarBug();

            bug.preencherAlteracaoBug("Bug Clonado em: " + SeleniumUteis.GetCurrentDateTime());


        }
        [Test]
        public void CT011_atualizarStatusBugSucesso()
        {
            bug.acessarContextoListarBug();
            bug.pesquisaBugPorId(null);

            bug.alteraStatusBug("resolved", "Bug Corrigido");

            SeleniumMetodosSet.validaMensagemEsperada(bug.tblAlteracaoStatus, "resolved");

        }
    }
}
