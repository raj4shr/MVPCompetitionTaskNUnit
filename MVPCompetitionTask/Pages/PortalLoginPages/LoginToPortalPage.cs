using AventStack.ExtentReports;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPCompetitionTask;

public class LoginToPortalPage : CommonDriver,IExtentRpt
{
    private CommonSendKeysAndClickElements findElements;
    private ExtentTest test;
    private ExtentReports testReport;
    private IExcelDataReader reader;
    private FileStream fileStream;
    private DataSet dataSet;
    private DataTable dataTable;
    private string filePath,userName,password;

    
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
            filePath = @"C:\MVPCompetionTask2NUnit\MVPCompetitionTaskNUnit\MVPCompetitionTask\LoginCred.xlsx";
            //Encoding excel file stream
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            //Reading login credentials from excel file to be used in login page
            fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            reader=ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            dataSet=reader.AsDataSet();
            dataTable=dataSet.Tables[0];
            userName = dataTable.Rows[1][0].ToString();
            password = dataTable.Rows[1][1].ToString();

            findElements.TakeScreenShot();
            //Finding and interacting with elements using my custom common methods
            findElements.sendKeysToElement(nameof(By.Name), "email", userName);
            findElements.sendKeysToElement(nameof(By.Name), "password", password);
            test.Log(Status.Info, "Send username and password credentials");
            findElements.clickOnElement(nameof(By.XPath), "//button[text()='Login']");
            test.Log(Status.Info, "Login Button Clicked");
            test.Log(Status.Pass, "Test Passed");

            //Closing file streams
            fileStream.Close();
            reader.Close();
        }
        catch
        {
            test.Log(Status.Fail, "Test Failed");
            throw;
        }
    }
}
