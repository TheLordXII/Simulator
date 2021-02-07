using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Simulator
{
    public class Management
    {
        public bool DestinationSet(int cutvalue)
        {
            int res = cutvalue & 0b1000_0000;

            if (res == 128)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ReadProgrammspeicherInhalt(int programminhalt)
        {
            string binary = Convert.ToString(programminhalt, 2); //transformiert in BIN
            //Console.WriteLine(binary);

            string pattern = @"\S\S\S\S\S\S\S\S\b";
            string input = binary;
            string cut = "";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                //Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
                cut = m.Value;
            }

            return Convert.ToInt32(cut, 2);

        }

        public int ReadProgrammspeicherInhalt7(int programminhalt)
        {
            string binary = Convert.ToString(programminhalt, 2); //transformiert in BIN
            //Console.WriteLine(binary);

            string pattern = @"\S\S\S\S\S\S\S\b";
            string input = binary;
            string cut = "";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                //Console.WriteLine("'{0}' found at index {1}. 7", m.Value, m.Index);
                cut = m.Value;
            }

            return Convert.ToInt32(cut, 2);

        }
        public int ReadProgrammspeicherInhalt3(int programminhalt)
        {
            string binary = Convert.ToString(programminhalt, 2); //transformiert in BIN
            //Console.WriteLine(binary);

            string pattern = @"^\S\S\S\S\S\S";
            string input = binary;
            string cut = "";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                //Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
                cut = m.Value;
            }
            int value = Convert.ToInt32(cut, 2) & 0b0000_0111;
            return value;

        }

        public int ReadProgrammspeicherInhalt11(int programminhalt)
        {
            string binary = Convert.ToString(programminhalt, 2); //transformiert in BIN
            //Console.WriteLine(binary);

            string pattern = @"\d\d\d\d\d\d\d\d\d\d\d\b";
            string input = binary;
            string cut = "";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                //Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
                cut = m.Value;
            }

            return Convert.ToInt32(cut, 2);

        }

        public bool getDestination(int programminhalt)
        {
            int cutvalue = ReadProgrammspeicherInhalt(programminhalt);
            bool destination;
            destination = DestinationSet(cutvalue);
            //Console.WriteLine("Destination: " + destination);
            return destination;
        }
    }
}
