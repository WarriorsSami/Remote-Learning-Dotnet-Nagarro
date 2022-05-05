using System;
using System.ComponentModel;

namespace VendingMachine.Domain.Business.IHelpersPayment;

public enum PaymentMethodType
{
    [Description("cash payment")]
    Cash,
    [Description("credit card payment")]
    CreditCard
}

public static class PaymentMethodTypeExtensions
{
    public static string GetDescription(this PaymentMethodType paymentMethodType)
    {
        var field = paymentMethodType.GetType().GetField(paymentMethodType.ToString());
        if (field != null)
        {
            return
                Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                    is not DescriptionAttribute attribute
              ? paymentMethodType.ToString()
              : attribute.Description;
        }
        return null;
    }
}
