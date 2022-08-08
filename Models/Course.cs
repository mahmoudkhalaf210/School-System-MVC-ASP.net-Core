using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Models
{
    public class Course
    {
        public Course()
        {
            instructor = new List<Instructor>();
            crsResult = new List<CrsResult>();
        }

        public int id { get; set; }
        
        [Required(ErrorMessage ="Please Enter The Course Name")]
        [UniqueCourseName]
        public string name { get; set; }

        [CheckDegree]
        public int degree { get; set; }

        [Remote("checkminDegree", "Course", AdditionalFields = "degree", ErrorMessage = "Min degree must be less than Degree")]
        public int minDegree { get; set; }

        [ForeignKey ("department")]
        public int dept_id { get; set; }

        public virtual Department? department { get; set; }                                                                                                                                             
        public virtual List<Instructor> instructor { get; set; }
        public virtual List<CrsResult> crsResult { get; set; }
    }
}
