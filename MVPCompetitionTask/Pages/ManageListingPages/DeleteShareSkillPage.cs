using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPCompetitionTask;

public class DeleteShareSkillPage
{
    private readonly CommonSendKeysAndClickElements findElements;
    private ReadOnlyCollection<IWebElement>? rowElements, colElements, elements;
    private string shareSkillTitle;
    private ExtentReports testReport;
    private ExtentTest test;
    private bool rowExists;
    public DeleteShareSkillPage()
    {
        rowExists = false;
        shareSkillTitle = "";
        findElements = new CommonSendKeysAndClickElements();
        testReport = IExtentRpt.testReport;
        test = testReport.CreateTest("Test_DeleteShareSkill" + DateTime.Now.ToString("_hhmmss")).Info("Deleting A Share Skill");

    }

    public void DeleteShareSkill(string shareSkillTitle)
    {
        this.shareSkillTitle = shareSkillTitle;
        findElements.clickOnElement(nameof(By.XPath), "//a[text()='Manage Listings']");
        //Getting all the row elements for manage listings
        rowElements = findElements.findElementsByLocator(nameof(By.XPath), "//tr");
        for (int i = 0; i < rowElements.Count; i++)
        {
            //Getting all the column elements in each row in manage listings
            colElements = rowElements[i].FindElements(By.TagName("td"));
            if (colElements.Count > 0)
            {
                if (colElements[2].Text == shareSkillTitle)
                {
                    //clicking the delete button from the 8th column of the row
                    colElements[7].FindElements(By.TagName("button"))[2].Click();
                    //Confirming delete
                    elements = findElements.findElementsByLocator(nameof(By.XPath), "//button");
                    elements[elements.Count - 1].Click();
                    break;
                }
            }
        }
        test.Log(Status.Info, "Share skill deleted as per scenario outline value");
        findElements.TakeScreenShot();
        DeleteShareSkillAssertion();
    }

    public void DeleteShareSkillAssertion()
    {
        rowExists = findElements.CheckShareSkillExists(shareSkillTitle);
        if (rowExists == true)
        {
            test.Log(Status.Fail, "Delete UnSuccessful");
        }
        else
        {
            test.Log(Status.Info, "Share skill record not found");
            test.Log(Status.Pass, "Delete Successful");
        }
        rowExists.Should().BeFalse();
    }
}
