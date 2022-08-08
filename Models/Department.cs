namespace Day2.Models
{
    public class Department
    {
        public Department()
        {
            instructor = new List<Instructor>();
            course = new List<Course>();
            trainee = new List<Trainee>();
        }

        public int id { get; set; }
        public string? name { get; set; }    
        public string? manager { get; set; }


        public virtual List<Instructor> instructor { get; set; }
        public virtual List<Course> course { get; set; }
        public virtual List<Trainee> trainee { get; set; }
    }
}
