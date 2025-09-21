using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumSample.Pages
{
    public class RepertoireMgmtModulePageModel
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public RepertoireMgmtModulePageModel(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        private By additionalFeaturesLocator = By.XPath("//h2[@class='vc_custom_heading' and text()='Additional Features']");
        private IWebElement additionalFeaturesElement => driver.FindElement(additionalFeaturesLocator);
        private By productsSupportedLocator = By.XPath("//span[@class='vc_tta-title-text' and text()='Products Supported']");
        private IWebElement productsSupportedElement => driver.FindElement(productsSupportedLocator);
        private By productSupportedHeadingLocator = By.XPath("//h3[contains(@class, 'vc_custom_heading') and contains(text(), 'There are several types of Product Supported')]");
        private IWebElement productSupportedHeadingElement => driver.FindElement(productSupportedHeadingLocator);
        private By cueSheetItemLocator = By.XPath("//span[@data-usefontface='false' and @data-contrast='none' and text()='Cue Sheet / AV Work']");
        private IWebElement cueSheetItemElement => driver.FindElement(cueSheetItemLocator);
        private By recordingItemLocator = By.XPath("//span[@data-usefontface='false' and @data-contrast='none' and text()='Recording']");
        private IWebElement recordingItemElement => driver.FindElement(recordingItemLocator);
        private By bundleItemLocator = By.XPath("//span[@data-usefontface='false' and @data-contrast='none' and text()='Bundle']");
        private IWebElement bundleItemElement => driver.FindElement(bundleItemLocator);
        private By advertisementItemLocator = By.XPath("//span[@data-usefontface='false' and @data-contrast='none' and contains(normalize-space(.), 'Advertisement')]");
        private IWebElement advertisementItemElement => driver.FindElement(advertisementItemLocator);


        public void scrollToAdditionalFeatures()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", additionalFeaturesElement);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public void clickProductsSupported()
        {
            Console.WriteLine("Clicking Products Supported element...");
            productsSupportedElement.Click();
            
            Console.WriteLine("Waiting for page to complete loading...");
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState")?.Equals("complete") == true);
            
            Console.WriteLine("Looking for Products Supported heading...");
            try
            {
                wait.Until(d => productSupportedHeadingElement.Displayed);
                Console.WriteLine("Products Supported heading found!");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout waiting for Products Supported heading. Trying alternative approach...");
                // Alternative approach: Scroll to the heading directly
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", productSupportedHeadingElement);
            }
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            
            Console.WriteLine("Looking for individual product items...");
            try
            {
                wait.Until(d => cueSheetItemElement.Displayed);
                Console.WriteLine("Cue Sheet item found!");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout waiting for Cue Sheet item. Trying alternative approach...");
                // Alternative approach: Scroll to the item directly
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", cueSheetItemElement);
            }
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            try
            {
                wait.Until(d => recordingItemElement.Displayed);
                Console.WriteLine("Recording item found!");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout waiting for Recording item. Trying alternative approach...");
                // Alternative approach: Scroll to the item directly
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", recordingItemElement);
            }
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            try
            {
                wait.Until(d => bundleItemElement.Displayed);
                Console.WriteLine("Bundle item found!");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout waiting for Bundle item. Trying alternative approach...");
                // Alternative approach: Scroll to the item directly
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", bundleItemElement);
            }
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            try
            {
                wait.Until(d => advertisementItemElement.Displayed);
                Console.WriteLine("Advertisement item found!");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout waiting for Advertisement item. Trying alternative approach...");
                // Alternative approach: Scroll to the item directly
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", advertisementItemElement);
            }
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public bool isProductsSupportedHeadingVisible()
        {
            return productSupportedHeadingElement.Displayed;
        }

        public bool isCueSheetItemVisible()
        {
            return cueSheetItemElement.Displayed;
        }

        public bool isRecordingItemVisible()
        {
            return recordingItemElement.Displayed;
        }

        public bool isBundleItemVisible()
        {
            return bundleItemElement.Displayed;
        }

        public bool isAdvertisementItemVisible()
        {
            return advertisementItemElement.Displayed;
        }        

        public string GetPageTitle()
        {
            return driver.Title;
        }
    }
}