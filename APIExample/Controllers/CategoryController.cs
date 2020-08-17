using DataAccessLayer;
using MODELS=APIExampleModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc;
using BusinessAccessLayer;
using viewModels = APIExampleModels.ViewModels;
using System.ComponentModel.DataAnnotations;



namespace APIExample.Controllers
{
    public class CategoryController : ApiController
    {
        //Injecting Dependancy
        ItemBusinessLayer _itemBusiness;
        public CategoryController()
        {
            _itemBusiness = new ItemBusinessLayer(new ItemInformation());
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult GetItemDetails(string name , [FromUri]viewModels.parameter page)
     {

            if (name != null && name.Length >= 3 && name.Length <= 12)
            {
                return new ObjectResult(_itemBusiness.GetItemsByName(name.ToString(), page.PageNo));
            }
            else
        
            {
                return new BadRequestObjectResult("The length of name should between 3 and 12");
            }
        }
                
        public bool Deletecategory(string name)
        {

            return _itemBusiness.CategoryName(name); ;
        }
    }

}
