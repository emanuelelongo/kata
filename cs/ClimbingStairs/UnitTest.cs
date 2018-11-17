using System;
using Xunit;

namespace ClimbingStairs
{
    public class UnitTest
    {
        [Theory]
        [InlineData(new int[] {10, 15, 20}, 15)]
        [InlineData(new int[] {10, 15, 20, 5, 8}, 20)]
        [InlineData(new int[] {1, 100, 1, 1, 1, 100, 1, 1, 100, 1}, 6)]
        public void Test(int[] data, int expected)
        {
            var s = new Solution();
            var result = s.MinCostClimbingStairs(data);
            Assert.Equal(expected, result);
        }
    }
}
