using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace THA.Search
{
    public interface ISearchService
    {
        IReadOnlyCollection<Result> FindResults(string search);

        Task<IReadOnlyCollection<Result>> FindResultsAsync(string search, CancellationToken cancellationToken);
    }
}
