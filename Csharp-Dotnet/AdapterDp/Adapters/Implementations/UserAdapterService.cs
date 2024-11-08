using System.Xml;
using AdapterDp.Adapters.Interfaces;
using AdapterDp.Services.Interfaces;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace AdapterDp.Adapters.Implementations;

public class UserAdapterService(IUserService userService) : IUserAdapterService
{
    public async Task<string> GetUsers()
    {
        var xmlResult = await userService.GetUsers();
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlResult);
        return JsonConvert.SerializeObject(xmlDoc, Formatting.Indented);
    }
}