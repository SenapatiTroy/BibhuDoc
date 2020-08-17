
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using DataAccessLayer;
using  viewModels = APIExampleModels.ViewModels;
using System.Web.ModelBinding;

namespace BusinessAccessLayer
{
    
  
   public class ItemInformation : IitemDetailsDataAccess
    {

        public ItemInformation()
        {

        }
        codingTestEntities cd = new codingTestEntities();

        public viewModels.Pagination GetItemsByName(string name,int page)
        {
           
                List<Item> items = cd.Items.Where(x => x.Name == name).ToList();
            List<viewModels.ViewAllData> finalData = new List<viewModels.ViewAllData>();
           // var Totalitem;
            viewModels.Pagination allDatapage = new viewModels.Pagination();
            foreach (var item in items)
            {
            viewModels.ViewAllData allData = new viewModels.ViewAllData();

                if (item != null)
                {
                    allData.CategoryName = item.SubCategory.Category.Name;
                    allData.SubCategoryName = item.SubCategory.Name;
                    allData.ItemName = item.Name;
                    allData.Description = item.Description;
                    finalData.Add(allData);
                }
            }
           
                int count = finalData.Count();
                allDatapage.pageNumber = page; ;
                allDatapage.PageSize = allDatapage.PageSize;
                allDatapage.TotalCount = count;
                allDatapage.TotalPages = (int)Math.Ceiling(count / (double)allDatapage.PageSize);
                var Totalitem = finalData.Skip((allDatapage.pageNumber - 1) * allDatapage.PageSize).Take(allDatapage.PageSize).ToList();
                allDatapage.PreviouPage = allDatapage.pageNumber > 1 ? "Yes" : "No";
                allDatapage.NextPage = allDatapage.pageNumber < allDatapage.TotalPages ? "Yes" : "No";
           
            allDatapage.Results = Totalitem;
            return allDatapage;
        }


        public bool CategoryName( string name)
        {
            var category = cd.Categories.Where(X => X.Name == name).FirstOrDefault();
           var subcategory= cd.SubCategories.Where(x=>x.CategoryId==category.CategoryId).ToList();
           foreach(var y in subcategory)
            {
                SubCategory sc = cd.SubCategories.Find(y.SubCategoryId);
                var item = cd.Items.Where(x => x.SubCategoryId == sc.SubCategoryId).ToList();
                if (item != null)
                {
                    foreach (var a in item)
                    {
                        Item i = cd.Items.Find(a.Id);
                        cd.Items.Remove(i);
                    }
                    cd.SubCategories.Remove(sc);
                }
            }
            cd.Categories.Remove(category);
            cd.SaveChanges();
            return true;
        }
    }
}
