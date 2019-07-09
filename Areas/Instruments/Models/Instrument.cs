using Aspire.Areas.Instruments.Models.Enums;
using Aspire.Areas.Instruments.ViewModels;

namespace Aspire.Areas.Instruments.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public InstrumentType InstrumentType { get; set; }
        public int ProgramId { get; set; }
        public int UserId { get; set; } = 1;
        public string SerialNumber { get; set; }
        public string Notes { get; set; }

        public Instrument(CreateInstrumentViewModel createInstrumentViewModel)
        {
            MakeId = createInstrumentViewModel.SelectedMakeId;
            InstrumentType = createInstrumentViewModel.SelectedInstrumentType;
            ProgramId = createInstrumentViewModel.SelectedProgramId;
            //add user later
            SerialNumber = createInstrumentViewModel.SerialNumber;
            Notes = createInstrumentViewModel.Notes;
        }

        public Instrument() { }
    }
}
