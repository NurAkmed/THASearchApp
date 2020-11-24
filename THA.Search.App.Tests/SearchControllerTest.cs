using System;
using Microsoft.AspNetCore.Mvc;
using THA.Search.App.Controllers;
using THA.Search.Mocks;
using Xunit;

namespace THA.Search.App.Tests
{
    public class SearchControllerTest : IDisposable
    {
        private readonly SearchController _controller;

        public SearchControllerTest()
        {
            ISearchService service = new SearchService();
            _controller = new SearchController(service);
        }

        [Fact]
        public void CheckWhenStringIsNull()
        {
            var results = _controller.Get(null);
            Assert.IsType<BadRequestResult>(results.Result);
        }

        [Fact]
        public void CheckWhenStringIsEmpty()
        {
            var results = _controller.Get(string.Empty);
            Assert.IsType<BadRequestResult>(results.Result);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _controller?.Dispose();
            }
        }
    }
}