namespace MVPCompetitionTask;

public class ViewShareSkillPage
{
    private readonly CommonSendKeysAndClickElements elementInteractions;
    private ReadOnlyCollection<IWebElement>? rowElements, colElements;
    private ExtentReports testReport;
    private ExtentTest test;
    private bool shareSkillFound;

    //Element repository for POM design pattern
    private readonly By manageListingsBtn = By.XPath("//a[text()='Manage Listings']");
    private readonly By manageListingRows = By.XPath("//tr");
    private readonly By manageListingsColumns = By.TagName("td");
    private readonly By manageListingsViewBtn = By.TagName("button");
    private readonly By pageNavigated = By.XPath("//a[text()='Chat']");

    public ViewShareSkillPage()
    {
        shareSkillFound = false;
        elementInteractions = new CommonSendKeysAndClickElements();
        testReport = IExtentRpt.testReport;
        test = testReport.CreateTest("Test_ViewShareSkill" + DateTime.Now.ToString("_hhmmss")).Info("Viewing A Share Skill");
    }

    public void ClickOnManageListingsBtn()
    {
        //Clicking on manage listings button
        elementInteractions.ClickElement(manageListingsBtn);
    }

    public void FindManageListinRows()
    {
        //Getting all the rows in manage listings
        rowElements = elementInteractions.ReturnElementCollectionByPresenceOfAllElements(manageListingRows);
    }

    public void FindColumnsInManageListingRow(int rowIndex)
    {
        //Getting all the columns in a manage listings row
        colElements = rowElements[rowIndex].FindElements(manageListingsColumns);
    }

    public void ClickManageListingViewBtn()
    {
        colElements[7].FindElements(manageListingsViewBtn)[0].Click();
    }

    public void ViewShareSkill(string shareSkillTitle)
    {
        ClickOnManageListingsBtn();
        FindManageListinRows();
        for (int i = 0; i < rowElements.Count; i++)
        {
            FindColumnsInManageListingRow(i);
            //Getting all the column elements in each row in manage listings
            if (colElements.Count > 0)
                if (colElements[2].Text == shareSkillTitle)
                {
                    //clicking the view button from the 8th column of the row
                    ClickManageListingViewBtn();
                    shareSkillFound = true;
                    break;
                }
        }
        //Check if share skill exists 
        CheckIfShareSkillFound();
    }

    public void CheckIfShareSkillFound()
    {
        if(shareSkillFound)
        {
            test.Log(Status.Info, "Share skill found and view button clicked");
            ViewSkillPageAssertion();
            elementInteractions.TakeScreenShot();
        }
        else
        {
            //Asserts false if share skill not found
            shareSkillFound.Should().BeTrue("Share skill not found...Enter a valid share skill to view");
        }
    }

    public void ViewSkillPageAssertion()
    {
        if(elementInteractions.ElementIsDisplayed(pageNavigated))
            test.Log(Status.Pass, "Navigation to View Share Skill Page Successful");
        else
            test.Log(Status.Fail, "Navigation to View Share Skill Page UnSuccessful");

        //Asserts true if page is navigated(By looking for a chat button)
        elementInteractions.ElementIsDisplayed(pageNavigated).Should().BeTrue();
    }
}
