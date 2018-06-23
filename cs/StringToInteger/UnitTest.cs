using System;
using Xunit;

namespace StringToInteger
{
    public class UnitTest
    {
        [Theory]
        [InlineData("0", 0)]
        [InlineData("42", 42)]
        [InlineData("-42", -42)]
        [InlineData("4193 with words", 4193)]
        [InlineData("words and 987", 0)]
        [InlineData("-91283472332", -2147483648)]
        public void Test(string str, int n)
        {
            var sol = new Solution();
            var result = sol.MyAtoi(str);

            Assert.Equal(n, result);
        }
    }
}
