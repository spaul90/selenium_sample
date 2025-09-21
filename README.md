# Selenium WebDriver Sample Project

This project demonstrates automated web testing using Selenium WebDriver with C#.

## Dependencies

The project uses the following NuGet packages:

- **Selenium.WebDriver (v4.35.0)** - Core Selenium functionality for browser automation
- **Selenium.WebDriver.ChromeDriver (v140.0.7339.18500)** - Chrome-specific driver for running tests in Chrome browser
- **NUnit** - Unit testing framework for .NET
- **NUnit3TestAdapter** - Test adapter for running NUnit tests in Visual Studio and dotnet CLI
- **Microsoft.NET.Test.Sdk** - MSTest framework and test host for running tests

## Getting Started

### Prerequisites

- .NET SDK installed on your machine
- Chrome browser installed

### Project Setup

Follow these steps to create and set up the Selenium project:

1. **Create a new console application:**
   ```bash
   dotnet new console -n SeleniumSample
   cd SeleniumSample
   ```

2. **Add Selenium packages:**
   ```bash
   dotnet add package Selenium.WebDriver
   dotnet add package Selenium.WebDriver.ChromeDriver
   ```

3. **Add NUnit testing packages:**
   ```bash
   dotnet add package NUnit
   dotnet add package NUnit3TestAdapter
   dotnet add package Microsoft.NET.Test.Sdk
   ```

### Building and Running

1. **Build the project:**
   ```bash
   dotnet build
   ```

2. **Run the application:**
   ```bash
   dotnet run
   ```

3. **Run tests (if you have test files):**
   ```bash
   dotnet test
   ```

## Project Structure

```
SeleniumSample/
├── Program.cs              # Main application entry point
├── SeleniumSample.csproj   # Project file with package references
├── test.runsettings        # Test configuration settings
├── Pages/                  # Page Object Model classes
├── TestData/               # Test data files
├── Tests/                  # NUnit test classes
├── bin/                    # Compiled binaries
└── obj/                    # Build artifacts
```

## Notes
- The ChromeDriver version (140.0.7339.18500) should match your installed Chrome browser version
- The `chrome-win64/` folder contains the Chrome browser binaries for testing
- Test settings can be configured in `test.runsettings`
