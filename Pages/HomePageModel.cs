using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumSample.TestData;

namespace SeleniumSample.Pages
{
    public class HomePageModel
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private TestConfiguration testConfig;

        public HomePageModel(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            testConfig = TestConfigurationLoader.LoadConfiguration();
        }

        private By titleImgLocator = By.XPath("//img[@alt='Home Matching Engine']");
        private IWebElement titleImgElement => driver.FindElement(titleImgLocator);
        private By moduleNavBarLocator = By.XPath("//a[@href='https://www.matchingengine.com/#Modules']");
        private IWebElement moduleNavBarElm => driver.FindElement(moduleNavBarLocator);
        private By repertoireModuleSubNavLocator = By.XPath("//a[@href='https://www.matchingengine.com/repertoire-management-module/']");
        private IWebElement repertoireModuleSubNavElm => driver.FindElement(repertoireModuleSubNavLocator);

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public void NavigateToHomePage()
        {
            string homePageUrl = testConfig.TestData.HomePage.Url;
            driver.Navigate().GoToUrl(homePageUrl);
            wait.Until(d => titleImgElement.Displayed);
        } 

        public void NavigateToRepertoireModule()
        {
            moduleNavBarElm.Click();
            wait.Until(d => repertoireModuleSubNavElm.Displayed);
            repertoireModuleSubNavElm.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

    }
}