using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ComsciProject
{
    public class SnakeGame
    {
        public static int updateRate = 1; //times per second to update gamestate
        public static World world;
        private static Thread gameThread;
        public static void Input(int direction)
        {
            switch (direction)
            {
                case 0:
                    if (world.snake.moveDirection != 2) { world.snake.moveDirection = 0; }
                    break;
                case 1:
                    if (world.snake.moveDirection != 0) { world.snake.moveDirection = 2; }
                    break;
                case 2:
                    if (world.snake.moveDirection != 3) { world.snake.moveDirection = 1; }
                    break;
                case 3:
                    if (world.snake.moveDirection != 1) { world.snake.moveDirection = 3; }
                    break;
            }
        }
        public static void StartGame()
        {
            Debug.Log("Starting Game");
            world = new World();
            world.createWorld(60, 60);
            gameThread = new Thread(DoUpdate);
            gameThread.Start();
        }
        public static void DoUpdate()
        {
            Debug.Log("Game Thread Started");
            int frames = 0;
            while (true)
            {
                Debug.Log("Game Thread Update " + frames++ + " begin");
                world.Update();
                Render();
                Thread.Sleep(1000 / updateRate);
            }
        }
        public static void GameOver()
        {
            Debug.Log("Game Over");
            //gameThread.Abort();
            Console.Read();
        }
        public static void Render()
        {
            /*
            Console.Clear();
            Debug.Log("Begin Render");
            string finalRender = "";
            char[,] render = world.RenderWorld();
            for (int y = 0; y < render.GetLength(1); y++)
            {
                for (int x = 0; x < render.GetLength(0); x++)
                {
                    finalRender += render[y, x];
                }
                finalRender += '\n';
            }
            Console.WriteLine(finalRender);
            Debug.Log("End Render");
            */
            Debug.Log("Begin Render");
            string finalRender = "";
            char[,] render = world.RenderWorld();
            for (int y = 0; y < render.GetLength(1); y++)
            {
                for (int x = 0; x < render.GetLength(0); x++)
                {
                    finalRender += render[y, x];
                }
                finalRender += '\n';
            }
            screen = finalRender;
            Debug.Log("End Render");
            MainWindow.instance.Render();
        }
        public static string screen = "";
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
        }
        public class Snake
        {
            public Snake(Position startPos)
            {
                Debug.Log("Snake created");
                body = new List<Position>();
                body.Add(startPos);
                body.Add(new Position(startPos.x - 1, startPos.y));
                body.Add(new Position(startPos.x - 2, startPos.y));
                body.Add(new Position(startPos.x - 3, startPos.y));
            }
            public List<Position> body
            {
                get;
                private set;
            }
            public int moveDirection = 2;//left - 0, up - 1, right - 2, down - 3
            public char headChar = '#';
            public char bodyChar = '0';
            public void UpdatePosition()
            {
                Debug.Log("Snake Update Begin");
                Position tail = body[body.Count - 1];//move tail to head + move
                if (body.Count > 1)
                {
                    switch (moveDirection)
                    {
                        case 0://left
                            {
                                tail.x = body[0].x - 1;
                                tail.y = body[0].y;
                                break;
                            }
                        case 1://up
                            {
                                tail.x = body[0].x;
                                tail.y = body[0].y - 1;
                                break;
                            }
                        case 2://right
                            {
                                tail.x = body[0].x + 1;
                                tail.y = body[0].y;
                                break;
                            }
                        case 3://down
                            {
                                tail.x = body[0].x;
                                tail.y = body[0].y + 1;
                                break;
                            }
                    }
                    //gameovercheck
                    body.RemoveAt(body.Count - 1);
                    Debug.Log(!isOnSnake(tail) + " : " + !world.IsInWorld(tail));
                    if (!isOnSnake(tail) || !world.IsInWorld(tail))
                        GameOver();
                    body.Insert(0, tail);
                }
                else
                {
                    switch (moveDirection)
                    {
                        case 0://left
                            {
                                tail.x = tail.x - 1;
                                break;
                            }
                        case 1://up
                            {
                                tail.y = tail.y - 1;
                                break;
                            }
                        case 2://right
                            {
                                tail.x = tail.x + 1;
                                break;
                            }
                        case 3://down
                            {
                                tail.y = tail.x + 1;
                                break;
                            }
                    }
                    body[0] = tail;
                }
                Debug.Log("Snake Update End: " + body[0]);
            }
            public bool isOnSnake(Position p)
            {
                return !body.Contains(p);
            }
        }
        public class World
        {
            public World()
            {
                foodPositions = new List<Position>();
                snake = new Snake(new Position(30, 30));//make this var based
            }
            public char[,] world
            {
                get;
                private set;
            }
            public int width
            {
                get;
                private set;
            }
            public int height
            {
                get;
                private set;
            }

            public void createWorld(int width, int height)
            {
                char wall = '+';
                char space = ' ';
                this.width = width;
                this.height = height;
                world = new char[height, width];
                for (int iy = 0; iy < height; iy++)
                {
                    for (int ix = 0; ix < width; ix++)
                    {
                        world[iy, ix] = (ix == 0 || ix == width - 1) ? wall : (iy == 0 || iy == height - 1) ? wall : space;//put extra case for horizontal walls
                    }
                }
            }
            public Snake snake
            {
                get;
                private set;
            }
            public List<Position> foodPositions
            {
                get;
                private set;
            }

            public char foodChar = '*';
            public void SpawnFood()
            {
                Position pos = new Position(0, 0);
                while (!IsInWorld(pos) && !snake.isOnSnake(pos))
                {
                    Random rnd = new Random();
                    pos.x = rnd.Next(width);
                    pos.y = rnd.Next(height);
                }
                foodPositions.Add(pos);
            }

            public void Update()
            {
                Debug.Log("World Update");
                if (foodPositions.Count == 0)
                    SpawnFood();
                snake.UpdatePosition();
            }
            public bool IsInWorld(Position p)
            {
                if (p.x != 0 && p.y != 0 && p.x < width && p.y < height)//if this check passses its in world
                    return true;
                return false;
            }
            public char[,] RenderWorld()
            {
                char[,] render = new char[height, width];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        render[y, x] = world[y, x];
                    }
                }
                foreach (Position p in foodPositions)
                {
                    render[p.y, p.x] = foodChar;
                }
                for (int i = 0; i < snake.body.Count; i++)
                {
                    render[snake.body[i].y, snake.body[i].x] = (i == 0) ? snake.headChar : snake.bodyChar;
                }
                return render;
            }
        }
    }
}