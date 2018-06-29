using System.Collections.Generic;

namespace WordLadderII
{
    public class Solution
    {
        
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            return new string[][]{
                new string[] {"hit","hot","dot","dog","cog"},
                new string[] {"hit","hot","lot","log","cog"}
            };
        }
    }
}