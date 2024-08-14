using MovieCatalogTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace MovieCatalogTests.Tests.Tests
{
	public class BaseTest
	{
		public IWebDriver driver;

		public Actions actions;

		public LoginPage loginPage;

		public AddMoviePage addMoviePage;

		public AllMoviesPage allMoviesPage;

		public EditMoviePage editMoviePage;

		public WatchedMoviesPage watchedMoviesPage;

		public DeleteMoviePage deleteMoviePage;


		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			var chromeOptions = new ChromeOptions();

			chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
			chromeOptions.AddArgument("--disable-search-engine-choice-screen");

			driver = new ChromeDriver(chromeOptions);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			loginPage = new LoginPage(driver);
			addMoviePage = new AddMoviePage(driver);
			allMoviesPage = new AllMoviesPage(driver);
			editMoviePage = new EditMoviePage(driver);
			watchedMoviesPage = new WatchedMoviesPage(driver);
			deleteMoviePage = new DeleteMoviePage(driver);

			loginPage.OpenPage();
			loginPage.PerformLogin("andarztest@gmail.com", "123456");

			actions = new Actions(driver);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		private const string CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		public string GenerateRandomTitle(int length)
		{
			var random = new Random();
			return new string(Enumerable.Range(0, length)
										.Select(_ => CharSet[random.Next(CharSet.Length)])
										.ToArray());
		}
	}
}
