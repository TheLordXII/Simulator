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

            if (result > 255)
            {
                result = result - 256;
            }



        }
    }
}
