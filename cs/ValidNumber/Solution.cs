namespace ValidNumber
{
    public class Solution
    {
        public bool IsNumber(string s)
        {
            bool valid = false;
            if (string.IsNullOrEmpty(s)) return false;
            int i = 0;
            int beforeDigits = 0;
            while (i < s.Length && s[i] == ' ') i++;
            if (i == s.Length) return false;

            if (s[i] == '+' || s[i] == '-') i++;
            if (i == s.Length) return false;
        
            beforeDigits = i;
            while (i < s.Length && char.IsDigit(s[i])) {
                i++;
                valid = true;
            }
            if (i == s.Length) return true;

            if(s[i] != '.')
            {
                if (beforeDigits == i) return false;
                
            }
            else 
            {
                i++;
                if (i == s.Length && valid) return true;
                beforeDigits = i;
                while (i < s.Length && char.IsDigit(s[i])) i++;
                while (i < s.Length && s[i] == ' ') i++;
                if (beforeDigits == i) return false;
                if (i == s.Length) return true;
            }

            if (s[i] == 'e')
            {
                i++;
                if (i == s.Length) return false;
                beforeDigits = i;
                while (i < s.Length && char.IsDigit(s[i])) i++;
                if (beforeDigits == i) return false;
            }
            while (i < s.Length && s[i] == ' ') i++;
            if (i == s.Length) return true;

            return false;
        }
    }
}