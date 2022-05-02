using System;
using VendingMachine.Domain.Dtos;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Presentation.Views;

internal class SupplyProductView : ISupplyProductView
{
    private static string RequestProductDetail(string detail)
    {
        DisplayBase.DisplayLine(
            $"Enter the {detail} of the product you want to supply:",
            ConsoleColor.Yellow
        );
        var value = Console.ReadLine() ?? string.Empty;

        return value;
    }

    public QuantitySupply RequestProductQuantity()
    {
        return new QuantitySupply
        {
            ColumnId = int.Parse(RequestProductDetail("id")),
            Quantity = int.Parse(RequestProductDetail("quantity"))
        };
    }

    public Product RequestNewProduct()
    {
        return new Product
        {
            ColumnId = int.Parse(RequestProductDetail("id")),
            Name = RequestProductDetail("name"),
            Price = decimal.Parse(RequestProductDetail("price")),
            Quantity = int.Parse(RequestProductDetail("quantity"))
        };
    }

    public void DisplayProduct(Product product)
    {
        DisplayBase.DisplayLine("You have updated/added the following product:", ConsoleColor.Cyan);
        DisplayBase.DisplayLine(product.ToString(), ConsoleColor.Green);
    }
}
