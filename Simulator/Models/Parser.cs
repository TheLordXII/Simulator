using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Simulator
{
    public class Parser 
    {
        public String[] matches = new String[1024];
        public int counter = 0;

        public void setCounter(int counter)
        {
            this.counter = counter;
        }

        public void Main(String Pfad)
        {

            string pattern = @"\d\d\w\w\s\w\w\w\w\b";
            string input = File.ReadAllText(Pfad);



            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
                matches[counter] = m.Value;
                counter++;
            }

            for (int i = 0; i < matches.Length; i++)
            {
                if(matches[i] != null)
                {
                    Console.WriteLine(matches[i]);
                }    
            }
        }

        public void ProgrammspeicherLeeren()
        {
            for (int i = 0; i < matches.Length; i++)
            {
                matches[i] = null;
            }
            counter = 0;
        }

    }
}
