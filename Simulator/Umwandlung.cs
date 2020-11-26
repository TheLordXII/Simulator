using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
   
    public class Umwandlung : Global
    {
        public Operationen operation = new Operationen();
        public Global Global = new Global();

        // 0000 hex | 3011 hex
        //Progammspeicher[0000] = 12305 dec | 3011 hex | 11 0000 0001 0001‬ bin
        public void EingabeAuseinanderschneiden(String value)
        {

            Console.WriteLine(value);
            if (value != null)
            {
                String Eingabe = value;
                String[] Werte = Eingabe.Split(' ');
                Global.Programmspeicher[Convert.ToInt32(Werte[0], 16)] = Convert.ToInt32(Werte[1], 16);

                //Console.WriteLine(Programmspeicher[0]);
                
            }
            
        }

        public void Programmcounterzurueck()
        {
            Global.programmcounter = 0;
        }

        public void Einzelschritt()
        {
            operation.syncFSR();
            operation.getPrescaler();
            Befehlauswahl();
            Global.programmcounter++;
            //Console.WriteLine("PC:" + Global.programmcounter);
        }

        public int Befehlauswahl()
        {
                string binary = Convert.ToString(Global.Programmspeicher[Global.programmcounter], 2);
                Console.WriteLine(binary);

                    switch (Global.Programmspeicher[Global.programmcounter]) 
                    {
                        //BYTE-ORIENTED FILE REGISTER OPERATIONS
                        case int n when (1792 <= n && n <= 2047):
                            //addwf
                            Console.WriteLine("addwf");
                            Global.programmcounter = operation.addwf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (1280 <= n && n <= 1535):
                            //andwf
                            Console.WriteLine("andwf");
                            Global.programmcounter = operation.andwf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (384 <= n && n <= 511):
                            //clrf
                            Console.WriteLine("clrf");
                            Global.programmcounter = operation.clrf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (256 <= n && n <= 383):
                            //clrw
                            Console.WriteLine("clrw");
                    Global.programmcounter = operation.clrw(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (2304 <= n && n <= 2559):
                            //comf
                            Console.WriteLine("comf");
                    Global.programmcounter = operation.comf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (768 <= n && n <= 1023):
                            //decf
                            Console.WriteLine("decf");
                    Global.programmcounter = operation.decf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (2816 <= n && n <= 3071):
                            //decfsz
                            Console.WriteLine("decfsz");
                            Global.programmcounter = operation.decfsz(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (2560 <= n && n <= 2815):
                            //incf
                            Console.WriteLine("incf");
                    Global.programmcounter = operation.incf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (3840 <= n && n <= 4095):
                            //incfsc
                            Console.WriteLine("incfsz");
                            Global.programmcounter = operation.incfsz(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (1024 <= n && n <= 1279):
                            //iorwf
                            Console.WriteLine("iorwf");
                    Global.programmcounter = operation.iorwf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (2048 <= n && n <= 2303):
                            //movf
                            Console.WriteLine("movf");
                    Global.programmcounter = operation.movf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (128 <= n && n <= 255):
                            //movwf
                            Console.WriteLine("movwf");
                    Global.programmcounter = operation.movwf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (n == 0 || n == 96 || n == 32 || n == 64):
                            //nop
                            Console.WriteLine("nop");
                    Global.programmcounter = operation.nop(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (3328 <= n && n <= 3583):
                            //rlf
                            Console.WriteLine("rlf");
                    Global.programmcounter = operation.rlf(Global.Programmspeicher[Global.programmcounter], operation.getC(), Global.programmcounter);
                            return 0;

                        case int n when (3072 <= n && n <= 3327):
                            //rrf
                            Console.WriteLine("rrf");
                    Global.programmcounter = operation.rrf(Global.Programmspeicher[Global.programmcounter], operation.getC(), Global.programmcounter);
                            return 0;

                        case int n when (512 <= n && n <= 767):
                            //subwf
                            Console.WriteLine("subwf");
                    Global.programmcounter = operation.subwf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (3584 <= n && n <= 3839):
                            //swapf
                            Console.WriteLine("swapf");
                    Global.programmcounter = operation.swapf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (1536 <= n && n <= 1791):
                            //xorwf
                            Console.WriteLine("xorwf");
                    Global.programmcounter = operation.xorwf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;
                        //BIT-ORIENTED FILE REGISTER OPERATIONS
                        case int n when (4096 <= n && n <= 5119):
                            //bcf
                            Console.WriteLine("bcf");
                    Global.programmcounter = operation.bcf(Global.Programmspeicher[Global.programmcounter] ,Global.programmcounter);
                            return 0;

                        case int n when (5120 <= n && n <= 6143):
                            //bsf
                            Console.WriteLine("bsf");
                    Global.programmcounter = operation.bsf(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (6144 <= n && n <= 7167):
                            //btfsc
                            Console.WriteLine("btfsc");
                            Global.programmcounter = operation.btfsc(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            Console.WriteLine("PC:" + Global.programmcounter);
                            return 0;

                        case int n when (7168 <= n && n <= 8191):
                            //btfss
                            Console.WriteLine("btfss");
                            Global.programmcounter = operation.btfss(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;
                        
                        //LITERAL AND CONTROL OPERATIONS
                        case int n when (15872 <= n && n <= 16383):
                            //addlw
                            Console.WriteLine("addlw");
                    Global.programmcounter = operation.addlw(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (14592 <= n && n <= 14847):
                            //andlw
                            Console.WriteLine("andlw");
                    Global.programmcounter = operation.andlw(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (8192 <= n && n <= 10239):
                            //call
                            Console.WriteLine("call");
                            Global.programmcounter = operation.call(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case 100:
                            //clrwdt
                            Console.WriteLine("clrwdt");
                    Global.programmcounter = operation.clrwdt(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (10240 <= n && n <= 11287):
                            //goto
                            Console.WriteLine("goto");
                            Global.programmcounter = operation.Goto(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (14336 <= n && n <= 14591):
                            //iorlw
                            Console.WriteLine("iorlw");
                    Global.programmcounter = operation.iorlw(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (12288 <= n && n <= 13311):
                            //movelw
                            Console.WriteLine("movelw");
                    Global.programmcounter = operation.movlw(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case 9:
                            //refie
                            Console.WriteLine("retfie");
                    Global.programmcounter = operation.retfie(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (13312 <= n && n <= 14335):
                            //retlw
                            Console.WriteLine("retlw");
                    Global.programmcounter = Global.programmcounter = operation.retlw(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case 8:
                            //return
                            Console.WriteLine("return");
                            Global.programmcounter = operation.RETURN(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case 99:
                            //sleep
                            Console.WriteLine("sleep");
                    Global.programmcounter = operation.sleep(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (15360 <= n && n <= 15871):
                            //sublw
                            Console.WriteLine("sublw");
                    Global.programmcounter = operation.sublw(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        case int n when (14848 <= n && n <= 15103):
                            //xorlw
                            Console.WriteLine("xorlw");
                    Global.programmcounter = operation.xorlw(Global.Programmspeicher[Global.programmcounter], Global.programmcounter);
                            return 0;

                        default:
                            Console.WriteLine("Programm Ende");
                            return 1;
                    }
        }

        public int getPCIntern()
        {
            return Global.programmcounter;
        }

        public int getPCL()
        {
            int erg = Global.programmcounter & 0b1111_1111;
            return erg;
        }

        public int getPCLATCH()
        {
            int erg = Global.programmcounter & 0b0000_0000;
            return erg;
        }
    }
}
