using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using viewModels = APIExampleModels.ViewModels;


namespace BusinessAccessLayer
{
   public interface IitemDetailsDataAccess
    {

        viewModels.Pagination GetItemsByName(string name, int page);
        bool CategoryName(string name);
    }
}
