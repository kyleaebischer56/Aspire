namespace Aspire.Areas.Instruments.Models
{
    public class InstrumentViewModel
    {
        public int Id { get; set; }
        //public Type Type { get; set; } on hold till Kris gets clarification
        public int InventoryId { get; set; } // what is this?
        public string SerialNumber { get; set; }
        public int Make { get; set; }
        public int Model { get; set; }
        public int ProgramId { get; set; }
        public int StudentId { get; set; }
        public string Note { get; set; }
    }
}
