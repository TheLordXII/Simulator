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
        public BitCommands _bitCommands
        {
            get
            {
                return _bitCommands;
            }

            set
            {
                _bitCommands = value;
                RaisePropertyChanged();
            }
        }

        public LiteralCommands _literalCommands
        {
            get
            {
                return _literalCommands;
            }

            set
            {
                _literalCommands = value;
                RaisePropertyChanged();
            }
        }

        public ByteCommands _byteCommands
        {
            get
            {
                return _byteCommands;
            }

            set
            {
                _byteCommands = value;
                RaisePropertyChanged();
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
