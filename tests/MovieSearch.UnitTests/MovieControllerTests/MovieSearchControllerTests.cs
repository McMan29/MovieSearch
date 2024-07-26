namespace MovieSearch.UnitTests.MovieControllerTests
{
    using NUnit.Framework;
    using MovieSearch.Server.Controllers;
    using MovieSearch.Server.Service.Interface;
    using MovieSearch.Server.Models;
    using Microsoft.AspNetCore.Mvc;
    using Moq;

    [TestFixture()]
    public class MovieSearchControllerTests
    {
        private readonly MovieSearchController _controller;
        private readonly Mock<IMovieService> _mockMovieService;
        private readonly MovieSearchByTitleResponse _movieSearchbyTitleResponse;
        private readonly MovieDetails? _movieSearchbyDetailsResponse;

        public MovieSearchControllerTests()
        {
            _mockMovieService = new Mock<IMovieService>();

            _movieSearchbyTitleResponse = new MovieSearchByTitleResponse()
            {
                Search = new List<MovieInfo>()
                { 
                    new MovieInfo() 
                    { 
                        Title = "Test",
                        Year = "2024",
                        ImdbID = "9.9",
                        Poster = "link",
                        Type = "test"
                    } 
                },
                Response = "True",
                Error = null,
                totalResults = 1
            };

            _movieSearchbyDetailsResponse = new MovieDetails()
            {
                Title = "test",
                Type = "test",
                Response = "True"
            };

            _mockMovieService.Setup(s => s.GetMovieInfoAsync(It.IsAny<string>()))
                .Returns(ValueTask.FromResult(_movieSearchbyTitleResponse));

            _mockMovieService.Setup(s => s.GetMovieDetailsAsync(It.IsAny<string>()))
                .Returns(ValueTask.FromResult(_movieSearchbyDetailsResponse));

            _controller = new MovieSearchController(_mockMovieService.Object);

        }

        [Test()]
        public async ValueTask GetMovieByTitle_ValidRequest_ShouldReturnOk()
        {
            var result = await _controller.GetMovieByTitle("test").ConfigureAwait(false);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.TypeOf<MovieSearchByTitleResponse>());
            Assert.That(okResult.Value, Is.SameAs(_movieSearchbyTitleResponse));

            _mockMovieService.Verify(v => v.GetMovieInfoAsync(It.IsAny<string>()), Times.Once);
        }

        [Test()]
        public async ValueTask GetMovieByTitle_InValidRequest_ShouldReturnBadRequest()
        {
            var result = await _controller.GetMovieByTitle(null).ConfigureAwait(false);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<BadRequestResult>());

            _mockMovieService.Verify(v => v.GetMovieInfoAsync(It.IsAny<string>()), Times.Never);
        }

        [Test()]
        public async ValueTask GetMovieDetails_ValidRequest_ShouldReturnOk()
        {
            var result = await _controller.GetMovieDetailsById("Test").ConfigureAwait(false);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.TypeOf<MovieDetails>());
            Assert.That(okResult.Value, Is.SameAs(_movieSearchbyDetailsResponse));

            _mockMovieService.Verify(v => v.GetMovieDetailsAsync(It.IsAny<string>()), Times.Once);
        }

        [Test()]
        public async ValueTask GetMovieDetails_InValidRequest_ShouldReturnBadRequest()
        {
            var result = await _controller.GetMovieDetailsById(null).ConfigureAwait(false);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<BadRequestResult>());

            _mockMovieService.Verify(v => v.GetMovieDetailsAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
