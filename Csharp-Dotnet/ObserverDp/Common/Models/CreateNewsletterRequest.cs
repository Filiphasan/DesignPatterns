namespace ObserverDp.Common.Models;

public class CreateNewsletterRequest
{
    public string Title { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string Content { get; set; } = string.Empty;
}