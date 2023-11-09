using Project.Models;

namespace Project.Services {
    public class OrderDetailService {
        NorthWindContext _context = new NorthWindContext();
        public OrderDetail AddOrderDetail(OrderDetail orderDetail) {
            var addedOrderDetail = _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
            return addedOrderDetail.Entity;
        }

        public List<OrderDetail> GetOrderDetails(int orderId) {
            return _context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }
    }
}
