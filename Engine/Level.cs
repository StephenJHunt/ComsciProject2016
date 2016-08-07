using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine
{
    public class Level
    {
        protected Level()
        {

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
        public List<Entity> entities;
    }
}
