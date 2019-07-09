using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aspire.Areas.Instruments.ViewModels
{
    public class CreateInstrumentViewModel
    {
        [Required(ErrorMessage = "Serial Number is required")]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Please select a Make")]
        [Display(Name = "Make")]
        public int SelectedMakeId { get; set; }

        //Going to have to get these values from the DB, but for now just hard code them
        public List<SelectListItem> Makes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Yamaha" },
            new SelectListItem { Value = "2", Text = "Roland" }
        };

        [Required(ErrorMessage = "Please select a Model")]
        [Display(Name = "Model")]
        public int SelectedModelId { get; set; }

        public List<SelectListItem> Models { get; set; }

        [Display(Name = "Program")]
        public int SelectedProgramId { get; set; }
        //Accompanying list of programs to pick from

        public List<SelectListItem> Programs { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Seminole" },
            new SelectListItem { Value = "2", Text = "Clair-Mel" }
        };

        [Display(Name = "Student")]
        public int SelectedStudentId { get; set; }
        //Accompanying list of students to pick from for a given program

        public List<SelectListItem> Students { get; set; } 

        [MaxLength(2000, ErrorMessage = "Notes must be 2000 or less characters")]
        public string Notes { get; set; }
    }
}
