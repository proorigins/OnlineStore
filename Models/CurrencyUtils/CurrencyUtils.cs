using System.Collections.Generic;
using System.Linq;
using Enums;

namespace Models.CurrencyUtils
{
    public class CurrencyUtils
    {
        public static double Convert(double amount, Currency source, Currency dest)
        {
            if (Equals(source, dest))
            {
                return amount;
            }
            return amount * (d.FirstOrDefault(t => t.Key == source).Value.FirstOrDefault(l => l.Currency == dest).Ratio);
        }

        private static Dictionary<Currency, List<CurrencyRatio>> d = new Dictionary<Currency, List<CurrencyRatio>>()
        {
            {
                Currency.USD, new List<CurrencyRatio>()
                {
                    new CurrencyRatio { Currency = Currency.ILS, Ratio = 3.40 }
                }
            },
            {
                Currency.ILS, new List<CurrencyRatio>()
                {
                    new CurrencyRatio { Currency = Currency.USD, Ratio = 0.29 }
                }
            }
        };
    }
}