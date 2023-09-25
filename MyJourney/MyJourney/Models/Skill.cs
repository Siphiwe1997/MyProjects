using System.ComponentModel.DataAnnotations;

namespace MyJourney.Models
{
    public class Skill
    {
        public int SkillId { get; set; }

        [Required(ErrorMessage ="Enter a skill name")]
        public string Name { get; set; }
    }
}
