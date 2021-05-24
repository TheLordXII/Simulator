using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simulator.Models.Controls
{
    public class Parser
    {
        private Memory _memory;
        private int index = 0;

        public Parser(Memory memory)
        {
            _memory = memory;
        }

        /// ------------------TESTEN
        public void ReadFromPath(String Pfad)
        {

            string pattern = @"\d\d\w\w\s\w\w\w\w\b";
            string input = File.ReadAllText(Pfad);

            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {

                short value = Convert.ToInt16(m.Value.Substring(5), 16);
                _memory.SaveToProgramMemory(value, m.Value);
                index++;

            }
        }

        public void OpenFileDialog()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
                ReadFromPath(filePath);

            }
        }
    }
}

