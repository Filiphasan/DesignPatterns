namespace ObserverDp.Common.Entities;

public class Newsletter
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required int CategoryId { get; set; }
    public required string Content { get; set; }

    public Category? Category { get; set; }
}