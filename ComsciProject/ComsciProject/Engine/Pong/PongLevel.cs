using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine.Pong
{
    class PongLevel:Level
    {
        public PongLevel()
        {
            this.xBoundry = 50;
            this.yBoundry = 40;
            entities = new List<Entity>();
        }
    }
}
