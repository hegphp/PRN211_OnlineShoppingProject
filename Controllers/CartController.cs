using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.DTO;
using Project.Models;
using Project.Services;

namespace Project.Controllers {
    public class CartController : Controller {
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();
        
        [HttpGet("/cart/info")]
        public IActionResult Info() {
            ViewBag.User = HttpContext.Session.GetString("user");
            ViewBag.CateList = categoryService.GetCategories();
            List<CartDTO> cartList;
            if (HttpContext.Session.GetString("cartList") != null) {
                cartList = JsonConvert.DeserializeObject<List<CartDTO>>(HttpContext.Session.GetString("cartList"));
                ViewBag.CartList = cartList;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Info(int id) {
            ViewBag.CateList = categoryService.GetCategories();
            List<CartDTO> cartList;
            if (HttpContext.Session.GetString("cartList") != null) {
                cartList = JsonConvert.DeserializeObject<List<CartDTO>>(HttpContext.Session.GetString("cartList"));
                ViewBag.CartList = cartList;
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(int ProductId, int? Quantity){
            if (HttpContext.Session.GetString("user") == null)
                return Redirect("/login");
            
            if (!Quantity.HasValue) {
                TempData["Message"]  = "Error: Quantity is empty!";
                return Redirect("/product/info/" + ProductId);
            }
                
            
            ViewBag.CateList = categoryService.GetCategories();
            Product addedProduct = productService.GetProduct(ProductId);
            List<CartDTO> cartList;
            if (HttpContext.Session.GetString("cartList")!= null)
                cartList = JsonConvert.DeserializeObject<List<CartDTO>>(HttpContext.Session.GetString("cartList"));
            else
                cartList = new List<CartDTO>();
            bool flag = false;
            //Access every item in the cart Product List
            foreach(CartDTO i in cartList) { 
                //Check if the product which has productId is founded or not
                if(i.ProductId == ProductId) {
                    //Check if the quantity is more than the product stock quantity or not
                    if (addedProduct.UnitsInStock < (i.Quantity + Quantity)) {
                        TempData["Message"] = "Error: The quantity mustn't be more than its Unit In stock!";
                        TempData["CurrentQuantity"] = "Your current quantity is " + i.Quantity;
                    }
                    else {
                        i.Quantity += Quantity;
                    }
                    flag = true;
                    break;
                }
            }
            if (!flag) { 
                CartDTO cartDTO = new CartDTO();
                cartDTO.ProductId = ProductId;
                cartDTO.Quantity = Quantity;
                cartDTO.QuantityPerUnit = addedProduct.QuantityPerUnit;
                cartDTO.UnitPrice = addedProduct.UnitPrice;
                cartDTO.ProductName = addedProduct.ProductName;
                cartList.Add(cartDTO);
            }
            HttpContext.Session.SetString("cartList", JsonConvert.SerializeObject(cartList));
            return Redirect("/product/info/"+ProductId);
        }

        [HttpGet]
        public IActionResult Delete(int var) {
            List<CartDTO> cartList;
            if (HttpContext.Session.GetString("cartList") != null) {
                cartList = JsonConvert.DeserializeObject<List<CartDTO>>(HttpContext.Session.GetString("cartList"));
                ViewBag.CartList = cartList;
                CartDTO cartDTO = cartList.FirstOrDefault(c => c.ProductId == var);
                cartList.Remove(cartDTO);

                HttpContext.Session.SetString("cartList", JsonConvert.SerializeObject(cartList));
            }
            return Redirect("/cart/info");
        }
    }
}
