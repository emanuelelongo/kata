using System;

namespace MedianTwoArray
{
    public class Solution
    {
        public double Median(int[] nums)
        {
            if(nums.Length == 1) return nums[0];

            if(nums.Length % 2 == 0)
            {
                return (nums[nums.Length/2 - 1] + nums[nums.Length/2]) / 2.0;
            }
            else {
                return nums[(nums.Length-1)/2];
            }
        }

        public double Median(int[] left, int[] right)
        {
            if(left.Length == right.Length) 
            {
                return (left[left.Length-1] + right[0]) / 2.0;
            }

            int b = (int)Math.Ceiling((double)(left.Length + right.Length)/2);
            int a = b - 1;
            bool even = (left.Length + right.Length) % 2 == 0;

            if(left.Length > right.Length)
            {
                return even ? (left[a] + left[b]) / 2.0 : left[a];
            }
            else
            {
                return even ? (right[a-left.Length] + right[b-left.Length]) / 2.0 : right[a-left.Length];
            }
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            if(nums1.Length == 0) return Median(nums2);
            if(nums2.Length == 0) return Median(nums1);

            if(nums1[nums1.Length-1] < nums2[0]) {
                return Median(nums1, nums2);
            }
            if(nums2[nums2.Length-1] < nums1[0]) {
                return Median(nums2, nums1);
            }

            var stop = Math.Ceiling((double)(nums1.Length + nums2.Length) / 2.0);
            var even = (nums1.Length + nums2.Length) % 2 == 0;
            int[] lastTwo = new int[2] {0,0};
            int i=0, j=0, next;
            while(i+j <= stop && even || i+j < stop)
            {
                if(i==nums1.Length){
                    next = nums2[j++];
                }
                else if(j == nums2.Length) 
                {
                    next = nums1[i++];
                }
                else {
                    next = nums1[i]<nums2[j] ? nums1[i++] : nums2[j++];
                }

                if(i+j == stop) {
                    lastTwo[0] = next;
                }
                if(i+j == stop+1) {
                    lastTwo[1] = next;
                }               
            }
            if(even)
            {
                return (lastTwo[0] + lastTwo[1]) / 2.0;
            }
            else {
                return lastTwo[0];
            }
        }
    }
}