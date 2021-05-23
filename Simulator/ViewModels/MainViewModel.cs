using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public short W 
        {
            get
            {
                return _memory.W;
            }
            set
            {
                _memory.W = value;
                RaisePropertyChanged();
            } 
        }
        
        public MainViewModel(Memory memory, ControlUnit controlUnit, Parser parser)
        {
            _memory = memory;
            _controlUnit = controlUnit;
            _parser = parser;
        }

        public void OnSingleStep()
        {
            _controlUnit.OperationStep();
        }
    }
}
