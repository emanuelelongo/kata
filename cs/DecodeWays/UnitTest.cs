using System;
using Xunit;

namespace DecodeWays
{
    public class UnitTest
    {
        [Theory]
        [InlineData("0", 0)]
        [InlineData("10", 1)]
        [InlineData("101", 1)]
        [InlineData("100", 0)]
        [InlineData("110", 1)]
        [InlineData("1111001", 0)]

        [InlineData("1", 1)]
        [InlineData("11", 2)]
        [InlineData("111", 3)]
        [InlineData("1111", 5)]
        [InlineData("11111", 8)]
        [InlineData("111111", 13)]

        [InlineData("3", 1)]
        [InlineData("33", 1)]
        [InlineData("333", 1)]
        [InlineData("3333", 1)]
        
        [InlineData("13", 2)]
        [InlineData("131", 2)]
        [InlineData("1311", 4)]
        [InlineData("13111", 6)]      
        [InlineData("131111", 10)]
        [InlineData("11131", 5)]
        public void Test(string data, int expected)
        {
            var s = new Solution();
            var result = s.NumDecodings(data);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12", true)]
        [InlineData("21", true)]
        [InlineData("32", false)]
        [InlineData("128", false)]
        [InlineData("126", true)]
        public void TestCanConcatLastTwo(string str, bool expected)
        {
            var s = new  Solution();
            var result = s.canConcatLastTwo(str, str.Length-1);
            Assert.Equal(expected, result);
        }
    }
}
