namespace StaticFactoryDp.StaticFactories;

public class User
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }

    private User(string name, string lastName, string email)
    {
        Name = name;
        LastName = lastName;
        FullName = $"{name} {lastName}";
        Email = email;
    }

    public static User Create(string name, string lastName, string email)
    {
        return new User(name, lastName, email);
    }
}