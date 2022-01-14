namespace VendingMachine.Helpers.Payment
{
    internal class PaymentMethod
    {
        public PaymentMethodType Id { get; set; }
        public string Name { get; set; }
        
        public PaymentMethod(PaymentMethodType id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}