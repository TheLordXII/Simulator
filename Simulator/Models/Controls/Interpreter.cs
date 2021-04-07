using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models.Controls
{
    public class Interpreter
    {
        public bool InterpretDestinationBit(short programMemory)
        {
            short res = (short)(programMemory & 0b00_0000_1000_0000);

            if (res == 128)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public short InterpretFileRegister(short programMemory)
        {
            return (short)(programMemory & 0b00_0000_0111_1111);
        }

        public short InterpretBit(short programMemory)
        {
            return (short)(programMemory & 0b00_0011_1000_0000);
        }

        public short InterpretLiteral(short programMemory)
        {
            return (short)(programMemory & 0b00_0000_1111_1111);
        }

        public short InterpretTarget(short programMemory)
        {
            return (short)(programMemory & 0b00_0111_1111_1111);
        }
    }
}
