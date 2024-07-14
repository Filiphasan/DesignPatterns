using System.Xml;
using System.Xml.Serialization;
using AdapterDp.Common;
using AdapterDp.Services.Interfaces;

namespace AdapterDp.Services.Implementations;

public class UserService : IUserService
{
    public Task<string> GetUsers()
    {
        var users = UserDateProvider.GetUsers();
        var emptyNamespace = new XmlSerializerNamespaces([XmlQualifiedName.Empty]);
        var xmlSerializer = new XmlSerializer(users.GetType());
        var xmlSettings = new XmlWriterSettings
        {
            Indent = true,
            OmitXmlDeclaration = true
        };
        using var stringWriter = new StringWriter();
        using var writer = XmlWriter.Create(stringWriter, xmlSettings);
        xmlSerializer.Serialize(writer, users, emptyNamespace);
        return Task.FromResult(stringWriter.ToString());
    }
}