using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;

namespace Project.Controllers {
    public class CategoryController : Controller {
        CategoryService categoryService = new CategoryService();
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult GetProducts(int var, int? page) {
            var productList = categoryService.GetProductsByCateId(var);
            int totalPage = (int)Math.Ceiling((decimal)productList.Count/12);
            int pageNumber = page ?? 1;
            if(page > totalPage) 
                pageNumber = 1;

            ViewBag.CateList = categoryService.GetCategories();
            ViewBag.ProductList = productList.Skip((pageNumber - 1) * 12).Take(12).ToList();
            ViewBag.Category = categoryService.GetCategoryById(var);
            ViewBag.TotalPage = totalPage;
            ViewBag.PageNumber = pageNumber;
            return View(); 
        }

        [HttpPost]
        public IActionResult GetProducts(int var, string order) {
            ViewBag.CateList = categoryService.GetCategories();
            List<Product> productList = categoryService.GetProductsByCateId(var);
            if (order == "desc") {
                productList = productList.OrderByDescending(p => p.UnitPrice).ToList();
            }
            ViewBag.ProductList = productList;
            ViewBag.Category = categoryService.GetCategoryById(var);
            return View();
        }
    }
}
