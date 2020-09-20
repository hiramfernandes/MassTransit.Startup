﻿using System;

namespace MassTransit.Contracts
{
    public interface IOrderSubmissionAccepted
    {
        Guid OrderId { get; }
        DateTime Timestamp { get; }

        string CustomerNumber { get; }
    }
}
