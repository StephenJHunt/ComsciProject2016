using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine
{
    /// <summary>
    /// Represents a game world, defines it's boundries, and stores a list of all functioning entities
    /// </summary>
    public abstract class Level
    {
        protected Level()
        {
            //Reserve it so only children can implement it publically
        }

        public Level(int xBoundry, int yBoundry)
        {
            this.xBoundry = xBoundry;
            this.yBoundry = yBoundry;
            entities = new List<Entity>();
        }

        public int xBoundry
        {
            get;
            protected set;
        }

        public int yBoundry
        {
            get;
            protected set;
        }
        /// <summary>
        /// Creates all the entities needed for the first frame
        /// </summary>

        public virtual void InstantiateFirstFrameEntities()
        { }
        /// <summary>
        /// Checks if a specified position in the gameworld has no entities, returns true if no entities occupy the position.
        /// </summary>
        /// <param name="position">Position to check in world space</param>
        /// <returns>True if empty, false if one or more entities occupy the same space</returns>

        public bool CheckClear(Vector2 position)
        {
            return entities.Find(x => x.position.compareTo(position) == 0) == null;
        }
        /// <summary>
        /// Checks position clear, if an entity is found, the first entity is parsed to out
        /// </summary>
        /// <param name="position">Position to check in world space</param>
        /// <param name="firstEntity">value of first entity</param>
        /// <returns></returns>

        public bool CheckClear(Vector2 position, out Entity firstEntity)
        {
            firstEntity = entities.Find(x => x.position.compareTo(position) == 0);
            return firstEntity == null;
        }
        /// <summary>
        /// Checks position clear, returns all found entities in the entities field
        /// </summary>
        /// <param name="position"></param>
        /// <param name="entities"></param>
        /// <returns></returns>

        public bool CheckClear(Vector2 position, out Entity[] entities)
        {
            entities = this.entities.FindAll(x => x.position.compareTo(position) == 0).ToArray();
            return entities == null ;
        }
        /// <summary>
        /// Returns if the position is in the world's bounds
        /// </summary>
        /// <param name="position">Position to be tested</param>
        /// <returns>True if the position is in the worlds bounds, false if otherwise</returns>

        public bool positionInBounds(Vector2 position)
        {
            if (position.x < 0 || position.y < 0 ||
                position.x > xBoundry - 1 || position.y > yBoundry - 1)
                return false;
            return true;
        }

        public List<Entity> entities
        {
            get;
            protected set;
        }
    }
}
