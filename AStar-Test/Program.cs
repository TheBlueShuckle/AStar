using System;
using System.Collections.Generic;
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
        static void Main(string[] args)
        {
            Node[,] map = CreateMap(6, 6);
            foreach (Node node in map)
            {
                node.FindNeighbors(map);
            }

            AStar aStar = new AStar(map, new Node(5, 0, true), new Node(0, 4, true));

            DrawMap(map);

            Console.ReadLine();
        }

        static Node[,] CreateMap(int width, int height)
        {
            Node[,] map = new Node[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[x, y] = new Node(x, y, true);
                }
            }

            SetNonWalkableNodes(map);

            return map;
        }

        static void SetNonWalkableNodes(Node[,] map)
        {
            map[0, 2] = new Node(0, 3, false);
            map[1, 2] = new Node(0, 3, false);
            map[2, 2] = new Node(0, 3, false);
            map[3, 2] = new Node(0, 3, false);
            map[3, 3] = new Node(0, 3, false);
            map[3, 4] = new Node(0, 3, false);
        }

        static void DrawMap(Node[,] map)
        {
            for(int y = 0; y < map.GetLength(0); y++)
            {
                for(int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write((map[x, y].IsWalkable ? 1 : 0) + " ");
                }

                Console.Write('\n');
            }
        }
    }
}