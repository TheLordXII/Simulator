using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Simulator
{
    public class Operationen
    {
        Global Global = new Global();
        public void InitialisierungBaenke()
        {
            for (int i = 0; i < Global.Bank1.Length; i++)
            {
                Global.Bank1[i] = 0b0000_0000;
            }

            Global.Bank1[0] = 0b0000_0000; //INDF
            Global.Bank1[1] = 0b0000_0000; //TMR0
            Global.Bank1[2] = 0b0000_0000; //PCL
            Global.Bank1[3] = 0b0001_1000; //STATUS
            Global.Bank1[4] = 0b0000_0000; //FSR
            Global.Bank1[5] = 0b0000_0000; //PORTA
            Global.Bank1[6] = 0b0000_0000; //PORTB
            Global.Bank1[8] = 0b0000_0000; //EEDATA
            Global.Bank1[9] = 0b0000_0000; //EEADR
            Global.Bank1[10] = 0b0000_0000; //PCLATH
            Global.Bank1[11] = 0b0000_0000; //INTCON

            Global.Bank1[128] = 0b0000_0000; //INDF
            Global.Bank1[129] = 0b1111_1111; //OPTION_REG
            Global.Bank1[130] = 0b0000_0000; //PCL
            Global.Bank1[131] = 0b0001_1000; //STATUS
            Global.Bank1[132] = 0b0000_0000; //FSR
            Global.Bank1[133] = 0b1111_1111; //TRISA
            Global.Bank1[134] = 0b1111_1111; //TRISB
            Global.Bank1[136] = 0b0000_0000; //EECON1
            Global.Bank1[137] = 0b0000_0000; //EECON2
            Global.Bank1[138] = 0b0000_0000; //PCLATH
            Global.Bank1[139] = 0b0000_0000; //INTCON

        }

        public void clearW()
        {
            Global.w = 0;
        }

        public int ExtractRP0()
        {
            int flag = Global.Bank1[3] & 0b0001_0000;
            return flag;
        }

        public void ChangeZ(int result)
        {
            if (result == 0)
            {
                Global.Bank1[3] |= 0b0000_0100;
                Global.Bank1[131] |= 0b0000_0100;
            }
            else
            {
                Global.Bank1[3] &= 0b1111_1011;
                Global.Bank1[131] &= 0b1111_1011;
            }
        }

        public void ChangeC(int result)
        {
            if (result > 255)
            {
                Global.Bank1[3] |= 0b0000_0001;
                Global.Bank1[131] |= 0b0000_0001;
            }
            else
            {
                Global.Bank1[3] &= 0b1111_1110;
                Global.Bank1[131] &= 0b1111_1110;
            }
        }

        public void ChangeCSUB(int result)
        {
            if(result >= 0)
            {
                Global.Bank1[3] |= 0b0000_0001;
                Global.Bank1[131] |= 0b0000_0001;
            }
            else
            {
                Global.Bank1[3] &= 0b1111_1110;
                Global.Bank1[131] &= 0b1111_1110;
            }
        }

        public void ChangeDCADD(int w, int data) //nur für Addition
        {
            w &= 15;
            data &= 15;

            int hilfe = w + data;
            if (hilfe > 15)
            {
                Global.Bank1[3] |= 0b0000_0010;
                Global.Bank1[131] |= 0b0000_0010;
            }
            else
            {
                Global.Bank1[3] &= 0b1111_1101;
                Global.Bank1[131] |= 0b1111_1101;
            }
        }

        public void ChangeDCSUB(int w, int data) //nur für Subtraktion
        {
            w &= 15;
            data &= 15;

            int hilfe = data - w;
            if (hilfe >= 0)
            {
                Global.Bank1[3] |= 0b0000_0010;
                Global.Bank1[131] |= 0b0000_0010;
            }
            else
            {
                Global.Bank1[3] &= 0b1111_1101;
                Global.Bank1[131] |= 0b1111_1101;
            }
        }

        public int isIndirect(int cutvalue)
        {
            //Console.WriteLine("Cutvalue ID" + cutvalue);
            if (cutvalue == 0 || cutvalue == 128)
            {
                Console.WriteLine("Indirekt");
                return Global.Bank1[4];
            }
            else
            {
                Console.WriteLine("Direkt");
                return cutvalue;
            }
        }

        public void syncFSR()
        {
            Global.Bank1[132] = Global.Bank1[4];
        }

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

        public int Bank(int cutvalue)
        {
            if (getRP0() != 1)
            {
                return cutvalue;
            }
            else
            {
                return cutvalue + 128;
            }
        }

        public int getPrescaler()
        {
            int prescaler = 0;
            int ps0 = getPS0();
            int ps1 = getPS1();
            int ps2 = getPS2();

            if (ps0 == 1)
            {
                prescaler += 1;
            }

            if (ps1 == 1)
            {
                prescaler += 2;
            }
            if (ps2 == 1)
            {
                prescaler += 4;
            }

            if (WTDorTMR())
            {
                //TMR0
                switch (prescaler)
                {
                    case 0:
                        Global.prescaler = 2;
                        break;
                    case 1:
                        Global.prescaler = 4;
                        break;
                    case 2:
                        Global.prescaler = 8;
                        break;
                    case 3:
                        Global.prescaler = 16;
                        break;
                    case 4:
                        Global.prescaler = 32;
                        break;
                    case 5:
                        Global.prescaler = 64;
                        break;
                    case 6:
                        Global.prescaler = 128;
                        break;
                    case 7:
                        Global.prescaler = 256;
                        break;
                    default:
                        break;
                }

                return Global.prescaler;
            }
            else
            {
                //WTD
                switch (prescaler)
                {
                    case 0:
                        Global.prescaler = 1;
                        break;
                    case 1:
                        Global.prescaler = 2;
                        break;
                    case 2:
                        Global.prescaler = 4;
                        break;
                    case 3:
                        Global.prescaler = 8;
                        break;
                    case 4:
                        Global.prescaler = 16;
                        break;
                    case 5:
                        Global.prescaler = 32;
                        break;
                    case 6:
                        Global.prescaler = 64;
                        break;
                    case 7:
                        Global.prescaler = 128;
                        break;
                    default:
                        break;
                }

                return Global.prescaler;
            }


        }

        public bool WTDorTMR()
        {
            int psa = getPSA();

            if (psa == 0)
            {
                return true; //TMR0
            }
            else
            {
                return false; // WTD
            }
        }

        public int calcTMR(int programmcounter)
        {
            if (Global.Bank1[1] == 1 && Global.counter >= getPrescaler())
            {
                
                Global.counter = getPrescaler()-1;
                //Console.WriteLine("Counter set");
                return 0;
            }

            if (Global.counter == 0)
            {
                
                Global.counter = getPrescaler()-1;
                Global.Bank1[1]++;
                if (Global.Bank1[1] >= 255)
                {
                    //TimerInterrupt
                    Global.Bank1[11] |= 0b0000_0100;
                    Global.Bank1[139] |=  0b0000_0100;
                    
                    
                    
                    Global.Bank1[1] = 0;
                    Global.push(programmcounter);
                    
                    //wenn GIE dann pc-> adresse 4
                    if (getGIE() == 1)
                    {
                        Global.Bank1[11] &= 0b0111_1111;
                        Global.Bank1[139] &= 0b0111_1111;
                        return 4;
                    }
                    
                }
                //Console.WriteLine("Counter: " + Global.counter);
                return 0;
            }
            else
            {
                Global.counter--;
                //Console.WriteLine("Counter: " + Global.counter);
                return 0;
            }
        }

        public void calcWTD()
        {
            int prescaler = getPrescaler();

            switch (prescaler)
            {
                case 1:
                    Thread.Sleep(18);
                    Global.watchdog++;
                    break;
                case 2:
                    Thread.Sleep(36);
                    Global.watchdog++;
                    break;
                case 4:
                    Thread.Sleep(72);
                    Global.watchdog++;
                    break;
                case 8:
                    Thread.Sleep(144);
                    Global.watchdog++;
                    break;
                case 16:
                    Thread.Sleep(288);
                    Global.watchdog++;
                    break;
                case 32:
                    Thread.Sleep(576);
                    Global.watchdog++;
                    break;
                case 64:
                    Thread.Sleep(1100);
                    Global.watchdog++;
                    break;
                case 128:
                    Thread.Sleep(2300);
                    Global.watchdog++;
                    break;
                default:
                    break;
            }
        }

        public bool einzelnesBitAuslesen(int stelle, int cutvalue)
        {

            int zwischenwert;

            switch (stelle)
            {
                case 0:
                    zwischenwert = Global.Bank1[cutvalue] & 0b0000_0001;
                    if (zwischenwert == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case 1:
                    zwischenwert = Global.Bank1[cutvalue] & 0b0000_0010;
                    if (zwischenwert == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                case 2:
                    zwischenwert = Global.Bank1[cutvalue] & 0b0000_0100;
                    if (zwischenwert == 4)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case 3:
                    zwischenwert = Global.Bank1[cutvalue] & 0b0000_1000;
                    if (zwischenwert == 8)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case 4:
                    zwischenwert = Global.Bank1[cutvalue] & 0b0001_0000;
                    if (zwischenwert == 16)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case 5:
                    zwischenwert = Global.Bank1[cutvalue] & 0b0010_0000;
                    if (zwischenwert == 32)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 6:
                    zwischenwert = Global.Bank1[cutvalue] & 0b0100_0000;
                    if (zwischenwert == 64)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 7:
                    zwischenwert = Global.Bank1[cutvalue] & 0b1000_0000;
                    if (zwischenwert == 128)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    Console.WriteLine("Oh no something went wrong");
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

        public int getFinalCut(int programminhalt)
        {
            
            int cutvalue = ReadProgrammspeicherInhalt7(programminhalt);
            cutvalue = isIndirect(cutvalue);
            cutvalue = Bank(cutvalue);
            //Console.WriteLine("FinalCutMethode: " + cutvalue);
            return cutvalue;
        }

        public bool getDestination(int programminhalt)
        {
            int cutvalue = ReadProgrammspeicherInhalt(programminhalt);
            bool destination;
            destination = DestinationSet(cutvalue);
            //Console.WriteLine("Destination: " + destination);
            return destination;
        }

        //*********************************************
        //BYTE-ORIENTED FILE REGISTER OPERATIONS
        //*********************************************
        public int addwf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);
            int erg = 0;

            if (destination)
            {
                erg = Global.Bank1[cutvalue] + Global.w;
                ChangeC(erg);
                ChangeDCADD(Global.w, Global.Bank1[cutvalue]);

                if(erg >= 255)
                {
                    Global.Bank1[cutvalue] = (byte) (erg - 256);
                    ChangeZ(Global.Bank1[cutvalue]);
                }
                else
                {
                    Global.Bank1[cutvalue] = (byte) erg;
                    ChangeZ(Global.Bank1[cutvalue]);
                }
                
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Global.Bank1[cutvalue]);
                return programmcounter;
            }
            else
            {

                erg = Global.Bank1[cutvalue] + Global.w;
                ChangeC(erg);
                ChangeDCADD(Global.w, Global.Bank1[cutvalue]);

                if (erg >= 256)
                {
                    Global.w = (byte)(erg - 256);
                    ChangeZ(Global.w);
                }
                else
                {
                    Global.w = (byte)erg;
                    ChangeZ(Global.w);
                }
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + Global.w);
                return programmcounter;
            }
        }

        public int andwf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                Global.Bank1[cutvalue] = (byte) (Global.Bank1[cutvalue] & Global.w);
                ChangeZ(Global.Bank1[cutvalue]);
                
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Global.Bank1[cutvalue]);
                return programmcounter;
            }
            else
            {

                Global.w = (byte)(Global.Bank1[cutvalue] & Global.w);
                ChangeZ(Global.w);
                
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + Global.w);
                return programmcounter;
            }
        }

        public int clrf(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt7(programminhalt);
            cutvalue = isIndirect(cutvalue);
            cutvalue = Bank(cutvalue);

            Global.Bank1[cutvalue] = 0b0000_0000;

            ChangeZ(Global.Bank1[cutvalue]);

            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            Console.WriteLine("Speicherstelle: " + cutvalue + "Speicherinhalt: " + Global.Bank1[cutvalue]);
            return programmcounter;
        }

        public int clrw(int programminhalt, int programmcounter)
        {
            Global.w = 0b0000_0000;

            ChangeZ(Global.w);
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            Console.WriteLine("W-Register: " + Global.w);
            return programmcounter;
        }

        public int comf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                int Zwischenergebnis = ~Global.Bank1[cutvalue];
                Zwischenergebnis &= 0b1111_1111;
                //Console.WriteLine("Zwischenergebnis" + Zwischenergebnis);
                Global.Bank1[cutvalue - 128] = (byte) Zwischenergebnis;
                ChangeZ(Global.Bank1[cutvalue]);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Global.Bank1[cutvalue]);
                return programmcounter;
            }
            else 
            {

                int Zwischenergebnis = ~Global.Bank1[cutvalue];
                Zwischenergebnis &= 0b1111_1111;
                Global.w = (byte) Zwischenergebnis;
                ChangeZ(Global.w);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + Global.w);
                return programmcounter;
            }



        }

        public int decf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                int Zwischenergebnis = Global.Bank1[cutvalue] -1;
                Zwischenergebnis &= 0b1111_1111;
                //Console.WriteLine("Zwischenergebnis" + Zwischenergebnis);
                Global.Bank1[cutvalue] = (byte) Zwischenergebnis;
                ChangeZ(Global.Bank1[cutvalue]);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Global.Bank1[cutvalue]);
                return programmcounter;
            }
            else {

                int Zwischenergebnis = Global.Bank1[cutvalue] - 1;
                Zwischenergebnis &= 0b1111_1111;
                Global.w = (byte) Zwischenergebnis;
                ChangeZ(Global.w);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + Global.w);
                return programmcounter;
            }

        }

        public int decfsz(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);
            int erg;

            if (destination)
            {
                erg = Global.Bank1[cutvalue] - 1;
                if (erg == 0)
                {
                    nop(programminhalt, programmcounter);
                    if (calcTMR(programmcounter) == 4)
                    {
                        return 3;
                    }
                    return programmcounter + 1;
                }
                else
                {
                    Global.Bank1[cutvalue] = (byte) erg;
                    ChangeZ(Global.Bank1[cutvalue]);
                    Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Global.Bank1[cutvalue]);
                    //Console.WriteLine("Ergebnis: " + erg);
                    if (calcTMR(programmcounter) == 4)
                    {
                        return 3;
                    }
                    return programmcounter;
                }
                
            }
            else
            {

                erg = Global.Bank1[cutvalue] - 1;
                if (erg == 0)
                {
                    nop(programminhalt, programmcounter);
                    if (calcTMR(programmcounter) == 4)
                    {
                        return 3;
                    }
                    return programmcounter + 1;
                }
                else
                {
                    Global.w = (byte) erg;
                    ChangeZ(Global.w);
                    Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + Global.w);
                    //Console.WriteLine("Ergebnis: " + erg);
                    if (calcTMR(programmcounter) == 4)
                    {
                        return 3;
                    }
                    return programmcounter;
                }
                
            }
            
        }

        public int incf(int programminhalt, int programmcounter)
        {
            
            bool destination = getDestination(programminhalt);
            int cutvalue = getFinalCut(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);
            int erg;

            if (destination)
            {
                erg = Global.Bank1[cutvalue] + 1;
                if (erg >= 256)
                {
                    Global.Bank1[cutvalue] = (byte) (erg - 255);
                    ChangeZ(Global.Bank1[cutvalue]);
                }
                else
                {
                    Global.Bank1[cutvalue] = (byte) erg;
                    ChangeZ(Global.Bank1[cutvalue]);
                }

                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Global.Bank1[cutvalue]);
                return programmcounter;
            }
            else
            {

                erg = Global.Bank1[cutvalue] + 1;
                if (erg > 255)
                {
                    Global.w = (byte)(erg - 255);
                    ChangeZ(Global.w);
                }
                else
                {
                    Global.w = (byte) erg;
                    ChangeZ(Global.w);
                }
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + Global.w);
                return programmcounter;

            }
        }

        public int incfsz(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);
            int erg;

            if (destination)
            {
                erg = Global.Bank1[cutvalue] + 1;
                if (erg == 256)
                {
                    erg = 0;
                }

                if (erg == 0)
                {
                    nop(programminhalt, programmcounter);
                    if (calcTMR(programmcounter) == 4)
                    {
                        return 3;
                    }
                    return programmcounter + 1;
                }
                else
                {
                    Global.Bank1[cutvalue] = (byte) erg;
                    ChangeZ(Global.Bank1[cutvalue]);
                    Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Global.Bank1[cutvalue]);
                    //Console.WriteLine("Ergebnis: " + erg);
                    if (calcTMR(programmcounter) == 4)
                    {
                        return 3;
                    }
                    return programmcounter;
                }

            }
            else
            {
                
                erg = Global.Bank1[cutvalue] + 1;
                if (erg == 256)
                {
                    erg = 0;
                }

                if (erg == 0)
                {
                    nop(programminhalt, programmcounter);
                    if (calcTMR(programmcounter) == 4)
                    {
                        return 3;
                    }
                    return programmcounter + 1;
                }
                else
                {
                    Global.w = (byte) erg;
                    ChangeZ(Global.w);
                    Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + Global.w);
                    //Console.WriteLine("Ergebnis: " + erg);
                    if (calcTMR(programmcounter) == 4)
                    {
                        return 3;
                    }
                    return programmcounter;
                }

            }
        }

        public int iorwf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                Global.Bank1[cutvalue] = (byte) (Global.Bank1[cutvalue] | Global.w);
                ChangeZ(Global.Bank1[cutvalue]);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: " + cutvalue + "Speicherinhalt: " + Global.Bank1[cutvalue]);
                return programmcounter;
            }
            else
            {

                Global.w = (byte)(Global.Bank1[cutvalue] | Global.w);
                ChangeZ(Global.w);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + Global.w);
                return programmcounter;

            }
        }

        public int movf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                ChangeZ(Global.Bank1[cutvalue]);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Global.Bank1[cutvalue]);
                return programmcounter;
            }
            else
            {

                Global.w = Global.Bank1[cutvalue];
                ChangeZ(Global.w);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + Global.w);
                return programmcounter;

            }
        }

        public int movwf(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt7(programminhalt);
            cutvalue = isIndirect(cutvalue);
            cutvalue = Bank(cutvalue);

            Global.Bank1[cutvalue] = (byte) Global.w;
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            Console.WriteLine("Speicherstelle: " + cutvalue + "Speicherinhalt: " + Global.Bank1[cutvalue]);
            return programmcounter;
        }

        public int nop(int programminhalt, int programmcounter)
        {
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            Console.WriteLine("NOP - Succsessfull");
            return programmcounter;
        }

        public int rlf(int programminhalt, int c, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                int res = Global.Bank1[cutvalue];
                res = res  << 1;
                res = res + c;
                ChangeC(res);
                cutvalue = isIndirect(cutvalue);
                Global.Bank1[cutvalue] = (byte) (res & 0b1111_1111);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Global.Bank1[cutvalue]);
                return programmcounter;
            }
            else
            {
                int res = 0;
                res = Global.Bank1[cutvalue]  << 1;
                res = res + c;
                ChangeC(res);
                Global.w = (byte)(res & 0b1111_1111);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + Global.w);
                return programmcounter;
            }
        }

        public int rrf(int programminhalt, int c, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);
            
            if (destination)
            {
                //Console.WriteLine("Carry-Flag:" + c);
                int res = Global.Bank1[cutvalue];
                res += c << 8;
                res += (res & 0b1) << 10;
                res >>= 1;
                ChangeC(res);
                res &= 0b1111_1111;
                Global.Bank1[cutvalue] = (byte) res;
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Global.Bank1[cutvalue]);
                return programmcounter;
            }
            else
            {
                //Console.WriteLine("Carry-Flag:" + c);
                int res = Global.Bank1[cutvalue];
                res += c << 8;
                res += (res & 0b1) << 10;
                res >>= 1;
                ChangeC(res);
                res &= 0b1111_1111;
                Global.w = (byte) res;
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + Global.w);
                return programmcounter;

            }
        }

        public int subwf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                int res = (Global.Bank1[cutvalue] - Global.w) & 0b1111_1111;
                ChangeZ(res);
                ChangeCSUB(Global.Bank1[cutvalue]- Global.w);
                ChangeDCSUB(Global.w, Global.Bank1[cutvalue]);
                Global.Bank1[cutvalue] = (byte)res;
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Inhalt Bank1" + Global.Bank1[cutvalue]);
                return programmcounter;

            }
            else
            {

                int res = (Global.Bank1[cutvalue] - Global.w) & 0b1111_1111;
                ChangeZ(res);
                ChangeCSUB(Global.Bank1[cutvalue]- Global.w);
                ChangeDCSUB(Global.w, Global.Bank1[cutvalue]);
                Global.w = (byte) res;
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Inhalt w" + Global.w);
                return programmcounter;

            }
        }

        public int swapf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                Global.Bank1[cutvalue] = (byte) ((Global.Bank1[cutvalue] & 0x0F) << 4 |((Global.Bank1[cutvalue] & 0xF0) >> 4));
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Bank1 an der Stelle" + (cutvalue) + "Inahlt" + Global.Bank1[cutvalue]);
                return programmcounter;
            }
            else
            {
                Global.w = (byte) ((Global.Bank1[cutvalue] & 0x0F) << 4 | (Global.Bank1[cutvalue] & 0xF0) >> 4);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("W Register Inhalt" + Global.w);
                return programmcounter;
            }
        }

        public int xorwf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                Global.Bank1[cutvalue] = (byte) (Global.Bank1[cutvalue]  ^ Global.w);
                ChangeZ(Global.Bank1[cutvalue]);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Inhalt Bank1" + Global.Bank1[cutvalue]);
                return programmcounter;

            }
            else
            {

                Global.w = (byte) (Global.Bank1[cutvalue] ^ Global.w);
                ChangeZ(Global.w);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Inhalt w" + Global.w);
                return programmcounter;

            }
        }

        //*********************************************
        //BIT-ORIENTED FILE REGISTER OPERATIONS
        //*********************************************

        public int bcf(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt7(programminhalt);
            int clearvalue = ReadProgrammspeicherInhalt3(programminhalt);
            //Console.WriteLine("Bit Set an der Stelle:" + clearvalue);
            //Console.WriteLine("Cutvalue " + cutvalue);
            cutvalue = Bank(cutvalue);
            cutvalue = isIndirect(cutvalue);
            bool bitgesetzt = einzelnesBitAuslesen(clearvalue, cutvalue);
            //Console.WriteLine(bitgesetzt);


            if (bitgesetzt != false)
            {
                    switch (clearvalue)
                    {
                        case 0:
                            Global.Bank1[cutvalue] = (byte) (Global.Bank1[cutvalue] & 0b1111_1110);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte) (Global.Bank1[131] & 0b1111_1110); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte) (Global.Bank1[3] & 0b1111_1110); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte) (Global.Bank1[139] & 0b1111_1110); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte) (Global.Bank1[11] & 0b1111_1110); }
                        Console.WriteLine("Bit 1 cleared");
                            break;
                    
                        case 1:
                            Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] & 0b1111_1101);

                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] & 0b1111_1101); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] & 0b1111_1101); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] & 0b1111_1101); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] & 0b1111_1101); }
                        Console.WriteLine("Bit 1 cleared");
                            break;

                        case 2:
                            Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] & 0b1111_1011);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] & 0b1111_1011); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] & 0b1111_1011); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] & 0b1111_1011); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] & 0b1111_1011); }
                        Console.WriteLine("Bit 2 cleared");
                            break;

                        case 3:
                            Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] & 0b1111_0111);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] & 0b1111_0111); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] & 0b1111_0111); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] & 0b1111_0111); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] & 0b1111_0111); }
                        Console.WriteLine("Bit 3 cleared");
                            break;

                        case 4:
                            Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] & 0b1110_1111);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] & 0b1110_1111); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] & 0b1110_1111); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] & 0b1110_1111); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] & 0b1110_1111); }
                        Console.WriteLine("Bit 4 cleared");
                            break;

                        case 5:
                            Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] & 0b1101_1111);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] & 0b1101_1111); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] & 0b1101_1111); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] & 0b1101_1111); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] & 0b1101_1111); }
                        Console.WriteLine("Bit 5 cleared");
                            break;

                        case 6:
                            Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] & 0b1011_1111);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] & 0b1011_1111); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] & 0b1011_1111); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] & 0b1011_1111); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[111] & 0b1011_1111); }
                        Console.WriteLine("Bit 6 cleared");
                            break;

                        case 7:
                            Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] & 0b0111_1111);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] & 0b0111_1111); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] & 0b0111_1111); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] & 0b0111_1111); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] & 0b0111_1111); }
                        Console.WriteLine("Bit 7 cleared");
                            break;

                        default:
                            Console.WriteLine("Oh no something went wrong");
                            break;

                }
                if(calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                return programmcounter;
            }
            else
            {
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("Bit Already Cleared");
                return programmcounter;
            }
          
        }

        public int bsf(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt7(programminhalt);
            int clearvalue = ReadProgrammspeicherInhalt3(programminhalt);
            //Console.WriteLine("Bit Set an der Stelle:" + clearvalue);
            //Console.WriteLine("Cutvalue " + cutvalue);
            cutvalue = Bank(cutvalue);
            cutvalue = isIndirect(cutvalue);
            bool bitgesetzt = einzelnesBitAuslesen(clearvalue, cutvalue);
            //Console.WriteLine(bitgesetzt);

            if (bitgesetzt == false)
            {

                switch (clearvalue)
                {
                    case 0:
                        Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] | 0b0000_0001);
                        if(cutvalue == 3) {Global.Bank1[131] = (byte)(Global.Bank1[131] | 0b0000_0001); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] | 0b0000_0001); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] | 0b0000_0001); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] | 0b0000_0001); }
                        Console.WriteLine("Bit 0 set");
                        break;

                    case 1:
                        Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] | 0b0000_0010);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] | 0b0000_0010); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] | 0b0000_0010); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] | 0b0000_0010); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] | 0b0000_0010); }
                        Console.WriteLine("Bit 1 set");
                        break;
                        

                    case 2:
                        Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] | 0b0000_0100);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] | 0b0000_0100); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] | 0b0000_0100); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] | 0b0000_0100); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] | 0b0000_0100); }
                        Console.WriteLine("Bit 2 set");
                        break;

                    case 3:
                        Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] | 0b0000_1000);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] | 0b0000_1000); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] | 0b0000_1000); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] | 0b0000_1000); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] | 0b0000_1000); }
                        Console.WriteLine("Bit 3 set");
                        break;

                    case 4:
                        Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] | 0b0001_0000);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] | 0b0001_0000); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] | 0b0001_0000); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] | 0b0001_0000); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] | 0b0001_0000); }
                        Console.WriteLine("Bit 4 set");
                        break;

                    case 5:
                        Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] ^ 0b0010_0000);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] | 0b0010_0000); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] | 0b0010_0000); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] | 0b0010_0000); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] | 0b0010_0000); }
                        Console.WriteLine("Bit 5 set");
                        break;

                    case 6:
                        Global.Bank1[cutvalue] = (byte) (Global.Bank1[cutvalue]  | 0b0100_0000);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] | 0b0100_0000); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] | 0b0100_0000); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] | 0b0100_0000); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] | 0b0100_0000); }
                        Console.WriteLine("Bit 6 set");
                        break;

                    case 7:
                        Global.Bank1[cutvalue] = (byte)(Global.Bank1[cutvalue] | 0b1000_0000);
                        if (cutvalue == 3) { Global.Bank1[131] = (byte)(Global.Bank1[131] | 0b1000_0000); }
                        if (cutvalue == 131) { Global.Bank1[3] = (byte)(Global.Bank1[3] | 0b1000_0000); }

                        if (cutvalue == 11) { Global.Bank1[139] = (byte)(Global.Bank1[139] | 0b1000_0000); }
                        if (cutvalue == 139) { Global.Bank1[11] = (byte)(Global.Bank1[11] | 0b1000_0000); }
                        Console.WriteLine("Bit 7 set");
                        break;

                    default:
                        Console.WriteLine("Oh no something went wrong");
                        break;

                }
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                return programmcounter;
            }

            else { 
            Console.WriteLine("Bit Already Set");
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                return programmcounter;
            }
        }

        public int btfsc(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt7(programminhalt);
            int clearvalue = ReadProgrammspeicherInhalt3(programminhalt);
            //Console.WriteLine("Bit Test an der Stelle:" + clearvalue);
            cutvalue = isIndirect(cutvalue);
            cutvalue = Bank(cutvalue);
            bool bitgesetzt = einzelnesBitAuslesen(clearvalue, cutvalue);
            //Console.WriteLine(bitgesetzt);


            if (bitgesetzt == false)
            {
                Console.WriteLine("Bit clear Skip");
                nop(programminhalt, programmcounter);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                return programmcounter = programmcounter + 1;
            }
            else
            {
                Console.WriteLine("Bit not clear no skip");
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                return programmcounter;
            }

        }

        public int btfss(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt7(programminhalt);
            int clearvalue = ReadProgrammspeicherInhalt3(programminhalt);
            //Console.WriteLine("Bit Test an der Stelle;", clearvalue);
            cutvalue = isIndirect(cutvalue);
            cutvalue = Bank(cutvalue);
            bool bitgesetzt = einzelnesBitAuslesen(clearvalue, cutvalue);

            if (bitgesetzt != false)
            {
                Console.WriteLine("Bit set skip");
                nop(programminhalt, programmcounter);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                return programmcounter = programmcounter + 1;
            }
            else
            {
                Console.WriteLine("Bit not set no Skip");
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                return programmcounter;
            }

        }

        //*********************************************
        //LITERAL AND CONTROL OPERATIONS
        //*********************************************
        public int addlw(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt(programminhalt);

            int res = (Global.w + cutvalue) & 0b1111_1111;

            ChangeZ(res);
            ChangeC(Global.w+ cutvalue);
            ChangeDCADD(Global.w, cutvalue);
            Global.w = (byte) res;

            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            Console.WriteLine("Inhalt W-Register: {0}", Global.w);
            return programmcounter;
        }

        public int andlw(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt(programminhalt);

            int inhaltw = Global.w;

            int erg = cutvalue & inhaltw;

            ChangeZ(erg);

            Global.w = (byte) erg;
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            Console.WriteLine("Inhalt W-Register: {0}", Global.w);
            return programmcounter;
        }
        public int call(int programminhalt, int programmcounter) 
        {
            int cutvalue = ReadProgrammspeicherInhalt11(programminhalt);

            //Console.WriteLine("Programmcounter: " + programmcounter);
            Global.push(programmcounter);
            Console.WriteLine("Sprungziel: " + cutvalue);
            //Console.WriteLine("Top of Stack: " + Global.stack[Global.stackindex]);
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            return cutvalue - 1;
        }

        public int clrwdt(int programminhalt, int programmcounter)
        {
            Global.watchdog = 0;
            Global.Bank1[3] = 0b0001_1000;
            Global.Bank1[131] = 0b0001_1000;
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            Console.WriteLine("Watchdog cleared" + Global.Bank1[3]);
            return programmcounter;

        }

        public int Goto(int programminhalt, int programmcounter)
        {
            string binary = Convert.ToString(programminhalt, 2); //transformiert in BIN
            //Console.WriteLine(binary);

            string pattern = @"\S\S\S\S\S\S\S\S\S\S\S\b";
            string input = binary;
            string cut = "";
            int cutvalue;
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                //Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
                cut = m.Value;
            }

            cutvalue = Convert.ToInt32(cut, 2);
            Console.WriteLine("Sprungadresse: {0}", cutvalue);
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            return cutvalue -1;
        }

        public int iorlw(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt(programminhalt);
            //Console.WriteLine(cutvalue);

            string inhw = Convert.ToString(Global.w, 2);
            int inhaltw = Convert.ToInt32(inhw, 2);
            //Console.WriteLine(inhaltw);

            Global.w = (byte) (cutvalue | inhaltw);

            ChangeZ(Global.w);
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            Console.WriteLine("Inhalt W-Register: {0}", Global.w);
            return programmcounter;
        }

        public int movlw(int programminhalt, int programmcounter) //kommt als DEC an 
        {
            int cutvalue = ReadProgrammspeicherInhalt(programminhalt);

            Global.w = (byte) cutvalue;
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            Console.WriteLine("Inhalt W-Register: {0}", Global.w);
            return programmcounter;
        }

        public int retfie(int programminhalt, int programmcounter)
        {
            int GIEset = Global.Bank1[11] & 0b1000_0000;
            Global.Bank1[11] = (byte) (Global.Bank1[11] | 0b1000_0000);
            Global.Bank1[139] = (byte)(Global.Bank1[139] | 0b1000_0000);
            if (GIEset == 128)
            {
                Console.WriteLine("Nothing to do");
                
                return Global.pop();
            }
            else
            {
                Global.Bank1[11] = (byte)(Global.Bank1[11] + 128);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("GIE Set");
                return Global.pop();
            }
        }

        public int retlw(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt(programminhalt);

            Global.w = (byte) cutvalue;
            Console.WriteLine(Global.w);
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            return Global.pop();
        }

        public int RETURN(int programminhalt, int programmcounter)
        {
            Console.WriteLine("RETURN:" + Global.programmcounter);
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            return Global.pop();
        }

        public int sleep(int programminhalt, int programmcounter)
        {     //PD = 0, TO = 1, WTD = 0

            if (getPD() == 1)
            {
                Global.Bank1[3] = (byte)(Global.Bank1[3] & 0b1111_0111);
                Global.Bank1[131] = (byte)(Global.Bank1[131] & 0b1111_0111);
            }
            

            if (getTO() == 0)
            {
                Global.Bank1[3] = (byte)(Global.Bank1[3] | 0b0001_0000);
                Global.Bank1[131] = (byte)(Global.Bank1[131] | 0b0001_0000);
            }
            

            Global.watchdog = 0;
            calcWTD();

            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            return programmcounter;
        }

        public int sublw(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt(programminhalt);

            int res = (cutvalue - Global.w) & 0b1111_1111;

            ChangeZ(res);
            ChangeCSUB(cutvalue-Global.w);
            ChangeDCSUB(Global.w, cutvalue);

            Global.w = (byte) res;
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            Console.WriteLine("Inhalt W-Register Test: {0}" , Global.w);
            return programmcounter;
        }

        public int xorlw(int programminhalt, int programmcounter)
        {
            int cutvalue = ReadProgrammspeicherInhalt(programminhalt);

            Global.w ^= (byte) cutvalue;
            ChangeZ(Global.w);
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            Console.WriteLine("Inhalt W-Register = {0}", Global.w);
            return programmcounter;
        }

        //*********************************************
        //GUI Zeug
        //*********************************************

        public int getIRP()
        {
            int erg = Global.Bank1[3] & 0b1000_0000;
            if(erg == 128)
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
            int erg = Global.Bank1[3] & 0b0100_0000;
            if (erg == 64)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getRP0()
        {
            int erg = Global.Bank1[3] & 0b0010_0000;
            if (erg == 32)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getTO()
        {
            int erg = Global.Bank1[3] & 0b0001_0000;
            if (erg == 16)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getPD()
        {
            int erg = Global.Bank1[3] & 0b0000_1000;
            if (erg == 8)
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
            int erg = Global.Bank1[3] & 0b0000_0100;
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
            int erg = Global.Bank1[3] & 0b0000_0010;
            if (erg == 2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getC()
        {
            int erg = Global.Bank1[3] & 0b0000_0001;
            if (erg == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //Get Option Bits
        public int getRPu()
        {
            int erg = Global.Bank1[129] & 0b1000_0000;
            if (erg == 128)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int getIEg()
        {
            int erg = Global.Bank1[129] & 0b0100_0000;
            if (erg == 64)
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
            int erg = Global.Bank1[129] & 0b0010_0000;
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
            int erg = Global.Bank1[129] & 0b0001_0000;
            if (erg == 16)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getPSA()
        {
            int erg = Global.Bank1[129] & 0b0000_1000;
            if (erg == 8)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getPS2()
        {
            int erg = Global.Bank1[129] & 0b0000_0100;
            if (erg == 4)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getPS1()
        {
            int erg = Global.Bank1[129] & 0b0000_0010;
            if (erg == 2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getPS0()
        {
            int erg = Global.Bank1[129] & 0b0000_0001;
            if (erg == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //Get INTCON Bits
        public int getGIE()
        {
            int erg = Global.Bank1[11] & 0b1000_0000;
            if (erg > 0)
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
            int erg = Global.Bank1[11] & 0b0100_0000;
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
            int erg = Global.Bank1[11] & 0b0010_0000;
            if (erg == 32)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getIE()
        {
            int erg = Global.Bank1[11] & 0b0001_0000;
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
            int erg = Global.Bank1[11] & 0b0000_1000;
            if (erg == 8)
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
            int erg = Global.Bank1[11] & 0b0000_0100;
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
            int erg = Global.Bank1[11] & 0b0000_0010;
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
            int erg = Global.Bank1[11] & 0b0000_0001;
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
            return Global.w;
        }

        public int getFSR()
        {
            return Global.Bank1[4];
        }

        public int getStatus()
        {
            return Global.Bank1[3];
        }

        public int getOption()
        {
            return Global.Bank1[129];
        }

        public int getStack1()
        {
            return Global.stack[0];
        }
        public int getStack2()
        {
            return Global.stack[1];
        }
        public int getStack3()
        {
            return Global.stack[2];
        }
        public int getStack4()
        {
            return Global.stack[3];
        }
        public int getStack5()
        {
            return Global.stack[4];
        }
        public int getStack6()
        {
            return Global.stack[5];
        }
        public int getStack7()
        {
            return Global.stack[6];
        }
        public int getStack8()
        {
            return Global.stack[7];
        }

        public int getTrisA()
        {
            return Global.Bank1[133];
        }

        public int getTrisB()
        {
            Console.WriteLine("TrisB" + Global.Bank1[134]);
            return Global.Bank1[134];
        }

        public int Pinbelegung(int portA, int portB, int programmcounter)
        {
            byte portAvorher = (byte) Global.Bank1[5];
            byte portBvorher = (byte) Global.Bank1[6];
            Global.Bank1[5] = (byte) portA;
            Global.Bank1[6] = (byte) portB;
            bool rb0int = false;
            bool rbint  = false ;
            //int ursprung = Global.stack[0];

            if (getIEg() == 1)
            {
                //steigende 
                if ((portBvorher & 0b0000_0001) == 0 && (portB & 0b0000_0001) == 1)
                {
                    Global.Bank1[11] |= 0b0000_0010;

                    if (getGIE() ==1 && getIE() == 1)
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
                    Global.Bank1[11] |= 0b0000_0010;

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
            
            //Console.WriteLine("PortA: " + Global.Bank1[5]);
            //Console.WriteLine("PortB: " + Global.Bank1[6]);
            return programmcounter;
        }

        public bool RB0Interrupt(int portA, int portB, int programmcounter)
        {
            int eingang = Global.Bank1[134] & 0b0000_0001;

            if (eingang == 1)
            {
                            Console.WriteLine("RB0 Interrupt");
                            //RB0 Interruptflag
                            Global.Bank1[11] = (byte)(Global.Bank1[11] | 0b0000_0010);
                            Global.Bank1[139] = (byte)(Global.Bank1[139] | 0b0000_0010);

                            Global.Bank1[11] = (byte)(Global.Bank1[11] & 0b0111_1111);
                            Global.Bank1[139] = (byte)(Global.Bank1[139] & 0b0111_1111);
                            Global.push(programmcounter);
                            return true;
            }

            return false;
        }

        public bool RBInterrupt(int portAvorher, int programmcounter)
        {
            int eingang = Global.Bank1[134] & 0b1111_0000;



            if (eingang != 0 )
            {
                if (getGIE() == 1)
                {
                    if (getRIE() == 1)
                    {
                        Console.WriteLine("RB Interrupt");

                        int interrupt = Global.Bank1[6] & 0b1111_0000;
                        if (16 <= interrupt && interrupt <= 128)
                        {
                            Console.WriteLine("RB Interrupt");
                            //RB0 Interruptflag
                            Global.Bank1[11] = (byte)(Global.Bank1[11] | 0b0000_0001);
                            Global.Bank1[139] = (byte)(Global.Bank1[139] | 0b0000_0001);
                            
                            Global.Bank1[11] = (byte)(Global.Bank1[11] & 0b0111_1111);
                            Global.Bank1[139] = (byte)(Global.Bank1[139] & 0b0111_1111);
                            Global.push(programmcounter);
                            return true;
                        }
                    }
                }

            }

            return false;
        }

        public int GetPortA()
        {
            return Global.Bank1[5];
        }

        public int GetPortB()
        {
            return Global.Bank1[6];
        }

        public float getWatchdog()
        {
            return Global.watchdog;
        }

        public int getBankInhalt(int stelle)
        {
            return Global.Bank1[stelle];
        }

        public int getPrescalerGUI()
        {
            return Global.prescaler;
        }

        public int getTimer0()
        {
            return Global.Bank1[1];
        }

        public void updateFile(int speicherstelle, int wert)
        {
            Global.Bank1[speicherstelle] = (byte) wert;
        }
    }
}
