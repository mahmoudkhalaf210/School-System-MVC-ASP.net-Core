using System.ComponentModel.DataAnnotations;

namespace Day2.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string name { get; set; }
    }
}
