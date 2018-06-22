using System;
using Xunit;
using static AddTwoNumbers.Solution;

namespace AddTwoNumbers
{
    public class UnitTest
    {
        public ListNode NumbToList(int n)
        {
            ListNode result = new ListNode(0);
            var cursor = result;
            var digits = Math.Floor(Math.Log10(n)) + 1;
            for (int i = 0, rest = n; i < digits; i++)
            {
                cursor.val = (int)(rest - (int)Math.Floor((decimal)rest / 10) * 10);
                rest = (int)Math.Floor((decimal)rest) / 10;
                if(rest != 0) {
                    cursor.next = new ListNode(0);
                    cursor = cursor.next;
                }
            }
            return result;
        }
        
        public int ListToNumb(ListNode list)
        {
            int value = 0; 
            for(int i=0; list != null; i++)
            {
                value += list.val * (int)Math.Pow(10, i);
                list = list.next;
            }
            return value;
        }

        [Theory]
        [InlineData(91, 9, 100)]
        [InlineData(10, 0, 10)]
        [InlineData(123, 880, 1003)]
        [InlineData(23, 0, 23)]
        public void Test(int n1, int n2, int expected)
        {
            var sol = new Solution();
            var v1 = NumbToList(n1);
            var v2 = NumbToList(n2);
            var result = sol.AddTwoNumbers(v1, v2);

            Assert.Equal(ListToNumb(result), expected);
        }
    }
}
