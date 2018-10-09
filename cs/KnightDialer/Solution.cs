using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightDialer
{
    class DialNode
    {
        public int Number { get; }
        public List<DialNode> Adjacents { get; set; }

        public DialNode(int n)
        {
            Number = n;
            Adjacents = new List<DialNode>();
        }
    }

    class Dial
    {
        private List<DialNode> dial;
        public Dial()
        {
            dial = new List<DialNode>();
            for (int i = 0; i < 10; i++)
            {
                dial.Add(new DialNode(i));
            }
            dial[0].Adjacents.Add(dial[4]);
            dial[0].Adjacents.Add(dial[6]);
            dial[1].Adjacents.Add(dial[6]);
            dial[1].Adjacents.Add(dial[8]);
            dial[2].Adjacents.Add(dial[7]);
            dial[2].Adjacents.Add(dial[9]);
            dial[3].Adjacents.Add(dial[4]);
            dial[3].Adjacents.Add(dial[8]);
            dial[4].Adjacents.Add(dial[0]);
            dial[4].Adjacents.Add(dial[3]);
            dial[4].Adjacents.Add(dial[9]);
            dial[6].Adjacents.Add(dial[1]);
            dial[6].Adjacents.Add(dial[0]);
            dial[6].Adjacents.Add(dial[7]);
            dial[7].Adjacents.Add(dial[2]);
            dial[7].Adjacents.Add(dial[6]);
            dial[8].Adjacents.Add(dial[1]);
            dial[8].Adjacents.Add(dial[3]);
            dial[9].Adjacents.Add(dial[2]);
            dial[9].Adjacents.Add(dial[4]);
        }

        public DialNode this[int index]
        {
            get { return dial[index]; }
        }
    }
    public class Solution
    {
        private readonly Dial dial = new Dial();
        private Dictionary<(int, int), long> cache = new Dictionary<(int, int), long>();

        public long CountDials(int initialPosition, int hops)
        {
            if(cache.ContainsKey((initialPosition, hops)))
            {
                return cache[(initialPosition, hops)];
            }
            if (hops == 0 || dial[initialPosition].Adjacents.Count == 0)
            {
                return 1;
            }
            return cache[(initialPosition, hops)] =  dial[initialPosition].Adjacents.Sum(i => CountDials(i.Number, hops - 1));
        }

        public List<List<int>> FindDials(int initialPosition, int hops)
        {
            var solutions = new List<List<int>>();
            var currentPath = new List<int>();
            FindDialsRecursive(solutions, currentPath, initialPosition, hops);
            return solutions;
        }

        public void FindDialsRecursive(List<List<int>> solutions, List<int> currentPath, int initialPosition, int hops)
        {
            var newPath = currentPath.Select(i => i).ToList();
            newPath.Add(initialPosition);

            if (hops == 0 || dial[initialPosition].Adjacents.Count == 0)
            {
                solutions.Add(newPath);
                return;
            }
            foreach (var adj in dial[initialPosition].Adjacents)
            {
                FindDialsRecursive(solutions, newPath, adj.Number, hops - 1);
            }
        }

        static void Main(string[] args)
        {
            var s = new Solution();
            for(var initial = 0; initial <= 9; initial++)
            {
                for(var hops=0; hops<20; hops++)
                {
                    Console.WriteLine($"{initial}, {hops}, {s.CountDials(initial, hops)}");
                }
            }
        }
    }
}