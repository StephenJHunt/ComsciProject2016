using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComsciProject.Engine;


namespace ComsciProject.SnakeGame
{
    public class DANKMEMEException : Exception
    {
        //All done
    }
    class BodyMover : Component
    {
        List<Snake> bodyparts = new List<Snake>();
        public Direction direction;
        public BodyMover()
        {

        }

        public override void Update()
        {
            base.Update();
            switch (direction)
            {
                case Direction.Up:
                    entity.position.y--;
                    break;
                case Direction.Down:
                    entity.position.y++;
                    break;
                case Direction.Left:
                    entity.position.x--;
                    break;
                case Direction.Right:
                    entity.position.x++;
                    break;
                default:
                    throw new DANKMEMEException();
            }
            //SnakeHead movement
            foreach (Entity e in Engine.Engine.currentLevel.entities)
            {
                if(Position.isEqual(entity.position, e.position)&& e != entity)
                {
                    switch (e.name)
                    {
                        case "Food":
                            //food eating here
                            break;
                        case "Wall":
                            //wall collision
                            break;
                        case "Body":
                            //YOUR'RE EATING YOURSELF, DUMBASS
                            break;
                    }
                }

            }
        }
        public override void LateUpdate()
        {
            base.LateUpdate();
            bodyparts[bodyparts.Count-1].position = entity.position;
            Snake temp = bodyparts[bodyparts.Count - 1];
            bodyparts.RemoveAt(bodyparts.Count - 1);
            bodyparts.Insert(0, temp);
        }
    }
}
