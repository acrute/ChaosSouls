using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosSouls.Handlers
{
    public class SingleKeyCommandHandler : ICommandHandler
    {
        private readonly ScanCodeShort _keyCode;

        public SingleKeyCommandHandler(ScanCodeShort keyCode)
        {
            _keyCode = keyCode;
        }

        public void Handle()
        {
            KeyboardInterface.SendKeyPress(_keyCode);
        }
    }
}
