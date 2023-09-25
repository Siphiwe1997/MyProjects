using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyJourney.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [DisplayName("Subject Name")]
        [Required(ErrorMessage = "Enter a subject name")]
        public string SubjectName { get; set;}


        [DisplayName("Subject Marks")]
        [Required(ErrorMessage = "Enter a subject marks")]
        [Range(0,100,ErrorMessage ="Marks must be in a range 0-100")]
        public double SubjectMarks { get; set;}


        [Required(ErrorMessage = "Enter a level")]
        [Range(1,7,ErrorMessage ="Level must be in a range of 1-7")]
        public int Level { get; set;}
    }
}
