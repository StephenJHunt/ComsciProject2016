using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsciProject
{
    public static class Debug
    {
        public static bool log = true;
        public static void Log(object message)
        {
            if (log)
                Console.WriteLine("[DEBUG] " + message);
        }
        public static void LogError(object message)
        {
            if (log)
                Console.Error.WriteLine("[DEBUG ERROR] " + message);
        }
    }
}
