using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace UI.Controllers
{
  
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList(int page = 1)
        {
            var products = pm.TGetListAll().Where(x => x.Status == true);
            var jsonProducts = JsonConvert.SerializeObject(products);
            return Json(jsonProducts);
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            p.Status = true;
            pm.TAdd(p);
            var jsonProduct = JsonConvert.SerializeObject(p);
            return Json(jsonProduct);
        }
        public IActionResult DeleteProduct(int id)
        {
            var product = pm.TGetById(id);
            pm.TDelete(product);
            return RedirectToAction("Index") ;
        }
        
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = pm.TGetById(id);   
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product p)
        {
            p.Status = true;
            pm.TUpdate(p);         
            return RedirectToAction("Index");
        }






    }
}
