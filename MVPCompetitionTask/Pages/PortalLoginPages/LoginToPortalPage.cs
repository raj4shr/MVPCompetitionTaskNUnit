using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPCompetitionTask;

public class LoginToPortalPage : CommonDriver,IExtentRpt
{
    private CommonSendKeysAndClickElements findElements;
    private ExtentTest test;
    private ExtentReports testReport;
    
    public LoginToPortalPage()
    {
        driver=new ChromeDriver();
        findElements = new CommonSendKeysAndClickElements();
        //Creating a test report
        testReport = IExtentRpt.testReport;
        test = IExtentRpt.testReport.CreateTest("Test_LoginToPortal" + DateTime.Now.ToString("_hhmmss")).Info("Login Test");
    }
    public void LogintoPortal()
    {
        //Opening up MVP portal running on docker image
        driver.Navigate().GoToUrl("http://localhost:5000/");
        test.Log(Status.Info, "Navigate to Url");
        driver.Manage().Window.Maximize();
        //Clicking on sign in button
        findElements.clickOnElement(nameof(By.ClassName), "item");
        test.Log(Status.Info, "Click on Sign In");
        //Signing in method with valid credentials
        EnterLoginDetails();
    }

    public void EnterLoginDetails()
    {
        try
        {
            findElements.TakeScreenShot();
            //Finding and interacting with elements using my custom common methods
            findElements.sendKeysToElement(nameof(By.Name), "email", "raj4shr@gmail.com");
            findElements.sendKeysToElement(nameof(By.Name), "password", "IndustryConnect2023");
            test.Log(Status.Info, "Send username and password credentials");
            findElements.clickOnElement(nameof(By.XPath), "//button[text()='Login']");
            test.Log(Status.Info, "Login Button Clicked");
            test.Log(Status.Pass, "Test Passed");
        }
        catch
        {
            test.Log(Status.Fail, "Test Failed");
            throw;
        }
    }
}
