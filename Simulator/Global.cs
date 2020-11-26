using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Global
    {
        //Programmcounter 
        public int programmcounter = 0;
        public int[] Programmspeicher = new int[1024];

        public byte w = 0; //Work Register

        //Bänke
        public byte[] Bank1 = new byte[256];


        //Watchdog
        public float watchdog = 0;
        public int prescaler = 1;
        public int counter;
        
        public int sprungziel;
        public int[] stack = new int[8];
        public int stackindex = -1;

        

        public void push(int element)
        {
            if(stackindex <= 7)
            {
                stackindex++;
                stack[stackindex] = element;
            }
            else
            {
                Console.WriteLine("Stack is Full!");
            }
        }

        public int pop()
        {
            int element = stack[stackindex];
            stack[stackindex] = 0;
            stackindex--;
            return element;
        }
    }
}
