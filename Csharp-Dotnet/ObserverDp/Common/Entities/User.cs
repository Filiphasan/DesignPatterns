using ObserverDp.Observers.Interfaces;

namespace ObserverDp.Common.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;

    public ICollection<CategoryUser> CategoryUsers { get; set; } = [];
}