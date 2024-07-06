namespace MyProject.WebAPI.Models
{
    public class StationModel
    {
        public int Id { get; set; }

        public string FullAddress { get; set; }

        public int RouteId { get; set; }

        public string Lan { get; set; }

        public string Lat { get; set; }
    }
}
