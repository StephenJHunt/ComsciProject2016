using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine.PacMan
{
    class PacManLevel : Level
    {
        public PacManLevel()
        {
            xBoundry = 38;
            yBoundry = 21;
            entities = new List<Entity>();
        }

        public override void InstantiateFirstFrameEntities()
        {
            makeWalls();
            spawnPlayer();
        }

        private void spawnPlayer()
        {
            Engine.SpawnEntity(new PacManPlayer(), new Vector2(18, 15));
        }

        private void makeWalls()
        {
            //string array representing map
            //Way easier than doing each char separately
            //Double x length just to retain ratio - TODO make sure x movement is double y movement
            string[] map =
            {
                "######################################",
                "##* * * * * * * * ##* * * * * * * * ##",
                "##* ####* ######* ##  ######* ####* ##",
                "##* * * * * * * * * * * * * * * * * ##",
                "##* ####* ##* ##########* ##* ####* ##",
                "##* * * * ##* * * ##* * * ##* * * * ##",
                "########* ######* ##* ######* ########",
                "      ##* ##* * * * * * * ##* ##      ",
                "      ##* ##* ####  ####* ##* ##      ",
                "      ##* * * ##      ##* * * ##      ",
                "      ##* ##* ##########* ##* ##      ",
                "      ##* ##* * * * * * * ##* ##      ",
                "########* ##* ##########* ##* ########",
                "##* * * * * * * * ##* * * * * * * * ##",
                "##* ####  ######  ##  ######  ####* ##",
                "##* * ##* * * * *   * * * * * ##* * ##",
                "####* ##* ##* ##########* * * ##* ####",
                "##* * * * ##* * * ##* * * ##* * * * ##",
                "##* ############* ##* ############* ##",
                "##* * * * * * * * * * * * * * * * * ##",
                "######################################",
            };

            //creating entities
            //still need to work on this for food to work properly
            //need to fix slowness
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x] != ' ' && map[y][x] != '*')
                    {
                        Engine.SpawnEntity(new PacWalls(map[y][x]), new Vector2(x, y));
                    }
                }
            }
        }
    }
}
