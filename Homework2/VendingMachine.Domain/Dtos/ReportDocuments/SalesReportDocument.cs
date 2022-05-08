using System;
using System.Xml.Serialization;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.Dtos.ReportDocuments;

[Serializable]
[XmlRoot("SalesReport")]
public class SalesReportDocument
{
    [XmlElement("Sale")]
    public Sale[] Sales { get; set; }
}
