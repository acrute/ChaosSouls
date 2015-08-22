using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosSouls.Handlers
{
    public class ReleaseKeyCommandHandler : ICommandHandler
    {
        private readonly ScanCodeShort[] _keyCodes;

        public ReleaseKeyCommandHandler(params ScanCodeShort[] keys)
        {
            _keyCodes = keys;
        }

        public void Handle()
        {
            foreach (var key in _keyCodes)
            {
                KeyboardInterface.SendKeyUp(key);
            }
        }
    }
}
