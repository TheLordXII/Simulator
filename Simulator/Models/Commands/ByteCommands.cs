using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models.Commands
{
    public class ByteCommands
    {
        private protected IMemoryByte _memory;

        public ByteCommands(IMemoryByte memory)
        {
            _memory = memory;
        }

        public void ADDWF(short register, bool destination)
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
            short result = (short)(_memory.GetRegisterContent(register) - 1);

            if (result <= 0)
            {
                NOP();
            }
            else
            {
                if (destination)
                {
                    _memory.WriteToMemory(result, register);
                }
                else
                {
                    _memory.WriteToMemory(result);
                }
            }
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

        public void INCFSZ(short register, bool destination)
        {
            short result = (short)(_memory.GetRegisterContent(register) + 1);

            if (result >= 256)
            {
                NOP();
            }
            else
            {
                if (destination)
                {
                    _memory.WriteToMemory(result, register);
                }
                else
                {
                    _memory.WriteToMemory(result);
                }
            }
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
            _memory.WriteToMemory(_memory.W, register);
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
            short result = (short)(_memory.GetRegisterContent(register) - _memory.W);

            if (destination)
            {
                _memory.WriteToMemory(result, register);
            }
            else
            {
                _memory.WriteToMemory(result);
            }
        }

        public void SWAPF(short register, bool destination)
        {
            short result = (short)((_memory.GetRegisterContent(register) & 0x0F) << 4 | ((_memory.GetRegisterContent(register) & 0xF0) >> 4));

            if (destination)
            {
                _memory.WriteToMemory(result, register);
            }
            else
            {
                _memory.WriteToMemory(result);
            }
        }

        public void XORWF(short register, bool destination)
        {
            short result = (short)(_memory.GetRegisterContent(register) ^ _memory.W);

            if (destination)
            {
                _memory.WriteToMemory(result, register);
            }
            else
            {
                _memory.WriteToMemory(result);
            }
        }
    }
}
