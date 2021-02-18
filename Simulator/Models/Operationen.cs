﻿using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Simulator
{
    public class Operationen
    {
        public byte w { get; set; } //Work Register

        public byte[] Bank1 = new byte[256];

        //Watchdog
        public float watchdog { get; set; }
        public int prescaler { get; set; }
        public int counter { get; set; }

        public int[] stack = new int[8];
        public int stackindex { get; set; }


        Management man = new Management();

        public Operationen()
        {
            w = 0;
            watchdog = 0;
            prescaler = 1;
            stackindex = -1;

        }

        public void push(int element)
        {
            if (stackindex <= 7)
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

        public void ChangeZ(int result)
        {
            if (result == 0)
            {
                Bank1[3] |= 0b0000_0100;
                Bank1[131] |= 0b0000_0100;
            }
            else
            {
                Bank1[3] &= 0b1111_1011;
                Bank1[131] &= 0b1111_1011;
            }
        }

        public void ChangeC(int result)
        {
            if (result > 255)
            {
                Bank1[3] |= 0b0000_0001;
                Bank1[131] |= 0b0000_0001;
            }
            else
            {
                Bank1[3] &= 0b1111_1110;
                Bank1[131] &= 0b1111_1110;
            }
        }

        public void ChangeCSUB(int result)
        {
            if (result >= 0)
            {
                Bank1[3] |= 0b0000_0001;
                Bank1[131] |= 0b0000_0001;
            }
            else
            {
                Bank1[3] &= 0b1111_1110;
                Bank1[131] &= 0b1111_1110;
            }
        }

        public void ChangeDCADD(int w, int data) //nur für Addition
        {
            w &= 15;
            data &= 15;

            int hilfe = w + data;
            if (hilfe > 15)
            {
                Bank1[3] |= 0b0000_0010;
                Bank1[131] |= 0b0000_0010;
            }
            else
            {
                Bank1[3] &= 0b1111_1101;
                Bank1[131] &= 0b1111_1101;
            }
        }

        public void ChangeDCSUB(int w, int data) //nur für Subtraktion
        {
            w &= 15;
            data &= 15;

            int hilfe = data - w;
            if (hilfe >= 0)
            {
                Bank1[3] |= 0b0000_0010;
                Bank1[131] |= 0b0000_0010;
            }
            else
            {
                Bank1[3] &= 0b1111_1101;
                Bank1[131] |= 0b1111_1101;
            }
        }

        public int isIndirect(int cutvalue)
        {
            //Console.WriteLine("Cutvalue ID" + cutvalue);
            if (cutvalue == 0 || cutvalue == 128)
            {
                Console.WriteLine("Indirekt");
                return Bank1[4];
            }
            else
            {
                Console.WriteLine("Direkt");
                return cutvalue;
            }
        }

        public void syncFSR()
        {
            Bank1[132] = Bank1[4];
        }

        public void InitialisierungBaenke()
        {
            for (int i = 0; i < Bank1.Length; i++)
            {
                Bank1[i] = 0b0000_0000;
            }

            Bank1[0] = 0b0000_0000; //INDF
            Bank1[1] = 0b0000_0000; //TMR0
            Bank1[2] = 0b0000_0000; //PCL
            Bank1[3] = 0b0001_1000; //STATUS
            Bank1[4] = 0b0000_0000; //FSR
            Bank1[5] = 0b0000_0000; //PORTA
            Bank1[6] = 0b0000_0000; //PORTB
            Bank1[8] = 0b0000_0000; //EEDATA
            Bank1[9] = 0b0000_0000; //EEADR
            Bank1[10] = 0b0000_0000; //PCLATH
            Bank1[11] = 0b0000_0000; //INTCON

            Bank1[128] = 0b0000_0000; //INDF
            Bank1[129] = 0b1111_1111; //OPTION_REG
            Bank1[130] = 0b0000_0000; //PCL
            Bank1[131] = 0b0001_1000; //STATUS
            Bank1[132] = 0b0000_0000; //FSR
            Bank1[133] = 0b1111_1111; //TRISA
            Bank1[134] = 0b1111_1111; //TRISB
            Bank1[136] = 0b0000_0000; //EECON1
            Bank1[137] = 0b0000_0000; //EECON2
            Bank1[138] = 0b0000_0000; //PCLATH
            Bank1[139] = 0b0000_0000; //INTCON

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
                        prescaler = 2;
                        break;
                    case 1:
                        prescaler = 4;
                        break;
                    case 2:
                        prescaler = 8;
                        break;
                    case 3:
                        prescaler = 16;
                        break;
                    case 4:
                        prescaler = 32;
                        break;
                    case 5:
                        prescaler = 64;
                        break;
                    case 6:
                        prescaler = 128;
                        break;
                    case 7:
                        prescaler = 256;
                        break;
                    default:
                        break;
                }

                return prescaler;
            }
            else
            {
                //WTD
                switch (prescaler)
                {
                    case 0:
                        prescaler = 1;
                        break;
                    case 1:
                        prescaler = 2;
                        break;
                    case 2:
                        prescaler = 4;
                        break;
                    case 3:
                        prescaler = 8;
                        break;
                    case 4:
                        prescaler = 16;
                        break;
                    case 5:
                        prescaler = 32;
                        break;
                    case 6:
                        prescaler = 64;
                        break;
                    case 7:
                        prescaler = 128;
                        break;
                    default:
                        break;
                }

                return prescaler;
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
            if (Bank1[1] == 1 && counter >= getPrescaler())
            {

                counter = getPrescaler() - 1;
                //Console.WriteLine("Counter set");
                return 0;
            }

            if (counter == 0)
            {

                counter = getPrescaler() - 1;
                Bank1[1]++;
                if (Bank1[1] >= 255)
                {
                    //TimerInterrupt
                    Bank1[11] |= 0b0000_0100;
                    Bank1[139] |= 0b0000_0100;



                    Bank1[1] = 0;
                    push(programmcounter);

                    //wenn GIE dann pc-> adresse 4
                    if (getGIE() == 1)
                    {
                        Bank1[11] &= 0b0111_1111;
                        Bank1[139] &= 0b0111_1111;
                        return 4;
                    }

                }
                //Console.WriteLine("Counter: " + counter);
                return 0;
            }
            else
            {
                counter--;
                //Console.WriteLine("Counter: " + counter);
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
                    watchdog++;
                    break;
                case 2:
                    Thread.Sleep(36);
                    watchdog++;
                    break;
                case 4:
                    Thread.Sleep(72);
                    watchdog++;
                    break;
                case 8:
                    Thread.Sleep(144);
                    watchdog++;
                    break;
                case 16:
                    Thread.Sleep(288);
                    watchdog++;
                    break;
                case 32:
                    Thread.Sleep(576);
                    watchdog++;
                    break;
                case 64:
                    Thread.Sleep(1100);
                    watchdog++;
                    break;
                case 128:
                    Thread.Sleep(2300);
                    watchdog++;
                    break;
                default:
                    break;
            }
        }

        public int isInterrupt(int programmcounter)
        {
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }

            return programmcounter;
        }

        public bool einzelnesBitAuslesen(int stelle, int cutvalue)
        {

            int zwischenwert;

            switch (stelle)
            {
                case 0:
                    zwischenwert = Bank1[cutvalue] & 0b0000_0001;
                    if (zwischenwert == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case 1:
                    zwischenwert = Bank1[cutvalue] & 0b0000_0010;
                    if (zwischenwert == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                case 2:
                    zwischenwert = Bank1[cutvalue] & 0b0000_0100;
                    if (zwischenwert == 4)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case 3:
                    zwischenwert = Bank1[cutvalue] & 0b0000_1000;
                    if (zwischenwert == 8)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case 4:
                    zwischenwert = Bank1[cutvalue] & 0b0001_0000;
                    if (zwischenwert == 16)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case 5:
                    zwischenwert = Bank1[cutvalue] & 0b0010_0000;
                    if (zwischenwert == 32)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 6:
                    zwischenwert = Bank1[cutvalue] & 0b0100_0000;
                    if (zwischenwert == 64)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 7:
                    zwischenwert = Bank1[cutvalue] & 0b1000_0000;
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

        public int getFinalCut(int programminhalt)
        {

            int cutvalue = man.ReadProgrammspeicherInhalt7(programminhalt);
            cutvalue = isIndirect(cutvalue);
            cutvalue = Bank(cutvalue);
            //Console.WriteLine("FinalCutMethode: " + cutvalue);
            return cutvalue;
        }

        //*********************************************
        //BYTE-ORIENTED FILE REGISTER OPERATIONS
        //*********************************************
        public int addwf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);
            int erg = 0;

            if (destination)
            {
                erg = Bank1[cutvalue] + w;
                ChangeC(erg);
                ChangeDCADD(w, Bank1[cutvalue]);

                if(erg >= 255)
                {
                    Bank1[cutvalue] = (byte) (erg - 256);
                    ChangeZ(Bank1[cutvalue]);
                }
                else
                {
                    Bank1[cutvalue] = (byte) erg;
                    ChangeZ(Bank1[cutvalue]);
                }
                
                Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Bank1[cutvalue]);
                return isInterrupt(programmcounter);
                
                
            }
            else
            {

                erg = Bank1[cutvalue] + w;
                ChangeC(erg);
                ChangeDCADD(w, Bank1[cutvalue]);

                if (erg >= 256)
                {
                    w = (byte)(erg - 256);
                    ChangeZ(w);
                }
                else
                {
                    w = (byte)erg;
                    ChangeZ(w);
                }
                Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + w);
                return isInterrupt(programmcounter);
            }
        }

        public int andwf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                Bank1[cutvalue] = (byte) (Bank1[cutvalue] & w);
                ChangeZ(Bank1[cutvalue]);

                return isInterrupt(programmcounter);
            }
            else
            {

                w = (byte)(Bank1[cutvalue] & w);
                ChangeZ(w);

                return isInterrupt(programmcounter);
            }
        }

        public int clrf(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt7(programminhalt);
            cutvalue = isIndirect(cutvalue);
            cutvalue = Bank(cutvalue);

            Bank1[cutvalue] = 0b0000_0000;

            ChangeZ(Bank1[cutvalue]);

            return isInterrupt(programmcounter);
        }

        public int clrw(int programminhalt, int programmcounter)
        {
            w = 0b0000_0000;

            ChangeZ(w);
            return isInterrupt(programmcounter);
        }

        public int comf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                int Zwischenergebnis = ~Bank1[cutvalue];
                Zwischenergebnis &= 0b1111_1111;
                //Console.WriteLine("Zwischenergebnis" + Zwischenergebnis);
                Bank1[cutvalue - 128] = (byte) Zwischenergebnis;
                ChangeZ(Bank1[cutvalue]);
                return isInterrupt(programmcounter);
            }
            else 
            {

                int Zwischenergebnis = ~Bank1[cutvalue];
                Zwischenergebnis &= 0b1111_1111;
                w = (byte) Zwischenergebnis;
                ChangeZ(w);
                return isInterrupt(programmcounter);
            }



        }

        public int decf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                int Zwischenergebnis = Bank1[cutvalue] -1;
                Zwischenergebnis &= 0b1111_1111;
                //Console.WriteLine("Zwischenergebnis" + Zwischenergebnis);
                Bank1[cutvalue] = (byte) Zwischenergebnis;
                ChangeZ(Bank1[cutvalue]);

                return isInterrupt(programmcounter);
            }
            else {

                int Zwischenergebnis = Bank1[cutvalue] - 1;
                Zwischenergebnis &= 0b1111_1111;
                w = (byte) Zwischenergebnis;
                ChangeZ(w);

                return isInterrupt(programmcounter);
            }

        }

        public int decfsz(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);
            int erg;

            if (destination)
            {
                erg = Bank1[cutvalue] - 1;
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
                    Bank1[cutvalue] = (byte) erg;
                    ChangeZ(Bank1[cutvalue]);
                    Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Bank1[cutvalue]);
                    //Console.WriteLine("Ergebnis: " + erg);
                    
                    return isInterrupt(programmcounter);
                }
                
            }
            else
            {

                erg = Bank1[cutvalue] - 1;
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
                    w = (byte) erg;
                    ChangeZ(w);
                    Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + w);
                    //Console.WriteLine("Ergebnis: " + erg);
                    
                    return isInterrupt(programmcounter);
                }
                
            }
            
        }

        public int incf(int programminhalt, int programmcounter)
        {
            
            bool destination = man.getDestination(programminhalt);
            int cutvalue = getFinalCut(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);
            int erg;

            if (destination)
            {
                erg = Bank1[cutvalue] + 1;
                if (erg >= 256)
                {
                    Bank1[cutvalue] = (byte) (erg - 255);
                    ChangeZ(Bank1[cutvalue]);
                }
                else
                {
                    Bank1[cutvalue] = (byte) erg;
                    ChangeZ(Bank1[cutvalue]);
                }

                return isInterrupt(programmcounter);
            }
            else
            {

                erg = Bank1[cutvalue] + 1;
                if (erg > 255)
                {
                    w = (byte)(erg - 255);
                    ChangeZ(w);
                }
                else
                {
                    w = (byte) erg;
                    ChangeZ(w);
                }

                return isInterrupt(programmcounter);

            }
        }

        public int incfsz(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);
            int erg;

            if (destination)
            {
                erg = Bank1[cutvalue] + 1;
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
                    Bank1[cutvalue] = (byte) erg;
                    ChangeZ(Bank1[cutvalue]);
                    Console.WriteLine("Speicherstelle: " + (cutvalue) + "Speicherinhalt: " + Bank1[cutvalue]);
                    //Console.WriteLine("Ergebnis: " + erg);

                    return isInterrupt(programmcounter);
                }

            }
            else
            {
                
                erg = Bank1[cutvalue] + 1;
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
                    w = (byte) erg;
                    ChangeZ(w);
                    Console.WriteLine("Speicherstelle: W" + "Speicherinhalt: " + w);
                    //Console.WriteLine("Ergebnis: " + erg);
                    
                    return isInterrupt(programmcounter);
                }

            }
        }

        public int iorwf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                Bank1[cutvalue] = (byte) (Bank1[cutvalue] | w);
                ChangeZ(Bank1[cutvalue]);

                return isInterrupt(programmcounter);
            }
            else
            {

                w = (byte)(Bank1[cutvalue] | w);
                ChangeZ(w);

                return isInterrupt(programmcounter);

            }
        }

        public int movf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                ChangeZ(Bank1[cutvalue]);

                return isInterrupt(programmcounter);
            }
            else
            {

                w = Bank1[cutvalue];
                ChangeZ(w);

                return isInterrupt(programmcounter);

            }
        }

        public int movwf(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt7(programminhalt);
            cutvalue = isIndirect(cutvalue);
            cutvalue = Bank(cutvalue);

            Bank1[cutvalue] = (byte) w;

            return isInterrupt(programmcounter);
        }

        public int nop(int programminhalt, int programmcounter)
        {
            return isInterrupt(programmcounter);

        }

        public int rlf(int programminhalt, int c, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                int res = Bank1[cutvalue];
                res = res  << 1;
                res = res + c;
                ChangeC(res);
                cutvalue = isIndirect(cutvalue);
                Bank1[cutvalue] = (byte) (res & 0b1111_1111);

                return isInterrupt(programmcounter);
            }
            else
            {
                int res = 0;
                res = Bank1[cutvalue]  << 1;
                res = res + c;
                ChangeC(res);
                w = (byte)(res & 0b1111_1111);

                return isInterrupt(programmcounter);
            }
        }

        public int rrf(int programminhalt, int c, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);
            
            if (destination)
            {
                //Console.WriteLine("Carry-Flag:" + c);
                int res = Bank1[cutvalue];
                res += c << 8;
                res += (res & 0b1) << 10;
                res >>= 1;
                ChangeC(res);
                res &= 0b1111_1111;
                Bank1[cutvalue] = (byte) res;

                return isInterrupt(programmcounter);
            }
            else
            {
                //Console.WriteLine("Carry-Flag:" + c);
                int res = Bank1[cutvalue];
                res += c << 8;
                res += (res & 0b1) << 10;
                res >>= 1;
                ChangeC(res);
                res &= 0b1111_1111;
                w = (byte) res;

                return isInterrupt(programmcounter);

            }
        }

        public int subwf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                int res = (Bank1[cutvalue] - w) & 0b1111_1111;
                ChangeZ(res);
                ChangeCSUB(Bank1[cutvalue]- w);
                ChangeDCSUB(w, Bank1[cutvalue]);
                Bank1[cutvalue] = (byte)res;
                
                return isInterrupt(programmcounter);

            }
            else
            {

                int res = (Bank1[cutvalue] - w) & 0b1111_1111;
                ChangeZ(res);
                ChangeCSUB(Bank1[cutvalue]- w);
                ChangeDCSUB(w, Bank1[cutvalue]);
                w = (byte) res;

                return isInterrupt(programmcounter);

            }
        }

        public int swapf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                Bank1[cutvalue] = (byte) ((Bank1[cutvalue] & 0x0F) << 4 |((Bank1[cutvalue] & 0xF0) >> 4));

                return isInterrupt(programmcounter);
            }
            else
            {
                w = (byte) ((Bank1[cutvalue] & 0x0F) << 4 | (Bank1[cutvalue] & 0xF0) >> 4);

                return isInterrupt(programmcounter);
            }
        }

        public int xorwf(int programminhalt, int programmcounter)
        {
            int cutvalue = getFinalCut(programminhalt);
            bool destination = man.getDestination(programminhalt);

            //Console.WriteLine("Final Cutvalue: " + cutvalue);

            if (destination)
            {
                Bank1[cutvalue] = (byte) (Bank1[cutvalue]  ^ w);
                ChangeZ(Bank1[cutvalue]);

                return isInterrupt(programmcounter);

            }
            else
            {

                w = (byte) (Bank1[cutvalue] ^ w);
                ChangeZ(w);

                return isInterrupt(programmcounter);

            }
        }

        //*********************************************
        //BIT-ORIENTED FILE REGISTER OPERATIONS
        //*********************************************

        public int bcf(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt7(programminhalt);
            int clearvalue = man.ReadProgrammspeicherInhalt3(programminhalt);
            Console.WriteLine("Bit Set an der Stelle:" + clearvalue);
            Console.WriteLine("Cutvalue " + cutvalue);
            cutvalue = Bank(cutvalue);
            cutvalue = isIndirect(cutvalue);
            bool bitgesetzt = einzelnesBitAuslesen(clearvalue, cutvalue);
            Console.WriteLine(bitgesetzt);


            if (bitgesetzt != false)
            {
                    switch (clearvalue)
                    {
                        case 0:
                            Bank1[cutvalue] = (byte) (Bank1[cutvalue] & 0b1111_1110-1);
                        if (cutvalue == 3) { Bank1[131] = (byte) (Bank1[131] & 0b1111_1110); }
                        if (cutvalue == 131) { Bank1[3] = (byte) (Bank1[3] & 0b1111_1110); }

                        if (cutvalue == 11) { Bank1[139] = (byte) (Bank1[139] & 0b1111_1110); }
                        if (cutvalue == 139) { Bank1[11] = (byte) (Bank1[11] & 0b1111_1110); }
                        Console.WriteLine("Bit 1 cleared");
                            break;
                    
                        case 1:
                            Bank1[cutvalue] = (byte)(Bank1[cutvalue] & 0b1111_1101);

                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] & 0b1111_1101); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] & 0b1111_1101); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] & 0b1111_1101); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] & 0b1111_1101); }
                        Console.WriteLine("Bit 1 cleared");
                            break;

                        case 2:
                            Bank1[cutvalue] = (byte)(Bank1[cutvalue] & 0b1111_1011);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] & 0b1111_1011); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] & 0b1111_1011); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] & 0b1111_1011); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] & 0b1111_1011); }
                        Console.WriteLine("Bit 2 cleared");
                            break;

                        case 3:
                            Bank1[cutvalue] = (byte)(Bank1[cutvalue] & 0b1111_0111);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] & 0b1111_0111); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] & 0b1111_0111); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] & 0b1111_0111); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] & 0b1111_0111); }
                        Console.WriteLine("Bit 3 cleared");
                            break;

                        case 4:
                            Bank1[cutvalue] = (byte)(Bank1[cutvalue] & 0b1110_1111);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] & 0b1110_1111); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] & 0b1110_1111); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] & 0b1110_1111); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] & 0b1110_1111); }
                        Console.WriteLine("Bit 4 cleared");
                            break;

                        case 5:
                            Bank1[cutvalue] = (byte)(Bank1[cutvalue] & 0b1101_1111);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] & 0b1101_1111); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] & 0b1101_1111); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] & 0b1101_1111); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] & 0b1101_1111); }
                        Console.WriteLine("Bit 5 cleared");
                            break;

                        case 6:
                            Bank1[cutvalue] = (byte)(Bank1[cutvalue] & 0b1011_1111);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] & 0b1011_1111); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] & 0b1011_1111); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] & 0b1011_1111); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[111] & 0b1011_1111); }
                        Console.WriteLine("Bit 6 cleared");
                            break;

                        case 7:
                            Bank1[cutvalue] = (byte)(Bank1[cutvalue] & 0b0111_1111);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] & 0b0111_1111); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] & 0b0111_1111); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] & 0b0111_1111); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] & 0b0111_1111); }
                        Console.WriteLine("Bit 7 cleared");
                            break;

                        default:
                            Console.WriteLine("Oh no something went wrong");
                            break;

                }
                return isInterrupt(programmcounter);
            }
            else
            {
                return isInterrupt(programmcounter);
            }
          
        }

        public int bsf(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt7(programminhalt);
            int clearvalue = man.ReadProgrammspeicherInhalt3(programminhalt);
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
                        Bank1[cutvalue] = (byte)(Bank1[cutvalue] | 0b0000_0001 - 1);
                        if(cutvalue == 3) {Bank1[131] = (byte)(Bank1[131] | 0b0000_0001); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] | 0b0000_0001); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] | 0b0000_0001); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] | 0b0000_0001); }
                        Console.WriteLine("Bit 0 set");
                        break;

                    case 1:
                        Bank1[cutvalue] = (byte)(Bank1[cutvalue] | 0b0000_0010);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] | 0b0000_0010); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] | 0b0000_0010); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] | 0b0000_0010); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] | 0b0000_0010); }
                        Console.WriteLine("Bit 1 set");
                        break;
                        

                    case 2:
                        Bank1[cutvalue] = (byte)(Bank1[cutvalue] | 0b0000_0100);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] | 0b0000_0100); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] | 0b0000_0100); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] | 0b0000_0100); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] | 0b0000_0100); }
                        Console.WriteLine("Bit 2 set");
                        break;

                    case 3:
                        Bank1[cutvalue] = (byte)(Bank1[cutvalue] | 0b0000_1000);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] | 0b0000_1000); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] | 0b0000_1000); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] | 0b0000_1000); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] | 0b0000_1000); }
                        Console.WriteLine("Bit 3 set");
                        break;

                    case 4:
                        Bank1[cutvalue] = (byte)(Bank1[cutvalue] | 0b0001_0000);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] | 0b0001_0000); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] | 0b0001_0000); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] | 0b0001_0000); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] | 0b0001_0000); }
                        Console.WriteLine("Bit 4 set");
                        break;

                    case 5:
                        Bank1[cutvalue] = (byte)(Bank1[cutvalue] ^ 0b0010_0000);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] | 0b0010_0000); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] | 0b0010_0000); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] | 0b0010_0000); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] | 0b0010_0000); }
                        Console.WriteLine("Bit 5 set");
                        break;

                    case 6:
                        Bank1[cutvalue] = (byte) (Bank1[cutvalue]  | 0b0100_0000);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] | 0b0100_0000); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] | 0b0100_0000); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] | 0b0100_0000); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] | 0b0100_0000); }
                        Console.WriteLine("Bit 6 set");
                        break;

                    case 7:
                        Bank1[cutvalue] = (byte)(Bank1[cutvalue] | 0b1000_0000);
                        if (cutvalue == 3) { Bank1[131] = (byte)(Bank1[131] | 0b1000_0000); }
                        if (cutvalue == 131) { Bank1[3] = (byte)(Bank1[3] | 0b1000_0000); }

                        if (cutvalue == 11) { Bank1[139] = (byte)(Bank1[139] | 0b1000_0000); }
                        if (cutvalue == 139) { Bank1[11] = (byte)(Bank1[11] | 0b1000_0000); }
                        Console.WriteLine("Bit 7 set");
                        break;

                    default:
                        Console.WriteLine("Oh no something went wrong");
                        break;

                }

                return isInterrupt(programmcounter);
            }

            else 
            { 
                Console.WriteLine("Bit Already Set");

                return isInterrupt(programmcounter);
            }
        }

        public int btfsc(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt7(programminhalt);
            int clearvalue = man.ReadProgrammspeicherInhalt3(programminhalt);
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

                return isInterrupt(programmcounter);
            }

        }

        public int btfss(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt7(programminhalt);
            int clearvalue = man.ReadProgrammspeicherInhalt3(programminhalt);
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

                return isInterrupt(programmcounter);
            }

        }

        //*********************************************
        //LITERAL AND CONTROL OPERATIONS
        //*********************************************
        public int addlw(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt(programminhalt);

            int res = (w + cutvalue) & 0b1111_1111;

            ChangeZ(res);
            ChangeC(w + cutvalue);
            ChangeDCADD(w, cutvalue);
            w = (byte)res;

            return isInterrupt(programmcounter);
        }

        public int andlw(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt(programminhalt);

            int inhaltw = w;

            int erg = cutvalue & inhaltw;

            ChangeZ(erg);

            w = (byte)erg;

            return isInterrupt(programmcounter);
        }
        public int call(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt11(programminhalt);

            //Console.WriteLine("Programmcounter: " + programmcounter);
            push(programmcounter);
            Console.WriteLine("Sprungziel: " + cutvalue);
            //Console.WriteLine("Top of Stack: " + stack[stackindex]);
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

        public int clrwdt(int programmcounter)
        {
            watchdog = 0;
            Bank1[3] = 0b0001_1000;
            Bank1[131] = 0b0001_1000;

            return isInterrupt(programmcounter);

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
            return cutvalue - 1;
        }

        public int iorlw(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt(programminhalt);
            //Console.WriteLine(cutvalue);

            string inhw = Convert.ToString(w, 2);
            int inhaltw = Convert.ToInt32(inhw, 2);
            //Console.WriteLine(inhaltw);

            w = (byte)(cutvalue | inhaltw);

            ChangeZ(w);

            return isInterrupt(programmcounter);
        }

        public int movlw(int programminhalt, int programmcounter) //kommt als DEC an 
        {
            int cutvalue = man.ReadProgrammspeicherInhalt(programminhalt);

            w = (byte)cutvalue;

            return isInterrupt(programmcounter);
        }

        public int retfie(int programminhalt, int programmcounter)
        {
            int GIEset = Bank1[11] & 0b1000_0000;
            Bank1[11] = (byte)(Bank1[11] | 0b1000_0000);
            Bank1[139] = (byte)(Bank1[139] | 0b1000_0000);
            if (GIEset == 128)
            {
                Console.WriteLine("Nothing to do");

                return pop();
            }
            else
            {
                Bank1[11] = (byte)(Bank1[11] + 128);
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                if (calcTMR(programmcounter) == 4)
                {
                    return 3;
                }
                Console.WriteLine("GIE Set");
                return pop();
            }
        }

        public int retlw(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt(programminhalt);

            w = (byte)cutvalue;
            Console.WriteLine(w);
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            return pop();
        }

        public int RETURN(int programminhalt, int programmcounter)
        {
            Console.WriteLine("RETURN:" + programmcounter);
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            if (calcTMR(programmcounter) == 4)
            {
                return 3;
            }
            return pop();
        }

        public int sleep(int programminhalt, int programmcounter)
        {     //PD = 0, TO = 1, WTD = 0

            if (getPD() == 1)
            {
                Bank1[3] = (byte)(Bank1[3] & 0b1111_0111);
                Bank1[131] = (byte)(Bank1[131] & 0b1111_0111);
            }


            if (getTO() == 0)
            {
                Bank1[3] = (byte)(Bank1[3] | 0b0001_0000);
                Bank1[131] = (byte)(Bank1[131] | 0b0001_0000);
            }


            watchdog = 0;
            calcWTD();

            return isInterrupt(programmcounter);
        }

        public int sublw(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt(programminhalt);

            int res = (cutvalue - w) & 0b1111_1111;

            ChangeZ(res);
            ChangeCSUB(cutvalue - w);
            ChangeDCSUB(w, cutvalue);

            w = (byte)res;

            return isInterrupt(programmcounter);
        }

        public int xorlw(int programminhalt, int programmcounter)
        {
            int cutvalue = man.ReadProgrammspeicherInhalt(programminhalt);

            w ^= (byte)cutvalue;
            ChangeZ(w);

            return isInterrupt(programmcounter);
        }

        public int getRP0()
        {
            int erg = Bank1[3] & 0b0010_0000;
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
            int erg = Bank1[3] & 0b0001_0000;
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
            int erg = Bank1[3] & 0b0000_1000;
            if (erg == 8)
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
            int erg = Bank1[3] & 0b0000_0001;
            if (erg == 1)
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
            int erg = Bank1[129] & 0b0100_0000;
            if (erg == 64)
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
            int erg = Bank1[129] & 0b0000_1000;
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
            int erg = Bank1[129] & 0b0000_0100;
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
            int erg = Bank1[129] & 0b0000_0010;
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
            int erg = Bank1[129] & 0b0000_0001;
            if (erg == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getGIE()
        {
            int erg = Bank1[11] & 0b1000_0000;
            if (erg > 0)
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