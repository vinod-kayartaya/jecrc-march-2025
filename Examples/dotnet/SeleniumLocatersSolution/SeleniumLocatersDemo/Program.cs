using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumLocatersDemo.Pages;

ChromeOptions chromeOptions = new ChromeOptions();
chromeOptions.AddArgument("--headless");
IWebDriver driver = new ChromeDriver(chromeOptions);

//driver.Navigate().GoToUrl("http://127.0.0.1:5500/6.Selenium/Day1/example1.html");

//IWebElement elem1 = driver.FindElement(By.TagName("h1"));
//Console.WriteLine(elem1.Text);

//IWebElement elem2 = driver.FindElement(By.Id("heading1"));
//Console.WriteLine(elem2.Text);

//Console.WriteLine(driver.FindElement(By.Name("subheading")).Text);

//var elem3 = driver.FindElement(By.CssSelector("body div > ul > li.active"));
//Console.WriteLine(elem3.Text);



//driver = new ChromeDriver();
//driver.Navigate().GoToUrl("https://imdb.com");
//var e = driver.FindElement(By.CssSelector("#__next > main > div > div.ipc-page-content-container.ipc-page-content-container--center.sc-cd2d94b0-0.ccXuUy > div:nth-child(6) > div.sc-59fa6bcc-1.cnBOgw.ipc-page-grid__item.ipc-page-grid__item--span-3 > div > div > hgroup > h3"));
//var e2 = driver.FindElement(By.XPath("//*[@id=\"__next\"]/main/div/div[3]/div[3]/div[1]/div/div/hgroup/h3"));
//Console.WriteLine(e.Text);
//Console.WriteLine(e2.Text);

//var btn = driver.FindElement(By.Id("btnGetName"));
//btn.Click();

//IAlert alert = driver.SwitchTo().Alert();
//alert.SendKeys("Deepank");
//alert.Accept();

//Console.WriteLine(driver.FindElement(By.Id("userMsg")).Text);

driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
LoginPage page = new(driver);

page.Username = "vinodkumar";
Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
string path = Path.Combine(Directory.GetCurrentDirectory(), "step1.png");
screenshot.SaveAsFile(path);

page.Password = "mytopsecretpassword";
Screenshot screenshot2 = ((ITakesScreenshot)driver).GetScreenshot();
path = Path.Combine(Directory.GetCurrentDirectory(), "step2.png");
screenshot2.SaveAsFile(path);

page.Submit();
Screenshot screenshot3 = ((ITakesScreenshot)driver).GetScreenshot();
path = Path.Combine(Directory.GetCurrentDirectory(), "error.png");
screenshot3.SaveAsFile(path);

Console.WriteLine(page.ErrorMessage);

driver.Quit();