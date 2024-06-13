namespace MyProject.WebAPI.Models
{
    public class CoustemerModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public int UserId { get; set; }
    }
    public class CoustemerLoginModel
    {

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;


    }
}
