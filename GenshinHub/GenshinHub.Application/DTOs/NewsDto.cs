namespace GenshinHub.Application.DTOs;

public class NewsDto
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? SourceUrl { get; set; }
    public DateTime PublishedAt { get; set; }
}

public class CreateNewsDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? SourceUrl { get; set; }
}