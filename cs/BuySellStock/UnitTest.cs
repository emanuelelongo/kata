using System;
using Xunit;

namespace BuySellStock
{
    public class UnitTest
    {
        [Theory]
        [InlineData(new int[] {}, 0)]
        [InlineData(new int[] {7, 1, 5, 3, 6, 4}, 5)]
        [InlineData(new int[] {3, 7, 5, 1, 6, 4}, 5)]
        [InlineData(new int[] {3, 1, 6, 7, 4, 5}, 6)]
        public void Test(int[] data, int expected)
        {
            var s = new Solution();
            Assert.Equal(s.MaxProfit(data), expected);
        }
    }
}
