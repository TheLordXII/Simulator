using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models.Commands
{
    public class BitCommands
    {
        private protected IMemoryBit _memory;

        public BitCommands(IMemoryBit memory)
        {
            _memory = memory;
        }

        public void BCF(short register, short bit)
        {
            _memory.ClearBit(register, bit);
        }

        public void BSF(short register, short bit)
        {
            _memory.SetBit(register, bit);
        }

        public void BTFSC(short register, short bit)
        {
            if (!_memory.BitSet(register, bit))
            {
                //NOP;
                _memory.Programcounter++;
            }
        }

        public void BTFSS(short register, short bit)
        {
            if (_memory.BitSet(register, bit))
            {
                //NOP;
                _memory.Programcounter++;
            }
        }
    }
}
