using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace VendingMachine.Domain.Entities;

[Serializable]
[Table("products")]
public class Product
{
    [Key]
    [XmlIgnore]
    [JsonIgnore]
    public int ColumnId { get; set; }
    public string Name { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"{Name} - price: {Price}$, colId: {ColumnId}, qty: {Quantity}";
    }
}
