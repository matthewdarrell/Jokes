using System.Collections.Generic;

namespace Jokes.Core.Entities
{
    public class Page<T>
    {
        public List<T> Content { get; set; }
        public int Count { get; set; }
        public int PageNumber { get; set; }
        public int MaxPerPage { get; set; }
    }
}