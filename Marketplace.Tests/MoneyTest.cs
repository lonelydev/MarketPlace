using Marketplace.Domain;
using System;
using Xunit;

namespace Marketplace.Tests
{
    public class MoneyTest
    {
        private readonly ICurrencyLookup CurrencyLookup = new FakeCurrencyLookup();
        
        [Fact]
        public void Money_UnknownCurrency_ShouldNotBeAllowed()
        {
            var exception = Assert.Throws<ArgumentException>(() => Money.FromDecimal(5.0m, "WHT", CurrencyLookup));
            Assert.Equal("Currency WHT is not valid", exception.Message);
        }

        [Fact]
        public void Money_UnusedCurrency_ShouldNotBeAllowed()
        {
            var exception = Assert.Throws<ArgumentException>(() => Money.FromDecimal(5.0m, "DEM", CurrencyLookup));
            Assert.Equal("Currency DEM is not valid", exception.Message);
        }

        [Fact]
        public void Money_TooManyDecimalPlaces_ForCurrency_ShouldNotBeAllowed()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Money.FromDecimal(5.0234m, "EUR", CurrencyLookup));
            Assert.Equal("Amount in EUR cannot have more than 2 decimals (Parameter 'amount')", exception.Message);
        }

        [Fact]
        public void Money_ObjectsWithSameAmount_SameCurrency_ShouldBeEqual()
        {
            var firstAmount = Money.FromDecimal(5.0m, "EUR", CurrencyLookup);
            var secondAmount = Money.FromString("5", "EUR", CurrencyLookup);
            Assert.Equal(firstAmount, secondAmount);
        }

        [Fact]
        public void Money_ObjectsWithSameAmount_DifferentCurrency_ShouldNotBeEqual()
        {
            var firstAmount = Money.FromDecimal(5.0m, "USD", CurrencyLookup);
            var secondAmount = Money.FromString("5", "EUR", CurrencyLookup);
            Assert.NotEqual(firstAmount, secondAmount);
        }

        [Fact]
        public void Money_ObjectsWithDifferentAmount_DifferentCurrency_ShouldNotBeEqual()
        {
            var firstAmount = Money.FromDecimal(5.01m, "USD", CurrencyLookup);
            var secondAmount = Money.FromString("5", "EUR", CurrencyLookup);
            Assert.NotEqual(firstAmount, secondAmount);
        }

        [Fact]
        public void Money_ObjectsWithDifferentAmount_SameCurrency_ShouldNotBeEqual()
        {
            var firstAmount = Money.FromDecimal(5.25m, "EUR", CurrencyLookup);
            var secondAmount = Money.FromString("5", "EUR", CurrencyLookup);
            Assert.NotEqual(firstAmount, secondAmount);
        }


        [Fact]
        public void Sum_Gives_Total_Amount()
        {
            var oneMoney = Money.FromDecimal(1.01m, "EUR", CurrencyLookup);
            var twoMoney = Money.FromString("2.34", "EUR", CurrencyLookup);
            var sixMoney = Money.FromDecimal(6.99m, "EUR", CurrencyLookup);
            var sumMoney = oneMoney + twoMoney + sixMoney;
            var expectedSumMoney = Money.FromDecimal(1.01m + 2.34m + 6.99m, "EUR", CurrencyLookup);
            Assert.Equal(expectedSumMoney, sumMoney);
        }

        [Fact]
        public void Subtract_Gives_Remaining_Amount()
        {
            var tenMoney = Money.FromString("10.13", "EUR", CurrencyLookup);
            var twoMoney = Money.FromDecimal(2.25m, "EUR", CurrencyLookup);
            var oneMoney = Money.FromString("1.13", "EUR", CurrencyLookup);
            var remainingMoney = tenMoney - twoMoney - oneMoney;
            var expectedSumMoney = Money.FromDecimal(10.13m - 2.25m - 1.13m, "EUR", CurrencyLookup);
            Assert.Equal(expectedSumMoney, remainingMoney);
        }

        [Fact]
        public void Adding_Monies_OfTwoDifferentCurrencies_ThrowsException()
        {
            var oneMoney = Money.FromDecimal(1.13m, "USD", CurrencyLookup);
            var twoMoney = Money.FromDecimal(2.24m, "EUR", CurrencyLookup);

            CurrencyMismatchException currencyMismatchException = Assert.Throws<CurrencyMismatchException>(() => oneMoney.Add(twoMoney));
        }
    }
}
