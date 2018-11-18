using System;
using System.Linq;

namespace DecodeWays
{
    public class Solution
    {
        public bool canConcatLastTwo(string s, int index)
        {
            return s[index-1] == '1' || s[index-1] == '2' && s[index] <= '6';
        }
        public int NumDecodings(string s)
        {
            if(s[0] == '0') return 0;
            if(s.Length==1) return 1;

            int a=1,
                b=1,
                v=1;

            for(int i=1; i<s.Length; i++)
            {
                if(s[i] == '0')
                {
                    if(s[i-1] != '1' && s[i-1] != '2')
                        return 0;
                    continue;
                }

                if(canConcatLastTwo(s, i))
                {
                    v = a + b;
                }
                a = b;
                b = v;
            }

            return s[s.Length-1]=='0'? a : v;
        }
    }
}