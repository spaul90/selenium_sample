using System.Text.Json;

namespace SeleniumSample.TestData
{
    public class TestConfiguration
    {
        public TestDataSection TestData { get; set; } = new();
    }

    public class TestDataSection
    {
        public PageData HomePage { get; set; } = new();
        public PageData RepertoireManagementModule { get; set; } = new();
        public ProductSupportData ProductSupportSection { get; set; } = new();
    }

    public class PageData
    {
        public string Url { get; set; } = string.Empty;
        public string ExpectedTitle { get; set; } = string.Empty;
    }

    public class ProductSupportData
    {
        public string ExpectedHeading { get; set; } = string.Empty;
        public List<string> ExpectedItems { get; set; } = new();
    }

    public static class TestConfigurationLoader
    {
        private static TestConfiguration testConfig;

        public static TestConfiguration LoadConfiguration()
        {
            if (testConfig != null)
                return testConfig;

            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "TestConfiguration.json");
            
            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException($"Test configuration file not found at: {configPath}");
            }

            var jsonContent = File.ReadAllText(configPath);
            testConfig = JsonSerializer.Deserialize<TestConfiguration>(jsonContent);

            return testConfig ?? throw new InvalidOperationException("Failed to load test configuration");
        }
    }
}