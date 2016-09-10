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
            //simple solution of just moving each piece of the paddle in the specified direction
            switch(Input.getLastKeypress())
            {
                case Key.Left: Move(Vector2.left);break;
                case Key.Right: Move(Vector2.right);break;
            }
        }
    }
}
