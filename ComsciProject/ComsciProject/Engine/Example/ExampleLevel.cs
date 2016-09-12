using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine.Example
{
    public class ExampleLevel : Level
    {

        public ExampleLevel()
        {
            xBoundry = 50;
            yBoundry = 40;
            entities = new List<Entity>();
        }

        public override void InstantiateFirstFrameEntities()
        {
            //make walls
            makeWalls();
            //add the player entity
            addPlayer();
        }

        private void makeWalls()//good practice to keep methods the public doesnt need - private 
        {
            //fill the edges of the world with walls
            //our parametised constructor in entity allows us to make the top and side walls different
            for (int y = 0; y < yBoundry; y++)
            {
                for (int x = 0; x < xBoundry; x++)
                {
                    if (y == 0 || y == yBoundry - 1)
                    {
                        Engine.SpawnEntity(new ExampleWall('='), new Vector2(x, y));
                    }
                    else
                        break;
                }
                if (y == 0 || y == yBoundry - 1)
                {
                    Engine.SpawnEntity(new ExampleWall('+'), new Vector2(0, y));
                    Engine.SpawnEntity(new ExampleWall('+'), new Vector2(xBoundry - 1, y));
                }
                else
                {
                    Engine.SpawnEntity(new ExampleWall('|'), new Vector2(0, y));
                    Engine.SpawnEntity(new ExampleWall('|'), new Vector2(xBoundry - 1, y));
                }
            }
        }

        private void addPlayer()
        {
            Engine.SpawnEntity(new ExamplePlayer(), new Vector2(xBoundry / 2, yBoundry / 2));
        }
    }
}