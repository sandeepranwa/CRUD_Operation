namespace EmployeeCRUD.Model.DTO
{
    public class MassageBoxDTO
    {
        public string Message { get; set; }
    }
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Pass { get; set; }
    }
}