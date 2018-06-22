namespace AddTwoNumbers
{
    public class Solution
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var result = new ListNode(0);
            var resultCursor = result;
            var reminder = 0;
            var sum = 0;
            while (l1 != null || l2 != null || reminder > 0)
            {
                sum = (l1?.val ?? 0) + (l2?.val ?? 0) + reminder;
                resultCursor.val = sum % 10;
                reminder = sum / 10;
                if (l1?.next != null || l2?.next != null || reminder > 0)
                {
                    resultCursor.next = new ListNode(0);
                    resultCursor = resultCursor.next;
                }
                l1 = l1?.next;
                l2 = l2?.next;
            }
            return result;
        }
    }
}