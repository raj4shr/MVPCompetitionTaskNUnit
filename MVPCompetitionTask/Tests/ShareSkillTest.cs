global using TechTalk.SpecFlow;
global using FluentAssertions;
global using OpenQA.Selenium;
global using OpenQA.Selenium.Chrome;
global using System.Collections.ObjectModel;
global using OpenQA.Selenium.Support.UI;
global using SeleniumExtras.WaitHelpers;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter.Configuration;


namespace MVPCompetitionTask;

[TestFixture]
public class ShareSkillTest : CommonDriver
{
    //Data driven test case
    [TestCase("Cucumber","BDD in Java", "Programming & Tech","QA")]
    [TestCase("NUnit", "Unit Testing", "Programming & Tech", "QA")]
    public void AddNewShareSkill(string title,string description,string category,string subCatefgory)
    {
        AddShareSkillPage addShareSkill = new();
        addShareSkill.AddNewShareSkill(title,description,category,subCatefgory);
    }

    [SetUp]
    public void Setup()
    {
        LoginToPortalPage loginToPortalPage = new();
        loginToPortalPage.LogintoPortal();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
