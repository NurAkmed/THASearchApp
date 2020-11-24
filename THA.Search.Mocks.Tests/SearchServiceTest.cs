using System;
using Xunit;

namespace THA.Search.Mocks.Tests
{
    public class SearchServiceTest
    {
        [Fact]
        public void CheckWhenSearchStringIsNull()
        {
            SearchService service = new SearchService();
            Assert.Throws<ArgumentNullException>(() => service.FindResults(null));
        }

        [Fact]
        public void CheckWhenSearchStringIsEmpty()
        {
            SearchService service = new SearchService();
            Assert.Throws<ArgumentException>(() => service.FindResults(string.Empty));
        }

        [Fact]
        public void CheckConstructorForNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SearchService(null));
        }
    }
}