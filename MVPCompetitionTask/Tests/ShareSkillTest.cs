namespace MVPCompetitionTask;

[TestFixture]
public class ShareSkillTest : CommonDriver
{
    [SetUp]
    public void Setup()
    {
        LoginToPortalPage loginToPortalPage = new();
        loginToPortalPage.LogintoPortal();
    }

    //Data driven test case for happy path
    [TestCase("SpecFlow","BDD in CSharp", "Programming & Tech","QA")]
    [TestCase("NUnit", "Unit Testing", "Programming & Tech", "QA")]
    public void AddNewShareSkill(string title,string description,string category,string subCatefgory)
    {
        AddShareSkillPage addShareSkill = new();
        addShareSkill.AddNewShareSkill(title,description,category,subCatefgory);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
