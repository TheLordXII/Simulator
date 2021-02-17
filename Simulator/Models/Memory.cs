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
    public class Memory : ObservableObject
    {
        /// <summary>
        /// W-Register
        /// </summary>
        private byte _w;

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
        /// 
        /// </summary>
        private Stack<short> _stack = new Stack<short>(8);

        public byte W
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
    }
}
