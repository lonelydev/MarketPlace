using Marketplace.Domain;
using Xunit;

namespace Marketplace.Tests
{
    public class MoneyTest
    {
        [Fact]
        public void Money_ObjectsWithSameAmount_ShouldBeEqual()
        {
            var firstAmount = Money.FromDecimal(5.0m);
            var secondAmount = Money.FromString("5");
            Assert.Equal(firstAmount, secondAmount);
        }

        [Fact]
        public void Sum_Gives_Total_Amount()
        {
            var oneMoney = Money.FromDecimal(1.01m);
            var twoMoney = Money.FromString("2.34");
            var sixMoney = Money.FromDecimal(6.99m);
            var sumMoney = oneMoney + twoMoney + sixMoney;
            var expectedSumMoney = Money.FromDecimal(1.01m + 2.34m + 6.99m);
            Assert.Equal(expectedSumMoney, sumMoney);
        }

        [Fact]
        public void Subtract_Gives_Remaining_Amount()
        {
            var tenMoney = Money.FromString("10.13");
            var twoMoney = Money.FromDecimal(2.25m);
            var oneMoney = Money.FromString("1.13");
            var remainingMoney = tenMoney - twoMoney - oneMoney;
            var expectedSumMoney = Money.FromDecimal(10.13m - 2.25m - 1.13m);
            Assert.Equal(expectedSumMoney, remainingMoney);
        }
    }
}
