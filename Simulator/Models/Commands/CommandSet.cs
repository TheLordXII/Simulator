using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Models.Commands;

namespace Simulator.Models
{
    public class CommandSet
    {
        private BitCommands _bitCommands;
        private LiteralCommands _literalCommands;
        private ByteCommands _byteCommands;

        public CommandSet(BitCommands bitCommands, LiteralCommands literalCommands, ByteCommands byteCommands)
        {
            _bitCommands = bitCommands;
            _literalCommands = literalCommands;
            _byteCommands = byteCommands;
        }
    }
}
