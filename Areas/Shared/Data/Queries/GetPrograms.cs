using Aspire.Configuration;
using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Aspire.Areas.Shared.Data.Queries
{
    public class GetPrograms : IRequest<IEnumerable<Models.Program>> { }

    public class GetProgramsHandler : IRequestHandler<GetPrograms, IEnumerable<Models.Program>>
    {
        private const string sproc = "[dbo].[sto_get_active_programs]";

        private readonly IIocDbConnectionFactory _iocDbConnectionFactory;

        public GetProgramsHandler(IIocDbConnectionFactory iocDbConnectionFactory)
        {
            _iocDbConnectionFactory = iocDbConnectionFactory;
        }

        public async Task<IEnumerable<Models.Program>> Handle(GetPrograms message, CancellationToken cancellationToken)
        {
            using(var connection = _iocDbConnectionFactory.GetReadOnlyConnection())
            {
                return await connection.QueryAsync<Models.Program>(sproc, CommandType.StoredProcedure);
            }
        }
    }
}
