using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.Dtos.Reports;

[Serializable]
[XmlRoot("StockReport")]
[JsonObject("StockReport")]
public class StockReportDocument
{
    [XmlElement("Product")]
    [JsonProperty("StockReport")]
    public Product[] Products { get; set; }
}
