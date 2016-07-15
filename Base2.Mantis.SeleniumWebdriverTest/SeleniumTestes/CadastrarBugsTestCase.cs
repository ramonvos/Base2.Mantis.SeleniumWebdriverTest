using Base2.Mantis.SeleniumWebdriverTest.SeleniumPageObjects;
using NUnit.Framework;

namespace Base2.Mantis.SeleniumWebdriverTest.SeleniumTestes
{

    class CadastrarBugsTestCase
    {
        BugPageObjects bug = new BugPageObjects();
        
     
        [Test]
        public void CT006_cadastrarNovoBugFalhaCampoSumarioNaoPreenchido() {

            bug.acessarContexto();

            ExcelUtil.PopulateInCollection(SeleniumUteis.getPathDataDriven() + "\\bugReportData.xlsx");
            bug.preencherNovoBug(ExcelUtil.ReadData(1, "Category"),
                ExcelUtil.ReadData(1, "Reproducibility"),
                ExcelUtil.ReadData(1, "Severity"),
                ExcelUtil.ReadData(1, "Priority"),
                ExcelUtil.ReadData(1, "Profile"),
                ExcelUtil.ReadData(1, "Platform"),
                ExcelUtil.ReadData(1, "OS"),
                ExcelUtil.ReadData(1, "Version"),
                ExcelUtil.ReadData(1, "Assign"),
                "", // Sumário não preenchido
                ExcelUtil.ReadData(1, "Description"),
                ExcelUtil.ReadData(1, "Steps"),
                ExcelUtil.ReadData(1, "Additional"));

            SeleniumMetodosSet.validaMensagemEsperada(bug.msgErroCampoObrig, Resources.Mensagens.msgBugCampoSumarioObrig);    

        }
        [Test]
        public void CT007_cadastrarNovoBugFalhaCampoDescricaoNaoPreenchido()
        {
            //ExcelUtil.PopulateInCollection(SeleniumUteis.getPathDataDriven() + "\\bugReportData.xlsx");
            bug.acessarContexto(); 

            bug.preencherNovoBug(ExcelUtil.ReadData(1, "Category"),
                ExcelUtil.ReadData(1, "Reproducibility"),
                ExcelUtil.ReadData(1, "Severity"),
                ExcelUtil.ReadData(1, "Priority"),
                ExcelUtil.ReadData(1, "Profile"),
                ExcelUtil.ReadData(1, "Platform"),
                ExcelUtil.ReadData(1, "OS"),
                ExcelUtil.ReadData(1, "Version"),
                ExcelUtil.ReadData(1, "Assign"),
                ExcelUtil.ReadData(1, "Summary"),
                "",// Descrição não preenchida
                ExcelUtil.ReadData(1, "Steps"),
                ExcelUtil.ReadData(1, "Additional"));
                      

            SeleniumMetodosSet.validaMensagemEsperada(bug.msgErroCampoObrig, Resources.Mensagens.msgBugCampoDescricaoObrig);

        }
        [Test]
        public void CT008_cadastrarNovoBugSucesso()
        {
            //ExcelUtil.PopulateInCollection(SeleniumUteis.getPathDataDriven() + "\\bugReportData.xlsx");
            bug.acessarContexto();

            bug.preencherNovoBug(ExcelUtil.ReadData( 1 , "Category"),
                ExcelUtil.ReadData(1, "Reproducibility"),
                ExcelUtil.ReadData(1, "Severity"),
                ExcelUtil.ReadData(1, "Priority"),
                ExcelUtil.ReadData(1, "Profile"),
                ExcelUtil.ReadData(1, "Platform"),
                ExcelUtil.ReadData(1, "OS"),
                ExcelUtil.ReadData(1, "Version"),
                ExcelUtil.ReadData(1, "Assign"),
                ExcelUtil.ReadData(1, "Summary")+ SeleniumUteis.GetCurrentDateTime(),
                ExcelUtil.ReadData(1, "Description"),
                ExcelUtil.ReadData(1, "Steps"),
                ExcelUtil.ReadData(1, "Additional"));

            SeleniumMetodosSet.validaMensagemEsperada(bug.msgSucesso, Resources.Mensagens.msgBugSucesso);
        }

    }
}
