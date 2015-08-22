using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChaosSouls.Handlers
{
    public class DelayedKeyCommandHandler : ICommandHandler
    {
        private readonly int _delay;
        private readonly ScanCodeShort[] _keyCodes;

        public DelayedKeyCommandHandler(int delay, params ScanCodeShort[] keys)
        {
            _delay = delay;
            _keyCodes = keys;
        }

        public void Handle()
        {
            foreach (var key in _keyCodes)
            {
                KeyboardInterface.SendKeyPress(key);
                Thread.Sleep(_delay);
            }
        }
    }
}
