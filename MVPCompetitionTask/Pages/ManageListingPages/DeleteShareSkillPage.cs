namespace MVPCompetitionTask;

public class DeleteShareSkillPage
{
    //Collections to store element collection
    private ReadOnlyCollection<IWebElement>? rowElements, colElements, elements;

    private string shareSkillTitle;
    private ExtentReports testReport;
    private ExtentTest test;
    private bool rowExists;
    

    //Element repository for POM design pattern
    private readonly By manageListings = By.XPath("//a[text()='Manage Listings']");
    private readonly By manageListingsRows = By.XPath("//tr");
    private readonly By manageListingsColumns = By.TagName("td");
    private readonly By manageListingsPageBtns = By.TagName("button");

    private readonly CommonSendKeysAndClickElements elementInteractions;

    public DeleteShareSkillPage()
    {
        elementInteractions = new CommonSendKeysAndClickElements();
        rowExists = false;
        shareSkillTitle = "";
        testReport = IExtentRpt.testReport;
        test = testReport.CreateTest("Test_DeleteShareSkill" + DateTime.Now.ToString("_hhmmss")).Info("Deleting A Share Skill");
    }

    public void ClickOnManageListings()
    {
        //Click on manage listings button
        elementInteractions.ClickElement(manageListings);
    }

    public void GetShareSkillRows()
    {
        //Getting all share skill rows
        rowElements = elementInteractions.ReturnElementCollectionByPresenceOfAllElements(manageListingsRows);
    }

    public void GetShareSkillRowColumns(int rowID)
    {
        //Getting all the column elements in each row in manage listings
        colElements = rowElements[rowID].FindElements(manageListingsColumns);
    }

    public void ClickOnDeleteShareSkillBtn()
    {
        //clicking the delete button from the 8th column of the row
        colElements[7].FindElements(manageListingsPageBtns)[2].Click();
    }

    public void ConfirmDeleteInAlertWindow()
    {
        //Confirming delete
        elements = elementInteractions.ReturnElementCollectionByElementISVisible(manageListingsPageBtns);
        elements[elements.Count - 1].Click();
    }

    public void DeleteShareSkill(string shareSkillTitle)
    {
        this.shareSkillTitle = shareSkillTitle;
        ClickOnManageListings();
        GetShareSkillRows();
        //Checking if a valid share skill is entered for delete operation
        if (CheckShareSkill() == false)
            rowExists.Should().BeTrue("Share Skill Not Found....Enter a valid share skill to delete");
        test.Log(Status.Info, "Share skill deleted as per scenario outline value");
        elementInteractions.TakeScreenShot();
        //Assertion for successful delete
        DeleteShareSkillAssertion();
    }

    public bool CheckShareSkill()
    {
        for (int i = 0; i < rowElements.Count; i++)
        {
            GetShareSkillRowColumns(i);
            if (colElements.Count > 0)
                if (colElements[2].Text == shareSkillTitle)
                {
                    ClickOnDeleteShareSkillBtn();
                    ConfirmDeleteInAlertWindow();
                    rowExists = true;
                    return rowExists;
                }
        }
        rowExists = false;
        return rowExists;
    }

    public void DeleteShareSkillAssertion()
    {
        ClickOnManageListings();
        GetShareSkillRows();
        CheckShareSkill();
        if (rowExists == true)
        {
            test.Log(Status.Fail, "Delete UnSuccessful");
        }
        else
        {
            test.Log(Status.Info, "Share skill record not found");
            test.Log(Status.Pass, "Delete Successful");
        }
        //Asserts true if the row is not found
        rowExists.Should().BeFalse();
    }
}
