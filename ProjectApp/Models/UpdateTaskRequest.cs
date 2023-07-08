namespace ProjectApp.Models
{
    public class UpdateTaskRequest
    {


        public string ProjectName { get; set; }

        public string TaskName { get; set; }


        public int Priority { get; set; }

        public DateTime startdate { get; set; }

        public DateTime enddate { get; set; }

    }
}
