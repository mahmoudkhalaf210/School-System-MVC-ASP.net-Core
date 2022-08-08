using Day2.Models;

namespace Day2.ViewModel
{
    public class InstructorWithDepartmentAndCourseViewModel
    {
        public InstructorWithDepartmentAndCourseViewModel()
        {
            deptList = new List<Department>();
            crsList = new List<Course>();   
        }
        public int id { get; set; }
        public string name { get; set; }
        public int? salary { get; set; }
        public string  address { get; set; }
        public string image { get; set; }
        public int dept_id { get; set; }
        public int crs_id { get; set; }
        public List<Department> deptList { get; set; }
        public List<Course> crsList { get; set; }
    }
}
