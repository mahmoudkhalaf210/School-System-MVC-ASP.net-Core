using System.ComponentModel.DataAnnotations;
namespace Day2.ViewModel
{
    public class LoginUserNameViewModel
    {
        [Required]
        public string userName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool rememberMe { get; set; }
    }
}
