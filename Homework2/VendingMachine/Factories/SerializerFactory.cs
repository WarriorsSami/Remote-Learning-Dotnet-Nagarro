using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VendingMachine.Configuration;
using VendingMachine.Domain.Business.IFactories;
using Formatting = Newtonsoft.Json.Formatting;

namespace VendingMachine.Factories;

internal class SerializerFactory : ISerializerFactory
{
    private readonly SerializerConfiguration _config;

    public SerializerFactory(SerializerConfiguration config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public void Serialize<TReport>(TReport report, ref string filePath) where TReport : class
    {
        filePath += $".{_config.Type}";
        using var stream = new FileStream(filePath, FileMode.Create);
        using var writer = new StreamWriter(stream);

        switch (_config.Type)
        {
            case "xml":
                var settings = new XmlWriterSettings { Indent = true, IndentChars = "\t" };
                using (var xmlWriter = XmlWriter.Create(writer, settings))
                {
                    new XmlSerializer(typeof(TReport)).Serialize(xmlWriter, report);
                }
                break;
            case "json":
                using (
                    var jsonWriter = new JsonTextWriter(writer) { Formatting = Formatting.Indented }
                )
                {
                    new JsonSerializer().Serialize(jsonWriter, report);
                }
                break;
        }
    }
}
