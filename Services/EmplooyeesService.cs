using AngularDotNet.Data.Models;

namespace AngularDotNet.Services
{
    public class EmployeesService
    {
        List<Employee> employees = new List<Employee>()
            {
                new Employee(){Id=1,Name="ammar", Surname="hakanovic", Active=true, Age=18, DepartmentId=1},
                new Employee(){Id=3,Name="john", Surname="dow", Active=false, Age=8, DepartmentId=0},
                new Employee(){Id=2,Name="majkl", Surname="hak", Active=true, Age=8, DepartmentId=2},
                new Employee(){Id=4,Name="ali", Surname="novic", Active=true, Age=1, DepartmentId=1},
                new Employee(){Id=5,Name="josko", Surname="macola", Active=true, Age=18, DepartmentId=0}
            };

        public EmployeesService()
        {
        }

        public Employee AddEmployee(Employee employee)
        {

            if (getEmployeeById(employee.Id) != null)
            {
                throw new NotImplementedException();
            }

            employees.Add(employee);
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            Employee _employee = getEmployeeById(employee.Id);
            if (employee == null)
            {
                throw new NotImplementedException();

            }
            _employee.Surname = employee.Surname;
            _employee.Age = employee.Age;
            _employee.DepartmentId = employee.DepartmentId;
            _employee.Name = employee.Name;
            return (_employee);

        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee getEmployeeById(int? id)
        {
            return employees.FirstOrDefault(employee => employee.Id == id);
        }


        public void DeleteEmployee(int employeeId)
        {
            Employee employee = getEmployeeById(employeeId);
            if (employee == null)
            {
                throw new NotImplementedException();

            }
            employees.Remove(employee);

        }
        public List<Employee> getEmployeesByActivity(bool isActive)
        {
            List<Employee> result = employees.Where(employee => employee.Active == isActive).ToList();
            return result;
        }

        public List<Employee> getEmployeesByDepartment(int departmentId, bool isActive)
        {
            List<Employee> result = employees.Where(employee => employee.DepartmentId == departmentId && employee.Active == isActive).ToList();
            return result;
        }

    }
}
