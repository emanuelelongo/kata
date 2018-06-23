using System;

namespace StringToInteger
{
    public class Solution {
        public int MyAtoi(string str) {
            long result = 0, digits = 0;
            int i=0;
            int sign = 1;
            
            while(i<str.Length && str[i]== ' ') i++;
            if(i == str.Length) return 0;

            if(str[i] == '-') 
            {
                sign = -1;
                i++;
            }
            else if(str[i] == '+')
            {
                i++;
            }
            if(i == str.Length) return 0;

            while(i<str.Length && char.IsDigit(str[i]))
            {
                result *= 10;
                result += int.Parse(str[i].ToString());
                if(sign == 1 && result >= int.MaxValue) {
                    return int.MaxValue;
                }
                if(sign == -1 && result > int.MaxValue) {
                    return int.MinValue;
                }
                digits++;
                i++;
            }
            return sign * (int)result;
        }
    }
}