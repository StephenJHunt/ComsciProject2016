using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    struct Loc
    {
        public int X;
        public int Y;

        public Loc(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    class Program
    {

        static void Restart()
        {

        }

        static void Main(string[] args)
        {
            Snake();
        }
        static Thread thread = new Thread(Move);
        static List<Loc> snake = new List<Loc>();
        static string direction;
        static Loc star = new Loc(20, 16);
        static string[] scoreboard = {
        "XXXX                                                                            ",
        "X99X                                                                            ",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "X                                                                              X",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"};
                                        
        public static void Snake()
        {
            snake.Clear();
            Console.CursorVisible = false;
            Loc head = new Loc(40, 12);
            snake.Add(head);
            direction = "R";
            thread.IsBackground = true;
            thread.Start();
            Input();
        }

        public static void Input()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (direction != "D") { direction = "U"; } break;
                    case ConsoleKey.DownArrow:
                        if (direction != "U") { direction = "D"; } break;
                    case ConsoleKey.LeftArrow:
                        if (direction != "R") { direction = "L"; } break;
                    case ConsoleKey.RightArrow:
                        if (direction != "L") { direction = "R"; } break;
                }
            }
        }

        public static void Move()
        {
            bool run = true;
            Console.WindowWidth = 80;
            Console.WindowHeight = 26;
            Loc last = new Loc();
            Console.SetCursorPosition(0, 0);
            foreach(string s in scoreboard)
            {
                Console.Write(s);
            }
            while (run)
            {
                var next = snake[0];

                switch (direction)
                {
                    case "R":
                        if (next.X < 79)
                        {
                            next.X++;
                        }
                        break;
                    case "L":
                        if (next.X > 0)
                        {
                            next.X--;
                        }
                        break;
                    case "U":
                        if (next.Y > 3)
                        {
                            next.Y--;
                        }
                        break;
                    case "D":
                        if (next.Y < 24)
                        {
                            next.Y++;
                        }
                        break;
                }
                //Console.Clear();

                //Console.SetCursorPosition(0, 0);
                //foreach (string s in scoreboard)
                //{
                //Console.Write(s);
                //}

                last = snake.Last();
                Console.SetCursorPosition(last.X, last.Y);
                Console.Write(" ");

                Console.SetCursorPosition(next.X, next.Y);
                Console.Write("x");

                foreach (Loc loc in snake)
                {
                    //Console.SetCursorPosition(loc.X, loc.Y);
                    //Console.Write("x");
                    if (next.X == loc.X && next.Y == loc.Y)
                    {
                        run = false;
                    }
                }
                snake.Insert(0, next);

                if (snake[0].X == star.X && snake[0].Y == star.Y)
                {
                    bool good = false;
                    while (good == false)
                    {
                        Random ran = new Random();
                        star.X = ran.Next(0, 80);
                        star.Y = ran.Next(3, 25);

                        if (scoreboard[star.Y][star.X] == 'X')
                        {
                            continue;
                        }

                        foreach(Loc loc in snake)
                        {
                            if(star.X != loc.X && star.Y != loc.Y)
                            {
                                good = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    snake.RemoveAt(snake.Count - 1);
                }
                Console.SetCursorPosition(star.X, star.Y);
                Console.Write("*");
                if (scoreboard[next.Y][next.X] == 'X')
                {
                    run = false;
                }
                Console.SetCursorPosition(30, 0);
                Thread.Sleep(150);
            }
            Restart();
        }
    }
}
