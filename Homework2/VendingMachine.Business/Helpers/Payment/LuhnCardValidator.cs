using System;
using System.Linq;
using VendingMachine.Domain.Business.IHelpersPayment;

namespace VendingMachine.Business.Helpers.Payment
{
    public class LuhnCardValidator : ICardValidityAlgorithm
    {
        private int SumDigits(int number)
        {
            var sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        public bool IsValid(string cardNumber)
        {
            var checkDigit = cardNumber.Last();
            cardNumber = cardNumber.Remove(cardNumber.Length - 1);

            var res =
                cardNumber
                    .Reverse()
                    .ToList()
                    .Select(x => int.Parse(x.ToString()))
                    .Aggregate(
                        Tuple.Create(0, 0),
                        (current, digit) =>
                        {
                            var (item1, item2) = current;
                            var sum = item1 + (item2 % 2 == 1 ? digit : SumDigits(digit * 2));

                            return Tuple.Create(sum, item2 + 1);
                        }
                    ).Item1;
            res = 10 - res % 10;

            return res == int.Parse(checkDigit.ToString());
        }
    }
}
