using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosSouls.Handlers
{
    public class KeyChordCommandHandler : ICommandHandler
    {
        private readonly ScanCodeShort[] _keyCodes;

        public KeyChordCommandHandler(params ScanCodeShort[] keys)
        {
            _keyCodes = keys;
        }

        public void Handle()
        {
            KeyboardInterface.SendKeyChord(_keyCodes);
        }
    }
}
