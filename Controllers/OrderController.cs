using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.DTO;
using Project.Models;
using Project.Services;

namespace Project.Controllers {
    public class OrderController : Controller {
        OrderService orderService = new OrderService();
        OrderDetailService orderDetailService = new OrderDetailService();
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        ShipperService shipperService = new ShipperService();
        EmployeeService employeeService = new EmployeeService();
        CustomerService customerService = new CustomerService();
        
        public IActionResult Index() {
            return View();
        }

        [HttpGet("/order/addOrder")]
        public IActionResult AddOrderMenu(Order order, List<CartDTO> productList, int[]? selectedProduct) {
            string username = HttpContext.Session.GetString("user");
            //check if user login to the website or not
            if (username == null) {
                return Redirect("/login");
            }
            ViewBag.User = username;
            ViewBag.CateList = categoryService.GetCategories();

            List<CartDTO> selectedCartList = new List<CartDTO>();
            List<CartDTO> cartList = JsonConvert.DeserializeObject<List<CartDTO>>(HttpContext.Session.GetString("cartList"));
            //Get Selected Product
            foreach (var i in selectedProduct) {
                var item = cartList.FirstOrDefault(c => c.ProductId == i);
                selectedCartList.Add(item);
                cartList.Remove(item);
            }

            HttpContext.Session.SetString("selectedCartList", JsonConvert.SerializeObject(selectedCartList));
            HttpContext.Session.SetString("cartList", JsonConvert.SerializeObject(cartList));
            ViewBag.ShipVia = shipperService.GetShippers();
            ViewBag.EmpList = employeeService.GetEmployees();

            return View("Views/Order/AddOrder.cshtml");
        }

        [HttpPost]
        public IActionResult AddOrder(OrderDTO orderDTO) {
            if (HttpContext.Session.GetString("selectedCartList") == null)
                return Redirect("/home");

            List<CartDTO> selectedCartList = JsonConvert.DeserializeObject<List<CartDTO>>(HttpContext.Session.GetString("selectedCartList"));

            Order order = new Order();
            order.CustomerId = HttpContext.Session.GetString("user");
            order.EmployeeId = orderDTO.EmployeeId;
            order.OrderDate = DateTime.Now;
            order.RequiredDate = orderDTO.RequiredDate;
            order.ShipVia = orderDTO.ShipVia;
            order.Freight = orderDTO.Freight;
            order.ShipName = orderDTO.ShipName;
            order.ShipAddress = orderDTO.ShipAddress;
            order.ShipCity = orderDTO.ShipCity;
            order.ShipRegion = orderDTO.ShipRegion;
            order.ShipPostalCode = orderDTO.ShipPostalCode;
            order.ShipCountry = orderDTO.ShipCountry;

            order = orderService.AddOrder(order);

            foreach (CartDTO cart in selectedCartList) {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.ProductId = cart.ProductId;
                orderDetail.OrderId = order.OrderId;
                orderDetail.UnitPrice = cart.UnitPrice.Value;
                orderDetail.Quantity = cart.Quantity.Value;
                orderDetail.Discount = 0;

                productService.DecreaseQuantityAfterPurchase(cart.ProductId, cart.Quantity.Value);

                orderDetailService.AddOrderDetail(orderDetail);
            }
            return Redirect("/order/list");
        }

        [HttpGet]
        public IActionResult List() {
            string username = HttpContext.Session.GetString("user");
            //check if user login to the website or not
            if(username == null) {
                return Redirect("/login");
            }
            ViewBag.User = username;
            ViewBag.CateList = categoryService.GetCategories();
            ViewBag.OrderList = orderService.GetOrdersByCustomerId(username);
            return View();
        }

        [HttpGet]
        public IActionResult Details(int var) {
            string username = HttpContext.Session.GetString("user");
            //check if user login to the website or not
            if (username == null) {
                return Redirect("/login");
            }
            ViewBag.CateList = categoryService.GetCategories();
            ViewBag.OrderDetailList = orderDetailService.GetOrderDetails(var);
            return View();
        }
    }
}
