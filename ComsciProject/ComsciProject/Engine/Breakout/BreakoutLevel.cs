using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine.Breakout
{

    public class BreakoutLevel : Level
    {

        public List<Entity> paddle = new List<Entity>();
        public BreakoutLevel()
        {
            this.xBoundry = 20;
            this.yBoundry = 20;
            entities = new List<Entity>();
        }

        public override void InstantiateFirstFrameEntities()
        {
            makePaddle();
            makeWalls();
        }

        private void makePaddle()
        {
            //spawning each paddle piece. TODO adjust positions
            Engine.SpawnEntity(new BreakoutPaddle(), new Vector2(10, 16));
            Engine.SpawnEntity(new BreakoutPaddle(), new Vector2(11, 16));
            Engine.SpawnEntity(new BreakoutPaddle(), new Vector2(12, 16));
        }

        //Creating walls, ripped from example
        private void makeWalls()
        {
            for (int y = 0; y < yBoundry; y++)
            {
                for (int x = 0; x < xBoundry; x++)
                {
                    if (y == 0 || y == yBoundry - 1)
                    {
                        Engine.SpawnEntity(new BreakoutWall('='), new Vector2(x, y));
                    }
                    else
                        break;
                }
                if (y == 0 || y == yBoundry - 1)
                {
                    Engine.SpawnEntity(new BreakoutWall('+'), new Vector2(0, y));
                    Engine.SpawnEntity(new BreakoutWall('+'), new Vector2(xBoundry - 1, y));
                }
                else
                {
                    Engine.SpawnEntity(new BreakoutWall('|'), new Vector2(0, y));
                    Engine.SpawnEntity(new BreakoutWall('|'), new Vector2(xBoundry - 1, y));
                }
            }
        }
    }
}
