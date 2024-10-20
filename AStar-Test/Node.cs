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
        public Node Parent { get; private set; }

        public Node(Node parent, int x, int y)
        {
            X = x;
            Y = y;
            Parent = parent;
        }

        public int[] GetPosition()
        {
            return new int[] { X, Y }; // Replace with vector2d in unity
        }

        public int EvaluateCost(Node goal)
        {
            int gCost = GetGCost(this);
            int hCost = (int)Math.Floor(Math.Sqrt(Math.Pow(X - goal.X, 2) + Math.Pow(Y - goal.Y, 2))); // get euclidian distance to goal

            return gCost + hCost;
        }

        // Untested
        private int GetGCost(Node current, int cost = 0)
        {
            if (current.Parent != null)
            {
                return GetGCost(current.Parent, cost + 1);
            }

            else
            {
                return cost;
            }
        }
    }
}
