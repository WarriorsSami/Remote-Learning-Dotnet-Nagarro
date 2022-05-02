using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendingMachine.Domain.Entities;

[Table("products")]
public class Product
{
    [Key]
    public int ColumnId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"{Name} - price: {Price}$, colId: {ColumnId}, qty: {Quantity}";
    }
}
