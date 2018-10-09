using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KnightDialer
{
    public class UnitTest
    {
        [Theory]
        [InlineData(5, 1, 1)]
        [InlineData(5, 3, 1)]
        [InlineData(1, 1, 2)]
        [InlineData(6, 1, 3)]
        [InlineData(7, 2, 5)]
        [InlineData(6, 2, 6)]
        public void TestCount(int initialPosition, int hops, int expected)
        {
            var s = new Solution();
            var result = s.CountDials(initialPosition, hops);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 1, new int[] {5})]
        [InlineData(5, 3, new int [] {5})]
        [InlineData(1, 1, new int [] {1,6,  1,8})]
        [InlineData(6, 1, new int [] {6,1,  6,7,  6,0})]
        [InlineData(7, 2, new int [] {7,2,7,  7,2,9,  7,6,1,  7,6,7,  7,6,0})]
        [InlineData(6, 2, new int [] {6,1,8,  6,1,6,  6,7,6,  6,7,2,  6,0,6, 6,0,4})]
        public void TestSolutions(int initialPosition, int hops, int[] expected)
        {
            var s = new Solution();
            var result = s.FindDials(initialPosition, hops);
            var expectedList = rebuildExpected(expected, hops+1);
            Assert.Equal(expectedList.Count, result.Count);
            expectedList.ForEach(i => Assert.Contains(i, result));
        }

        private List<List<int>> rebuildExpected(int[] data, int length)
        {
            var dataList = new List<int>(data);
            var result = new List<List<int>>();
            for(int i=0; i<Math.Ceiling((decimal)data.Length/length); i++)
            {
                result.Add(dataList.Skip(i*length).Take(length).ToList());
            }
            return result;
        }
    }
}
