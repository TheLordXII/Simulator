using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Simulator.ViewModels;

namespace Simulator
{
    public partial class MainView : Form
    {
        double Laufzeit = 0;

        //*****************************************************************************************
        //GUI ZEUG
        //*****************************************************************************************
        public MainView()
        {
            InitializeComponent();
            //Create the ViewModel with a factory
            MainViewModelFactory factory = new MainViewModelFactory();

            //Map the bindings

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateSFR();
            UpdateTris();
            clearCheckBoxes();
        }

        private void schließenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;



                }
            }


        }

        private void btnReset_Click(object sender, EventArgs e) //Reset Button1
        {
            dgvFileregister.Rows.Clear();
            Laufzeit = 0;
        }

        private void btnEinzelschritt_Click(object sender, EventArgs e)
        {
            Step();
        }

        public void clearCheckBoxes()
        {
            cbPinA0.Checked = false;
            cbPinA1.Checked = false;
            cbPinA2.Checked = false;
            cbPinA3.Checked = false;
            cbPinA4.Checked = false;

            cbTrisA0.Checked = false;
            cbTrisA1.Checked = false;
            cbTrisA2.Checked = false;
            cbTrisA3.Checked = false;
            cbTrisA4.Checked = false;
            cbTrisA5.Checked = false;
            cbTrisA6.Checked = false;
            cbTrisA7.Checked = false;

            cbPinB0.Checked = false;
            cbPinB1.Checked = false;
            cbPinB2.Checked = false;
            cbPinB3.Checked = false;
            cbPinB4.Checked = false;
            cbPinB5.Checked = false;
            cbPinB6.Checked = false;
            cbPinB7.Checked = false;

            cbTrisB0.Checked = false;
            cbTrisB1.Checked = false;
            cbTrisB2.Checked = false;
            cbTrisB3.Checked = false;
            cbTrisB4.Checked = false;
            cbTrisB5.Checked = false;
            cbTrisB6.Checked = false;
            cbTrisB7.Checked = false;
        }

        //*****************************************************************************************
        //STEPS
        //*****************************************************************************************
        public void Step()
        {
            //Einzelschritte im Programm
            //int counter = umwandlung.getPCIntern();
            int counter = 0;
            try
            {
                if (lvAusgabe.Items[counter].Checked)
                {
                    MessageBox.Show("Breakpoint");
                }
                else
                {
                    getPins();
                    clearFields();
                    lvAusgabe.Items[counter].BackColor = Color.Yellow;
                    //umwandlung.Einzelschritt();
                    UpdateSFR();
                    UpdateRegisterinhalt();
                    UpdateStack();
                    UpdateTris();
                    UpdateTiming();
                    UpdateFile();
                    Laufzeit++;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("BITTE PROGRAMM LADEN!");
            }

        }

        //*****************************************************************************************
        //EINGABEN AUF GUI
        //*****************************************************************************************

        public void getPins()
        {
            int portA = 0;
            int portB = 0;

            if (cbPinA0.Checked == true) { portA += 1; };
            if (cbPinA1.Checked == true) { portA += 2; };
            if (cbPinA2.Checked == true) { portA += 4; };
            if (cbPinA3.Checked == true) { portA += 8; };
            if (cbPinA4.Checked == true) { portA += 16; };

            if (cbPinB0.Checked == true) { portB += 1; };
            if (cbPinB1.Checked == true) { portB += 2; };
            if (cbPinB2.Checked == true) { portB += 4; };
            if (cbPinB3.Checked == true) { portB += 8; };
            if (cbPinB4.Checked == true) { portB += 16; };
            if (cbPinB5.Checked == true) { portB += 32; };
            if (cbPinB6.Checked == true) { portB += 64; };
            if (cbPinB7.Checked == true) { portB += 128; };

            //umwandlung.programmcounter = umwandlung.gui.Pinbelegung(portA, portB, umwandlung.programmcounter);

        }

        public void UpdateSFR()
        {
            //Status
            //lblIRP.Text = Convert.ToString(umwandlung.gui.getIRP());
            //lblRP1.Text = Convert.ToString(umwandlung.gui.getRP1());
            //lblRP0.Text = Convert.ToString(umwandlung.operation.getRP0());
            //lblTO.Text = Convert.ToString(umwandlung.operation.getTO());
            //lblPD.Text = Convert.ToString(umwandlung.operation.getPD());
            //lblZ.Text = Convert.ToString(umwandlung.gui.getZ());
            //lblDC.Text = Convert.ToString(umwandlung.gui.getDC());
            //lblC.Text = Convert.ToString(umwandlung.operation.getC());
            //Option
            //lblRPu.Text = Convert.ToString(umwandlung.gui.getRPu());
            //lblIEg.Text = Convert.ToString(umwandlung.operation.getIEg());
            //lblTCs.Text = Convert.ToString(umwandlung.gui.getTCs());
            //lblTSe.Text = Convert.ToString(umwandlung.gui.getTSe());
            //lblPSA.Text = Convert.ToString(umwandlung.operation.getPSA());
            //lblPS2.Text = Convert.ToString(umwandlung.operation.getPS2());
            //lblPS1.Text = Convert.ToString(umwandlung.operation.getPS1());
            //lblPS0.Text = Convert.ToString(umwandlung.operation.getPS0());
            //Intcon
            //lblGIE.Text = Convert.ToString(umwandlung.operation.getGIE());
            //lblEIE.Text = Convert.ToString(umwandlung.gui.getEIE());
            //lblTIE.Text = Convert.ToString(umwandlung.gui.getTIE());
            //lblIE.Text = Convert.ToString(umwandlung.gui.getIE());
            //lblRIE.Text = Convert.ToString(umwandlung.gui.getRIE());
            //lblTIF.Text = Convert.ToString(umwandlung.gui.getTIF());
            //lblIF.Text = Convert.ToString(umwandlung.gui.getIF());
            //lblRIF.Text = Convert.ToString(umwandlung.gui.getRIF());
        }

        public void UpdateRegisterinhalt()
        {
            //lblWReg.Text = Convert.ToString(umwandlung.gui.getW());
            //lblPCIntern.Text = Convert.ToString(umwandlung.getPCIntern());
            //lblPCL.Text = Convert.ToString(umwandlung.getPCL());
            //lblPCLATCH.Text = Convert.ToString(umwandlung.getPCLATCH());
            //lblStatus.Text = Convert.ToString(umwandlung.gui.getStatus());
            //lblFSR.Text = Convert.ToString(umwandlung.gui.getFSR());
            //lblOption.Text = Convert.ToString(umwandlung.gui.getOption());
            //lblVorteiler.Text = "1:" + Convert.ToString(umwandlung.gui.getPrescalerGUI());
            //lblTimer0.Text = Convert.ToString(umwandlung.gui.getTimer0());
        }

        public void UpdateStack()
        {
            //lblStack1.Text = Convert.ToString(umwandlung.gui.getStack1());
            //lblStack2.Text = Convert.ToString(umwandlung.gui.getStack2());
            //lblStack3.Text = Convert.ToString(umwandlung.gui.getStack3());
            //lblStack4.Text = Convert.ToString(umwandlung.gui.getStack4());
            //lblStack5.Text = Convert.ToString(umwandlung.gui.getStack5());
            //lblStack6.Text = Convert.ToString(umwandlung.gui.getStack6());
            //lblStack7.Text = Convert.ToString(umwandlung.gui.getStack7());
            //lblStack8.Text = Convert.ToString(umwandlung.gui.getStack8());
        }

        public void UpdateTris()
        {
            int trisA = 0; //umwandlung.gui.getTrisA();
            int trisB = 0; //umwandlung.gui.getTrisB();
            int portA = 0; //umwandlung.gui.GetPortA();
            int portB = 0; //umwandlung.gui.GetPortB();

            Console.WriteLine("TrisA" + trisA);
            Console.WriteLine("TrisB" + trisB);
            Console.WriteLine("PortA" + portA);
            Console.WriteLine("PortB" + portB);

            if ((trisA & 0b0000_0001) == 1) { cbTrisA0.Checked = true; } else { cbTrisA0.Checked = false; }
            if ((trisA & 0b0000_0010) == 2) { cbTrisA1.Checked = true; } else { cbTrisA1.Checked = false; }
            if ((trisA & 0b0000_0100) == 4) { cbTrisA2.Checked = true; } else { cbTrisA2.Checked = false; }
            if ((trisA & 0b0000_1000) == 8) { cbTrisA3.Checked = true; } else { cbTrisA3.Checked = false; }
            if ((trisA & 0b0001_0000) == 16) { cbTrisA4.Checked = true; } else { cbTrisA4.Checked = false; }
            if ((trisA & 0b0010_0000) == 32) { cbTrisA5.Checked = true; } else { cbTrisA5.Checked = false; }
            if ((trisA & 0b0100_0000) == 64) { cbTrisA6.Checked = true; } else { cbTrisA6.Checked = false; }
            if ((trisA & 0b1000_0000) == 128) { cbTrisA7.Checked = true; } else { cbTrisA7.Checked = false; }

            if ((portA & 0b0000_0001) == 1) { cbPinA0.Checked = true; } else { cbPinA0.Checked = false; }
            if ((portA & 0b0000_0010) == 2) { cbPinA1.Checked = true; } else { cbPinA1.Checked = false; }
            if ((portA & 0b0000_0100) == 4) { cbPinA2.Checked = true; } else { cbPinA2.Checked = false; }
            if ((portA & 0b0000_1000) == 8) { cbPinA3.Checked = true; } else { cbPinA3.Checked = false; }
            if ((portA & 0b0001_0000) == 16) { cbPinA4.Checked = true; } else { cbPinA4.Checked = false; }

            if ((trisB & 0b0000_0001) == 1) { cbTrisB0.Checked = true; } else { cbTrisB0.Checked = false; }
            if ((trisB & 0b0000_0010) == 2) { cbTrisB1.Checked = true; } else { cbTrisB1.Checked = false; }
            if ((trisB & 0b0000_0100) == 4) { cbTrisB2.Checked = true; } else { cbTrisB2.Checked = false; }
            if ((trisB & 0b0000_1000) == 8) { cbTrisB3.Checked = true; } else { cbTrisB3.Checked = false; }
            if ((trisB & 0b0001_0000) == 16) { cbTrisB4.Checked = true; } else { cbTrisB4.Checked = false; }
            if ((trisB & 0b0010_0000) == 32) { cbTrisB5.Checked = true; } else { cbTrisB5.Checked = false; }
            if ((trisB & 0b0100_0000) == 64) { cbTrisB6.Checked = true; } else { cbTrisB6.Checked = false; }
            if ((trisB & 0b1000_0000) == 128) { cbTrisB7.Checked = true; } else { cbTrisB7.Checked = false; }

            if ((portB & 0b0000_0001) == 1) { cbPinB0.Checked = true; } else { cbPinB0.Checked = false; }
            if ((portB & 0b0000_0010) == 2) { cbPinB1.Checked = true; } else { cbPinB1.Checked = false; }
            if ((portB & 0b0000_0100) == 4) { cbPinB2.Checked = true; } else { cbPinB2.Checked = false; }
            if ((portB & 0b0000_1000) == 8) { cbPinB3.Checked = true; } else { cbPinB3.Checked = false; }
            if ((portB & 0b0001_0000) == 16) { cbPinB4.Checked = true; } else { cbPinB4.Checked = false; }
            if ((portB & 0b0010_0000) == 32) { cbPinB5.Checked = true; } else { cbPinB5.Checked = false; }
            if ((portB & 0b0100_0000) == 64) { cbPinB6.Checked = true; } else { cbPinB6.Checked = false; }
            if ((portB & 0b1000_0000) == 128) { cbPinB7.Checked = true; } else { cbPinB7.Checked = false; }
        }

        public void clearFields()
        {
            for (int i = 0; i < lvAusgabe.Items.Count; i++)
            {
                lvAusgabe.Items[i].BackColor = Color.Transparent;
            }
        }

        public void UpdateTiming()
        {
            //lblWatchdog.Text = Convert.ToString(umwandlung.gui.getWatchdog());
            double result = 0;
            Console.WriteLine("CBQUARZ" + cbQuarz.SelectedIndex);

            switch (cbQuarz.SelectedIndex)
            {
                case -1:
                    //32kHz
                    result = Laufzeit * 32.25;
                    lblLaufzeit.Text = Convert.ToString(result);
                    break;
                case 0:
                    //64kHz
                    result = Laufzeit * 15.625;
                    lblLaufzeit.Text = Convert.ToString(result);
                    break;
                case 1:
                    //1MHz
                    result = Laufzeit * 1;
                    lblLaufzeit.Text = Convert.ToString(result);
                    break;
                case 2:
                    //10MHz
                    result = Laufzeit * 0.1;
                    lblLaufzeit.Text = Convert.ToString(result);
                    break;
                default:
                    break;
            }
        }

        public void UpdateFile()
        {
            dgvFileregister.Rows.Clear();

            for (int i = 0; i < 256; i = i + 8)
            {
                int[] inhaltrow = new int[8];

                for (int j = 0; j <= 7; j++)
                {
                    int stelle = i + j;
                    //inhaltrow[j] = umwandlung.gui.getBankInhalt(stelle);
                }

                string[] row =
                {
                        Convert.ToString(i),
                        Convert.ToString(inhaltrow[0]),
                        Convert.ToString(inhaltrow[1]),
                        Convert.ToString(inhaltrow[2]),
                        Convert.ToString(inhaltrow[3]),
                        Convert.ToString(inhaltrow[4]),
                        Convert.ToString(inhaltrow[5]),
                        Convert.ToString(inhaltrow[6]),
                        Convert.ToString(inhaltrow[7])
                };
                dgvFileregister.Rows.Add(row);
            }
        }
    }
}
