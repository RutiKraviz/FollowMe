namespace MyProject.WebAPI.Models
{
    public class CostumerModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public int UserId { get; set; }
    }
}
