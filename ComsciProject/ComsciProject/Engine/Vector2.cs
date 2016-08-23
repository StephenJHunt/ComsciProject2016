using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine
{
    /// <summary>
    /// Cartesian Vector in 2 dimensions
    /// </summary>
    public struct Vector2
    {
        public int x;
        public int y;
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
        public static readonly Vector2 zero = new Vector2(0, 0);
        public static readonly Vector2 up = new Vector2(0, -1);
        public static readonly Vector2 down = new Vector2(0, 1);
        public static readonly Vector2 left = new Vector2(-1, 0);
        public static readonly Vector2 right = new Vector2(1, 0);

        public static bool isEqual(Vector2 p1, Vector2 p2)
        {
            if (p1.x == p2.x && p1.y == p2.y)
                return true;
            return false;
        }
        public int compareTo(Vector2 other)
        {
            return (this.x - other.x + this.y - other.y);
        }
    }
}
