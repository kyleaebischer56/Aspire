using Aspire.Areas.Instruments.Models;
using Aspire.Areas.Instruments.ViewModels;
using Aspire.Configuration;
using Dapper;
using MediatR;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Aspire.Areas.Instruments.Data.Commands
{
    public class CreateInstrument : IRequest<int>
    {
        public Instrument Instrument { get; private set; }

        private CreateInstrument() { }

        public static CreateInstrument With(Instrument instrument)
        {
            return new CreateInstrument
            {
                Instrument = instrument
            };
        }
    }

    public class CreateInstrumentHandler : IRequestHandler<CreateInstrument, int>
    {
        private const string _sproc = "[dbo].[sto_insert_instrument]";

        private readonly IIocDbConnectionFactory _iocDbConnectionFactory;

        public CreateInstrumentHandler(IIocDbConnectionFactory iocDbConnectionFactory) => 
            _iocDbConnectionFactory = iocDbConnectionFactory;

        public async Task<int> Handle(CreateInstrument message, CancellationToken cancellationToken)
        {
            using (var connection = _iocDbConnectionFactory.GetReadWriteConnection())
            {
                var instrument = message.Instrument;

                var sprocParameters = new
                {
                    instrument.MakeId,
                    InstrumentTypeId = (int)instrument.InstrumentType,
                    instrument.ProgramId,
                    UserId = 2716,//instrument.UserId,
                    instrument.SerialNumber,
                    instrument.Notes
                };

                return await connection.QuerySingleAsync<int>(_sproc, sprocParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
