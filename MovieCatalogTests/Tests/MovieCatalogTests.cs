using MovieCatalogTests.Tests.Tests;

namespace MovieCatalogTests.Tests
{
    public class MovieCatalogTests : BaseTest
    {
        private string? lastMovieTitle;
        private string? lastMovieDescription;

        [Test, Order(1)]
        public void AddMovieWithoutTitle_Test()
        {
            addMoviePage.OpenPage();

            addMoviePage.TitleInput.Clear();

            actions.ScrollToElement(addMoviePage.AddButton).Perform();

            addMoviePage.AddButton.Click();

            addMoviePage.AssertEmptyTitleMessage();
        }

        [Test, Order(2)]
        public void AddMovieWithoutDescription_Test()
        {
            lastMovieTitle = GenerateRandomTitle(7);

            addMoviePage.OpenPage();

            addMoviePage.TitleInput.Clear();

            addMoviePage.TitleInput.SendKeys(lastMovieTitle);

            addMoviePage.DescriptionInput.Clear();

			actions.ScrollToElement(addMoviePage.AddButton).Perform();

			addMoviePage.AddButton.Click();

            addMoviePage.AssertEmptyDescriptionMessage();
        }

        [Test, Order(3)]
        public void AddMovieWithTitleAndDescription_Test()
        {
            lastMovieTitle = "Title: " + GenerateRandomTitle(7);
            lastMovieDescription = "Description: " + GenerateRandomTitle(24);

            addMoviePage.OpenPage();

            addMoviePage.TitleInput.Clear();
            addMoviePage.TitleInput.SendKeys(lastMovieTitle);

            addMoviePage.DescriptionInput.Clear();
            addMoviePage.DescriptionInput.SendKeys(lastMovieDescription);

            actions.ScrollToElement(addMoviePage.AddButton).Perform();

            addMoviePage.AddButton.Click();

            allMoviesPage.NavigateToLastPage();

            Assert.That(allMoviesPage.LastMovieTitle.Text, Is.EqualTo(lastMovieTitle.ToUpper()));
        }

        [Test, Order(4)]
        public void EditLastAddedMovie_Test()
        {
			lastMovieTitle = "Title: " + GenerateRandomTitle(5) + ": edited";
			lastMovieDescription = "Description: " + GenerateRandomTitle(17);

			allMoviesPage.OpenPage();

            allMoviesPage.NavigateToLastPage();

            allMoviesPage.LastMovieEditButton.Click();

            editMoviePage.TitleInputEdit.Clear();
            editMoviePage.TitleInputEdit.SendKeys(lastMovieTitle);

            actions.ScrollToElement(editMoviePage.EditButton).Perform();
            editMoviePage.EditButton.Click();

            editMoviePage.AssertRecordEdited();
        }

        [Test, Order(5)]
        public void MarkAsWatchedLastAddedMovie_Test()
        {
			allMoviesPage.OpenPage();

			allMoviesPage.NavigateToLastPage();

            allMoviesPage.LastMovieMarkAsWatchedButton.Click();

            watchedMoviesPage.OpenPage();

            watchedMoviesPage.NavigateToLastPage();

            Assert.That(watchedMoviesPage.LastMovieTitle.Text, Is.EqualTo(lastMovieTitle.ToUpper()));
		}

        [Test, Order(6)]
        public void DeleteLastAddedMovie_Test()
        {
            allMoviesPage.OpenPage();

            allMoviesPage.NavigateToLastPage();

            allMoviesPage.LastMovieDeleteButton.Click();

            deleteMoviePage.ConfirmationButton.Click();

            Assert.That(allMoviesPage.ToastMessage.Text, Is.EqualTo("The Movie is deleted successfully!"));
        }
    }
}