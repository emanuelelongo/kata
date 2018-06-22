# Add Two Numbers
This work is by [LeetCode](https://leetcode.com/)

Original content ca be found at https://leetcode.com/problems/add-two-numbers/description

### Description
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

### Definition for singly-linked list
``` CS
 public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
 }
```
### Example

    Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
    Output: 7 -> 0 -> 8
    Explanation: 342 + 465 = 807.