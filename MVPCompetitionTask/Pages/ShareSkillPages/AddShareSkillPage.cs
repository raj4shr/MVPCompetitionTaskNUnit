namespace MVPCompetitionTask;

public class AddShareSkillPage : CommonDriver,IExtentRpt
{
    private readonly CommonSendKeysAndClickElements elementInteractions;
    private ReadOnlyCollection<IWebElement>? tagElements,availableDaysElements,startTimeElements,endTimeElements;
    private string shareSkillTitleStr;
    private ExtentReports testReport;
    private ExtentTest test;
    private bool rowExists;
    private ReadOnlyCollection<IWebElement> rowElements, colElements;
    private SelectElement categoryOptions,subCategoryOptions;

    //Element repository for POM design pattern
    private readonly string startTimeStr = "07:00 am";
    private readonly string endTimeStr = "04:00 pm";
    private readonly By shareSkillBtn = By.XPath("//a[text()='Share Skill']");
    private readonly By shareSkillTitle = By.Name("title");
    private readonly By shareSkillDescription = By.Name("description");
    private readonly By categoryID = By.Name("categoryId");
    private readonly By subcategoryID = By.Name("subcategoryId");
    private readonly By shareSkillTags = By.XPath("//input[@placeholder='Add new tag']");
    private readonly By availableDays = By.Name("Available");
    private readonly By startTime = By.Name("StartTime");
    private readonly By endTime = By.Name("EndTime");
    private readonly By saveBtn = By.XPath("//input[@value='Save']");
    private readonly By manageListingsRows = By.XPath("//tr");
    private readonly By manageListingsColumns = By.TagName("td");
    private readonly By newShareSkillInfoEnteredIncorrectly = By.XPath("//div[text()='Please complete the form correctly']");

    public AddShareSkillPage()
    {
        shareSkillTitleStr = "";
        rowExists = false;
        elementInteractions = new CommonSendKeysAndClickElements();
        testReport = IExtentRpt.testReport;
        test = testReport.CreateTest("Test_AddNewShareSkill" + DateTime.Now.ToString("_hhmmss")).Info("Adding A New Share Skill");

    }

    public void ClickShareSkillBtn()
    {
        //Clicking on share skill button
        elementInteractions.ClickElement(shareSkillBtn);
    }

    public void EnterTitle(string title)
    {
        //Entering the title
        elementInteractions.SendKeysToElement(shareSkillTitle,title);
    }

    public void EnterDescription(string description)
    {
        //Entering the description
        elementInteractions.SendKeysToElement(shareSkillDescription,description);
    }

    public void SelectCategory(string category)
    {
        //Selcting the category
        categoryOptions = new SelectElement(elementInteractions.ReturnElement(categoryID));
        categoryOptions.SelectByText(category);
    }

    public void SelectSubCategory(string subCategory)
    {
        //Selecting the sub category
        subCategoryOptions = new SelectElement(elementInteractions.ReturnElement(subcategoryID));
        subCategoryOptions.SelectByText(subCategory);
    }

    public void EnterShareSkillTags(string tags)
    {
        //Entering tags
        tagElements = elementInteractions.ReturnElementCollectionByElementISVisible(shareSkillTags);
        tagElements[0].SendKeys(tags);
        tagElements[0].SendKeys(Keys.Enter);
    }

    public void EnterShareSkillSkillExchangeTag(string skillExchange)
    {
        //Entering skill exchange tags
        tagElements[1].SendKeys(skillExchange);
        tagElements[1].SendKeys(Keys.Enter);
    }

    public void EnterAvailableDays()
    {
        //Entering available days
        availableDaysElements= elementInteractions.ReturnElementCollectionByPresenceOfAllElements(availableDays);
        availableDaysElements[3].Click();
    }

    public void EnterStartTime()
    {
        //Selcting start time
        endTimeElements = elementInteractions.ReturnElementCollectionByPresenceOfAllElements(startTime);
        endTimeElements[3].SendKeys(startTimeStr);
        endTimeElements[3].SendKeys(Keys.Enter);
    }

    public void EnterEndTime()
    {
        //Selecting end time
        startTimeElements = elementInteractions.ReturnElementCollectionByPresenceOfAllElements(endTime);
        startTimeElements[3].SendKeys(endTimeStr);
        startTimeElements[3].SendKeys(Keys.Enter);
    }

    public void ClickOnSaveBtn()
    {
        //Clicking on save button
        elementInteractions.ClickElement(saveBtn);
    }

    public void GetShareSkillRowColumns(int rowID)
    {
        //Gets all the columns in from a row
        colElements = rowElements[rowID].FindElements(manageListingsColumns);
    }

    public void GetShareSkillRows()
    {
        //Gets all the rows in manage listings
        rowElements = elementInteractions.ReturnElementCollectionByPresenceOfAllElements(manageListingsRows);
    }
    public void AddNewShareSkill(string shareSkillTitle, string shareSkillDesc, string shareSkillCategory, string shareSkillSubcategory)
    {
        this.shareSkillTitleStr = shareSkillTitle;
        ClickShareSkillBtn();
        test.Log(Status.Info, "AddNew share skill button clicked");
        EnterTitle(shareSkillTitle);
        test.Log(Status.Info, "Share skill title entered");
        EnterDescription(shareSkillDesc);
        test.Log(Status.Info, "Share skill description entered");
        SelectCategory(shareSkillCategory);
        SelectSubCategory(shareSkillSubcategory);
        elementInteractions.TakeScreenShot();
        test.Log(Status.Info, "Share skill category and category ID entered");
        EnterShareSkillTags(shareSkillCategory);
        EnterAvailableDays();
        EnterStartTime();
        EnterEndTime();
        EnterShareSkillSkillExchangeTag(shareSkillSubcategory);
        test.Log(Status.Info, "Share skill tags entered");
        //Taking screen shot and saving as a file
        elementInteractions.TakeScreenShot();
        test.Log(Status.Info, "Share skill availability,start time and end time entered");
        ClickOnSaveBtn();
        test.Log(Status.Info, "Share skill saved button clicked");
        ShareSkillAddedAssertion();
    }

    public void ShareSkillAddedAssertion()
    {

        GetShareSkillRows();
        CheckShareSkill();
        if (rowExists == true)
        {
            test.Log(Status.Info, "New share skill found");
            test.Log(Status.Pass, "Add Successful");
        }
        else
        {
            test.Log(Status.Fail, "Add UnSuccessful");
        }
        //Asserts true if row added
        rowExists.Should().BeTrue();
 
    }

    public bool CheckShareSkill()
    {
        for (int i = 0; i < rowElements.Count; i++)
        {
            GetShareSkillRowColumns(i);
            //checking new row added to manage listings rows
            if (colElements.Count > 0)
                if (colElements[2].Text == shareSkillTitleStr)
                {
                    rowExists = true;
                    return rowExists;
                }
        }
        return rowExists;
    }

}
