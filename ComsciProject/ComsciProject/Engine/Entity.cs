using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine
{
    /// <summary>
    /// Describes a 'GameObject', an object which is present in the game world.
    /// </summary>

    public abstract class Entity
    {
        /// <summary>
        /// Unique Integer assigned by the Engine which identifies this Entity. 
        /// </summary>
        public int instanceID;
        /// <summary>
        /// A short descriptive name for the object, this only serves to easily identify objects for debug
        /// </summary>
        public string descName;
        /// <summary>
        /// Describes Entity's position in the world space relative to the origin
        /// </summary>
        public Vector2 position;
        /// <summary>
        /// A character which will be displayed at the entity's position when the frame is rendered
        /// </summary>
        public char appearance;
        /// <summary>
        /// If disabled an Entity will not receive any Init, Update, or LateUpdate calls
        /// </summary>
        public bool enabled = true;
        /// <summary>
        /// Dictates if an Entity has been 'destroyed', as references to it may persist even after being removed from the game world
        /// </summary>
        public bool destroyed = false;
        /// <summary>
        /// Vector that describes the direction the entity is moving in
        /// </summary>
        public Vector2 direction;
        #region Helper Methods
        /// <summary>
        /// Move the entity the specified Cartesian Vector
        /// </summary>
        /// <param name="translation">A Cartesian Vector describing the required translation</param>

        public void Move(Vector2 translation)
        {
            position.x += translation.x;
            position.y += translation.y;
        }
        /// <summary>
        /// Simplification of Move(Vector2 translation)
        /// </summary>
        /// <param name="direction">Direction to move in</param>
        /// <param name="distance">Distance in units to move</param>

        public void MoveLinear(Direction direction, int distance)
        {
            switch(direction)
            {
                case Direction.Up:
                    {
                        position.y--;
                        break;
                    }
                case Direction.Down:
                    {
                        position.y++;
                        break;
                    }
                case Direction.Left:
                    {
                        position.y++;
                        break;
                    }
                case Direction.Right:
                    {
                        position.x++;
                        break;
                    }
            }
        }
        #endregion
        #region MainThread Methods
        /// <summary>
        /// Called when the Entity is added to the game world
        /// </summary>

        public virtual void Init()
        {

        }
        /// <summary>
        /// Called every Frame
        /// </summary>

        public virtual void Update()
        {
            
        }
        /// <summary>
        /// Called every frame after Update()
        /// </summary>

        public virtual void LateUpdate()
        {
           
        }
        #endregion
    }
}