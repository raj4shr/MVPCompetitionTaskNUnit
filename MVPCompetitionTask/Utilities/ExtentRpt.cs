using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using System.IO;

namespace MVPCompetitionTask;

public interface IExtentRpt
{
    public static ExtentReports testReport;

    public static void InitReports()
    {
        //Initialising extent reports in OneTimeSetup to be used for all the tests
        testReport = new ExtentReports();   
        string path = @"C:\ExtentReports\" + DateTime.Now.ToString("_MMddyyyy_hhmmss") + @"\index.html";
        var htmlReporter = new ExtentHtmlReporter(path);
        htmlReporter.Config.Theme = Theme.Standard;
        testReport.AttachReporter(htmlReporter);
    }

    public static void flushReport()
    {
        //Flushing the extent report after all the tests have been completed
        testReport.Flush();
    }





}
