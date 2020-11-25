using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace THA.Search.App.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _service;

        public SearchController(ISearchService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{search}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Result>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Result>> Get(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return BadRequest();
            }

            var results = _service.FindResults(search);
            if (results.Count != 0)
            {
                return Ok(results);
            }

            return NoContent();
        }

        [HttpGet("{search}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Result>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<Result>>> Get(string search, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(search))
            {
                return BadRequest();
            }

            var results = await _service.FindResultsAsync(search, cancellationToken);
            if (results.Count != 0)
            {
                return Ok(results);
            }

            return NoContent();
        }
    }
}
