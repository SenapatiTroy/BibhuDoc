using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viewModels = APIExampleModels.ViewModels;
namespace BusinessAccessLayer
{
   public class ItemBusinessLayer
    {
        IitemDetailsDataAccess _itemdataAccess;
     //Dependacy injection implemented
        public ItemBusinessLayer(IitemDetailsDataAccess itemdataAccess)
        {
            _itemdataAccess = itemdataAccess;
        }
        public ItemBusinessLayer()
        {
            _itemdataAccess = new ItemInformation();
        }

        public viewModels.Pagination GetItemsByName(string name, int page)
        {
            return _itemdataAccess.GetItemsByName(name, page);
        }

        public bool CategoryName(string name)
        {
            return _itemdataAccess.CategoryName(name);
        }


    }
}
