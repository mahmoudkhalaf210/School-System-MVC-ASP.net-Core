using System.ComponentModel.DataAnnotations;

namespace Day2.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        public string userName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        
        [Required]
        public string email { get; set; }
        
        [Required, Compare("password")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
        public string  address { get; set; }
    }
}
