public class Solution {
    public int MaxSubArray(int[] nums) 
    {
        if(nums.Length == 0) return 0;

        int value, max;
        value = max = nums[0];
        
        for(int i=1; i<nums.Length; i++)
        {
            if(nums[i] > value + nums[i])
                value = 0;
            
            value+=nums[i];

            if(value > max)
                max = value;
        }

        return max;
    }
}