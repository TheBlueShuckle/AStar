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
            int[,] map = {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 1, 1, 1, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 } };

            AStar aStar = new AStar(map, new Point(5, 0), new Point(0, 4));

            Console.ReadLine();
        }
    }
}
