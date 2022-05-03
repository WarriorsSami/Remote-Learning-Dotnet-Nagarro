using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VendingMachine.Domain.Business.IFactories;

namespace VendingMachine.Factories;

internal class SerializerFactory: ISerializerFactory
{
    private readonly SerializerConfiguration _config;

    public SerializerFactory(SerializerConfiguration config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public void Serialize<TReport>(TReport report, string fileName)
    {
        fileName += $".{_config.Type}";
        using var stream = new FileStream(fileName, FileMode.Create);
        using var writer = new StreamWriter(stream);
        
        switch (_config.Type)
        {
            case "xml":
                new XmlSerializer(typeof(TReport)).Serialize(writer, report);
                break;
            case "json":
                using (var jsonWriter = new JsonTextWriter(writer) { Formatting = Formatting.Indented })
                {
                    new JsonSerializer().Serialize(jsonWriter, report);
                }
                break;
        }
    }
}