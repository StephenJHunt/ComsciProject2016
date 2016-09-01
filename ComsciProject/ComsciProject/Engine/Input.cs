using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComsciProject.Engine
{
    public enum Direction { Up, Down, Left, Right };

    public sealed class Input
    {

        public static void ReceiveKey(KeyEventArgs e)
        {
            lastKeypress = e.Key;
        }

        private static volatile Key lastKeypress;//NEED TO MAKE THIS THREAD SAFE
        private static volatile Key frameKeypress;
        public static Key getLastKeypress()//VERY UNSAFE FOR MULTITHREADING,BUT YOLO
        {
            return frameKeypress;
        }
        public static void EngineRenderFrame()
        {
            frameKeypress = lastKeypress;
        }
    }
}
