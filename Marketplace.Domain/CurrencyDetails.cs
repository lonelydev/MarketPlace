using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class CurrencyDetails : Value<CurrencyDetails>
    {
        /// <summary>
        /// This is a pattern to deal with absense of values or nulls.
        /// If a currency code doesn't match any then we return this constant.
        /// This will make our code more readable by not introducing null checks wherever currency
        /// lookup is done.
        /// </summary>
        public static CurrencyDetails None = new CurrencyDetails { InUse = false };

        public string CurrencyCode { get; set; }

        /// <summary>
        /// Different countries currencies care about different number of decimal places.
        /// Japanese Yens have no decimal places at all.
        /// Whereas the Omani Riyal on the other hand cares about three decimal places.
        /// While most other currencies care about 2 decimal places
        /// </summary>
        public int DecimalPlaces { get; set; }

        public bool InUse { get; set; }
    }
}