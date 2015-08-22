using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChaosSouls.Handlers
{
    public class SequentialCommandHandler : ICommandHandler
    {
        private readonly ICommandHandler[] _handlers;

        public SequentialCommandHandler(params ICommandHandler[] handlers)
        {
            _handlers = handlers;
        }

        public void Handle()
        {
            foreach (var handler in _handlers)
            {
                handler.Handle();
                Thread.Sleep(10);
            }
        }
    }
}
