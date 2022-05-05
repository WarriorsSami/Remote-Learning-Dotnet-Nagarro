using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendingMachine.Domain.Entities;

[Serializable]
[Table("sales")]
public class Sale
{
    [Key]
    public DateTime Date { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string PaymentMethod { get; set; }
}