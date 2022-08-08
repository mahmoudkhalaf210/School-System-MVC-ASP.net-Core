using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Trainee
    {
        public Trainee()
        {
            crsResult = new List<CrsResult>();
        }

        public int id { get; set; }
        public string? name { get; set; }
        public string? image { get; set; }
        public string? address { get; set; }
        public int? grade { get; set; }

        [ForeignKey ("department")]
        public int dept_id { get; set; }

        public virtual Department? department { get; set; }
        public virtual List<CrsResult> crsResult { get; set; }
    }
}
