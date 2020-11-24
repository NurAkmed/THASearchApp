using System;
using Xunit;

namespace THA.Search.Mocks.Tests
{
    public class SearchServiceTest
    {
        [Fact]
        public void CheckForThrowingArgumentNullExceptionWhenStringIsNull()
        {
            SearchService service = new SearchService();
            Assert.Throws<ArgumentNullException>(() => service.FindResults(null));
        }

        [Fact]
        public void CheckForThrowingArgumentExceptionWhenEmptyString()
        {
            SearchService service = new SearchService();
            Assert.Throws<ArgumentException>(() => service.FindResults(string.Empty));
        }

        [Fact]
        public void CheckArrayForNotNullWhenElementsContainsASearchWord()
        {
            SearchService service = new SearchService();
            Assert.NotEmpty(service.FindResults("state"));
        }

        [Fact]
        public void CheckArrayForNullWhenElementsIsNotContainsASearchWord()
        {
            SearchService service = new SearchService();
            Assert.Empty(service.FindResults("bq"));
        }
    }
}