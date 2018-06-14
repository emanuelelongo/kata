using System;
using System.Collections.Generic;
using System.Linq;

namespace adjacents
{
    class Program
    {
        static ConsoleColor R = ConsoleColor.Red;
        static ConsoleColor G = ConsoleColor.Green;
        static ConsoleColor Y = ConsoleColor.Yellow;
        static ConsoleColor C = ConsoleColor.Cyan;

        static ConsoleColor[,] MAP = {
            {R, R, R, R, G, C, C},
            {C, G, G, C, G, G, G},
            {Y, Y, C, Y, C, Y, Y},
            {R, R, C, C, C, G, G},
            {Y, Y, Y, G, R, R, R}
        };
        static int H = MAP.GetLength(0);
        static int W = MAP.GetLength(1);

        struct Point 
        {
            public int X {get;set;}
            public int Y {get;set;}
            static public implicit operator Point((int x, int y) tuple) => new Point {X = tuple.x, Y = tuple.y};
        }
        
        static Dictionary<Point, bool> Visited = new Dictionary<Point, bool>();
        static Dictionary<Point, List<Point>> Index = new Dictionary<Point, List<Point>>();
        static Point Nord(Point p) => (p.X - 1, p.Y);
        static Point Sud(Point p)  => (p.X + 1, p.Y);
        static Point East(Point p) => (p.X,     p.Y + 1);
        static Point West(Point p) => (p.X,     p.Y - 1);
        static bool IsValid(Point p) => p.X >= 0 && p.Y >= 0 && p.X < H && p.Y < W;

        static void Scan(Point p)
        {
            if(!IsValid(p)) return;
            if(Visited.ContainsKey(p)) return;
            
            Visited[p] = true;
            Follow(p, Nord(p));
            Follow(p, Sud(p));
            Follow(p, East(p));
            Follow(p, West(p));
        }

        static void Follow(Point start, Point next)
        {   
            if(!IsValid(next)) return;
            if(Visited.ContainsKey(next)) return;

            if(MAP[start.X, start.Y] == MAP[next.X, next.Y]) 
            {
                Visited[next] = true;
                if(!Index.ContainsKey(start)) Index[start] = new List<Point>();
                Index[start].Add(next);
                Follow(start, Nord(next));
                Follow(start, Sud(next));
                Follow(start, East(next));
                Follow(start, West(next));
            }
        }

        static void Print(IEnumerable<Point> points) 
        {
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    Console.BackgroundColor = MAP[i, j];
                    Console.Write(" ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("      ");
                for (int j = 0; j < W; j++)
                {
                    if(points.Contains((i,j))) {
                        Console.BackgroundColor = MAP[i, j];
                    }
                    else {
                        Console.BackgroundColor = ConsoleColor.Gray;                   
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        static void Solve(ConsoleColor[,] map)
        {
            for (int i = 0; i < H; i++)
            {        
                for (int j = 0; j < W; j++)
                {
                    Scan((i,j));
                }
            }
        }

        static void Main(string[] args)
        {
            Solve(MAP);

            var winner = Index.OrderByDescending(i => i.Value.Count).First();
            var winnerPoints = winner.Value.Append(winner.Key);
            Print(winnerPoints);
        }
    }
}
