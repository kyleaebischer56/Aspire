using Aspire.Areas.Instruments.Models.Enums;
using System;

namespace Aspire.Areas.Instruments.Models
{
    public class InstrumentHistory
    {
        public int Id { get; set; }
        public int InstrumentId { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
