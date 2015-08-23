using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ChaosSouls
{
    public class Runner
    {
        public static void Main(string[] args)
        {
            Chaos.StartRandom();
            //Chaos.StartRiot();

            Console.WriteLine("Press the Enter key to return to order...");
            Console.ReadLine();
        }
    }
}
