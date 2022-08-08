using Day2.Models;

namespace Day2.ViewModel
{
    public class TraineeWithCourseAndDegreeViewModel
    {
        public TraineeWithCourseAndDegreeViewModel()
        {
            course = new List<string>();
            //degree = new List<int>();
            degree = new Dictionary<int, string>();
        }
        public int count { get; set; }
        public string name  { get; set; }
        public List<string> course { get; set; }  
        //public List<int> degree { get; set; }
        public Dictionary<int,string> degree { get; set; }

    }
}
