using System;
using System.Collections.Generic;
using Xunit;

namespace THA.Search.Mocks.Tests
{
    public class SearchServiceTest
    {
        [Fact]
        public void FindResultsArgumentExceptionsAndEmpty()
        {
            SearchService service = new SearchService();
            Assert.Throws<ArgumentNullException>(() => service.FindResults(null));
            Assert.Throws<ArgumentException>(() => service.FindResults(string.Empty));
            Assert.Empty(service.FindResults(Guid.NewGuid().ToString()));
        }

        [Fact]
        public void SearchServiceCheck()
        {
            var moqResults = new[]
                {
                    new Result { Id = 1, Description = "description", Title = "title" },
                };
            var searchService = new SearchService(moqResults);
            Assert.IsAssignableFrom<IEnumerable<Result>>(moqResults);
            Assert.NotNull(searchService);
            Assert.Throws<ArgumentNullException>(() => new SearchService(null));
        }
    }
}