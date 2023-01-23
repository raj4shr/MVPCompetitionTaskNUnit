using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPCompetitionTask;

public class CommonSendKeysAndClickElements : CommonDriver
{
    private ReadOnlyCollection<IWebElement>? elements;
    private IWebElement? element;
    WebDriverWait wait;
    string path;


    public CommonSendKeysAndClickElements()
    {
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        path = "";
    }

    public void sendKeysToElement(string elementLocator, string locatorValue, string elementValue)
    {
        if (elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
            element = driver.FindElement(By.Id(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locatorValue)));
            element = driver.FindElement(By.Name(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));
            element = driver.FindElement(By.ClassName(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            element = driver.FindElement(By.XPath(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locatorValue)));
            element = driver.FindElement(By.TagName(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
            element = driver.FindElement(By.CssSelector(locatorValue));
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locatorValue)));
            element = driver.FindElement(By.LinkText(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locatorValue)));
            element = driver.FindElement(By.PartialLinkText(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
    }

    public void clickOnElement(string elementLocator, string locatorValue)
    {
        if (elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            element = driver.FindElement(By.Id(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(locatorValue)));
            element = driver.FindElement(By.Name(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(locatorValue)));
            element = driver.FindElement(By.ClassName(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            element = driver.FindElement(By.XPath(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.TagName(locatorValue)));
            element = driver.FindElement(By.TagName(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
            element = driver.FindElement(By.CssSelector(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(locatorValue)));
            element = driver.FindElement(By.LinkText(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(locatorValue)));
            element = driver.FindElement(By.PartialLinkText(locatorValue));
            element.Click();
        }
    }

    public string getElementText(string elementLocator, string locatorValue)
    {
        string elementText = "";
        if (elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.Id(locatorValue)));
            element = driver.FindElement(By.Id(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.Name(locatorValue)));
            element = driver.FindElement(By.Name(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.ClassName(locatorValue)));
            element = driver.FindElement(By.ClassName(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath(locatorValue)));
            element = driver.FindElement(By.XPath(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.TagName(locatorValue)));
            element = driver.FindElement(By.TagName(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.CssSelector(locatorValue)));
            element = driver.FindElement(By.CssSelector(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.LinkText(locatorValue)));
            element = driver.FindElement(By.LinkText(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.PartialLinkText(locatorValue)));
            element = driver.FindElement(By.PartialLinkText(locatorValue));
            elementText = element.Text;
        }
        return elementText;
    }

    public ReadOnlyCollection<IWebElement> findElementsByLocator(string elementLocator, string locatorValue)
    {
        if (elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
            elements = driver.FindElements(By.Id(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locatorValue)));
            elements = driver.FindElements(By.Name(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));
            elements = driver.FindElements(By.Id(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            elements = driver.FindElements(By.XPath(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locatorValue)));
            elements = driver.FindElements(By.TagName(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
            elements = driver.FindElements(By.CssSelector(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locatorValue)));
            elements = driver.FindElements(By.LinkText(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locatorValue)));
            elements = driver.FindElements(By.PartialLinkText(locatorValue));
        }
        return elements;
    }

    public ReadOnlyCollection<IWebElement> findElementsByLocatorClickable(string elementLocator, string locatorValue)
    {
        if (elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            elements = driver.FindElements(By.Id(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(locatorValue)));
            elements = driver.FindElements(By.Name(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(locatorValue)));
            elements = driver.FindElements(By.Id(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            elements = driver.FindElements(By.XPath(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.TagName(locatorValue)));
            elements = driver.FindElements(By.TagName(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
            elements = driver.FindElements(By.CssSelector(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(locatorValue)));
            elements = driver.FindElements(By.LinkText(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(locatorValue)));
            elements = driver.FindElements(By.PartialLinkText(locatorValue));
        }
        return elements;
    }

    public ReadOnlyCollection<IWebElement> findElementsByLocatorElementExits(string elementLocator, string locatorValue)
    {
        if (elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id(locatorValue)));
            elements = driver.FindElements(By.Id(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.Name(locatorValue)));
            elements = driver.FindElements(By.Name(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.ClassName(locatorValue)));
            elements = driver.FindElements(By.Id(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath(locatorValue)));
            elements = driver.FindElements(By.XPath(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.TagName(locatorValue)));
            elements = driver.FindElements(By.TagName(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(locatorValue)));
            elements = driver.FindElements(By.CssSelector(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.LinkText(locatorValue)));
            elements = driver.FindElements(By.LinkText(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.PartialLinkText(locatorValue)));
            elements = driver.FindElements(By.PartialLinkText(locatorValue));
        }
        return elements;
    }

    //checking if a share skill exists to be used for Add and Delete assertion
    public bool CheckShareSkillExists(string shareSkillTitle)
    {
        bool shareSkillExists = false;
        ReadOnlyCollection<IWebElement> rowElements, colElements;

        //Reading all the share skill rows and checking if a particular share skill exists( as per the data from scenario outline)
        driver.FindElement(By.XPath("//a[text()='Manage Listings']")).Click();
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr")));
        rowElements = driver.FindElements(By.XPath("//tr"));
        for (int i = 0; i < rowElements.Count; i++)
        {
            colElements = rowElements[i].FindElements(By.TagName("td"));
            if (colElements.Count > 0)
            {
                if (colElements[2].Text == shareSkillTitle)
                {
                    shareSkillExists = true;
                }
            }
        }
        return shareSkillExists;
    }

    //Assertion to confirm the user navigated to the view skill page
    public bool ViewPageNavigated(string shareSkillTitle)
    {
        bool viewPageNavigated = false;
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Chat']")));
        if (driver.FindElements(By.XPath("//a[text()='Chat']")).Count > 0)
        {
            viewPageNavigated = true;
        }
        return viewPageNavigated;
    }

    public IWebElement ReturnElement(string elementLocator, string locatorValue)
    {
        if (elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
            element = driver.FindElement(By.Id(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locatorValue)));
            element = driver.FindElement(By.Name(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));
            element = driver.FindElement(By.ClassName(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            element = driver.FindElement(By.XPath(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locatorValue)));
            element = driver.FindElement(By.TagName(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
            element = driver.FindElement(By.CssSelector(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locatorValue)));
            element = driver.FindElement(By.LinkText(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locatorValue)));
            element = driver.FindElement(By.PartialLinkText(locatorValue));
        }
        return element;
    }

    //Method to take screenshot
    public void TakeScreenShot()
    {
        path = @"C:\ExtentReports\ScreenShots\" + DateTime.Now.ToString("_MMddyyyy_hhmmsstt") + @".png";
        ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Png);
    }
}
