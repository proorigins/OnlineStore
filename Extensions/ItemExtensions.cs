using Enums;
using Models;
using Models.Item;

namespace Extensions
{
    public static class ItemExtensions
    {
        public static double GetPrice(this IItem item, Currency baseCurrency, Currency currency)
        {
            return Models.CurrencyUtils.CurrencyUtils.Convert(item.Price, baseCurrency, currency);
        }
    }
}