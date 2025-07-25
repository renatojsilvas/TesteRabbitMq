using MassTransit;
using Publisher.Api.Models;
using Shared.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Publisher API", Version = "v1" });
});

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", 5672, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/publish", async (IPublishEndpoint publishEndpoint, PublishMessageRequest request) =>
{
    var message = new MessageContract { Content = request.Content };
    await publishEndpoint.Publish(message);
    return Results.Ok(new { Message = "Published successfully", Id = message.Id });
});

app.Run();