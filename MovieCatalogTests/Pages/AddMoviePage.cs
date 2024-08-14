using OpenQA.Selenium;

namespace MovieCatalogTests.Pages
{
	public class AddMoviePage : BasePage
	{
        public AddMoviePage(IWebDriver driver) : base(driver)
        {
            
        }

		public string Url => BaseUrl + "/Catalog/Add#add";


		public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@id='form2Example17' and @name='Title']"));
        public IWebElement DescriptionInput => driver.FindElement(By.XPath("//textarea[@id='form2Example17' and @name='Description']"));
		public IWebElement PosterUrlInput => driver.FindElement(By.XPath("//input[@id='form2Example17' and @name='PosterUrl']"));
		public IWebElement MarkAsWatchedCheckbox => driver.FindElement(By.XPath("//input[@class='form-check-input' and @name='IsWatched']"));
		public IWebElement AddButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));

		public IWebElement ToastMessage => driver.FindElement(By.XPath("//div[@class='toast-message']"));


		public void OpenPage()
		{
			driver.Navigate().GoToUrl(Url);
		}

		public void AssertEmptyTitleMessage()
		{
			Assert.That(ToastMessage.Text.Trim(), Is.EqualTo("The Title field is required."));
		}

		public void AssertEmptyDescriptionMessage()
		{
			Assert.That(ToastMessage.Text.Trim(), Is.EqualTo("The Description field is required."));
		}
	}
}
