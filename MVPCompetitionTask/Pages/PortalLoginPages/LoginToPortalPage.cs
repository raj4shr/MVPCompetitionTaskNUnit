namespace MVPCompetitionTask;

public class LoginToPortalPage : CommonDriver,IExtentRpt
{
    private CommonSendKeysAndClickElements elementInteractions;
    CommonDriver commonDriver = new CommonDriver();
    private ExtentTest test;
    private ExtentReports testReport;
    private IExcelDataReader reader;
    private FileStream fileStream;
    private DataSet dataSet;
    private DataTable dataTable;
    private string filePath,userName,password;

    //Element repository for POM design pattern
    private readonly By signInBtn = By.ClassName("item");
    private readonly By userNameInputBox = By.Name("email");
    private readonly By passwordInputBox=By.Name("password");
    private readonly By loginBtn = By.XPath("//button[text()='Login']");
    private readonly By signOutBtn = By.XPath("//button[text()='Sign Out']");
    
    public LoginToPortalPage()
    {
        commonDriver.InitDriver();
        elementInteractions = new CommonSendKeysAndClickElements();
        //Creating a test report
        this.testReport = IExtentRpt.testReport;
        test = testReport.CreateTest("Test_LoginToPortal" + DateTime.Now.ToString("_hhmmss")).Info("Login Test");
    }

    public void LogintoPortal()
    {
        test.Log(Status.Info, "Navigate to Url");
        //Clicking on sign in button
        elementInteractions.ClickElement(signInBtn);
        test.Log(Status.Info, "Click on Sign In");
        //Signing in method with valid credentials
        EnterLoginDetails();
    }

    public void EnterUserName()
    {
        elementInteractions.SendKeysToElement(userNameInputBox, userName);
    }

    public void EnterPassword()
    {
        elementInteractions.SendKeysToElement(passwordInputBox, password);
    }

    public void ClickOnLoginButoon()
    {
        elementInteractions.ClickElement(loginBtn);
    }

    public void CloseFileStream()
    {
        //Closing file streams
        fileStream.Close();
        reader.Close();
    }

    public void ExcelReadDataForLoginCredentials()
    {
        //Path to the excel file with login credentials
        filePath = @"C:\MVPCompetionTask2NUnit\MVPCompetitionTaskNUnit\MVPCompetitionTask\LoginCred.xlsx";
        //Encoding excel file stream
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        //Reading login credentials from excel file to be used in login page
        fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
        //Getting the excel file as a dataset
        dataSet = reader.AsDataSet();
        //Since only 1 sheet is in the excel file, index 0 is taken
        dataTable = dataSet.Tables[0];
        userName = dataTable.Rows[1][0].ToString();
        password = dataTable.Rows[1][1].ToString();
    }

    public void EnterLoginDetails()
    {
        //Getting login credentials from excel file using excel data reader
        ExcelReadDataForLoginCredentials();
        elementInteractions.TakeScreenShot();
        //Sending user name and password
        EnterUserName();
        EnterPassword();
        test.Log(Status.Info, "Send username and password credentials");
        //Click on login button
        ClickOnLoginButoon();
        test.Log(Status.Info, "Login Button Clicked");
        //Login successful assertion
        LoginSuccessful();
        CloseFileStream();
    }

    public void LoginSuccessful()
    {
        //If sighout button is visible then login sucessful
        if(elementInteractions.ElementIsDisplayed(signOutBtn))
            test.Log(Status.Pass, "Test Passed");
        else
            test.Log(Status.Fail, "Test Failed");
        //Login successful assertion 
        elementInteractions.ElementIsDisplayed(signOutBtn).Should().BeTrue();
    }
}
