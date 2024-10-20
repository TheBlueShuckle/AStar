using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
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
            List<Node> unvisited = new List<Node>(); // nodes to be evaluated
            List<Node> visited = new List<Node>(); // nodes already evaluated

            Node[] path;

            Node current = start;

            unvisited.Add(start);

            while (current != goal)
            {
                unvisited.Sort((x, y) => x.EvaluateCost(goal).CompareTo(y.EvaluateCost(goal)));
                current = unvisited[0];

                Console.WriteLine(current.X + ", " + current.Y);

                unvisited.Remove(current);
                visited.Add(current);

                foreach (Node neighbor in FindNeighbors(map, current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        if (neighbor.EvaluateCost(goal) < current.EvaluateCost(goal) || !unvisited.Contains(neighbor))
                        {
                            if (!unvisited.Contains(neighbor))
                            {
                                unvisited.Add((neighbor));
                            }
                        }
                    }
                }
            }

            path = SetPath(current);

            return path;
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

            // Remove non-traversable neighbors
            foreach (Node neighbor in neighbors.ToList())
            {
                if (map[neighbor.X, neighbor.Y] == 1)
                {
                    neighbors.Remove(neighbor);
                }
            }

            return neighbors.ToArray();
        }

        private Node[] SetPath(Node current)
        {
            List<Node> path = new List<Node>();

            path.Add(current);

            if (current.Parent != null)
            {
                path.AddRange(SetPath(current.Parent));
            }

            return path.ToArray();
        }
    }
}
