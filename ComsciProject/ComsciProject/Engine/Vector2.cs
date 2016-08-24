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
        public static bool operator == (Vector2 a, Vector2 b)
        {
            //check its not the same object
            if (System.Object.ReferenceEquals(a, b))
                return true;
            //check if null is involved, cast to object to prevent infinite loops (circular calls)
            if ((object)a == null || (object)b == null)
            {
                if ((object)a == null && (object)b == null)
                    return true;
                else
                    return false;
            }
            else
            {
                //we're sure there are no nulls
                //check the values and make equation conclusions from there
                return a.x == b.x && a.y == b.y;
            }
        }
        public static bool operator != (Vector2 a, Vector2 b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static Vector2 operator + (Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static Vector2 operator - (Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        public int compareTo(Vector2 other)
        {
            return (this.x - other.x + this.y - other.y);
        }
    }
}
