using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine.Breakout
{
    class BreakoutBall: Entity
    {
        public BreakoutBall()
        {
            appearance = 'o';
            descName = "Breakout ball";
            direction = new Vector2(1, 1);
        }

        public override void Update()
        {
            Vector2 newpos = position + direction;
            List<Entity> entities = Engine.currentLevel.entities;
            foreach(Entity e in entities)
            {
                #region BorderChecks
                if (e.position == newpos && e.appearance == '|')
                {
                    direction.x *= -1;
                    Move(direction);
                    return;
                }
                if (e.position == newpos && e.appearance == '=')
                {
                    direction.y *= -1;
                    Move(direction);
                    return;
                }
                if (e.position == newpos && e.appearance == '+')
                {
                    direction.y *= -1;
                    direction.x *= -1;
                    Move(direction);
                    return;
                } 
                #endregion

                if (e.position == newpos && e.appearance == '*')
                {
                    Move(direction);
                    direction.y *= -1;
                    e.appearance = ' ';
                    return;
                }
            }
            Move(direction);
        }
    }
}
