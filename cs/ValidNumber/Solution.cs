using System;
using System.Collections.Generic;

namespace ValidNumber
{
    public class Solution
    {
        public enum State {Space1, Space2, Sign1, Sign2, Dot1, Dot2, Scient, Num1, Num2, Num3}

        public bool IsNumber(string s)  
        {
            State state = State.Space1;
            int i = 0;
            char c;
            while(i < s.Length) 
            {
                c = s[i];
                switch(state) 
                {
                    case State.Space1:
                        if(c == ' ') state = State.Space1;
                        else if(c == '+' || c == '-') state = State.Sign1;
                        else if(c == '.') state = State.Dot1;
                        else if(char.IsDigit(c)) state = State.Num1;
                        else return false;
                        break;

                    case State.Sign1:
                        if(c == '.') state = State.Dot1;
                        else if(char.IsDigit(c)) state = State.Num1;
                        else return false;
                        break;

                    case State.Dot1:
                        if(char.IsDigit(c)) state = State.Num2;
                        else return false;
                        break;

                    case State.Num1:
                        if(char.IsDigit(c)) state = State.Num1;
                        else if(c == '.') state = State.Dot2;
                        else if(c == 'e') state = State.Scient;
                        else if(c == ' ') state = State.Space2;
                        else return false;
                        break;

                    case State.Dot2:
                        if(c == ' ') state = State.Space2;
                        else if(c == 'e') state = State.Scient;
                        else if(char.IsDigit(c)) state = State.Num2;
                        else return false;
                        break;

                    case State.Space2:
                        if(c == ' ') state = State.Space2;
                        else return false;
                        break;

                    case State.Num2:
                        if(char.IsDigit(c)) state = State.Num2;
                        else if(c == 'e') state = State.Scient;
                        else if(c == ' ') state = State.Space2;
                        else return false;
                        break;

                    case State.Scient:
                        if(char.IsDigit(c)) state = State.Num3;
                        else if(c == '+' || c == '-') state = State.Sign2;
                        else return false;
                        break;

                    case State.Sign2:
                        if(char.IsDigit(c)) state = State.Num3;
                        else return false;
                        break;

                    case State.Num3:
                        if(char.IsDigit(c)) state = State.Num3;
                        else if(c == ' ') state = State.Space2;
                        else return false;
                        break;
                }
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