using System;
using Xunit;

namespace ValidNumber
{
    public class UnitTest
    {
        [Theory]
        [InlineData("0", true)]
        [InlineData("0.1", true)]
        [InlineData("abc", false)]
        [InlineData("1 a", false)]
        [InlineData("2e10", true)]
        [InlineData("2.3e10", true)]
        [InlineData("-2.3e10", true)]
        [InlineData("  -2.3e10", true)]
        [InlineData(" + 2.3e10", false)]
        [InlineData("  -2.3e10  ", true)]
        [InlineData("  -2.3.4e10", false)]
        [InlineData("  -234e1.0", false)]
        [InlineData(".1", true)]
        [InlineData("-.1", true)]
        [InlineData("e10", false)]
        [InlineData("3.", true)]
        [InlineData("3. ", true)]
        [InlineData(".", false)]
        [InlineData("..", false)]
        [InlineData(". ", false)]
        [InlineData("3.5e+3.5e+3.5", false)]
        [InlineData("46.e3", true)]
        public void Test(string str, bool expected)
        {
            var sol = new Solution();
            var result = sol.IsNumber(str);

            Assert.Equal(expected, result);
        }
    }
}
