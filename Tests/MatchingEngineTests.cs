using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumSample.Pages;
using SeleniumSample.TestData;

namespace SeleniumSample.Tests
{
    [TestFixture]
    public class MatchingEngineTests
    {
        private IWebDriver driver = null!;
        private ChromeOptions options = null!;
        private TestConfiguration testConfig = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Load test configuration
            testConfig = TestConfigurationLoader.LoadConfiguration();
            
            // Configure Chrome options for visible testing
            options = new ChromeOptions();

            // Browser visibility options
            // options.AddArgument("--headless"); // Commented out to show browser
            options.AddArgument("--start-maximized"); // Start browser maximized
        }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }


        [Test]
        public void verifyProductSupported()
        {
            Console.WriteLine("Starting Test...");
            HomePageModel homePage = new HomePageModel(driver);
           
            string homePageUrl = testConfig.TestData.HomePage.Url;
            string expectedTitle = testConfig.TestData.HomePage.ExpectedTitle;
            
            Console.WriteLine($"1. Navigating to home page: {homePageUrl}");
            homePage.NavigateToHomePage();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            
            Console.WriteLine($"2. Verifying page title. Expected: '{expectedTitle}', Actual: '{homePage.GetPageTitle()}'");
            Assert.That(homePage.GetPageTitle(), Is.EqualTo(expectedTitle), "Home page should load with correct title");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            Console.WriteLine("3. Navigating to Repertoire Module");
            homePage.NavigateToRepertoireModule();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            
            string expectedModuleTitle = testConfig.TestData.RepertoireManagementModule.ExpectedTitle;

            Console.WriteLine($"4. Verifying module page title. Expected: '{expectedModuleTitle}', Actual: '{homePage.GetPageTitle()}'");
            Assert.That(homePage.GetPageTitle(), Is.EqualTo(expectedModuleTitle), "Repertoire Management Module page should load with correct title");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            RepertoireMgmtModulePageModel rpMgmtModulePage = new RepertoireMgmtModulePageModel(driver);
            Console.WriteLine("5. Scrolling to Additional Features section");
            rpMgmtModulePage.scrollToAdditionalFeatures();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            
            Console.WriteLine("6. Clicking Products Supported");
            rpMgmtModulePage.clickProductsSupported();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            string productSupportTitle = testConfig.TestData.ProductSupportSection.ExpectedHeading;

            Console.WriteLine($"7. Verifying Products Supported heading is visible");
            Assert.That(rpMgmtModulePage.isProductsSupportedHeadingVisible(), Is.True, $"Heading '{productSupportTitle}' should be visible after clicking 'Products Supported'");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            Console.WriteLine("8. Verifying all product items are visible");
            var expectedItems = testConfig.TestData.ProductSupportSection.ExpectedItems;
            Assert.Multiple(() =>
            {
                Assert.That(rpMgmtModulePage.isCueSheetItemVisible(), Is.True, $"{expectedItems[0]} item should be visible");
                Assert.That(rpMgmtModulePage.isRecordingItemVisible(), Is.True, $"{expectedItems[1]} item should be visible");
                Assert.That(rpMgmtModulePage.isBundleItemVisible(), Is.True, $"{expectedItems[2]} item should be visible");
                Assert.That(rpMgmtModulePage.isAdvertisementItemVisible(), Is.True, $"{expectedItems[3]} item should be visible");
            });
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            
            Console.WriteLine("Test completed successfully!");
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}