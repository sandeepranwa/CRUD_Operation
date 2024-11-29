using EmployeeCRUD.Repo;
using EmployeeCRUD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Linq;
using Azure;

namespace EmployeeCRUD.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        //Ragister Employee Route
        [HttpPost("")]
        public async Task<IActionResult> RagistorEmployee([FromBody] EmployeeRagister employeeRagister)
        {
            var RgEmployee = await employeeRepository.Ragistersion(employeeRagister);
            return Ok(RgEmployee);
        }

        //Login Employee Route
        [HttpPost("")]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var response = await employeeRepository.Login(login);

                if (response == null)
                {
                    return Unauthorized("Please Enter correct username and password.");
                }

                else
                {
                    return Ok(new
                    {
                        response.FirstOrDefault().Id,
                        response.FirstOrDefault().Passward
                    });
                }
            }
            else
            {
                return BadRequest(new { Message = ModelState.ErrorCount });
            }

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employee = await employeeRepository.GetAllEmployeeAsync();
            return Ok(employee);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            var newEmployee = await employeeRepository.AddEmployee(employee);
            return Ok(newEmployee);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            var updateEmployee = await employeeRepository.UpdateEmployee(employee);
            return Ok(updateEmployee);
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteEmployee([FromBody] Employee employee)
        {
            var deleteEmployee = await employeeRepository.DeleteEmployee(employee);
            return Ok(deleteEmployee);
        }
    }
}
