using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine
{
    public class Entity
    {
        protected Entity()
        {
            //Reserve the default constructor
        }
        public Entity(string name, char appearance, Position p)
        {
            this.name = name;
            this.components = new List<Component>();
            this.appearance = appearance;
        }
        public Entity(string name, List<Component> components, char appearance)
        {
            this.name = name;
            this.components = components;
            this.appearance = appearance;
            foreach(Component c in components)
            {
                c.Initialise(this);//Need to call this to link entity to componenet
            }
        }
        /// <summary>
        /// Entity's Position in WorldSpace
        /// </summary>
        public Position position;
        /// <summary>
        /// List of components on an Entity. Adding to this list after an entity has been instantiated may cause unexpected behaviour
        /// </summary>
        public List<Component> components;
        public string name;
        public void Init()
        {
            foreach(Component c in components)
            {
                c.Init();
            }
        }
        public void Update()
        {
            foreach (Component c in components)
            {
                c.Update();
            }
        }
        public void LateUpdate()
        {
            foreach (Component c in components)
            {
                c.LateUpdate();
            }
        }
        public char appearance;
    }
}
