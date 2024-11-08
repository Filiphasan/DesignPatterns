namespace AdapterDp.Common;

public static class UserDateProvider
{
    public static User[] GetUsers() =>
    [
        new User { FirstName = "Ahmet", LastName = "Yılmaz", Email = "yvUeh1@example.com", Password = "123456" },
        new User { FirstName = "Mehmet", LastName = "Demir", Email = "yvUeh2@example.com", Password = "123456" },
        new User { FirstName = "Ali", LastName = "Yılmaz", Email = "yvUeh3@example.com", Password = "123456" },
        new User { FirstName = "Veli", LastName = "Demir", Email = "yvUeh4@example.com", Password = "123456" },
        new User { FirstName = "Ayşe", LastName = "Yılmaz", Email = "yvUeh5@example.com", Password = "123456" }
    ];
}

public class User
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}