using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AStar_Test
{
    public class AStar
    {
        public Point[] Path { get; private set; }

        public AStar(int[,] map, Point start, Point goal)
        {
        }

        private Point[] FindOptimalPath(int[,] map, Point start, Point goal)
        {
            Dictionary<Point, int> close = new Dictionary<Point, int>();
            List<Point> open = new List<Point>();
            Point current = start;

            close.Add(start, 1);

            while (current != goal)
            {

            }

            return null;
        }

        private Point[] GetNeighbors(int[,] map, Point point)
        {
            List<Point> neighbors = new List<Point>();

            if (map.GetLength(0) - 1 != point.X)
            {
                neighbors.Add(new Point(point.X + 1, point.Y));
            }

            if (point.X != 0)
            {
                neighbors.Add(new Point(point.X - 1, point.Y));
            }

            if (map.GetLength(1) - 1 != point.Y)
            {
                neighbors.Add(new Point(point.X, point.Y + 1));
            }

            if (point.Y != 0)
            {
                neighbors.Add(new Point(point.X, point.Y -  1));
            }

            return neighbors.ToArray();
        }
    }
}
