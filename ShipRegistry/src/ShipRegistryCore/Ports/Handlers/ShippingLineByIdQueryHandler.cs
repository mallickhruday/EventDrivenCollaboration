using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;
using ShipRegistryCore.Ports.Exceptions;
using ShipRegistryCore.Ports.Queries;
using ShipRegistryCore.Ports.Repositories;

namespace ShipRegistryCore.Ports.Handlers
{
    public class ShippingLineByIdQueryHandler : QueryHandlerAsync<ShippingLineByIdQuery, ShippingLineByIdQueryResult>
    {
        private readonly IShipRegistryContextFactory _contextFactory;

        public ShippingLineByIdQueryHandler(IShipRegistryContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public override async Task<ShippingLineByIdQueryResult> ExecuteAsync(ShippingLineByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var uow = _contextFactory.Create())
            {
                var line = await uow.Lines.SingleOrDefaultAsync(l => l.Id == query.LineId, cancellationToken);
                if (line == null) throw new NotFoundException($"Could not find the line with id: {query.LineId.Value}");
                return new ShippingLineByIdQueryResult(line);
            }
        }
    }
}