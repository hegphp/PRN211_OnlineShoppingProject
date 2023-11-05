using Project.Models;

namespace Project.Services {
    public class CategoryService {
        NorthWindContext _context;
        public CategoryService() {
            _context = new NorthWindContext();
        }

        //get Cate list
        public List<Category> GetCategories() {
            return _context.Categories.ToList();
        }
        //get Product list by cateId
        public List<Product> GetProductsByCateId(int var) {
            return _context.Products.Where(p => p.CategoryId == var).ToList();
        }
        //get Category by id
        public Category GetCategoryById(int id) {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }
    }
}
