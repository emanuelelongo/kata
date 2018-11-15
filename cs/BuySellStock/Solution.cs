public class Solution {
    public int MaxProfit(int[] prices)
    {
        if(prices.Length == 0) return 0;
        
        int buy = prices[0], 
            sell = prices[0], 
            result = 0;

        for(int i=1; i<prices.Length; i++)
        {
            if(prices[i]<buy)
            {
                buy = sell = prices[i];
                continue;
            }

            if(prices[i]>sell)
            {
                sell = prices[i];
                if(result < sell - buy){
                    result = sell - buy;
                }
            }
        }
        return result;
    }
}