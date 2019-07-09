using Aspire.Areas.Instruments.Models;
using Aspire.Configuration;
using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Aspire.Areas.Instruments.Data.Queries
{
    public class GetMakes : IRequest<IEnumerable<Make>> { }

    public class GetMakesHandler : IRequestHandler<GetMakes, IEnumerable<Make>>
    {
        private const string sproc = "[dbo].[sto_get_makes]";

        private readonly IIocDbConnectionFactory _iocDbConnectionFactory;

        public GetMakesHandler(IIocDbConnectionFactory iocDbConnectionFactory)
        {
            _iocDbConnectionFactory = iocDbConnectionFactory;
        }

        public async Task<IEnumerable<Make>> Handle(GetMakes message, CancellationToken cancellationtoken)
        {
            using(var connection = _iocDbConnectionFactory.GetReadOnlyConnection())
            {
                return await connection.QueryAsync<Make>(sproc, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
