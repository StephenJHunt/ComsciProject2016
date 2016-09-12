using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine.Pong
{
    class PongPaddle:Entity
    {
        public PongPaddle()
        {
            appearance = '=';
            descName = "Paddle segment";
        }
    }
}
