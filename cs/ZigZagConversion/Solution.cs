using System;
using System.Text;

namespace ZigZagConversion
{
    public class Solution
    {
        public string Convert(string s, int numRows) {
            int[,] dis = new int [numRows, 2];
            var maxD = dis[numRows-1,1] = 2 * (numRows - 1);
            if(maxD == 0) maxD = 1;
            dis[0,0] = dis[0,1] = dis[numRows-1,0] = maxD;
            for(int i=1; i<numRows-1; i++) 
            {
                dis[i, 0] = dis[0,0] - i*2;   
                dis[i, 1] = dis[0,0] - dis[i, 0];
            }
            char[] result = s.ToCharArray();
            int j=0;
            for(int i=0; i<numRows; i++) {
                var toggle = false;
                for(int offset=i; offset < s.Length; ) {
                    result[j++] = s[offset];
                    offset+=dis[i,toggle?1:0];
                    toggle = !toggle;
                }
            }
            return new String(result);
        }
    }
}