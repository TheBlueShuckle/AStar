using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar_Test
{
    public class Point
    {
        public int X {
            get; private set;
        }

        public int Y
        {
            get; private set;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int[] GetPoint()
        {
            return new int[] { X, Y };
        }
    }
}
