using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosSouls.Handlers
{
    public class HoldKeyCommandHandler : ICommandHandler
    {
        private readonly ScanCodeShort[] _keyCodes;

        public HoldKeyCommandHandler(params ScanCodeShort[] keys)
        {
            _keyCodes = keys;
        }

        public void Handle()
        {
            foreach (var key in _keyCodes) 
            {
                KeyboardInterface.SendKeyDown(key);
            }
        }
    }    
}
