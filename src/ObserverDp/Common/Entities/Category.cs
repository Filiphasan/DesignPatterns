namespace ObserverDp.Common.Entities;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<CategoryUser> CategoryUsers { get; set; } = [];
    public ICollection<Newsletter> Newsletters { get; set; } = [];
}