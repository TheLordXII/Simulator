using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models
{
    public interface IMemoryBit
    {
        short Programcounter { get; set; }
        void SetBit(short position, short bit);
        void ClearBit(short position, short bit);
        bool BitSet(short position, short bit);
    }
}
