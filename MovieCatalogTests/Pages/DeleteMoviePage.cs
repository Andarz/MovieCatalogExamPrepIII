using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogTests.Pages
{
	public class DeleteMoviePage : BasePage
	{
        public DeleteMoviePage(IWebDriver driver) :base(driver)
        {
            
        }

        public string Url => BaseUrl + "/Movie/Delete";

        public IWebElement ConfirmationButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));
    }
}
