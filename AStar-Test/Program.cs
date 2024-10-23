using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AStar_Test
{
    internal class Program
    {
        static readonly int[] Start = { 3, 0 };
        static readonly int[] Goal = { 2, 4 };

        static void Main(string[] args)
        {
            Node[,] map = CreateMap(6, 6);

            Node start = map[Start[0], Start[1]];
            Node goal = map[Goal[0], Goal[1]];

            AStar aStar = new AStar(map, start, goal);

            DrawMap(map, aStar.Path);
            Console.WriteLine("---");

            Console.ReadLine();
        }

        static Node[,] CreateMap(int width, int height)
        {
            Node[,] map = new Node[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[x, y] = new Node(null, x, y, true);
                }
            }

            SetNonWalkableNodes(map);

            return map;
        }

        static void SetNonWalkableNodes(Node[,] map)
        {
            map[1, 1].IsTraversable = false;
            map[1, 2].IsTraversable = false;
            map[2, 1].IsTraversable = false;
            map[5, 0].IsTraversable = false;
            map[4, 0].IsTraversable = false;
            map[4, 1].IsTraversable = false;
            map[0, 5].IsTraversable = false;
            map[0, 4].IsTraversable = false;
            map[1, 4].IsTraversable = false;
            map[4, 3].IsTraversable = false;
            map[3, 3].IsTraversable = false;
            map[3, 4].IsTraversable = false;
        }

        static void DrawMap(Node[,] map, Node[] path)
        {
            for(int y = 0; y < map.GetLength(0); y++)
            {
                for(int x = 0; x < map.GetLength(1); x++)
                {
                    bool isPartOfPath = false;

                    if (x == Start[0] && y == Start[1])
                    {
                        Console.Write("S ");
                        continue;
                    }

                    else if (x == Goal[0] && y == Goal[1])
                    {
                        Console.Write("G ");
                        continue;
                    }

                    if (path != null)
                    {
                        foreach (Node node in path)
                        {
                            if (node.X == x && node.Y == y)
                            {

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write('\u25A0' + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                                isPartOfPath = true;
                            }
                        }
                    }

                    if (!isPartOfPath)
                    {
                        Console.Write((map[x, y].IsTraversable ? 'O' : '\u25A0') + " ");
                    }
                }

                Console.Write('\n');
            }
        }
    }
}