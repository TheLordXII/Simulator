﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulator.Models.Commands
{
    public class LiteralCommands
    {
        private protected IMemoryLiteral _memory;

        public LiteralCommands(IMemoryLiteral memory)
        {
            _memory = memory;
        }

        public void ADDLW(short literal)
        {
            int result = literal + _memory.W;

            _memory.WriteToMemory(result);
        }

        public void ANDLW(short literal)
        {
            int result = _memory.W & literal;

            _memory.WriteToMemory(result);
        }

        public void CALL(short target)
        {
            _memory.PushToStack(_memory.Programcounter);

            _memory.Programcounter = target;
        }

        public void CLRWTD()
        {
            _memory.Watchdog = 0;
            _memory.WriteToMemory(24, 3);
        }

        public void GOTO(short target)
        {
            _memory.Programcounter = target;
        }

        public void IORLW(short literal)
        {
            short result = (short)(_memory.W | literal);
            _memory.WriteToMemory(result);
        }

        public void MOVLW(short literal)
        {
            _memory.WriteToMemory(literal);
        }

        public void RETFIE()
        {
            _memory.Programcounter = _memory.PopFromStack();
            _memory.SetBit(11, 7);
        }

        public void RETLW(short literal)
        {
            _memory.WriteToMemory(literal);
            _memory.Programcounter = _memory.PopFromStack();
        }

        public void RETURN()
        {
            _memory.Programcounter = _memory.PopFromStack();
        }

        public void SLEEP()
        {
            _memory.Watchdog = 0;
            _memory.ClearBit(3, 3);
            _memory.SetBit(3, 4);
        }

        public void SUBLW(short literal)
        {
            short result = (short)(_memory.W - literal);
            _memory.WriteToMemory(result, false);
        }

        public void XORLW(short literal)
        {
            short result = (short)(_memory.W ^ literal);
            _memory.WriteToMemory(result);
        }
    }
}
