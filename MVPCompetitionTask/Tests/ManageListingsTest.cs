using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    [TestCase("NUnit")]
    public void DeleteShareSkill(string title)
    {
        DeleteShareSkillPage deleteShareSkillPage = new();
        deleteShareSkillPage.DeleteShareSkill(title);
    }

    [TestCase("SpecFlow")]
    public void ViewShareSkill(string title)
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
