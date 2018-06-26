using System;
using System.Collections.Generic;

namespace ValidNumber
{
    public class Solution
    {
        public enum State {Space1, Space2, Sign1, Sign2, Dot1, Dot2, Scient, Num1, Num2, Num3, NotValid}

        Dictionary<State, Func<char, State>> machine;

        public Solution()
        {
            machine = new Dictionary<State, Func<char, State>>();
            
            machine[State.Space1] = c =>
            {
                if(c == ' ') return State.Space1;
                if(c == '+' || c == '-') return State.Sign1;
                if(c == '.') return State.Dot1;
                if(char.IsDigit(c)) return State.Num1;
                return State.NotValid;
            };

            machine[State.Sign1] = c => {
                if(c == '.') return State.Dot1;
                if(char.IsDigit(c)) return State.Num1;
                return State.NotValid;
            };

            machine[State.Dot1] = c => {
                if(char.IsDigit(c)) return State.Num2;
                return State.NotValid;
            };

            machine[State.Num1] = c => {
                if(char.IsDigit(c)) return State.Num1;
                if(c == '.') return State.Dot2;
                if(c == 'e') return State.Scient;
                if(c == ' ') return State.Space2;
                return State.NotValid;
            };

            machine[State.Dot2] = c => {
                if(c == ' ') return State.Space2;
                if(c == 'e') return State.Scient;
                if(char.IsDigit(c)) return State.Num2;
                return State.NotValid;
            };

            machine[State.Space2] = c => {
                if(c == ' ') return State.Space2;
                return State.NotValid;
            };

            machine[State.Num2] = c => {
                if(char.IsDigit(c)) return State.Num2;
                if(c == 'e') return State.Scient;
                if(c == ' ') return State.Space2;
                return State.NotValid;
            };

            machine[State.Scient] = c => {
                if(char.IsDigit(c)) return State.Num3;
                if(c == '+' || c == '-') return State.Sign2;
                return State.NotValid;
            };

            machine[State.Sign2] = c => {
                if(char.IsDigit(c)) return State.Num3;
                return State.NotValid;
            };

            machine[State.Num3] = c => {
                if(char.IsDigit(c)) return State.Num3;
                if(c == ' ') return State.Space2;
                return State.NotValid;
            };
         }

        public bool IsNumber(string s)
        {
            State state = State.Space1;
            int i = 0;
            while(i < s.Length) 
            {
                state = machine[state](s[i]);
                
                if(state == State.NotValid)
                    return false;

                i++;
            }
            if(state == State.Num1 
                || state == State.Dot2 
                || state == State.Space2
                || state == State.Num2
                || state == State.Num3)
            {
                return true;
            }

            return false;
        }
    }
}