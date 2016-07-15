using Base2.Mantis.SeleniumWebdriverTest.SeleniumPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base2.Mantis.SeleniumWebdriverTest.SeleniumTestes
{
    class ExcluirBugsTestCase
    {
        BugPageObjects bug = new BugPageObjects();

        [Test]
        public void CT014_excluirBugSucesso()
        {
            bug.acessarContextoListarBug();
            bug.excluirBugs("1");
            SeleniumMetodosSet.validaMensagemEsperada(bug.msgConfirmExcluirBug, Resources.Mensagens.msgExcluirBug);
            SeleniumMetodosSet.clicarElemento(bug.btnSalvar);
        }
        [Test]
        public void CT015_excluirBugsMultiplos()
        {
            bug.acessarContextoListarBug();
            bug.excluirBugs("1");
            SeleniumMetodosSet.validaMensagemEsperada(bug.msgConfirmExcluirBug, Resources.Mensagens.msgExcluirBug);
            SeleniumMetodosSet.clicarElemento(bug.btnSalvar);

        }
    }
}
