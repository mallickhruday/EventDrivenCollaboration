using System.Collections.Generic;
using System.Linq;
using Paramore.Darker;
using ShipRegistryCore.Application;

namespace ShipRegistryCore.Ports.Queries
{
    public class ShippingLinesAllQuery : IQuery<ShippingLineByIdQueryResult>, IQuery<ShippingLinesAllQueryResult>
    {}


    public class ShippingLinesAllQueryResult
    {
        public ShippingLineByIdQueryResult[] ShippingLines { get; }

        public ShippingLinesAllQueryResult(IEnumerable<ShippingLine> lines)
        {

            ShippingLines = lines.Select(l => new ShippingLineByIdQueryResult(l)).ToArray();
        }
    }
}