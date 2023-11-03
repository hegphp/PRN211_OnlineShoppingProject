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
    }
}
