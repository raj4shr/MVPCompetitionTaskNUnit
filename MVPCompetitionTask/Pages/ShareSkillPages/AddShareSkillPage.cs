using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPCompetitionTask;

public class AddShareSkillPage : CommonDriver,IExtentRpt
{
    private readonly CommonSendKeysAndClickElements findElements;
    private ReadOnlyCollection<IWebElement>? elements;
    private string shareSkilltitle;
    private ExtentReports testReport;
    private ExtentTest test;
    private bool rowAdded;
    public AddShareSkillPage()
    {
        shareSkilltitle = "";
        rowAdded = false;
        findElements = new CommonSendKeysAndClickElements();
        testReport = IExtentRpt.testReport;
        test = testReport.CreateTest("Test_AddNewShareSkill" + DateTime.Now.ToString("_hhmmss")).Info("Adding A New Share Skill");

    }

    public void AddNewShareSkill(string shareSkillTitle, string shareSkillDesc, string shareSkillCategory, string shareSkillSubcategory)
    {
        SelectElement option;
        this.shareSkilltitle = shareSkillTitle;
        //Adding a share skill for user profile using my custom class to interact with web elements
        findElements.clickOnElement(nameof(By.XPath), "//a[text()='Share Skill']");
        test.Log(Status.Info, "AddNew share skill button clicked");
        findElements.sendKeysToElement(nameof(By.Name), "title", shareSkillTitle);
        //Log in event report
        test.Log(Status.Info, "Share skill title entered");
        findElements.sendKeysToElement(nameof(By.Name), "description", shareSkillDesc);
        //Log in event report
        test.Log(Status.Info, "Share skill description entered");
        //Selecting the value from drop down listboxes
        option = new SelectElement(findElements.ReturnElement(nameof(By.Name), "categoryId"));
        option.SelectByText(shareSkillCategory);
        findElements.TakeScreenShot();
        option = new SelectElement(findElements.ReturnElement(nameof(By.Name), "subcategoryId"));
        option.SelectByText(shareSkillSubcategory);
        //Log in event report
        test.Log(Status.Info, "Share skill category and category ID entered");
        //Adding other values in the share skill page
        elements = findElements.findElementsByLocator(nameof(By.XPath), "//input[@placeholder='Add new tag']");
        elements[0].SendKeys(shareSkillTitle);
        elements[0].SendKeys(Keys.Enter);
        elements[1].SendKeys(shareSkillSubcategory);
        elements[1].SendKeys(Keys.Enter);
        //Log in event report
        test.Log(Status.Info, "Share skill tags entered");
        elements = findElements.findElementsByLocatorElementExits(nameof(By.Name), "Available");
        elements[3].Click();
        elements = findElements.findElementsByLocatorElementExits(nameof(By.Name), "StartTime");
        elements[3].SendKeys("07:00 am");
        elements[3].SendKeys(Keys.Enter);
        elements = findElements.findElementsByLocatorElementExits(nameof(By.Name), "EndTime");
        elements[3].SendKeys("16:00");
        elements[3].SendKeys(Keys.Enter);
        //Taking screen shot and saving as a file
        findElements.TakeScreenShot();
        test.Log(Status.Info, "Share skill availability,start time and end time entered");
        findElements.clickOnElement(nameof(By.XPath), "//input[@value='Save']");
        test.Log(Status.Info, "Share skill saved button clicked");

        ShareSkillAddedAssertion();
    }

    public void ShareSkillAddedAssertion()
    {
        rowAdded = findElements.CheckShareSkillExists(shareSkilltitle);
        if (rowAdded == true)
        {
            test.Log(Status.Info, "New share skill found");
            test.Log(Status.Pass, "Add Successful");
        }
        else
        {
            test.Log(Status.Fail, "Add UnSuccessful");
        }
        rowAdded.Should().BeTrue();
 
    }
}
