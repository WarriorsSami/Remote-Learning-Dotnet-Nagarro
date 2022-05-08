using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace VendingMachine.Domain.Dtos.ReportDocuments;

[Serializable]
[XmlRoot("VolumeReport")]
public class VolumeReportDocument
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    [XmlArrayItem("Product")]
    [JsonProperty("Products")]
    public ProductSale[] Sales { get; set; }
}