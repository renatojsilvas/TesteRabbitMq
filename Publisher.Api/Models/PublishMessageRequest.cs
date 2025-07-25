namespace Publisher.Api.Models;

public record PublishMessageRequest
{
    public string Content { get; init; } = string.Empty;
}