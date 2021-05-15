using Marketplace.Framework;
using System;

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
        /// <summary>
        /// Factory functions to create money from different formats of inputs
        /// decimal and string. In combination with a non-public constructor, this streamlines
        /// the ways in which an instance of money can be created.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Money FromDecimal(decimal amount) => new Money(amount);
        public static Money FromString(string amount) => new Money(decimal.Parse(amount));
        
        public decimal Amount { get; }
        protected Money(decimal amount)
        {
            if (decimal.Round(amount, 2) != amount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot have more than two decimals");
            }

            Amount = amount;
        }

        public Money Add(Money summand) => new Money(Amount + summand.Amount);

        public Money Subtract(Money subtrahend) => new Money(Amount - subtrahend.Amount);

        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);

        public static Money operator -(Money minuend, Money subtrahend) => minuend.Subtract(subtrahend);
        
    }
}
