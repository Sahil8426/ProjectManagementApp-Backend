namespace ProjectApp.Models
{
    public class AddTask
    {

        public Guid Id { get; set; }

        public string ProjectName { get; set; }

        public string TaskName { get; set; }


        public int Priority { get; set; }

        public DateTime startdate { get; set; }

        public DateTime enddate { get; set; }
    }
}
