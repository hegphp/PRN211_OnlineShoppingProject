namespace Project.Services {
    using Models;
    public class ProductService {
        NorthWindContext _context;

        public ProductService() {
            _context = new NorthWindContext();
        }

        public List<Product> GetProducts() { 
            return _context.Products.ToList();
        } 
    }
}
