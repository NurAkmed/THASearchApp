using System;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using THA.Search.App.Controllers;
using THA.Search.Mocks;
using Xunit;

namespace THA.Search.App.Tests
{
    public class SearchControllerTest
    {
        [Fact]
        public void SearchControllerCheckForRequests()
        {
            ISearchService service = new SearchService();
            using var controller = new SearchController(service);
            var resultsNull = controller.Get(null);
            Assert.IsType<BadRequestResult>(resultsNull.Result);
            var resultsEmpty = controller.Get(string.Empty);
            Assert.IsType<BadRequestResult>(resultsEmpty.Result);
            var resultsGuid = controller.Get(Guid.NewGuid().ToString());
            Assert.IsType<NoContentResult>(resultsGuid.Result);
        }

        [Fact]
        public void SearchControllerOkResult()
        {
            Result[] moqData = { new Result { Id = 1, Description = "Description", Title = "Title" }, };
            var fakeService = A.Fake<ISearchService>();
            A.CallTo(() => fakeService.FindResults(moqData[0].Title)).Returns(moqData);
            using var controller = new SearchController(fakeService);
            var results = controller.Get(moqData[0].Title);
            Assert.IsType<OkObjectResult>(results.Result);
        }
    }
}
