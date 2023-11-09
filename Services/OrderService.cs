using Project.Models;

namespace Project.Services {
    public class OrderService {
        NorthWindContext _context = new NorthWindContext();
        //Add order
        public Order AddOrder(Order order) {
            var newOrder = _context.Add(order);
            _context.SaveChanges();
            return newOrder.Entity;
        }
        //Get All order list
        public List<Order> GetOrders() {
            return _context.Orders.ToList();
        }
        //get order list by Customer Id
        public List<Order> GetOrdersByCustomerId(string customerId) {
            return _context.Orders.Where(o => o.CustomerId == customerId).ToList();
        }
    }
}
