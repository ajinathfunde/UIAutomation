Automation Test Framework Documentation
---
1. Project Overview
This project is a robust, maintainable, and scalable UI automation framework for web applications using C#, Selenium WebDriver, and NUnit. It supports parallel execution, advanced reporting, and screenshot capture for each test case. The framework is designed for easy extension and maintainability, following best practices such as the Page Object Model and data-driven testing.
---
2. Technology Stack
  •	Language: C# 12.0
  •	Framework: .NET 8
  •	Test Framework: NUnit
  •	Automation: Selenium WebDriver
  •	Reporting: ExtentReports
  •	IDE: Visual Studio 2022
  •	Source Control: GitLab
---
3. Development Approach & Design Patterns
  •	Page Object Model (POM):
       All web page interactions are encapsulated in page classes (e.g., LoginPage, LogoutPage) to promote reusability and maintainability.
  •	Data-Driven Testing:
      Test data is separated from test logic using data providers (e.g., LoginMsgDataProvider).
  •	Thread-Safe Utilities:
      Services like reporting and screenshot capture use ThreadLocal<T> to ensure thread safety during parallel execution.
  •	Base Test Class:
      Common setup, teardown, and shared utilities are implemented in a BaseTest class.
---
4. Libraries Used
  | Library                        | Purpose                                                      |
  |---------------------------------|--------------------------------------------------------------| | Selenium.WebDriver              | Browser automation
  | | Selenium.Support                | Additional Selenium helpers                                  | | NUnit                           | Test framework and parallel execution
  | | AventStack.ExtentReports        | Rich HTML reporting                                          | | coverlet.collector              | Code coverage collection
  | | Microsoft.NET.Test.Sdk          | Test discovery and execution                                 | | NUnit3TestAdapter, NUnit.Analyzers
  | NUnit integration with Visual Studio and analyzers        |
---

5. Project Structure
  APPUITests/
    ├── TestCases/           # Test classes (e.g., LoginTC.cs, LoginTC2.cs)
    ├── TestData/            # Data providers for data-driven tests
    ├── WebPages/            # Page Object Model classes
    ├── Helpers/             # Utility/helper classes
    ├── ScreenshotService/   # ScreenshotService.cs (thread-safe screenshots)
    ├── Reports/             # ExtentManager.cs (reporting utilities)
    ├── Models/Config/       # Configuration models and readers
    └── AutomationConfig.json# Test configuration file
  AutoFrameworkCoreLib/
    └── ...                  # Core framework utilities

6. How to Run Test Cases (with Browsers)
    1.	Configure Browser and URL:
      •	  Edit AutomationConfig.json to set the browser (Chrome, Firefox, Edge) and appURL.
    2.	Build the Solution:
      •	Open in Visual Studio 2022 and build the solution.
    3.	Run Tests:
      •	From Visual Studio Test Explorer, select and run tests.
      •	Or, use the command line:
         dotnet test       
      •	To specify a browser at runtime, update the config or pass as an environment variable if supported.
    4.	Parallel Execution:
      •	Tests are decorated with [Parallelizable(ParallelScope.Fixtures)] for parallel execution by default.
---

7. Execution Flow
   
  1.	Setup:
    •	[SetUp] method initializes the browser, reporting, and screenshot folder for each test.
  
  2.	Test Execution:
    •	Test navigates to the application URL.
    •	Performs actions using Page Object Model classes.
    •	Asserts expected outcomes.
    •	Captures screenshots at key steps.
    •	Logs steps and results to ExtentReports.
  
  3.	Teardown:
    •	  [TearDown] method quits the browser and logs closure.
  
  4.	Reporting:
    •	ExtentReports logs are updated in real-time.
    •	Screenshots are attached to the report and saved in a per-test folder.
---
8. Parallel Execution Management
  •	NUnit Parallelization:
  [Parallelizable(ParallelScope.Fixtures)] enables parallel execution at the test class level.
  •	Thread Safety:
  •	ExtentManager and ScreenshotService use ThreadLocal<T> to ensure each test thread has its own reporting and screenshot context.
  •	WebDriver Management:
  •	Each test gets its own IWebDriver instance via WebDriverFactory.
---
9. Reporting & Screenshots
  •	ExtentReports:
  •	Generates a rich HTML report at TestResults/ExtentReport.html.
  •	Each test step and assertion is logged.
  •	Screenshots are attached to the report for failed and key steps.
  •	Screenshot Storage:
  •	Screenshots are saved in TestResults/Screenshots/{TestName}_{Timestamp}/.
  •	Each test run creates a unique folder for its screenshots.
---

10. Example Test Case Flow
  1.	Test Initialization:
    •	Browser and reporting are initialized.
    •	Screenshot folder is created for the test.
  2.	Test Steps:
    •	Navigate to the login page.
    •	Validate the page title.
    •	Enter credentials and submit.
    •	Validate login success or error message.
    •	Capture screenshots at each step.
  3.	Test Cleanup:
    •	Browser is closed.
    •	Test result and screenshots are logged in the report.
---
