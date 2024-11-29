using EmployeeCRUD.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCRUD.Repo
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeRagister>> Ragistersion(EmployeeRagister employeeRagister);
        Task<IEnumerable<Login>> Login(Login login);
        Task<IEnumerable<Employee>> GetAllEmployeeAsync();
        Task<IEnumerable<Employee>> AddEmployee(Employee employee);
        Task<IEnumerable<Employee>> UpdateEmployee(Employee employee);
        Task<IEnumerable<Employee>> DeleteEmployee(Employee employee);
    }
}


