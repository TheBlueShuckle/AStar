using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AStar_Test
{
    public class Node
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsWalkable { get; private set; }
        public Node[] neighbors { get; private set; }

        public Node(int x, int y, bool isWalkable)
        {
            X = x;
            Y = y;
            IsWalkable = isWalkable;
        }

        public int[] GetPosition()
        {
            return new int[] { X, Y }; // Replace with vector2d in unity
        }

        public void FindNeighbors(Node[,] map)
        {
            List<Node> neighbors = new List<Node>();

            if (map.GetLength(0) - 1 != X)
            {
                neighbors.Add(new Node(X + 1, Y, IsWalkable));
            }

            if (X != 0)
            {
                neighbors.Add(new Node(X - 1, Y, IsWalkable));
            }

            if (map.GetLength(1) - 1 != Y)
            {
                neighbors.Add(new Node(X, Y + 1, IsWalkable));
            }

            if (Y != 0)
            {
                neighbors.Add(new Node(X, Y - 1, IsWalkable));
            }

            this.neighbors = neighbors.ToArray();
        }

        public int EvaluateCost(Node goal)
        {
            int gCost = 1;
            int hCost = (int)Math.Sqrt(Math.Pow(X - goal.X, 2) + Math.Pow(Y - goal.Y, 2));

            return gCost + hCost;
        }
    }
}
