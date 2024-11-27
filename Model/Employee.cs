using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUD.Model
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
    }
}
