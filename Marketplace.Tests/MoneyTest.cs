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
    }
}
