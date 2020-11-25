using System;
using System.Threading;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using THA.Search.App.Controllers;
using Xunit;

namespace THA.Search.App.Tests
{
    public class SearchControllerTest
    {
        private readonly Result[] _moqData = { new Result { Id = 1, Description = "Description", Title = "Title" }, };

        [Fact]
        public void CheckForRequests()
        {
            var fakeService = A.Fake<ISearchService>();
            A.CallTo(() => fakeService.FindResults(_moqData[0].Title)).Returns(_moqData);
            using var controller = new SearchController(fakeService);
            var resultsNull = controller.Get(null);
            Assert.IsType<BadRequestResult>(resultsNull.Result);
            var resultsEmpty = controller.Get(string.Empty);
            Assert.IsType<BadRequestResult>(resultsEmpty.Result);
            var resultsGuid = controller.Get(Guid.NewGuid().ToString());
            Assert.IsType<NoContentResult>(resultsGuid.Result);
        }

        [Fact]
        public void CheckForOkResult()
        {
            var fakeService = A.Fake<ISearchService>();
            A.CallTo(() => fakeService.FindResults(_moqData[0].Title)).Returns(_moqData);
            using var controller = new SearchController(fakeService);
            var results = controller.Get(_moqData[0].Title);
            Assert.IsType<OkObjectResult>(results.Result);
        }

        [Fact]
        public void CheckForRequestsInAsync()
        {
            var fakeService = A.Fake<ISearchService>();
            A.CallTo(() => fakeService.FindResultsAsync(_moqData[0].Title, CancellationToken.None)).Returns(_moqData);
            using var controller = new SearchController(fakeService);
            var resultsNull = controller.Get(null, CancellationToken.None);
            Assert.IsType<BadRequestResult>(resultsNull.Result.Result);
            var resultsEmpty = controller.Get(string.Empty, CancellationToken.None);
            Assert.IsType<BadRequestResult>(resultsEmpty.Result.Result);
            var resultsGuid = controller.Get(Guid.NewGuid().ToString(), CancellationToken.None);
            Assert.IsType<NoContentResult>(resultsGuid.Result.Result);
        }

        [Fact]
        public void CheckForOkResultInAsync()
        {
            var fakeService = A.Fake<ISearchService>();
            A.CallTo(() => fakeService.FindResultsAsync(_moqData[0].Title, CancellationToken.None)).Returns(_moqData);
            using var controller = new SearchController(fakeService);
            var results = controller.Get(_moqData[0].Title, CancellationToken.None);
            Assert.IsType<OkObjectResult>(results.Result.Result);
        }
    }
}
