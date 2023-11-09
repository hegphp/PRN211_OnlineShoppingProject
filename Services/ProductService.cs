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

        public Product GetProductById(int id) {
            return _context.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public List<Product> searchProducts(string searchedValue) {
            return _context.Products.Where(p => p.ProductName.Contains(searchedValue)).ToList();
        }

        public Product GetProduct(int id) {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public void DecreaseQuantityAfterPurchase(int productId,short quantity) {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            product.UnitsInStock -= quantity;
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}
