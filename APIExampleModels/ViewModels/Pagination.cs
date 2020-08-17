using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIExampleModels.ViewModels
{
  public  class Pagination
    {
        public IEnumerable<ViewAllData> Results { get; set; }
        const int maxPageSize = 10;

        public int pageNumber { get; set; } = 1;
        public int TotalCount { get; set; }
        public int _pageSize { get; set; } = 10;
        public int TotalPages { get; set; }

        public string PreviouPage { get; set;}
        public string NextPage { get; set; }

        public int PageSize
        {

            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
