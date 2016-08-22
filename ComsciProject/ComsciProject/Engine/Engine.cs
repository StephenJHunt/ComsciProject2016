using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
/*
A short summary of a typical game cycle:
1. Engine.Initialize is called, the mainThread is started.
2. The mainThead runs GameUpdate() and waits for renderComplete to be true 
(set by the wpf form once it has copied the LastFrame variable)
3. The mainThread adds all new entities added in the last frame (or all entities for the first frame)
to the game world, and runs Entity.Init() on each of them.
4. Update is called on all Entities in the game world
5. LateUpdate is called on all Entities in the game world
6. A 2d char array is created based on currentLevel's boundaries and it is populated with whitespaces
7. The mainThread goes through the entities in the currentLevel and sets the corresponding position
(Entity.position -> char array position) in the char array to the value of Entity.appearance.
8. The mainThread sets LastFrame to the string equivalent of the char array, and sets renderComplete to true,
before sleeping for 1000/updateRate. The cycle repeats from 2. until Engine.Close() is called. 
*/
namespace ComsciProject.Engine
{
    /// <summary>
    /// Handles world and entities, should only be initialised once.
    /// </summary>
    public static class Engine
    {
        /// <summary>
        /// The currently loaded/active game world
        /// </summary>
        public static Level currentLevel;
        /// <summary>
        /// Thread on which the game loop runs
        /// </summary>
        public static Thread mainThread;
        /// <summary>
        /// Maximum number of times per second an update may be called
        /// </summary>
        public static float maxUpdateRate = 2f;
        /// <summary>
        /// Start the game engine loop
        /// </summary>
        public static void Initialize()
        {
            if (mainThread == null)
                mainThread = new Thread(GameUpdate);
            entitiesToInstantiate = new Queue<Entity>();
            LastFrame = "First Frame";
            mainThread.Start();
            currentLevel?.InstantiateFirstFrameEntities();
        }
        /// <summary>
        /// End the game engine loop, closing all relevant threads
        /// </summary>
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
        /// <summary>
        /// Used for debugging
        /// </summary>
        private static int updateNum = 0;
        /// <summary>
        /// Called by the renderer to tell the mainThread that it can render the next frame
        /// </summary>
        public static bool renderComplete = false;
        /// <summary>
        /// This method is run on the mainThread, it runs the entire gameloop logic, including Init(), Update() and LateUpdate() - on all entities in the currentLevel
        /// </summary>
        private static void GameUpdate()
        {
            while (true)
            {
                while (!renderComplete)//gameThread waits for render to complete
                    Thread.Sleep(1);
                if (currentLevel == null)
                {
                    Debug.LogError("No Level specified, exiting...");
                    Close();
                }
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
                Thread.Sleep((int)(1000 / maxUpdateRate));//this should technically be the difference since frame last rendered and this render in ms, but will be fine for now.
            }
        }
        /// <summary>
        /// The last update frame, the UI will render this
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
            List<StringBuilder> worldRender = new List<StringBuilder>();//each string is row
            //Draw the blank world
            for (int y = 0; y < currentLevel.yBoundry; y++)
            {
                worldRender.Add(new StringBuilder(currentLevel.xBoundry));
                for (int x = 0; x < currentLevel.xBoundry; x++)
                {
                    worldRender[y].Append(" ");
                }
            }
            //add entities to it
            foreach (Entity e in currentLevel.entities)
            {
                Debug.Log(e.instanceID + "("+e.descName+") being rendered");
                worldRender[e.position.y][e.position.x] = e.appearance;
            }
            string finalRender = "";
            foreach (StringBuilder s in worldRender)
                finalRender += s.ToString() + "\n";
            return finalRender;
        }
        /// <summary>
        /// Counter used to create IDs
        /// </summary>
        private static int idCounter = 0;
        /// <summary>
        /// Run Init on entities added in the last frame and add them to the gameworld
        /// </summary>
        private static void InitNewEntities()
        {
            //if there are entities to instantiate
            if (currentLevel == null || entitiesToInstantiate == null || entitiesToInstantiate.Count == 0)
                return;
            while (entitiesToInstantiate.Count > 0 && entitiesToInstantiate?.Peek() != null)
            {
                Entity e = entitiesToInstantiate.Dequeue();
                e.instanceID = idCounter++;//set the object ID
                e.Init();
                e.enabled = true;//enable it
                e.destroyed = false;//make sure its not destroyed
                currentLevel.entities.Add(e);
            }
        }
        /// <summary>
        /// Queue = Add-Time-Ordered list -- lists the entities that need to be added to the game world at the beginning of the next frame
        /// </summary>
        private static Queue<Entity> entitiesToInstantiate;
        /// <summary>
        /// Add a specified entity to the game world at the start of the next frame, at the given position-- NOTE: THE ENTITY IS NOT ADDED TO THE GAMEWORLD UNTIL THE START OF THE NEXT FRAME
        /// </summary>
        /// <param name="e">The entity to add</param>
        /// <param name="p">The desired position of the entity</param>
        /// <returns>A reference to the entity -- NOTE: THE ENTITY IS NOT ADDED TO THE GAMEWORLD UNTIL THE START OF THE NEXT FRAME</returns>
        public static Entity Instantiate(Entity e, Vector2 p)
        {
            //make sure the game world exists
            if (currentLevel != null)
            {
                e.position = p;//set the position
                entitiesToInstantiate.Enqueue(e);//add the entity to the instantiation queue
                return e;//return the entity
            }
            return null;
        }

        public static void Destroy(Entity e)
        {
            currentLevel.entities.Remove(e);
            e.destroyed = true;
            e.enabled = false;
        }
    }
}
