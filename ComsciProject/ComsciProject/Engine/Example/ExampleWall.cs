using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Just an interesting note:  "public ExampleWall(char appearance) : base()" means the code in the Entity() 
    constructor will be subbed into our ExampleWall(char appearance) function before the code we've specified here. ie.
    {<Entity constructor code>; this.appearance = appearance;} Feel free to manually copy the code
*/
namespace ComsciProject.Engine.Example
{
    public class ExampleWall : Entity
    {
        private ExampleWall()//make the default private to force the use of the parametised constructor
        {   

        }
        public ExampleWall(char appearance)//This parametised constructor allows us to have different wall appearances without making other classes
        {
            this.appearance = appearance;
        }
    }
}
