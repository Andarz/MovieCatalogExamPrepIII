using OpenQA.Selenium;

namespace MovieCatalogTests.Pages
{
	public class AllMoviesPage : BasePage
	{
        public AllMoviesPage(IWebDriver driver) : base(driver)
        {
            
        }

		public virtual string Url => BaseUrl + "/Catalog/All#all";

		public virtual void OpenPage()
		{
			driver.Navigate().GoToUrl(Url);
		}

		public IReadOnlyCollection<IWebElement> PageIndexes => driver.FindElements(By.XPath("//a[@class='page-link']"));
		public IReadOnlyCollection<IWebElement> AllMovies => driver.FindElements(By.XPath("//div[@class='col-lg-4']"));
		public IWebElement LastMovieTitle => AllMovies.Last().FindElement(By.XPath(".//h2"));
		public IWebElement LastMovieEditButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-outline-success']"));
		public IWebElement LastMovieDeleteButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-danger']"));
		public IWebElement LastMovieMarkAsWatchedButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-info']"));
		public IWebElement ToastMessage => driver.FindElement(By.XPath("//div[@class='toast-message']"));

		public void NavigateToLastPage()
		{
			PageIndexes.Last().Click();
		}
	}
}
