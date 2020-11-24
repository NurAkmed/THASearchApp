using System.Collections.Generic;

namespace THA.Search
{
    public interface ISearchService
    {
        IReadOnlyCollection<Result> FindResults(string search);
    }
}
