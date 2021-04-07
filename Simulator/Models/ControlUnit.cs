using Simulator.Models.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models
{
    public class ControlUnit
    {
        private Interpreter _interpreter;
        private OperationSelector _operationSelector;
        private Memory _memory;
        private short _register;
        private bool _destination;
        private short _literal;
        private short _target;
        private short _bit;

        public ControlUnit(Interpreter interpreter, OperationSelector operationSelector, Memory memory)
        {
            _interpreter = interpreter;
            _operationSelector = operationSelector;
            _memory = memory;
        }

        public void OperationStep()
        {
            _memory.Programcounter++;

            _register = _interpreter.InterpretFileRegister(_memory.GetFromProgramMemory(_memory.Programcounter));
            _destination = _interpreter.InterpretDestinationBit(_memory.GetFromProgramMemory(_memory.Programcounter));
            _bit = _interpreter.InterpretBit(_memory.GetFromProgramMemory(_memory.Programcounter));
            _target = _interpreter.InterpretTarget(_memory.GetFromProgramMemory(_memory.Programcounter));
            _literal = _interpreter.InterpretLiteral(_memory.GetFromProgramMemory(_memory.Programcounter));

            _operationSelector.ChooseOperation(_memory.GetFromProgramMemory(_memory.Programcounter), _register, _destination, _bit, _target, _literal);

        }
    }
}
