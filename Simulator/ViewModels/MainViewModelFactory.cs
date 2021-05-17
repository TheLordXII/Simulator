using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Models;
using Simulator.Models.Controls;
using Simulator.Models.Commands;

namespace Simulator.ViewModels
{
    class MainViewModelFactory : IViewModelFactory
    {
        /// <summary>
        /// Creates a MainViewModel and needed Models for it. 
        /// </summary>
        /// <returns></returns>
        public ViewModelBase Load()
        {
            // build models
            var memory = new Memory();
            
            var interpreter = new Interpreter();
            var Parser = new Parser(memory);
            var bitCommands = new BitCommands(memory);
            var byteCommands = new ByteCommands(memory);
            var literalCommands = new LiteralCommands(memory);
            var commandSet = new CommandSet(bitCommands, literalCommands, byteCommands);
            var operationSelector = new OperationSelector(commandSet);
            var controlUnit = new ControlUnit(interpreter, operationSelector, memory);

            return new MainViewModel(/* inject models for easier testing*/memory);
        }
    }
}
