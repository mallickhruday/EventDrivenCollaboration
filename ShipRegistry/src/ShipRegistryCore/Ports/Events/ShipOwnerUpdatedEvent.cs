using Paramore.Brighter;
using ShipRegistryCore.Application;

namespace ShipRegistryCore.Ports.Events
{
    public class ShipOwnerUpdatedEvent : Event
    {
        public Id ShipId { get; }
        public Id ShippingLine { get; }

        public ShipOwnerUpdatedEvent(Id shipId, Id shippingLine)
            : base(shipId.Value)
        {
            ShipId = shipId;
            ShippingLine = shippingLine;
        }
    }
}