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
        public List<Entity> entities;
    }
}
