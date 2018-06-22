using System;
using Xunit;

namespace ZigZagConversion
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("A", 1, "A")]
        [InlineData("AB", 1, "AB")]
        [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
        [InlineData("PAYPALISHIRING", 5, "PHASIYIRPLIGAN")]
        [InlineData("PAYPALISHIRING", 6, "PRAIIYHNPSGAIL")]
        public void Test(string input, int rows, string expected)
        {
            var sol = new Solution();
            var result = sol.Convert(input, rows);
            Assert.Equal(expected, result);
        }
    }
}
