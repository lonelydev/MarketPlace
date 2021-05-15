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
        private const string DefaultCurrency = "EUR";

        protected Money(decimal amount, string currencyCode, ICurrencyLookup currencyLookup)
        {
            if (string.IsNullOrEmpty(currencyCode))
            {
                throw new ArgumentNullException(nameof(currencyCode), "Currency code must be specified");
            }

            var currency = currencyLookup.FindCurrency(currencyCode);
            if (!currency.InUse)
            {
                throw new ArgumentException($"Currency {currencyCode} is not valid");
            }

            if (decimal.Round(amount, currency.DecimalPlaces) != amount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), $"Amount in {currencyCode} cannot have more than {currency.DecimalPlaces} decimals");
            }

            Amount = amount;
            Currency = currency;
        }

        /// <summary>
        /// used by operations like addition and subtraction
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        private Money(decimal amount, CurrencyDetails currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; }

        public CurrencyDetails Currency { get; }

        /// <summary>
        /// Factory functions to create money from different formats of inputs
        /// decimal and string. In combination with a non-public constructor, this streamlines
        /// the ways in which an instance of money can be created.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Money FromDecimal(decimal amount, string currency, ICurrencyLookup currencyLookup) => new Money(amount, currency, currencyLookup);

        public static Money FromString(string amount, string currency, ICurrencyLookup currencyLookup) => new Money(decimal.Parse(amount), currency, currencyLookup);

        public static Money operator -(Money minuend, Money subtrahend) => minuend.Subtract(subtrahend);

        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);

        public Money Add(Money summand)
        {
            if (Currency != summand.Currency)
            {
                throw new CurrencyMismatchException("Cannot sum amounts with different currencies");
            }
            return new Money(Amount + summand.Amount, Currency);
        }

        public Money Subtract(Money subtrahend)
        {
            if (Currency != subtrahend.Currency)
            {
                throw new CurrencyMismatchException("Cannot subtract amounts with different currencies");
            }

            return new Money(Amount - subtrahend.Amount, Currency);
        }

        public override string ToString()
        {
            return $"{Currency.CurrencyCode}{Amount}";
        }
    }
}