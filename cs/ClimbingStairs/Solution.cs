using System;

namespace ClimbingStairs
{
    public class Solution
    {
        public int MinCostClimbingStairs(int[] cost)
        {   
            int a = cost[0], b = cost[1];

            for(var i=2; i<cost.Length; i++)
            {
                var v = cost[i] + Math.Min(a, b);
                a = b;
                b = v;
            }
            return Math.Min(a, b);
        }
    }
}