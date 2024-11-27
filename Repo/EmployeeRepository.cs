using Dapper;
using EmployeeCRUD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EmployeeCRUD.Repo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection dbConnection;
        public EmployeeRepository(IDbConnection dbConnection) 
        { 
            this.dbConnection = dbConnection;
        }

        //Get All Employee
        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            var employee =  await dbConnection.QueryAsync< Employee > ("SELECT * FROM Employee");
            //var employee = await dbConnection.QueryAsync<Employee>("SPNAME", new { }, commandType: CommandType.StoredProcedure);

            return employee;
        }

        public async Task<IEnumerable<Employee>> AddEmployee(Employee employee)
        {
            var parameters = new
            {
                employee.Name,
                employee.Gender,
                employee.Department,
                employee.City,
            };
           var newEmployee = await dbConnection.QueryAsync<Employee>("AddEmploye", parameters, commandType: CommandType.StoredProcedure);
            return newEmployee;
        }

        public async Task<IEnumerable<Employee>> UpdateEmployee(Employee employee)
        {
            {
                var parameters = new
                {
                    employee.ID,
                    employee.Name,
                    employee.Gender,
                    employee.Department,
                    employee.City,
                };

                var UpdateEmployee = await dbConnection.QueryAsync<Employee>("UpdateEmployee", parameters, commandType: CommandType.StoredProcedure);

                if(UpdateEmployee != null)
                {
                    throw new Exception("Customer Not Found");
                }
                    return UpdateEmployee;
            }
        }

        //Delete Records SP Call
        public async Task<IEnumerable<Employee>> DeleteEmployee(Employee employee)
        {
            {
                var parameters = new
                {
                    employee.ID,
                };

                var UpdateEmployee = await dbConnection.QueryAsync<Employee>("DeleteEmployee", parameters, commandType: CommandType.StoredProcedure);
                return UpdateEmployee;
            }
        }
    }
}
