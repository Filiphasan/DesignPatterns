namespace AdapterDp.Services.Interfaces;

public interface IUserService
{
    Task<string> GetUsers();
}