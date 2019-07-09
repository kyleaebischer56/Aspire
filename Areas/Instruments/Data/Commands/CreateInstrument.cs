using Aspire.Areas.Instruments.ViewModels;
using Aspire.Configuration;
using Dapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aspire.Areas.Instruments.Data.Commands
{
    public class CreateInstrument : IRequest<int>
    {
        public CreateInstrumentViewModel Instrument { get; private set; }

        private CreateInstrument() { }

        public static CreateInstrument With(CreateInstrumentViewModel instrument)
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
                return await connection.QuerySingleAsync<int>(_sproc, message.Instrument);
            }

            //To simulate the DB call for now
            await Task.Delay(2000);

            return 1;
        }
    }
}
