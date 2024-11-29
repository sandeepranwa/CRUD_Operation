using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.Model
{
    public class EmployeeRagister
    {
        public int ID { get; set; }
    
        public string Name { get; set; }
     
        public string Email { get; set; }
    
        public string MobileNumber { get; set; }
     
        public string Passward { get; set; }

    }
}
