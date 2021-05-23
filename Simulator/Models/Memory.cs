using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Simulator.Helpers;

namespace Simulator.Models
{
    /// <summary>
    /// Represents all memories and register of the PIC16F84
    /// </summary>
    public class Memory : ObservableObject, IMemory
    {
        /// <summary>
        /// W-Register
        /// </summary>
        private short _w;

        /// <summary>
        /// The ROM
        /// </summary>
        private short[] _fileRegister = new short[256];

        /// <summary>
        /// watchdog
        /// </summary>
        private float _watchdog;

        /// <summary>
        /// prescaler
        /// </summary>
        private int _prescaler;

        /// <summary>
        /// stack
        /// </summary>
        private Stack<short> _stack = new Stack<short>(8);

        /// <summary>
        /// programcounter
        /// </summary>
        private short _programcounter;

        /// <summary>
        /// programmemory
        /// </summary>
        private short[] _programmemory = new short[1024];

        public short GetFromProgramMemory(int index)
        {
            return _programmemory[index];
        }

        public void SaveToProgramMemory(int index, short value)
        {
            _programmemory[index] = value;
            RaisePropertyChanged();
        }

        public void ClearProgramMemory()
        {
            for (int i = 0; i < _programmemory.Length; i++)
            {
                _programmemory[i] = 0;
            }
        }

        public void ClearFileRegister()
        {
            for (int i = 0; i < _fileRegister.Length; i++)
            {
                _fileRegister[i] = 0;
            }
        }

        public short W
        {
            get
            {
                return _w;
            }
            set
            {
                _w = value;
                RaisePropertyChanged();
            }
        }

        public short Programcounter
        {
            get
            {
                return _programcounter;
            }
            set
            {
                _programcounter = value;
                RaisePropertyChanged();
            }
        }

        public float Watchdog
        {
            get
            {
                return _watchdog;
            }
            set
            {
                _watchdog = value;
                RaisePropertyChanged();
            }
        }

