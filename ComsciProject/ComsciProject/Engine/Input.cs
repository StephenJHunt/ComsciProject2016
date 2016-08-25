using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComsciProject.Engine
{
    public enum Direction { Up, Down, Left, Right };
    public sealed class Input
    {
        public static void Initialize(KeyEventHandler keyHandler)
        {
            KeyDownEvent = keyHandler;
            KeyDownEvent += OnKeyDown;
        }
        private static KeyEventHandler KeyDownEvent;
        private static void OnKeyDown(object sender, KeyEventArgs e)
        {
            lastKeypress = e.KeyCode;
            //when a key is pressed
        }
        private static volatile Keys lastKeypress;//NEED TO MAKE THIS THREAD SAFE
        public static Keys getLastKeypress()//VERY UNSAFE FOR THREAD
        {
            return lastKeypress;
        }
    }
}
