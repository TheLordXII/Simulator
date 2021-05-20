using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public void ParseData()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    _parser.ReadFromPath(filePath);


                }
            }
        }
    }
}
