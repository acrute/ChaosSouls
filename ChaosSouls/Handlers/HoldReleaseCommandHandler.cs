using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChaosSouls.Handlers
{
    public class HoldReleaseCommandHandler : ICommandHandler
    {
        private readonly int _delay;
        private readonly ScanCodeShort[] _keys;

        public HoldReleaseCommandHandler(params ScanCodeShort[] keys)
        {
            _keys = keys;
            _delay = GetRandomInterval();
        }

        public HoldReleaseCommandHandler(int delay, params ScanCodeShort[] keys)
        {
            _delay = delay;
            _keys = keys;
        }

        private static int GetRandomInterval()
        {
            var random = new Random();
            return random.Next(1000);
        }

        public void Handle()
        {
            var stack = new Stack<ScanCodeShort>();
            foreach (var key in _keys)
            {
                KeyboardInterface.SendKeyDown(key);
                stack.Push(key);
            }
            
            Thread.Sleep(_delay);

            while (stack.Any())
            {
                var key = stack.Pop();
                KeyboardInterface.SendKeyUp(key);
            }
        }
    }
}
