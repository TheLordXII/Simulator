using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using Simulator.Models;
using Simulator.Models.Controls;
using System.Windows.Controls;

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

        public int PCL
        {
            get
            {
                return 0;
            }
        }

        public int PCLATCH
        {
            get
            {
                return 0;
            }
        }

        public short PCint
        {
            get
            {
                return _memory.Programcounter;
            }
        }

        public int Laufzeit
        {
            get
            {
                return 0;
            }
        }

        public int Status
        {
            get
            {
                return _memory.GetRegisterContent(3);
            }
        }

        public int FSR
        {
            get
            {
                return _memory.GetRegisterContent(4);
            }
        }

        public int Option
        {
            get
            {
                return _memory.GetRegisterContent(0);
            }
        }

        public int Vorteiler
        {
            get
            {
                return 0;
            }
        }

        public int Timer0
        {
            get
            {
                return 0;
            }
        }

        public int IRP
        {
            get
            {
                return 0;
            }
        }

        public int RP1
        {
            get
            {
                return 0;
            }
        }

        public int RP0
        {
            get
            {
                return 0;
            }
        }

        public int T0
        {
            get
            {
                return 0;
            }
        }

        public int PD
        {
            get
            {
                return 0;
            }
        }

        public int Z
        {
            get
            {
                return 0;
            }
        }

        public int DC
        {
            get
            {
                return 0;
            }
        }

        public int C
        {
            get
            {
                return 0;
            }
        }

        public int RPu
        {
            get
            {
                return 0;
            }
        }

        public int IEg
        {
            get
            {
                return 0;
            }
        }

        public int T0CS
        {
            get
            {
                return 0;
            }
        }

        public int T0SE
        {
            get
            {
                return 0;
            }
        }

        public int PSA
        {
            get
            {
                return 0;
            }
        }

        public int PS2
        {
            get
            {
                return 0;
            }
        }

        public int PS1
        {
            get
            {
                return 0;
            }
        }

        public int PS0
        {
            get
            {
                return 0;
            }
        }

        public int GIE
        {
            get
            {
                return 0;
            }
        }

        public int EEIE
        {
            get
            {
                return 0;
            }
        }

        public int T0IE
        {
            get
            {
                return 0;
            }
        }

        public int INTIE
        {
            get
            {
                return 0;
            }
        }

        public int RBIE
        {
            get
            {
                return 0;
            }
        }

        public int T0IF
        {
            get
            {
                return 0;
            }
        }

        public int INTF
        {
            get
            {
                return 0;
            }
        }

        public int RBIF
        {
            get
            {
                return 0;
            }
        }

        //Lose Kopplung, MainViewModel ist indirekt abhängig von Memory jedoch nicht umgekehrt!
        public MainViewModel(Memory memory, ControlUnit controlUnit, Parser parser)
        {
            _memory = memory;
            _controlUnit = controlUnit;
            _parser = parser;
            _memory.PropertyChanged += _memory_PropertyChanged;


        }

        private void _memory_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName);
        }

        public void OnSingleStep()
        {
            _controlUnit.OperationStep();
        }

        public void ParseData()
        {
            _parser.OpenFileDialog();
        }

        public void UpdateListView()
        {
            
        }
    }
}
