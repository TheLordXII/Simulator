using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Models;
using Simulator.Models.Controls;

namespace Simulator.ViewModels
{
    /// <summary>
    /// Contains UI Logic and UI Content
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private Memory _memory;
        private ControlUnit _controlUnit;
        private Parser _parser;

        public MainViewModel(Memory memory, ControlUnit controlUnit, Parser parser)
        {
            _memory = memory;
            _controlUnit = controlUnit;
            _parser = parser;
        }

        /// <summary>
        /// Takes a File from a File Dialog and parses the Important Information.
        /// </summary>
        /// ------------------TESTEN
        public void ParseData()
        {
            //OpenFile Dialog
        }

        /// <summary>
        /// Single Step of the Operation with the ControlUnit
        /// </summary>
        public void OperationStep()
        {
            _controlUnit.OperationStep();

            //GUI Aktualisieren

        }
    }
}
