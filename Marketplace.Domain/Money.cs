using Marketplace.Framework;

namespace Marketplace.Domain
{
    /// <summary>
    /// Implement IEquatable<T> ensures that you can compare two instances of Money
    /// Also to ensure Money is immutable the only way to have a new Money instance 
    /// is to create it with a new amount.
    /// Adding some operator overloads to do some simple Money math.
    /// </summary>
    public class Money : Value<Money>
    {
        public decimal Amount { get; }
        public Money(decimal amount) => Amount = amount;

        public Money Add(Money summand) => new Money(Amount + summand.Amount);

        public Money Subtract(Money subtrahend) => new Money(Amount - subtrahend.Amount);

        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);

        public static Money operator -(Money minuend, Money subtrahend) => minuend.Subtract(subtrahend);
    }
}
