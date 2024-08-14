using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogTests.Pages
{
	public class EditMoviePage : BasePage
	{
        public EditMoviePage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url => BaseUrl + "/Movie/Edit";

		public IWebElement TitleInputEdit => driver.FindElement(By.XPath("//input[@id='form2Example17' and @name='Title']"));
		public IWebElement DescriptionInputEdit => driver.FindElement(By.XPath("//textarea[@id='form2Example17' and @name='Description']"));
		public IWebElement PosterUrlInputEdit => driver.FindElement(By.XPath("//input[@id='form2Example17' and @name='PosterUrl']"));
		public IWebElement MarkAsWatchedCheckboxEdit => driver.FindElement(By.XPath("//input[@class='form-check-input' and @name='IsWatched']"));
		public IWebElement EditButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));

		public IWebElement ToastMessageEdit => driver.FindElement(By.XPath("//div[@class='toast-message']"));

		public void AssertRecordEdited()
		{
			Assert.That(ToastMessageEdit.Text, Is.EqualTo("The Movie is edited successfully!"));
		}
	}
}
