using Base2.Mantis.SeleniumWebdriverTest.SeleniumPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base2.Mantis.SeleniumWebdriverTest.SeleniumTestes
{
    class ListarBugsTestCase
    {
        BugPageObjects bug = new BugPageObjects();

        [Test]
        public void CT012_pesquisarBugPorNumeroInvalido()
        {
            bug.acessarContextoListarBug();

            bug.pesquisaBugPorId("asd");

            SeleniumMetodosSet.validaMensagemEsperada(bug.msgErroCampoObrig, Resources.Mensagens.msgNumeroBugNaoExiste);

        }

        [Test]
        public void CT013_pesquisarBugPorNumeroValido()
        {
            bug.acessarContextoListarBug();

            bug.pesquisaBugPorId("");

            SeleniumMetodosSet.validaMensagemEsperada(bug.tableVerBug, Resources.Mensagens.msgVerBug);

        }
    }
}
