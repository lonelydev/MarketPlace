using Marketplace.Framework;

namespace Marketplace.Domain
{
    /// <summary>
    /// Implement IEquatable<T> ensures that you can compare two instances of Money
    /// </summary>
    public class Money : Value<Money>
    {
        public decimal Amount { get; set; }
        public Money(decimal amount) => Amount = amount;
    }
}
