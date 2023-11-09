using Project.Models;

namespace Project.Services {
    public class EmployeeService {
        NorthWindContext _context = new NorthWindContext();

        //Get Employees List
        public List<Employee> GetEmployees() {
            return _context.Employees.ToList();
        }
    }
}
