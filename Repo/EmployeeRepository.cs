using Dapper;
using EmployeeCRUD.Model;
using EmployeeCRUD.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using static EmployeeCRUD.Model.DTO.MassageBoxDTO;

namespace EmployeeCRUD.Repo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection dbConnection;
        public EmployeeRepository(IDbConnection dbConnection) 
        { 
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<EmployeeRagister>> Ragistersion(EmployeeRagister employeeRagister)
        {
            var parameters = new
            {
                employeeRagister.Name,
                employeeRagister.Email,
                employeeRagister.MobileNumber,
                employeeRagister.Passward
            };
            var RgEmployee = await dbConnection.QueryAsync<EmployeeRagister>("RagisterEmployee", parameters, commandType: CommandType.StoredProcedure);
            return RgEmployee;
        }

        //Login 
        public async Task<IEnumerable<LoginDTO>> Login(Login loginDTO)
        {
            var parameters = new
            {
                loginDTO.Id,
                loginDTO.Passward
            };
            var data = await dbConnection.QueryAsync<LoginDTO>("LoginEmployee", parameters, commandType: CommandType.StoredProcedure);
            return data;

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

        //Upadte Employee
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
