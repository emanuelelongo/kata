using System;
using Xunit;

namespace MaximumSubarray
{
    public class UnitTest
    {
        [Theory]
        [InlineData(new int[] {-2,1,-3,4,-1,2,1,-5,4}, 6)]
        [InlineData(new int[] {1,1,1}, 3)]
        [InlineData(new int[] {1,-1,1}, 1)]
        public void Test(int[] data, int expected)
        {
            var s = new Solution();
            var result = s.MaxSubArray(data);
            Assert.Equal(expected, result);
        }
    }
}
