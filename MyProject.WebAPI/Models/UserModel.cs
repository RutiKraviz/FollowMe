namespace MyProject.WebAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PassWord { get; set; }
        public int RoleId { get; set; }
        public string? Email { get; set; }
    }

    public class CustomerLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
