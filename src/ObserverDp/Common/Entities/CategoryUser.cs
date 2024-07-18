namespace ObserverDp.Common.Entities;

public class CategoryUser
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}