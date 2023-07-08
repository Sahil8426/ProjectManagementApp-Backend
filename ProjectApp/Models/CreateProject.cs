namespace ProjectApp.Models
{
    public class CreateProject
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }

        public int Priority { get; set; }

        public string ManagerName { get; set; }

        public DateTime startdate { get; set; }
    }

}
