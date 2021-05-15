using System;

namespace Marketplace.Domain
{
    /// <summary>
    /// In order to make the implicit explicit, we create a Price value object
    /// This helps abstract the validations into an explicit place.
    /// </summary>
    //public class Price : Money
    //{
    //    public Price(decimal amount, string currencyCode): base(amount, currencyCode)
    //    {
    //        if (amount < 0)
    //        {
    //            throw new ArgumentException("Price cannot be negative", nameof(amount));
    //        }
    //    }
    //}
}
