using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine
{
    /// <summary>
    /// Vector in 2d space
    /// </summary>
    public struct Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
        public static Position zero = new Position(0, 0);
        public static bool isEqual(Position p1, Position p2)
        {
            if (p1.x == p2.x && p1.y == p2.y)
                return true;
            return false;
        }
    }
}
