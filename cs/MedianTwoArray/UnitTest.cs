using System;
using Xunit;

namespace MedianTwoArray
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[] {1},     new int[] {1},      1)]
        [InlineData(new int[] {1},     new int[] {2,3},    2)]  
        [InlineData(new int[] {1,3},   new int[] {2},      2)]
        [InlineData(new int[] {1,2},   new int[] {3,4},    2.5)]
        [InlineData(new int[] {1,2},   new int[] {},       1.5)]
        [InlineData(new int[] {1,2,3}, new int[] {},       2)]
        [InlineData(new int[] {1,3,5}, new int[] {4},    3.5)]
        public void Test(int[] arr1, int[] arr2, double expected)
        {
            var sol = new Solution();
            var result1 = sol.FindMedianSortedArrays(arr1, arr2);
            Assert.Equal(expected, result1);

            var result2 = sol.FindMedianSortedArrays(arr2, arr1);
            Assert.Equal(expected, result2);
        }
    }
}
