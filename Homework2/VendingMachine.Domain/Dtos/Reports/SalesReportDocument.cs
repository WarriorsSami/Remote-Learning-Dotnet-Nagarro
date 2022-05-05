using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.Dtos.Reports;

[Serializable]
[XmlRoot("SalesReport")]
[JsonObject("SalesReport")]
public class SalesReportDocument
{
    [XmlElement("Sale")]
    [JsonProperty("SalesReport")]
    public Sale[] Sales { get; set; }
}
