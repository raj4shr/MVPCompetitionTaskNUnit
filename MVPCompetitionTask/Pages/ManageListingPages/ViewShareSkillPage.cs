
using AventStack.ExtentReports;

namespace MVPCompetitionTask;

public class ViewShareSkillPage
{
    private readonly CommonSendKeysAndClickElements findElements;
    private ReadOnlyCollection<IWebElement>? rowElements, colElements, elements;
    private string shareSkillTitle;
    private ExtentReports testReport;
    private ExtentTest test;
    private bool pageNavigated;
    public ViewShareSkillPage()
    {
        pageNavigated = false;
        findElements = new CommonSendKeysAndClickElements();
        shareSkillTitle = "";
        testReport = IExtentRpt.testReport;
        test = testReport.CreateTest("Test_ViewShareSkill" + DateTime.Now.ToString("_hhmmss")).Info("Viewing A Share Skill");

    }

    public void ViewShareSkill(string shareSkillTitle)
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
                    //clicking the view button from the 8th column of the row
                    colElements[7].FindElements(By.TagName("button"))[0].Click();
                    break;
                }
            }
        }
        test.Log(Status.Info, "Share skill found and view button clicked");
        ViewSkillPageAssertion();
        findElements.TakeScreenShot();
    }

    public void ViewSkillPageAssertion()
    {
        pageNavigated = findElements.ViewPageNavigated(shareSkillTitle);
        if (pageNavigated == true)
        {
            test.Log(Status.Pass, "Navigation to View Share Skill Page Successful");
        }
        else
        {
            test.Log(Status.Fail, "Navigation to View Share Skill Page UnSuccessful");
        }
    }
}
