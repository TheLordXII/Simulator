using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models
{
    public interface IMemory : INotifyPropertyChanged
    {
        short W { get; set; }
        float Watchdog { get; set; }
        int Prescaler { get; set; }
        short Programcounter { get; set; }

        short GetFromProgramMemory(int index);
        void SaveToProgramMemory(int index, short value);
        void ClearProgramMemory();
        void ClearFileRegister();
        void WriteToMemory(int result);
        void WriteToMemory(int result, int FileRegisterPosition);
        void WriteToMemory(int result, bool Operator);
        void WriteToMemory(int result, bool Operator, int FileRegisterPosition);
        void PushToStack(short value);
        short PopFromStack();
        void SetBit(short position, short bit);
        void ClearBit(short position, short bit);
        bool BitSet(short position, short bit);
        short GetRegisterContent(short register);

    }
}
