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
        static readonly int[] Start = { 0, 0 };
        static readonly int[] Goal = { 4, 3 };

        static void Main(string[] args)
        {
            int[,] map = CreateMap(6, 6);

            Node start = new Node(null, Start[0], Start[1]);
            Node goal = new Node(null, Goal[0], Goal[1]);

            AStar aStar = new AStar(map, start, goal);

            DrawMap(map);

            Console.ReadLine();
        }

        static int[,] CreateMap(int width, int height)
        {
            int[,] map = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[x, y] = 0;
                }
            }

            SetNonWalkableNodes(map);

            return map;
        }

        static void SetNonWalkableNodes(int[,] map)
        {
            map[0, 2] = 1;
            map[1, 2] = 1;
            map[2, 2] = 1;
            map[3, 2] = 1;
            map[3, 3] = 1;
            map[3, 4] = 1;
        }

        static void DrawMap(int[,] map)
        {
            for(int y = 0; y < map.GetLength(0); y++)
            {
                for(int x = 0; x < map.GetLength(1); x++)
                {
                    if (x == Start[0] && y == Start[1])
                    {
                        Console.Write("S ");
                    }

                    else if (x == Goal[0] && y == Goal[1])
                    {
                        Console.Write("G ");
                    }

                    else
                    {
                        Console.Write(map[x, y] + " ");
                    }
                }

                Console.Write('\n');
            }
        }
    }
}