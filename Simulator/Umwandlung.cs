using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
   
    public class Umwandlung
    {
        public Umwandlung()
        {
            programmcounter = 0;
        }
        public Operationen operation = new Operationen();
        //Programmcounter 
        public int programmcounter { get; set; }
        private int[] Programmspeicher = new int[1024];

        // 0000 hex | 3011 hex
        //Progammspeicher[0000] = 12305 dec | 3011 hex | 11 0000 0001 0001‬ bin
        public void EingabeAuseinanderschneiden(String value)
        {

            Console.WriteLine(value);
            if (value != null)
            {
                String Eingabe = value;
                String[] Werte = Eingabe.Split(' ');
                Programmspeicher[Convert.ToInt32(Werte[0], 16)] = Convert.ToInt32(Werte[1], 16);

                //Console.WriteLine(Programmspeicher[0]);
                
            }
            
        }

        public void Programmcounterzurueck()
        {
            programmcounter = 0;
        }

        public void Einzelschritt()
        {
            operation.syncFSR();
            operation.getPrescaler();
            Befehlauswahl();
            programmcounter++;
            //Console.WriteLine("PC:" + programmcounter);
        }

        public int Befehlauswahl()
        {
                string binary = Convert.ToString(Programmspeicher[programmcounter], 2);
                Console.WriteLine(binary);

                    switch (Programmspeicher[programmcounter]) 
                    {
                        //BYTE-ORIENTED FILE REGISTER OPERATIONS
                        case int n when (1792 <= n && n <= 2047):
                            //addwf
                            Console.WriteLine("addwf");
                            programmcounter = operation.addwf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (1280 <= n && n <= 1535):
                            //andwf
                            Console.WriteLine("andwf");
                            programmcounter = operation.andwf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (384 <= n && n <= 511):
                            //clrf
                            Console.WriteLine("clrf");
                            programmcounter = operation.clrf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (256 <= n && n <= 383):
                            //clrw
                            Console.WriteLine("clrw");
                            programmcounter = operation.clrw(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (2304 <= n && n <= 2559):
                            //comf
                            Console.WriteLine("comf");
                            programmcounter = operation.comf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (768 <= n && n <= 1023):
                            //decf
                            Console.WriteLine("decf");
                            programmcounter = operation.decf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (2816 <= n && n <= 3071):
                            //decfsz
                            Console.WriteLine("decfsz");
                            programmcounter = operation.decfsz(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (2560 <= n && n <= 2815):
                            //incf
                            Console.WriteLine("incf");
                            programmcounter = operation.incf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (3840 <= n && n <= 4095):
                            //incfsc
                            Console.WriteLine("incfsz");
                            programmcounter = operation.incfsz(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (1024 <= n && n <= 1279):
                            //iorwf
                            Console.WriteLine("iorwf");
                            programmcounter = operation.iorwf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (2048 <= n && n <= 2303):
                            //movf
                            Console.WriteLine("movf");
                            programmcounter = operation.movf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (128 <= n && n <= 255):
                            //movwf
                            Console.WriteLine("movwf");
                            programmcounter = operation.movwf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (n == 0 || n == 96 || n == 32 || n == 64):
                            //nop
                            Console.WriteLine("nop");
                            programmcounter = operation.nop(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (3328 <= n && n <= 3583):
                            //rlf
                            Console.WriteLine("rlf");
                            programmcounter = operation.rlf(Programmspeicher[programmcounter], operation.getC(), programmcounter);
                            return 0;

                        case int n when (3072 <= n && n <= 3327):
                            //rrf
                            Console.WriteLine("rrf");
                            programmcounter = operation.rrf(Programmspeicher[programmcounter], operation.getC(), programmcounter);
                            return 0;

                        case int n when (512 <= n && n <= 767):
                            //subwf
                            Console.WriteLine("subwf");
                            programmcounter = operation.subwf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (3584 <= n && n <= 3839):
                            //swapf
                            Console.WriteLine("swapf");
                            programmcounter = operation.swapf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (1536 <= n && n <= 1791):
                            //xorwf
                            Console.WriteLine("xorwf");
                            programmcounter = operation.xorwf(Programmspeicher[programmcounter], programmcounter);
                            return 0;
                        //BIT-ORIENTED FILE REGISTER OPERATIONS
                        case int n when (4096 <= n && n <= 5119):
                            //bcf
                            Console.WriteLine("bcf");
                            programmcounter = operation.bcf(Programmspeicher[programmcounter] ,programmcounter);
                            return 0;

                        case int n when (5120 <= n && n <= 6143):
                            //bsf
                            Console.WriteLine("bsf");
                            programmcounter = operation.bsf(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (6144 <= n && n <= 7167):
                            //btfsc
                            Console.WriteLine("btfsc");
                            programmcounter = operation.btfsc(Programmspeicher[programmcounter], programmcounter);
                            Console.WriteLine("PC:" + programmcounter);
                            return 0;

                        case int n when (7168 <= n && n <= 8191):
                            //btfss
                            Console.WriteLine("btfss");
                            programmcounter = operation.btfss(Programmspeicher[programmcounter], programmcounter);
                            return 0;
                        
                        //LITERAL AND CONTROL OPERATIONS
                        case int n when (15872 <= n && n <= 16383):
                            //addlw
                            Console.WriteLine("addlw");
                            programmcounter = operation.addlw(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (14592 <= n && n <= 14847):
                            //andlw
                            Console.WriteLine("andlw");
                            programmcounter = operation.andlw(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (8192 <= n && n <= 10239):
                            //call
                            Console.WriteLine("call");
                            programmcounter = operation.call(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case 100:
                            //clrwdt
                            Console.WriteLine("clrwdt");
                            programmcounter = operation.clrwdt(programmcounter);
                            return 0;

                        case int n when (10240 <= n && n <= 11287):
                            //goto
                            Console.WriteLine("goto");
                            programmcounter = operation.Goto(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (14336 <= n && n <= 14591):
                            //iorlw
                            Console.WriteLine("iorlw");
                            programmcounter = operation.iorlw(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (12288 <= n && n <= 13311):
                            //movelw
                            Console.WriteLine("movelw");
                            programmcounter = operation.movlw(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case 9:
                            //refie
                            Console.WriteLine("retfie");
                            programmcounter = operation.retfie(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (13312 <= n && n <= 14335):
                            //retlw
                            Console.WriteLine("retlw");
                            programmcounter = programmcounter = operation.retlw(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case 8:
                            //return
                            Console.WriteLine("return");
                            programmcounter = operation.RETURN(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case 99:
                            //sleep
                            Console.WriteLine("sleep");
                            programmcounter = operation.sleep(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (15360 <= n && n <= 15871):
                            //sublw
                            Console.WriteLine("sublw");
                            programmcounter = operation.sublw(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        case int n when (14848 <= n && n <= 15103):
                            //xorlw
                            Console.WriteLine("xorlw");
                            programmcounter = operation.xorlw(Programmspeicher[programmcounter], programmcounter);
                            return 0;

                        default:
                            Console.WriteLine("Programm Ende");
                            return 1;
                    }
        }

        public int getPCIntern()
        {
            return programmcounter;
        }

        public int getPCL()
        {
            int erg = programmcounter & 0b1111_1111;
            return erg;
        }

        public int getPCLATCH()
        {
            int erg = programmcounter & 0b0000_0000;
            return erg;
        }
    }
}
