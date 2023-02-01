namespace MVPCompetitionTask;

[TestFixture]
public class ManageListingsTest : CommonDriver
{
    [SetUp]
    public void Setup()
    {
        LoginToPortalPage loginToPortalPage = new();
        loginToPortalPage.LogintoPortal();
    }
    //Delete a share skill if the share skill exists
    [TestCase("NUnit")]
    public void DeleteShareSkill(string title)
    {
        DeleteShareSkillPage deleteShareSkillPage = new();
        deleteShareSkillPage.DeleteShareSkill(title);
    }

    //Trying to delete a share skill which doesn't exist
    [TestCase("Non Existant")]
    public void DeleteShareSkillNotExist(string title)
    {
        DeleteShareSkillPage deleteShareSkillPage = new();
        deleteShareSkillPage.DeleteShareSkill(title);
    }


    //View an existing share skill
    [TestCase("SpecFlow")]
    public void ViewShareSkill(string title)
    {
        ViewShareSkillPage viewShareSkillPage = new();
        viewShareSkillPage.ViewShareSkill(title);
    }

    //Trying to view a share skill which doesn't exist
    [TestCase("Share skill doesn't exist")]
    public void ViewShareSkillNotExist(string title)
    {
        ViewShareSkillPage viewShareSkillPage = new();
        viewShareSkillPage.ViewShareSkill(title);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
