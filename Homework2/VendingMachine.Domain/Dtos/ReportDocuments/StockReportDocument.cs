using System;
using System.Xml.Serialization;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.Dtos.ReportDocuments;

[Serializable]
[XmlRoot("StockReport")]
public class StockReportDocument
{
    [XmlElement("Product")]
    public Product[] Products { get; set; }
}
