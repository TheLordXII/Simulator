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

        public int Prescaler
        {
            get => _memory.Prescaler;
            set
            {
                _memory.Prescaler = value;
                RaisePropertyChanged();
            }
        }
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

        public short Programmcounter
        {
            get => _memory.Programcounter;
            set
            {
                _memory.Programcounter = value;
                RaisePropertyChanged();
            }
        }

        //Lose Kopplung, MainViewModel ist indirekt abhängig von Memory jedoch nicht umgekehrt!
        public MainViewModel(Memory memory, ControlUnit controlUnit, Parser parser)
        {
            _memory = memory;
            _controlUnit = controlUnit;
            _parser = parser;
            _memory.PropertyChanged += (o, a) => { RaisePropertyChanged(); };


        }

        private void _memory_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(nameof(Memory.Prescaler)==e.PropertyName)
            {
                Prescaler = _memory.Prescaler;
            }
            else if (nameof(Memory.Programcounter) == e.PropertyName)
            {
                Programmcounter = _memory.Programcounter;
            }
        }

        public void OnSingleStep()
        {
            _controlUnit.OperationStep();
        }
    }
}
