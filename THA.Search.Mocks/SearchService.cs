using System;
using System.Collections.Generic;
using System.Linq;


namespace THA.Search.Mocks
{
    public class SearchService : ISearchService
    {

        public IReadOnlyCollection<Result> FindResults(string search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(nameof(search));
            }

            if (search == "")
                throw new ArgumentException();

            search = search.ToUpper();
            IReadOnlyCollection<Result> results = Data()
                .Where(r => r.Description.ToUpper().Contains(search))
                .OrderBy(r => r.Id)
                .ToList();
            return results;

        }
        List<Result> Data()
        {
            List<Result> dataObjects = new List<Result>()
            {
                new Result(){Id = 1,
                    Title = "Что делает setState?",
                    Description = "Метод setState() следит за изменением состояния (state) компонента. " +
                    "state — это объект. Когда состояние меняется, компонент рендерится повторно."},
                new Result(){Id = 2,
                    Title = "Какая разница между state и props?",
                    Description = "props (намеренно сокращённо от англ. «properties» — свойства) и state — " +
                                  "это обычные JavaScript-объекты. Несмотря на то, что оба содержат информацию, которая влияет " +
                                  "на то, что увидим после рендера, есть существенное различие: props передаётся в компонент " +
                                  "(служат как параметры функции), в то время как state находится внутри компонента (по аналогии с " +
                                  "переменными, которые объявлены внутри функции)."},
                new Result(){Id = 3,
                    Title= "Почему setState даёт неверное значение",
                    Description = "В React как this.props, так и this.state " +
                                  "представляют значения, которые уже были отрендерены, например, " +
                                  "то, что видите на экране. Вызовы setState являются асинхронными, " +
                                  "поэтому не стоит рассчитывать, что this.state отобразит новое " +
                                  "значение мгновенно после вызова setState. Необходимо добавить" +
                                  " функцию, которая сработает только после обновления состояния, " +
                                  "если нужно получить новое значение, основанное на текущем состоянии", },
                new Result(){Id = 4,
                    Title = "Как обновить состояние значениями, которые зависят от текущего состояния?",
                    Description = "Нужно добавить функцию вместо объекта к setState, которая будет срабатывать " +
                                  "только на самой последней версии состояния (пример ниже)."}

            };
            return dataObjects;
        }




    }
}