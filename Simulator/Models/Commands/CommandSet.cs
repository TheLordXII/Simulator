using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Models.Commands;
using Simulator.Helpers;

namespace Simulator.Models
{
    public class CommandSet : ObservableObject
    {
        private BitCommands _bitCommands;
        private LiteralCommands _literalCommands;
        private ByteCommands _byteCommands;

        public BitCommands _BitCommands
        {
            get
            {
                return _bitCommands;
            }
        }

        public LiteralCommands _LiteralCommands
        {
            get
            {
                return _literalCommands;
            }
        }

        public ByteCommands _ByteCommands
        {
            get
            {
                return _byteCommands;
            }
        }

        public CommandSet(BitCommands bitCommands, LiteralCommands literalCommands, ByteCommands byteCommands)
        {
            _bitCommands = bitCommands;
            _literalCommands = literalCommands;
            _byteCommands = byteCommands;
        }
    }
}
