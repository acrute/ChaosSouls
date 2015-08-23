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
        private readonly ScanCodeShort _key;

        public HoldReleaseCommandHandler(int delay, ScanCodeShort key)
        {
            _delay = delay;
            _key = key;
        }

        public void Handle()
        {
            KeyboardInterface.SendKeyDown(_key);
            Thread.Sleep(_delay);
            KeyboardInterface.SendKeyUp(_key);
        }
    }
}
