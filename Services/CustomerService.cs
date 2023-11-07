using Project.Models;

namespace Project.Services {
    public class CustomerService {
        NorthWindContext _context = new NorthWindContext();

        //check Customer valid
        public bool checkLoginValid(string username, string password) {
            var account = _context.Customers.FirstOrDefault(c => c.CustomerId == username && c.Phone == password);

            return account != null;
        }

        //get Customer info by id
        public Customer GetCustomer(string username) {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == username);
        }
    }
}