        public int Prescaler
        {
            get
            {
                return _prescaler;
            }
            set
            {
                _prescaler = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Changes Flags for Operations and stores Result into the W-Register
        /// </summary>
        public void WriteToMemory(int result)
        {
            result = ChangeC(result);
            ChangeZ(result);

            W = (byte)result;
        }

        /// <summary>
        /// Changes Flags for Operations and stores Result into the File Register
        /// </summary>
        public void WriteToMemory(int result, int FileRegisterPosition)
        {
            result = ChangeC(result);
            ChangeZ(result);

            _fileRegister[FileRegisterPosition] = (short)result;
        }

        /// <summary>
        /// Changes Flags for Operations and stores Result into the File Register
        /// </summary>
        public void WriteToMemory(int result, bool Operator)
        {
            result = ChangeC(result);
            ChangeZ(result);
            ChangeDC(result, Operator);

            W = (byte)result;
        }

        /// <summary>
        /// Changes Flags for Operations and stores Result into the File Register
        /// </summary>
        public void WriteToMemory(int result, bool Operator, int FileRegisterPosition)
        {
            result = ChangeC(result);
            ChangeZ(result);
            ChangeDC(result, Operator);

            _fileRegister[FileRegisterPosition] = (short)result;
        }

        /// <summary>
        /// Changes C-Flag in the FileRegister depending of the Result of the Operation
        /// </summary>
        /// <param name="value">Result of the Operation</param>
        private int ChangeC(int value)
        {
            if (value > 255)
            {
                _fileRegister[3] |= 0b0000_0001;
                _fileRegister[131] |= 0b0000_0001;

                value = value - 256;
                return value;
            }
            if (value < 0)
            {
                _fileRegister[3] |= 0b0000_0001;
                _fileRegister[131] |= 0b0000_0001;

                value = value + 256;
                return value;
            }

            _fileRegister[3] &= 0b1111_1110;
            _fileRegister[131] &= 0b1111_1110;

            return value;
        }

        /// <summary>
        /// Sets Z-Flag in the FileRegister if the Result of the Operation is 0, deletes if not
        /// </summary>
        /// <param name="value">Result of the Operation</param>
        private void ChangeZ(int value)
        {
            if (value == 0)
            {
                _fileRegister[3] |= 0b0000_0100;
                _fileRegister[131] |= 0b0000_0100;
            }
            else
            {
                _fileRegister[3] &= 0b1111_1011;
                _fileRegister[131] &= 0b1111_1011;
            }
        }

        /// <summary>
        /// Changes the DC-Flag depending of the Operation-Type
        /// </summary>
        /// <param name="value">Result of the Operation</param>
        /// <param name="Operator">True for Addition, False for Subtraction</param>
        private void ChangeDC(int value, bool Operator)
        {
            if (Operator)
            {
                short helper = (short)(W & 15 + value & 15);

                if (helper > 15)
                {
                    _fileRegister[3] |= 0b0000_0010;
                    _fileRegister[131] |= 0b0000_0010;
                }
                else
                {
                    _fileRegister[3] &= 0b1111_1101;
                    _fileRegister[131] &= 0b1111_1101;
                }
            }
            else
            {
                short helper = (short)(W & 15 - value & 15);

                if (helper >= 0)
                {
                    _fileRegister[3] |= 0b0000_0010;
                    _fileRegister[131] |= 0b0000_0010;
                }
                else
                {
                    _fileRegister[3] &= 0b1111_1101;
                    _fileRegister[131] &= 0b1111_1101;
                }
            }
        }

        /// <summary>
        /// Pushes a value on the Stack.
        /// </summary>
        /// <param name="value"></param>
        public void PushToStack(short value)
        {
            _stack.Push(value);
        }

        /// <summary>
        /// Pops a Value from the Stack and returns it.
        /// </summary>
        /// <returns></returns>
        public short PopFromStack()
        {
            return _stack.Pop();
        }

        /// <summary>
        /// Sets a Bit in the FileRegister 
        /// </summary>
        /// <param name="position">File Register Position</param>
        /// <param name="bit">Bit to Set</param>
        public void SetBit(short position, short bit)
        {
            switch (bit)
            {
                case 0:
                    _fileRegister[position] = (short)(_fileRegister[position] | 0b0000_0001);
                    break;
                case 1:
                    _fileRegister[position] = (short)(_fileRegister[position] | 0b0000_0010);
                    break;
                case 2:
                    _fileRegister[position] = (short)(_fileRegister[position] | 0b0000_0100);
                    break;
                case 3:
                    _fileRegister[position] = (short)(_fileRegister[position] | 0b0000_1000);
                    break;
                case 4:
                    _fileRegister[position] = (short)(_fileRegister[position] | 0b0001_0000);
                    break;
                case 5:
                    _fileRegister[position] = (short)(_fileRegister[position] | 0b0010_0000);
                    break;
                case 6:
                    _fileRegister[position] = (short)(_fileRegister[position] | 0b0100_0000);
                    break;
                case 7:
                    _fileRegister[position] = (short)(_fileRegister[position] | 0b1000_0000);
                    break;

            }
        }

        /// <summary>
        /// Clears a Bit in the Fileregister
        /// </summary>
        /// <param name="position">File Register Position</param>
        /// <param name="bit">Bit to Clear</param>
        public void ClearBit(short position, short bit)
        {
            switch (bit)
            {
                case 0:
                    _fileRegister[position] = (short)(_fileRegister[position] & 0b1111_1110);
                    break;
                case 1:
                    _fileRegister[position] = (short)(_fileRegister[position] & 0b1111_1101);
                    break;
                case 2:
                    _fileRegister[position] = (short)(_fileRegister[position] & 0b1111_1011);
                    break;
                case 3:
                    _fileRegister[position] = (short)(_fileRegister[position] & 0b1111_0111);
                    break;
                case 4:
                    _fileRegister[position] = (short)(_fileRegister[position] & 0b1110_1111);
                    break;
                case 5:
                    _fileRegister[position] = (short)(_fileRegister[position] & 0b1101_1111);
                    break;
                case 6:
                    _fileRegister[position] = (short)(_fileRegister[position] & 0b1011_1111);
                    break;
                case 7:
                    _fileRegister[position] = (short)(_fileRegister[position] & 0b0111_1111);
                    break;

            }
        }

        /// <summary>
        /// Checks if a Bit is set.
        /// </summary>
        /// <param name="position">File Register Position</param>
        /// <param name="bit">Bit to Clear</param>
        /// <returns></returns>
        public bool BitSet(short position, short bit)
        {
            switch (bit)
            {
                case 0:
                    if ((_fileRegister[position] & 0b1111_1110) == 1)
                    {
                        return true;
                    }
                    break;
                case 1:
                    if ((_fileRegister[position] & 0b1111_1101) == 2)
                    {
                        return true;
                    }
                    break;
                case 2:
                    if ((_fileRegister[position] & 0b1111_1011) == 4)
                    {
                        return true;
                    }
                    break;
                case 3:
                    if ((_fileRegister[position] & 0b1111_0111) == 8)
                    {
                        return true;
                    }
                    break;
                case 4:
                    if ((_fileRegister[position] & 0b1110_1111) == 16)
                    {
                        return true;
                    }
                    break;
                case 5:
                    if ((_fileRegister[position] & 0b1101_1111) == 32)
                    {
                        return true;
                    }
                    break;
                case 6:
                    if ((_fileRegister[position] & 0b1011_1111) == 64)
                    {
                        return true;
                    }
                    break;
                case 7:
                    if ((_fileRegister[position] & 0b0111_1111) == 128)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        /// <summary>
        /// Returns Content of one Register in the FileRegister
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public short GetRegisterContent(short register)
        {
            return _fileRegister[register];
        }
    }
}

