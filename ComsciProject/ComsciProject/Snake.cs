using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ComsciProject
{
    public class Snake
    {
        protected struct Loc
        {
            public int X;
            public int Y;

            public Loc(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        private static Thread thread;
        private static int score;
        private static List<Loc> snake;
        private static char direction;
        static void Restart()
        {
            thread.Suspend();
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("Press y to try again");
            string s = Console.ReadLine();
            if (s == "y")
            {
                //Snake();
            }
        }
    }
}
