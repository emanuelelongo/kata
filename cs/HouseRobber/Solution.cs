using System;

namespace HouseRobber
{
    public class Solution
    {
        public int Rob(int[] nums)
        {
            int[] grid = new int[3];

            if(nums.Length == 0) return 0;
            if(nums.Length == 1) return nums[0];
            if(nums.Length == 2) return Math.Max(nums[0], nums[1]); 

            grid[0] = nums[0];
            grid[1] = Math.Max(nums[0], nums[1]);

            for(int i=2; i<nums.Length; i++)
            {
                grid[i%3] = Math.Max(grid[(i-1)%3], grid[(i-2)%3] + nums[i]);
            }
            return grid[(nums.Length-1)%3];
        }
    }
}
