using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models
{
    public interface IMemoryLiteral
    {
        short W { get; set; }
        short Programcounter { get; set; }
        float Watchdog { get; set; }
        void WriteToMemory(int result);
        void WriteToMemory(int result, int FileRegisterPosition);
        void WriteToMemory(int result, bool Operator);
        void PushToStack(short value);
        short PopFromStack();
        void SetBit(short position, short bit);
        void ClearBit(short position, short bit);
    }
}
