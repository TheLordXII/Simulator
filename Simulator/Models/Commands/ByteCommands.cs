using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models.Commands
{
    public class ByteCommands
    {
        private Memory _memory;

        public ByteCommands(Memory memory)
        {
            _memory = memory;
        }

        public void ADDWF(short register , bool destination)
        {
            short result = (short)(_memory.W + _memory.GetRegisterContent(register));

            if (destination)
            {
                _memory.WriteToMemory(result, true, register);
            }
            else
            {
                _memory.WriteToMemory(result);
            }
        }

        public void ANDWF(short register, bool destination)
        {
            short result = (short)(_memory.W & _memory.GetRegisterContent(register));

            if (destination)
            {
                _memory.WriteToMemory(result, register);
            }
            else
            {
                _memory.WriteToMemory(result);
            }
        }

        public void CLRF(short register)
        {
            _memory.WriteToMemory(0, register);
        }

        public void CLRW()
        {
            _memory.WriteToMemory(0);
        }

        public void COMF(short register, bool destination)
        {
            short result = (short)~_memory.GetRegisterContent(register);

            if (destination)
            {
                _memory.WriteToMemory(result, register);
            }
            else
            {
                _memory.WriteToMemory(result);
            }
        }

        public void DECF(short register, bool destination)
        {
            short result = (short)(_memory.GetRegisterContent(register) - 1);

            if (destination)
            {
                _memory.WriteToMemory(result, register);
            }
            else
            {
                _memory.WriteToMemory(result);
            }
        }

        public void DECFSZ(short register, bool destination)
        {

        }

        public void INCF(short register, bool destination)
        {
            short result = (short)(_memory.GetRegisterContent(register) + 1);

            if (destination)
            {
                _memory.WriteToMemory(result, register);
            }
            else
            {
                _memory.WriteToMemory(result);
            }
        }

        public void INCFSZ()
        {

        }

        public void IORWF(short register, bool destination)
        {
            short result = (short)(_memory.W | _memory.GetRegisterContent(register));

            if (destination)
            {
                _memory.WriteToMemory(result, register);
            }
            else
            {
                _memory.WriteToMemory(result);
            }
        }

        public void MOVF(short register, bool destination)
        {
            if (destination)
            {
                _memory.WriteToMemory(_memory.GetRegisterContent(register), register);
            }
            else
            {
                _memory.WriteToMemory(_memory.GetRegisterContent(register));
            }
        }

        public void MOVWF(short register)
        {
            _memory.WriteToMemory(_memory.W , register);
        }

        public void NOP()
        {
            //Does Nothin?
        }

        public void RLF(short register, bool destination)
        {
            short carry = (short)(_memory.GetRegisterContent(3) & 0b0000_0001);
            short result = (short)(_memory.GetRegisterContent(register) << 1);
            result += carry;

            if (destination)
            {
                _memory.WriteToMemory(result, register);
            }
            else
            {
                _memory.WriteToMemory(result);
            }
        }

        public void RRF(short register, bool destination)
        {
            short carry = (short)(_memory.GetRegisterContent(3) & 0b0000_0001);
            short result = (short)_memory.GetRegisterContent(register);
            result += (short)(carry << 8);
            result += (short)((result & 0b1) << 10);
            result >>= 1;

            if (destination)
            {
                _memory.WriteToMemory(result, register);
            }
            else
            {
                _memory.WriteToMemory(result);
            }
        }

        public void SUBWF(short register, bool destination)
        {

        }
    }
}
