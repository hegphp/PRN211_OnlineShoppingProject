using Project.Models;

namespace Project.Services {
    public class ShipperService {
        NorthWindContext _context = new NorthWindContext();

        public List<Shipper> GetShippers() {
            return _context.Shippers.ToList();
        }
    }
}
