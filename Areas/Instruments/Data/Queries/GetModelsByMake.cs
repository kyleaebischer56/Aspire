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
    public class GetModelsByMake : IRequest<IEnumerable<Model>>
    {
        public int MakeId { get; }

        public GetModelsByMake(int makeId)
        {
            MakeId = makeId;
        }
    }

    public class GetModelsByMakeHandler : IRequestHandler<GetModelsByMake, IEnumerable<Model>>
    {
        private const string sproc = "[dbo].[sto_get_models_by_make]";

        private readonly IIocDbConnectionFactory _iocDbConnectionFactory;

        public GetModelsByMakeHandler(IIocDbConnectionFactory iocDbConnectionFactory)
        {
            _iocDbConnectionFactory = iocDbConnectionFactory;
        }

        public async Task<IEnumerable<Model>> Handle(GetModelsByMake message, CancellationToken cancellationToken)
        {
            using(var connection = _iocDbConnectionFactory.GetReadOnlyConnection())
            {
                return await connection.QueryAsync<Model>(sproc, message, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
