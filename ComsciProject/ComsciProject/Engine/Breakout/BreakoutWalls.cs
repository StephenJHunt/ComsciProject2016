using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine.Breakout
{
    public class BreakoutWall : Entity
    {
        //walls for breakout, ripped from example
        public BreakoutWall(char appearance)
        {
            this.appearance = appearance;
        }
    }
}
