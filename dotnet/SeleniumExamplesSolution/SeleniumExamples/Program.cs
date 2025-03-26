using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new ChromeDriver();

driver.Manage().Window.Maximize();

driver.Navigate().GoToUrl("https://vinod.co/posts/consuming-rest-services-using-cpr");
Console.WriteLine($"Title of the website is {driver.Title}");
driver.Quit();
