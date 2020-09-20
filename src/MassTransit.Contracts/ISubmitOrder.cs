using System;

namespace MassTransit.Contracts
{
    public interface ISubmitOrder
    {
        Guid OrderId { get; }
        DateTime Timestamp { get; }

        string CustomerNumber { get; }
    }
}
