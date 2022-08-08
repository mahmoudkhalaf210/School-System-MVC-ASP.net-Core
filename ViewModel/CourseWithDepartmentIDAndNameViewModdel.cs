using Day2.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Day2.ViewModel
{
    public class CourseWithDepartmentIDAndNameViewModdel
    {
        public CourseWithDepartmentIDAndNameViewModdel()
        {
            dept = new List<Department>();
        }
        public int id { get; set; }
        [UniqueCourseName]
        public string  name { get; set; }
       
        [CheckDegree]
        public int degree { get; set; }

        [Remote("checkminDegree", "Course", AdditionalFields = "degree", ErrorMessage = "Min degree must be less than Degree")]
        public int minDegree { get; set; }
        [Display(Name = "Department")]
        public int dept_id { get; set; }
        public List<Department> dept { get; set; }
    }
}
