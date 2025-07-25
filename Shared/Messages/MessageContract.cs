namespace Shared.Messages;

public record MessageContract
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Content { get; init; } = string.Empty;
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
}