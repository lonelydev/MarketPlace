using Marketplace.Domain;
using Xunit;

namespace Marketplace.Tests
{
    public class MoneyTest
    {
        [Fact]
        public void Money_ObjectsWithSameAmount_ShouldBeEqual()
        {
            var firstAmount = new Money(5);
            var secondAmount = new Money(5);
            Assert.Equal(firstAmount, secondAmount);
        }

        [Fact]
        public void Sum_Gives_Total_Amount()
        {
            var oneMoney = new Money(1);
            var twoMoney = new Money(2);
            var sixMoney = new Money(6);
            var sumMoney = oneMoney + twoMoney + sixMoney;
            var expectedSumMoney = new Money(9);
            Assert.Equal(expectedSumMoney, sumMoney);
        }

        [Fact]
        public void Subtract_Gives_Remaining_Amount()
        {
            var tenMoney = new Money(10);
            var twoMoney = new Money(2);
            var oneMoney = new Money(1);
            var remainingMoney = tenMoney - twoMoney - oneMoney;
            var expectedSumMoney = new Money(7);
            Assert.Equal(expectedSumMoney, remainingMoney);
        }
    }
}
