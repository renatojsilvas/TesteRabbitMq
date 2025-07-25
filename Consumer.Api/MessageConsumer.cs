using MassTransit;
using Shared.Messages;

namespace Consumer.Api;

public class MessageConsumer : IConsumer<MessageContract>
{
    private readonly ILogger<MessageConsumer> _logger;

    public MessageConsumer(ILogger<MessageConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MessageContract> context)
    {
        var message = context.Message;
        _logger.LogInformation("Received message: {Id} - {Content} at {Timestamp}", 
            message.Id, message.Content, message.Timestamp);
        
        return Task.CompletedTask;
    }
}