using System.Collections.Generic;
using System.Linq;

namespace WordLadderII
{
    public class Solution
    {
        public bool Adjacent(string a, string b)
        {
            bool diffFound = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    if (diffFound)
                        return false;
                    diffFound = true;
                }
            }
            return diffFound;
        }

        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
                return new string[0][];

            var q = new Queue<string>();
            q.Enqueue(beginWord);
            var prevs = new Dictionary<string, List<string>>();
            var visited = new Dictionary<string, bool>();
            foreach (var str in wordList)
                visited[str] = false;

            string current;

            while (q.Count > 0)
            {
                current = q.Dequeue();
                foreach (var str in wordList.Where(i => !visited[i]))
                {
                    if (Adjacent(current, str) && !visited[str])
                    {
                        if (!q.Contains(str))
                        {
                            q.Enqueue(str);
                            visited[str] = true;
                        }
                        if (!prevs.ContainsKey(str))
                        {
                            prevs[str] = new List<string>();
                        }
                        prevs[str].Add(current);
                    }
                }
            }
            var result = new List<List<string>>();

            if (!prevs.ContainsKey(endWord))
                return result.ToArray();

            current = endWord;
            var list = new List<string>();

            while (current != beginWord)
            {
                list.Add(current);
                current = prevs[current][0];
            }
            list.Add(beginWord);
            list.Reverse();
            result.Add(list);
            return result.ToArray();
        }
    }
}