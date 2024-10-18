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

        public AStar(Node[,] map, Node start, Node goal)
        {
            Path = FindOptimalPath(map, start, goal);
        }

        private Node[] FindOptimalPath(Node[,] map, Node start, Node goal)
        {
            Dictionary<Node, int> visited = new Dictionary<Node, int>();
            Dictionary<Node, int> unvisited = new Dictionary<Node, int>();

            List<Node> path = new List<Node>();

            Node current = start;

            visited.Add(start, 1);

            while (current != goal)
            {
                FindCheapestNeighbor(start, goal);
            }

            return path.ToArray();
        }

        private Node FindCheapestNeighbor(Node current, Node goal)
        {
            Node cheapestNeighbor = null;

            foreach (Node neighbor in current.neighbors)
            {
                if (cheapestNeighbor == null || current.EvaluateCost(goal) < cheapestNeighbor.EvaluateCost(goal)) {
                    cheapestNeighbor = neighbor;
                }
            }

            return cheapestNeighbor;
        }
    }
}
