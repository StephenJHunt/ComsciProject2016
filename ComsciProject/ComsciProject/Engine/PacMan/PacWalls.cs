using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//very simple, wall appearance defined in PacManLevel
namespace ComsciProject.Engine.PacMan
{
    class PacWalls : Entity
    {
        private PacWalls()
        {

        }
        public PacWalls(char appearance)
        {
            this.appearance = appearance;
        }
    }
}
