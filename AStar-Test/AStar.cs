using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AStar_Test
{
    public class AStar
    {
        public Node[] Path { get; private set; }

        public AStar(int[,] map, Node start, Node goal)
        {
            Path = FindOptimalPath(map, start, goal);
        }

        private Node[] FindOptimalPath(int[,] map, Node start, Node goal)
        {
            Dictionary<Node, int> visited = new Dictionary<Node, int>();
            Dictionary<Node, int> unvisited = new Dictionary<Node, int>();

            List<Node> path = new List<Node>();

            Node current = start;

            visited.Add(start, 1);

            while (current != goal)
            {
                current = goal;
            }

            return path.ToArray();
        }

        private Node FindCheapestNeighbor(int[,] map, Node current, Node goal)
        {
            Node cheapestNeighbor = null;

            foreach (Node neighbor in FindNeighbors(map, current))
            {
                if (cheapestNeighbor == null || current.EvaluateCost(goal) < cheapestNeighbor.EvaluateCost(goal))
                {
                    cheapestNeighbor = neighbor;
                }
            }

            return cheapestNeighbor;
        }

        private Node[] FindNeighbors(int[,] map, Node node)
        {
            List<Node> neighbors = new List<Node>();

            if (map.GetLength(0) - 1 != node.X)
            {
                neighbors.Add(new Node(node, node.X + 1, node.Y));
            }

            if (node.X != 0)
            {
                neighbors.Add(new Node(node, node.X - 1, node.Y));
            }

            if (map.GetLength(1) - 1 != node.Y)
            {
                neighbors.Add(new Node(node, node.X, node.Y + 1));
            }

            if (node.Y != 0)
            {
                neighbors.Add(new Node(node, node.X, node.Y - 1));
            }

            // Remove untraversable neighbors
            foreach (Node neighbor in neighbors)
            {
                if (map[neighbor.X, neighbor.Y] == 1)
                {
                    neighbors.Remove(neighbor);
                }
            }

            return neighbors.ToArray();
        }
    }
}
