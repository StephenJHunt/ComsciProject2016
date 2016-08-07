using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ComsciProject.Engine
{
    /// <summary>
    /// Handles world and entities, should only be initialised once.
    /// </summary>
    public static class Engine
    {
        public static Level currentLevel;
        public static Thread mainThread;
        /// <summary>
        /// Maximum number of times per second an update may be called
        /// </summary>
        public static float maxUpdateRate = 2f;
        public static void Initialize()

        {
            if (mainThread == null)
                mainThread = new Thread(GameUpdate);
            entitiesToInstantiate = new Queue<Entity>();
            LastFrame = "First Frame";
            mainThread.Start();
        }

        public static void Close()
        {
            currentLevel = null;
            entitiesToInstantiate = null;
            if (mainThread != null)
            {
                mainThread.Abort();
                mainThread = null;
            }
        }

        private static int updateNum = 0;
        public static bool renderComplete = false;

        private static void GameUpdate()
        {
            while (true)
            {
                while (!renderComplete)//gameThread waits for render to complete
                    Thread.Sleep(1);
                renderComplete = false;
                Debug.Log("GameUpdate Begin(" + updateNum++ + ")");
                //check items to run init on
                InitNewEntities();
                //run update
                foreach (Entity e in currentLevel.entities)
                {
                    e.Update();
                }
                //run late update
                foreach (Entity e in currentLevel.entities)
                {
                    e.LateUpdate();
                }
                //render
                LastFrame = RenderWorld();
                //invoke a render delegate on the UI
                //sleep until need to update again
                Thread.Sleep((int)(1000 / maxUpdateRate));
            }
        }
        /// <summary>
        /// The last update frame, the UI may render this.
        /// </summary>
        public static string LastFrame
        {
            get;
            private set;
        }

        private static string RenderWorld()
        {
            if (currentLevel == null)
                return "NO LEVEL LOADED";
            List<string> worldRender = new List<string>();//each string is row
            //Draw the blank world
            for (int y = 0; y < currentLevel.yBoundry; y++)
            {
                worldRender.Add("");
                for (int x = 0; x < currentLevel.xBoundry; x++)
                {
                    worldRender[y] += " ";
                }
            }
            //add entities to it
            foreach (Entity e in currentLevel.entities)
            {
                Debug.Log(e.name + " being rendered");
                worldRender[e.position.y].Remove(e.position.x, 1);
                worldRender[e.position.y].Insert(e.position.x, e.appearance + "");
            }
            string finalRender = "";
            foreach (string s in worldRender)
                finalRender += s + "\n";
            return finalRender;
        }

        private static void InitNewEntities()
        {
            if (currentLevel == null || entitiesToInstantiate == null || entitiesToInstantiate.Count == 0)
                return;
            while (entitiesToInstantiate.Peek() != null)
            {
                Entity e = entitiesToInstantiate.Dequeue();
                currentLevel.entities.Add(e);
            }
        }

        private static Queue<Entity> entitiesToInstantiate;
        public static Entity Instantiate(Entity e, Position p)
        {
            if (currentLevel != null)
            {
                e.position = p;
                currentLevel.entities.Add(e);
            }
            return null;
        }

        public static void Destroy(Entity e)
        {
            currentLevel.entities.Remove(e);
        }
    }
}
