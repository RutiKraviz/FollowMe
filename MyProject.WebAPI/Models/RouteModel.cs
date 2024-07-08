namespace MyProject.WebAPI.Models
{
    public class RouteModel
    {
        public int Id { get; set; }

        public string StartTime { get; set; }

        public List<StationModel> Stations { get; set; }
    }
}
