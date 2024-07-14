namespace AdapterDp.Adapters.Interfaces;

public interface IUserAdapterService
{
    Task<string> GetUsers();
}