using System;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace testProjectLogin;

[TestClass]
public class UnitTest1
{
    static IWebDriver driver = null;

    [TestMethod]
    public void test1()
    {
        Console.WriteLine("TestExcution Has Started");
        driver.Navigate().GoToUrl("https://www.tutorialspoint.com/selenium/selenium_automation_practice.htm");
        Console.WriteLine("Url is opened");
        driver.Manage().Window.Size = new Size(1920, 1080);
        String txt_title = driver.Title.ToString();
        bool titleIsEqual = txt_title.Equals("Selenium - Automation Practice Form");
        Assert.IsTrue(titleIsEqual);
        Console.WriteLine("Test has completed. Website is up.");
    }

    [TestMethod]
    public void test2()
    {
        Console.WriteLine("Login test started");

        var firstName = sendKeys("#mainContent > div:nth-child(7) > div > form > table > tbody > tr:nth-child(1) > td:nth-child(2) > input[type=text]",
            "viradeth");
        var lastname = sendKeys("#mainContent > div:nth-child(7) > div > form > table > tbody > tr:nth-child(2) > td:nth-child(2) > input[type=text]",
            "xayananh");





        //select a gender
        clickElement("#mainContent > div:nth-child(7) > div > form > table > tbody > tr:nth-child(3) > td:nth-child(2) > input[type=radio]:nth-child(1)");

        //select year of experiencee
        clickElement("#mainContent > div:nth-child(7) > div > form > table > tbody > tr:nth-child(4) > td:nth-child(2) > span:nth-child(1) > input[type=radio]");

        //enter in data in Date textbox
        sendKeys("#mainContent > div:nth-child(7) > div > form > table > tbody > tr:nth-child(5) > td:nth-child(2) > input[type=text]", "helloworld");

        //select profession
        clickElement("#mainContent > div:nth-child(7) > div > form > table > tbody > tr:nth-child(6) > td:nth-child(2) > span:nth-child(1) > input[type=checkbox]");

        //send keys to Choose File option
        string desktopPath = "/Users/viradethxay-ananh/Desktop/screenshot.png";
        driver.FindElement(By.Name("photo")).SendKeys(desktopPath);

        // choose flavor of selenium
        clickElement("#mainContent > div:nth-child(7) > div > form > table > tbody > tr:nth-child(8) > td:nth-child(2) > span:nth-child(1) > input[type=checkbox]");



        //create an instance of action class and pass in the driver
        Actions actions = new Actions(driver);

        //scroll down thee page using the action class

        actions.SendKeys(Keys.PageDown).Perform();

        //clicking on the submit button 
        clickElement("#mainContent > div:nth-child(7) > div > form > table > tbody > tr:nth-child(11) > td:nth-child(2) > button");


        Console.WriteLine("Test is finally finished");
    }

    public static IWebElement clickElement(string selector)
    {
        By elementSelector = By.CssSelector(selector);
        var element = driver.FindElement(elementSelector);
        if (element != null)
        {

            element.Click();
            Console.WriteLine("Element was clicked");
            return element;
        }
        else
        {
            Console.WriteLine("element not found");
            throw new InvalidOperationException("element is not exist");
        }
    }

    public static IWebElement sendKeys(string selector, string keys)
    {
        By elementSelector = By.CssSelector(selector);
        var element = driver.FindElement(elementSelector);
        if (element != null)
        {
            Console.WriteLine("Element exist");
            element.Clear();

            element.SendKeys(keys);
            return element;
        }
        else
        {
            Console.WriteLine("Element not found");
            throw new InvalidOperationException("element is not exist");
        }
    }

    // Means initialize once; Entry point where test is ran, only happens once
    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("no-sandbox");

        driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
        driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));


        if (driver != null)
        {
            Console.WriteLine("WebDriver is not null");

        }
        else
        {
            Console.WriteLine("WebDriver is not initialize");
            throw new InvalidOperationException("webDriver is not initialize");
        }
        Console.WriteLine("driverInitialize");
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        driver.Quit();
        driver.Close();
        Console.WriteLine("classCleanUp");
    }
}

