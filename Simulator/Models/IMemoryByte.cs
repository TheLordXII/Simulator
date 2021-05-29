using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models
{
    public interface IMemoryByte
    {
        short W { get; set; }
        void WriteToMemory(int result);
        void WriteToMemory(int result, int FileRegisterPosition);
        void WriteToMemory(int result, bool Operator, int FileRegisterPosition);
        short GetRegisterContent(short register);

    }
}
