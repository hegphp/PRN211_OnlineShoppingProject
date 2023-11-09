using Project.Models;

namespace Project.Services {
    public class CustomerService {
        NorthWindContext _context = new NorthWindContext();

        //check Customer valid
        public bool checkLoginValid(string username, string password) {
            var customers = _context.Customers.ToList();
            
            var account = customers.FirstOrDefault(c => string.Equals(c.CustomerId, username, StringComparison.Ordinal) && string.Equals(c.Phone, password));

            return account != null;
        }

        //get Customer info by id
        public Customer GetCustomer(string username) {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == username);
        }

        //Add new customer
        public void AddCustomer(Customer customer) { 
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}
