using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogTests.Pages
{
	public class WatchedMoviesPage : AllMoviesPage
	{
        public WatchedMoviesPage(IWebDriver driver) : base(driver)
        {
            
        }

		public override string Url => BaseUrl + "/Catalog/Watched#watched";

		public override void OpenPage()
		{
			driver.Navigate().GoToUrl(Url);
		}
	}
}
