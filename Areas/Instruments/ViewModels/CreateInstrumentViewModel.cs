using Aspire.Areas.Instruments.Models;
using Aspire.Areas.Instruments.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Aspire.Areas.Instruments.ViewModels
{
    public class CreateInstrumentViewModel
    {
        [Required(ErrorMessage = "Serial Number is required")]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        public InstrumentType SelectedInstrumentType { get; set; }


        [Required(ErrorMessage = "Please select a Make")]
        [Display(Name = "Make")]
        public int SelectedMakeId { get; set; }

        public List<SelectListItem> Makes { get; }

        [Required(ErrorMessage = "Please select a Model")]
        [Display(Name = "Model")]
        public int SelectedModelId { get; set; }
        public List<SelectListItem> Models { get; set; }

        [Display(Name = "Program")]
        public int SelectedProgramId { get; set; }
        public List<SelectListItem> Programs { get; }

        [Display(Name = "Student")]
        public int SelectedStudentId { get; set; }
        public List<SelectListItem> Students { get; set; }

        [MaxLength(2000, ErrorMessage = "Notes must be 2000 or less characters")]
        public string Notes { get; set; }

        public CreateInstrumentViewModel(IEnumerable<Make> makes, IEnumerable<Shared.Models.Program> programs)
        {
            Makes = new List<SelectListItem>(makes.Count());

            foreach (var make in makes)
            {
                Makes.Add(new SelectListItem(make.Description, make.Id.ToString()));
            }

            Programs = new List<SelectListItem>(programs.Count());

            foreach (var program in programs)
            {
                Programs.Add(new SelectListItem(program.Name, program.Id.ToString()));
            }

            //foreach(var instrumentType in InstrumentType)
            //{

            //}
        }

        public CreateInstrumentViewModel() { }
    }
}
