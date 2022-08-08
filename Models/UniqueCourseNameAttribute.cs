using System.ComponentModel.DataAnnotations;

namespace Day2.Models
{
    public class UniqueCourseNameAttribute: ValidationAttribute
    {
        ITIContext db = new ITIContext();
        //public UniqueCourseNameAttribute(ITIContext context)
        //{
        //        db = context;
        //}
        //public UniqueCourseNameAttribute()
        //{

        //}

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? name = value?.ToString();
            var newCourse = (Course)validationContext.ObjectInstance;

            Course? course = db.Courses.Where(n => n.dept_id == newCourse.dept_id).Where(n => n.name == name).FirstOrDefault();

            if(course == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"This Course Already Exist In This Department");
        }
    }
}
