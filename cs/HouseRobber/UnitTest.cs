using System;
using Xunit;

namespace HouseRobber
{
    public class UnitTest
    {
        [Theory]
        [InlineData(new int[]{1}, 1)]
        [InlineData(new int[]{0,0}, 0)]
        [InlineData(new int[]{1,2,3,1}, 4)]
        [InlineData(new int[]{2,7,9,3,1}, 12)]
        [InlineData(new int[]{2,1,1,2}, 4)]
        [InlineData(new int[]{1,1,1}, 2)]
        [InlineData(new int[]{1,3,1,3,100}, 103)]
        public void Test(int[] data, int expected)
        {
            var solution = new Solution();
            var result = solution.Rob(data);
            Assert.Equal(expected, result);
        }
    }
}
