using System;
using System.Collections.Generic;
using Xunit;

namespace WordLadderII
{
    public class UnitTest
    {
        [Theory]
        [InlineData(
            "hit", 
            "cog", 
            new string[] {"hot","dot","dog","lot","log","cog"},
            new string[] { "hit","hot","dot","dog","cog"},
            5
        )]
        public void Test(string beginWord, string endWord, string[] wordList, string[] expected, int len)
        {
            var sol = new Solution();
            var result = sol.FindLadders(beginWord, endWord, wordList);

            var sequences = splitSequences(expected, len);
            Assert.Equal(sequences.Count, result.Count);
            foreach(var seq in sequences)
            {
                Assert.Contains(seq, result);
            }
        }

        [Theory]
        [InlineData("hit", "hot", true)]
        [InlineData("hit", "lot", false)]
        [InlineData("hit", "hit", false)]
        public void TestAdjacent(string a, string b, bool expected)
        {
            var s = new Solution();
            Assert.Equal(expected, s.Adjacent(a, b));
        }

        List<List<string>> splitSequences(string[] expected, int len)
        {
            List<List<string>> result = new List<List<string>>();
            var list = new List<string>();
            for(int i=0; i<expected.Length; i++)
            {
                if(i % len == 0) {
                    list = new List<string>();
                    result.Add(list);
                }
                list.Add(expected[i]);
            }
            return result;
        }
    }
}
