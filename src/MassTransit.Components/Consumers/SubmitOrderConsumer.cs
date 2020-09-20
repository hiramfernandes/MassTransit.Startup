using MassTransit.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Components.Consumers
{
    public class SubmitOrderConsumer : IConsumer<ISubmitOrder>
    {
        private readonly ILogger<SubmitOrderConsumer> _logger;

        public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ISubmitOrder> context)
        {
            if (context.Message.CustomerNumber.Contains("TEST"))
            {
                await context.RespondAsync<IOrderSubmissionRejected>(new
                {
                    OrderId = context.Message.OrderId,
                    CustomerNumber = context.Message.CustomerNumber,
                    Timestamp = InVar.Timestamp,
                    Reason = $"Test Customer cannot submit orders: {context.Message.CustomerNumber}"

                });

                return;
            }

            await context.RespondAsync<IOrderSubmissionAccepted>(new
            {
                context.Message.OrderId,
                context.Message.CustomerNumber,
                InVar.Timestamp
            });
        }
    }
}
