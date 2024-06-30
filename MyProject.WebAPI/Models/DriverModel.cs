namespace MyProject.WebAPI.Models
{
    public class DriverModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullAddress { get; set; }

        public string? Email { get; set; }
       
        public int UserId { get; set; }
    }
}
