using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MovieCatalogTests.Pages
{
	public class BasePage
	{
		protected IWebDriver driver;
		protected WebDriverWait wait;

		protected string BaseUrl = "http://moviecatalog-env.eba-ubyppecf.eu-north-1.elasticbeanstalk.com";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

		public IWebElement LoginLink => driver.FindElement(By.XPath("//a[text()='Login']"));
		public IWebElement LoginHereButton => driver.FindElement(By.Id("loginBtn"));
		public IWebElement AddMovieLink => driver.FindElement(By.XPath("//a[text()='Add Movie']"));
		public IWebElement AllMoviesLink => driver.FindElement(By.XPath("//a[text()='All Movies']"));
		public IWebElement WatchedMoviesLink => driver.FindElement(By.XPath("//a[text()='Watched Movies']"));
		public IWebElement UnwatchedMoviesLink => driver.FindElement(By.XPath("//a[text()='Unwatched Movies']"));
		public IWebElement LogoutButton => driver.FindElement(By.XPath("//button[text()='Logout']"));


		
	}
}
