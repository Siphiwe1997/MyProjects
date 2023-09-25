using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyJourney.Models
{
    public class Module
    {
        public int ModuleId { get; set; }

        [DisplayName("Module Name")]
        [Required(ErrorMessage = "Enter the module name")]
        public string ModuleName { get; set; }


        [DisplayName("Module Marks")]
        [Required(ErrorMessage = "Enter the module marks")]
        [Range(0, 100, ErrorMessage = "Marks must be in a range 0-100")]
        public double ModuleMarks { get; set; }


        [Required(ErrorMessage = "Enter the credits for the module")]
        [Range(4, 32, ErrorMessage = "Credits must be in a range of 4-32")]
        public int Credits { get; set; }

		[Range(2020, 2023, ErrorMessage = "Year must be in a range of 2019-2023")]
		[Required(ErrorMessage = "Enter module year")]
        public int Year { get; set; }

        [DisplayName("Pass Description")]
        public string PassDescription { get; set; }

        [DisplayName("Module Code")]
        [Required(ErrorMessage ="Enter the module code")]
        public string ModuleCode { get; set; }

        public string PassDescriptionM()
        {
            string _sPassDescription;
            if (ModuleMarks > 74)
                _sPassDescription = "Pass with Distinction";
            else if (ModuleMarks > 49)
                _sPassDescription = "Pass";
            else if (ModuleMarks > 29)
                _sPassDescription = "Fail";
            else
                _sPassDescription = "Incomplete";
            return _sPassDescription;
        }
    }
}
