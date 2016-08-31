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
            Move(new Vector2(1, 0));
        }

        public override void LateUpdate()
        {
            //Move(new Vector2(1, 0)); <- this makes it move 2 times in one 'update'
            //this is not desired behaviour, rather use
            //Move(new Vector2(2,0));
            //or if you're fancy
            //Move(Vector2.right*2);
        }
    }
}
