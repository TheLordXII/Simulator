using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    class Notizen
    {
        /*
         * 1. einlesen
            2. Programmspeicher/Datenspeicher definieren -> globales array int. Programmspeicher Größe 1024 Datenspeicher Größe 2x128 entweder als ganzes oder 2 als bänke getrennt
                - Datenarray vorbelegen mit Daten aus dem Datenblatt / u und x muss man nichts machen
                - 1. und 2. Spalte abtrennen 0000 3011
                - umwandeln in ein INT
                - Wert der zweiten Spalte in Adresse der ersten Spalte schreiben
            3. Abwarten was der Bediener macht
                - im Klickereignis genauer definieren 
                Programmspeicher adresse 0 an befehlsdecoder und der decodiert den befehl
                0011 = 3 00xx = 0 11 = k 
                masken generieren für befehle. 
                von 0011 00 0000 0000
                bis   11 00 1111 1111
                variable befehlscode an befehlsdecoder
                an switch case
                zum befhel auswählen 
                   movelw = 
                    von 0011 00 0000 0000
                    bis   11 00 1111 1111

                    dann befehl aufrufen 

                befehl mit typecast auf binärwert
                0B = binärzahl
                0B 0011 0000

        

        public int GetData(int cmd)
        {
            int address = ExtractAdress(cmd);
            int result;
            if (ExtractRP0() == 32)
            {
                result = Globals.bank1[address];
            }
            else
            {
                result = Globals.bank0[address];
            }
            return result;
        }

        public void SetData(int cmd, int result)
        {
            int address = ExtractAdress(cmd);

            if (ExtractRP0() == 32)
            {
                Globals.bank1[address] = result;
            }
            else
            {
                Globals.bank0[address] = result;
            }
        }

        public void ChangeZ(int result)
        {
            if (result == 0)
            {
                Globals.bank0[3] |= 0b0000_0100;
                Globals.bank1[3] |= 0b0000_0100;
            }
            else
            {
                Globals.bank0[3] &= 0b1111_1011;
                Globals.bank1[3] &= 0b1111_1011;
            }
        }

        public void ChangeC(int result)
        {
            if (result > 255)
            {
                Globals.bank0[3] |= 0b0000_0001;
                Globals.bank1[3] |= 1; // geht weil zahl <9
            }
            else
            {
                Globals.bank0[3] &= 0b1111_1110;
                Globals.bank1[3] &= 0b1111_1110;
            }
        }

        public void WoF(int cmd, int result)
        {
            if (ExtractDestination(cmd) == 0)
            {
                Globals.w = result;
            }
            else
            {
                SetData(cmd, result);
            }
        }
        public void ChangeDCADD(int w, int data)
        {
            w &= 15;
            data &= 15;
            int a = w + data;
            if (a > 15)
            {
                Globals.bank0[3] |= 0b0000_0010;
                Globals.bank1[3] |= 2;
            }
            else
            {
                Globals.bank0[3] &= 0b1111_1101;
                Globals.bank1[3] &= 0b1111_1101;
            }
        }
        public void ChangeDCSUB(int w, int data)
        {
            w &= 15;
            data &= 15;
            int a = w - data;
            if (a >= 0)
            {
                Globals.bank0[3] |= 0b0000_0010;
                Globals.bank1[3] |= 2;
            }
            else
            {
                Globals.bank0[3] &= 0b1111_1101;
                Globals.bank1[3] &= 0b1111_1101;
            }
        }
         */
    }
}
