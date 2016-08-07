using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject.Engine
{
    /// <summary>
    /// All components must be added to an entity before it is run
    /// </summary>
    public abstract class Component
    {
        public void Initialise(Entity e)
        {
            if (entity != null)
                return;
            entity = e;
            Init();
        }
        public Entity entity
        {
            get;
            protected set;
        }
        public virtual void Init()
        {
            //Run once Entity.Insantiate is called
        }
        public virtual void Update()
        {

        }
        public virtual void LateUpdate()
        {

        }
    }
}
