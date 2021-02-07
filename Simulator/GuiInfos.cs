using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class GuiInfos : Operationen
    {
        public int getIRP()
        {
            int erg = Bank1[3] & 0b1000_0000;
            if (erg == 128)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int getRP1()
        {
            int erg = Bank1[3] & 0b0100_0000;
            if (erg == 64)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getZ()
        {
            int erg = Bank1[3] & 0b0000_0100;
            if (erg == 4)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getDC()
        {
            int erg = Bank1[3] & 0b0000_0010;
            if (erg == 2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getRPu()
        {
            int erg = Bank1[129] & 0b1000_0000;
            if (erg == 128)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getTCs()
        {
            int erg = Bank1[129] & 0b0010_0000;
            if (erg == 32)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getTSe()
        {
            int erg = Bank1[129] & 0b0001_0000;
            if (erg == 16)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getEIE()
        {
            int erg = Bank1[11] & 0b0100_0000;
            if (erg == 64)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getTIE()
        {
            int erg = Bank1[11] & 0b0010_0000;
            if (erg == 32)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getTIF()
        {
            int erg = Bank1[11] & 0b0000_0100;
            if (erg == 4)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getIF()
        {
            int erg = Bank1[11] & 0b0000_0010;
            if (erg == 2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getRIF()
        {
            int erg = Bank1[11] & 0b0000_0001;
            if (erg == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getW()
        {
            return w;
        }

        public int getFSR()
        {
            return Bank1[4];
        }

        public int getStatus()
        {
            return Bank1[3];
        }

        public int getOption()
        {
            return Bank1[129];
        }

        public int getStack1()
        {
            return stack[0];
        }
        public int getStack2()
        {
            return stack[1];
        }
        public int getStack3()
        {
            return stack[2];
        }
        public int getStack4()
        {
            return stack[3];
        }
        public int getStack5()
        {
            return stack[4];
        }
        public int getStack6()
        {
            return stack[5];
        }
        public int getStack7()
        {
            return stack[6];
        }
        public int getStack8()
        {
            return stack[7];
        }

        public int getTrisA()
        {
            return Bank1[133];
        }

        public int getTrisB()
        {
            Console.WriteLine("TrisB" + Bank1[134]);
            return Bank1[134];
        }

        public int Pinbelegung(int portA, int portB, int programmcounter)
        {
            byte portAvorher = (byte)Bank1[5];
            byte portBvorher = (byte)Bank1[6];
            Bank1[5] = (byte)portA;
            Bank1[6] = (byte)portB;
            bool rb0int = false;
            bool rbint = false;
            //int ursprung = stack[0];

            if (getIEg() == 1)
            {
                //steigende 
                if ((portBvorher & 0b0000_0001) == 0 && (portB & 0b0000_0001) == 1)
                {
                    Bank1[11] |= 0b0000_0010;

                    if (getGIE() == 1 && getIE() == 1)
                    {
                        rb0int = RB0Interrupt(portA, portB, programmcounter);
                    }

                }
            }
            else
            {
                //fallende
                if ((portBvorher & 0b0000_0001) == 1 && (portB & 0b0000_0001) == 0)
                {
                    Bank1[11] |= 0b0000_0010;

                    if (getGIE() == 1 && getIE() == 1)
                    {
                        rb0int = RB0Interrupt(portA, portB, programmcounter);
                    }
                }
            }



            //rbint = RBInterrupt(portAvorher, programmcounter);

            if (rb0int)
            {
                return 4;
            }

            if (rbint)
            {
                return 4;
            }

            //Console.WriteLine("PortA: " + Bank1[5]);
            //Console.WriteLine("PortB: " + Bank1[6]);
            return programmcounter;
        }

        public bool RB0Interrupt(int portA, int portB, int programmcounter)
        {
            int eingang = Bank1[134] & 0b0000_0001;

            if (eingang == 1)
            {
                Console.WriteLine("RB0 Interrupt");
                //RB0 Interruptflag
                Bank1[11] = (byte)(Bank1[11] | 0b0000_0010);
                Bank1[139] = (byte)(Bank1[139] | 0b0000_0010);

                Bank1[11] = (byte)(Bank1[11] & 0b0111_1111);
                Bank1[139] = (byte)(Bank1[139] & 0b0111_1111);
                push(programmcounter);
                return true;
            }

            return false;
        }

        public int GetPortA()
        {
            return Bank1[5];
        }

        public int GetPortB()
        {
            return Bank1[6];
        }

        public float getWatchdog()
        {
            return watchdog;
        }

        public int getBankInhalt(int stelle)
        {
            return Bank1[stelle];
        }

        public int getPrescalerGUI()
        {
            return prescaler;
        }

        public int getTimer0()
        {
            return Bank1[1];
        }

        public void updateFile(int speicherstelle, int wert)
        {
            Bank1[speicherstelle] = (byte)wert;
        }

        public int getIE()
        {
            int erg = Bank1[11] & 0b0001_0000;
            if (erg == 16)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getRIE()
        {
            int erg = Bank1[11] & 0b0000_1000;
            if (erg == 8)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
