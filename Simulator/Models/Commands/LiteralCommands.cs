using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulator.Models.Commands
{
    public class LiteralCommands
    {
        private Memory _memory;

        public LiteralCommands(Memory memory)
        {
            _memory = memory;
        }

        public void ADDLW(short literal)
        {
            int result = literal + _memory.W;

            _memory.WriteToMemory(result);
        }

        public void ANDLW(short literal)
        {
            int result = _memory.W & literal;

            _memory.WriteToMemory(result);
        }

        public void CALL(short target)
        {
            _memory.PushToStack(_memory.Programcounter);

            _memory.Programcounter = target;
        }

        public void CLRWTD()
        {
            
        }
    }
}
