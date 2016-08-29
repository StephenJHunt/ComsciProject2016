using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine.PacMan
{
    //Controllable character
    class PacManPlayer : Entity
    {
        public PacManPlayer()
        {
            appearance = 'C';
            descName = "Pac-Man";
        }
        //Moves very slowly, not sure why
        public override void Update()
        {
            Move(new Vector2(2, 0));
        }
    }
}
