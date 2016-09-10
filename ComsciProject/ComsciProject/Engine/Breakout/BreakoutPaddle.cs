using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComsciProject.Engine.Breakout
{
    public class BreakoutPaddle : Entity
    {
        public BreakoutPaddle()
        {
            appearance = '=';
            descName = "Paddle piece";
        }

        public override void Update()
        {
            List<Entity> entities = Engine.currentLevel.entities;
            string pos = "";
            bool move = false;
            //Since a new List would be very bothersome to make, this checks which position of the paddle the entity
            //is in, only loops through the first three entities because these were the first three to be declared
            for (int k = 0; k < 3; k++)
            {
                if (entities[k].position == this.position)
                {
                    if (k == 0)
                    {
                        pos = "left";
                    }
                    if (k == 1)
                    {
                        pos = "middle";
                    }
                    if (k == 2)
                    {
                        pos = "right";
                    }
                }
            }
            //simple solution of just moving each piece of the paddle in the specified direction
            switch(Input.getLastKeypress())
            {
                case Key.Left:
                    move = false;
                    switch (pos)
                    {
                        case "left": if (this.position.x > 1) move = true; break;
                        case "middle": if (this.position.x > 2) move = true; break;
                        case "right": if (this.position.x > 3) move = true; break;
                    }
                    if (move)
                        Move(Vector2.left);
                    break;
                case Key.Right:
                    move = false;
                    switch (pos)
                    {
                        case "left": if (this.position.x < 16) move = true; break;
                        case "middle": if (this.position.x < 17) move = true; break;
                        case "right": if (this.position.x < 18) move = true; break;
                    }
                    if (move)
                        Move(Vector2.right);
                    break;
            }
        }
    }
}
