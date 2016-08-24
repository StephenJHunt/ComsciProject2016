using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine.Example
{
    class ExamplePlayer : Entity
    {
        //Use default constructor as we need no parameters
        public ExamplePlayer()
        {
            appearance = '#';
            descName = "Player";
        }
        //Override Update() so we can move the player every frame
        public override void Update()
        {
            //Move the player
            Move(new Vector2(1, 0));
        }
        //Check if the player is hitting a wall
        public override void LateUpdate()
        {

        }
    }
}
