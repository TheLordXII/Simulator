using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simulator.Models.Controls
{
    public class Parser
    {
        private Memory _memory;
        private int index = 0;

        public Parser(Memory memory)
        {
            _memory = memory;
        }

        public void ReadFromPath(String Pfad)
        {

            string pattern = @"\d\d\w\w\s\w\w\w\w\b";
            string input = File.ReadAllText(Pfad);

            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                short value = Convert.ToInt16(m.Value, 16);
                _memory.SaveToProgramMemory(index , value);
                index++;
            }
        }

        public bool ExtractDestinationBit(short programMemory)
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

        public short ExtractFileRegister(short programMemory)
        {
            return (short)(programMemory & 0b00_0000_0111_1111);
        }

        public short ExtractBit(short programMemory)
        {
            return (short)(programMemory & 0b00_0011_1000_0000);
        }

        public short ExtractLiteral(short programMemory)
        {
            return (short)(programMemory & 0b00_0000_1111_1111);
        }

        public short ExtractTarget(short programMemory)
        {
            return (short)(programMemory & 0b00_0111_1111_1111);
        }
    }
}
