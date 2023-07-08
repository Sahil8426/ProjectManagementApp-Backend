namespace ProjectApp.Models
{
    public class UpdateProjectRequest
    {

        public string ProjectName { get; set; }

        public int Priority { get; set; }

        public string ManagerName { get; set; }

        public DateTime startdate { get; set; }
    }
}
