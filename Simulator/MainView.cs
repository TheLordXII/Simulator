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

namespace Simulator
{
    public partial class MainView : Form
    {
        Parser parser = new Parser();
        Umwandlung umwandlung = new Umwandlung();

        double Laufzeit = 0;

        //*****************************************************************************************
        //GUI ZEUG
        //*****************************************************************************************
        public MainView()
        {
            InitializeComponent();
            GuiThread.WorkerSupportsCancellation = true;
            GuiThread.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            umwandlung.operation.InitialisierungBaenke();
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

            parser.ProgrammspeicherLeeren();
            umwandlung.Programmcounterzurueck();

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
                    parser.Main(filePath);

                    foreach (String value in parser.matches)
                    {
                        if(value != null)
                        {
                            lvAusgabe.Items.Add(value);
                            umwandlung.EingabeAuseinanderschneiden(value);
                        }
                        
                        
                    }
                    
                }
            }


        }

        private void btnReset_Click(object sender, EventArgs e) //Reset Button1
        {
            parser.ProgrammspeicherLeeren();
            umwandlung.Programmcounterzurueck();

            dgvFileregister.Rows.Clear();
            Laufzeit = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Fuehrt Programm einmal aus
            GuiThread.RunWorkerAsync();
        }

        private void btnStopp_Click(object sender, EventArgs e)
        {
            //Stoppt das Programm
            if (GuiThread.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                GuiThread.CancelAsync();
            }
        }

        private void btnEinzelschritt_Click(object sender, EventArgs e)
        {
            Step();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while(true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    StepThread();
                    //System.Threading.Thread.Sleep(200);
                }
            }
        }

        private void aufgabenstellungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wbPDF.Navigate(@"D:\OneDrive\Dokumente\DHBW\4. Semester\SystemnahesProgrammieren\Simulator\Simulator\Projekt_Simulator.pdf", true);
        }

        private void bewertungsschemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wbPDF.Navigate(@"D:\OneDrive\Dokumente\DHBW\4. Semester\SystemnahesProgrammieren\Simulator\Simulator\Bewertungsschema_Simulator_2020.pdf", true);
        }

        private void datenblattToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wbPDF.Navigate(@"D:\OneDrive\Dokumente\DHBW\4. Semester\SystemnahesProgrammieren\Simulator\Simulator\PIC16F8x.pdf", true);
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
                    int counter = umwandlung.getPCIntern();

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
                        umwandlung.Einzelschritt();
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

        public void StepThread()
        {
            //Einzelschritte im Programm
            int counter = umwandlung.getPCIntern();

            if (BreakpointChecked(counter))
            {
                MessageBox.Show("Breakpoint");
                GuiThread.CancelAsync();
            }
            else
            {
                getPins();
                clearFieldsThread();
                lvAusgabe.Invoke(new Action(() => lvAusgabe.Items[counter].BackColor = Color.Yellow));
                umwandlung.Einzelschritt();
                UpdateSFRThread();
                UpdateRegisterinhaltThread();
                UpdateStackThread();
                UpdateTrisThread();
                UpdateFileThread();
                UpdateTimingThread();
                Laufzeit++;
                //Thread.Sleep(500);
            }
        }

        //*****************************************************************************************
        //EINGABEN AUF GUI
        //*****************************************************************************************

        public void getPins()
                {
                    int portA = 0;
                    int portB = 0;

                    if(cbPinA0.Checked == true) { portA += 1; };
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

                    umwandlung.programmcounter = umwandlung.gui.Pinbelegung(portA, portB, umwandlung.programmcounter);

                }


        //*****************************************************************************************
        //GUI UPDATE OHNE THREAD
        //*****************************************************************************************

        public void UpdateSFR()
        {
            //Status
            lblIRP.Text = Convert.ToString(umwandlung.gui.getIRP());
            lblRP1.Text = Convert.ToString(umwandlung.gui.getRP1());
            lblRP0.Text = Convert.ToString(umwandlung.operation.getRP0());
            lblTO.Text = Convert.ToString(umwandlung.operation.getTO());
            lblPD.Text = Convert.ToString(umwandlung.operation.getPD());
            lblZ.Text = Convert.ToString(umwandlung.gui.getZ());
            lblDC.Text = Convert.ToString(umwandlung.gui.getDC());
            lblC.Text = Convert.ToString(umwandlung.operation.getC());
            //Option
            lblRPu.Text = Convert.ToString(umwandlung.gui.getRPu());
            lblIEg.Text = Convert.ToString(umwandlung.operation.getIEg());
            lblTCs.Text = Convert.ToString(umwandlung.gui.getTCs());
            lblTSe.Text = Convert.ToString(umwandlung.gui.getTSe());
            lblPSA.Text = Convert.ToString(umwandlung.operation.getPSA());
            lblPS2.Text = Convert.ToString(umwandlung.operation.getPS2());
            lblPS1.Text = Convert.ToString(umwandlung.operation.getPS1());
            lblPS0.Text = Convert.ToString(umwandlung.operation.getPS0());
            //Intcon
            lblGIE.Text = Convert.ToString(umwandlung.operation.getGIE());
            lblEIE.Text = Convert.ToString(umwandlung.gui.getEIE());
            lblTIE.Text = Convert.ToString(umwandlung.gui.getTIE());
            lblIE.Text = Convert.ToString(umwandlung.gui.getIE());
            lblRIE.Text = Convert.ToString(umwandlung.gui.getRIE());
            lblTIF.Text = Convert.ToString(umwandlung.gui.getTIF());
            lblIF.Text = Convert.ToString(umwandlung.gui.getIF());
            lblRIF.Text = Convert.ToString(umwandlung.gui.getRIF());
        }

        public void UpdateRegisterinhalt()
        {
            lblWReg.Text = Convert.ToString(umwandlung.gui.getW());
            lblPCIntern.Text = Convert.ToString(umwandlung.getPCIntern());
            lblPCL.Text = Convert.ToString(umwandlung.getPCL());
            lblPCLATCH.Text = Convert.ToString(umwandlung.getPCLATCH());
            lblStatus.Text = Convert.ToString(umwandlung.gui.getStatus());
            lblFSR.Text = Convert.ToString(umwandlung.gui.getFSR());
            lblOption.Text = Convert.ToString(umwandlung.gui.getOption());
            lblVorteiler.Text = "1:" + Convert.ToString(umwandlung.gui.getPrescalerGUI());
            lblTimer0.Text = Convert.ToString(umwandlung.gui.getTimer0());
        }

        public void UpdateStack()
        {
            lblStack1.Text = Convert.ToString(umwandlung.gui.getStack1());
            lblStack2.Text = Convert.ToString(umwandlung.gui.getStack2());
            lblStack3.Text = Convert.ToString(umwandlung.gui.getStack3());
            lblStack4.Text = Convert.ToString(umwandlung.gui.getStack4());
            lblStack5.Text = Convert.ToString(umwandlung.gui.getStack5());
            lblStack6.Text = Convert.ToString(umwandlung.gui.getStack6());
            lblStack7.Text = Convert.ToString(umwandlung.gui.getStack7());
            lblStack8.Text = Convert.ToString(umwandlung.gui.getStack8());
        }

        public void UpdateTris()
        {
            int trisA = umwandlung.gui.getTrisA();
            int trisB = umwandlung.gui.getTrisB();
            int portA = umwandlung.gui.GetPortA();
            int portB = umwandlung.gui.GetPortB();

            Console.WriteLine("TrisA" + trisA);
            Console.WriteLine("TrisB" + trisB);
            Console.WriteLine("PortA" + portA);
            Console.WriteLine("PortB" + portB);

            if((trisA & 0b0000_0001) == 1){cbTrisA0.Checked = true;} else { cbTrisA0.Checked = false; }
            if ((trisA & 0b0000_0010) == 2){cbTrisA1.Checked = true;} else { cbTrisA1.Checked = false; }
            if ((trisA & 0b0000_0100) == 4){cbTrisA2.Checked = true;} else { cbTrisA2.Checked = false; }
            if ((trisA & 0b0000_1000) == 8){cbTrisA3.Checked = true;} else { cbTrisA3.Checked = false; }
            if ((trisA & 0b0001_0000) == 16){cbTrisA4.Checked = true;} else { cbTrisA4.Checked = false; }
            if ((trisA & 0b0010_0000) == 32){cbTrisA5.Checked = true;} else { cbTrisA5.Checked = false; }
            if ((trisA & 0b0100_0000) == 64){cbTrisA6.Checked = true;} else { cbTrisA6.Checked = false; }
            if ((trisA & 0b1000_0000) == 128){cbTrisA7.Checked = true;} else { cbTrisA7.Checked = false; }

            if ((portA & 0b0000_0001) == 1) { cbPinA0.Checked = true; } else { cbPinA0.Checked = false; }
            if ((portA & 0b0000_0010) == 2) { cbPinA1.Checked = true; } else { cbPinA1.Checked = false; }
            if ((portA & 0b0000_0100) == 4) { cbPinA2.Checked = true; } else { cbPinA2.Checked = false; }
            if ((portA & 0b0000_1000) == 8) { cbPinA3.Checked = true; } else { cbPinA3.Checked = false; }
            if ((portA & 0b0001_0000) == 16) { cbPinA4.Checked = true; } else { cbPinA4.Checked = false; }

            if ((trisB & 0b0000_0001) == 1) { cbTrisB0.Checked = true;} else { cbTrisB0.Checked = false; }
            if ((trisB & 0b0000_0010) == 2) { cbTrisB1.Checked = true;} else { cbTrisB1.Checked = false; }
            if ((trisB & 0b0000_0100) == 4) { cbTrisB2.Checked = true;} else { cbTrisB2.Checked = false; }
            if ((trisB & 0b0000_1000) == 8) { cbTrisB3.Checked = true;} else { cbTrisB3.Checked = false; }
            if ((trisB & 0b0001_0000) == 16) { cbTrisB4.Checked = true;} else { cbTrisB4.Checked = false; }
            if ((trisB & 0b0010_0000) == 32) { cbTrisB5.Checked = true;} else { cbTrisB5.Checked = false; }
            if ((trisB & 0b0100_0000) == 64) { cbTrisB6.Checked = true;} else { cbTrisB6.Checked = false; }
            if ((trisB & 0b1000_0000) == 128) { cbTrisB7.Checked = true;} else { cbTrisB7.Checked = false; }

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
            lblWatchdog.Text = Convert.ToString(umwandlung.gui.getWatchdog());
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

            for (int i = 0; i < 256; i=i+8)
            {   
                int[] inhaltrow = new int[8];

                for (int j = 0; j <= 7; j++)
                {
                    int stelle = i + j;
                    inhaltrow[j] = umwandlung.gui.getBankInhalt(stelle);
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

        //*****************************************************************************************
        //GUI UPDATE MIT THREAD
        //*****************************************************************************************

        public void UpdateTrisThread()
        {
            int trisA = umwandlung.gui.getTrisA();
            int trisB = umwandlung.gui.getTrisB();
            int portA = umwandlung.gui.GetPortA();
            int portB = umwandlung.gui.GetPortB();

            if ((trisA & 0b0000_0001) == 1) { cbTrisA0.Invoke(new Action(() => cbTrisA0.Checked = true)); } else { cbTrisA0.Invoke(new Action(() => cbTrisA0.Checked = false)); }
            if ((trisA & 0b0000_0010) == 2) { cbTrisA1.Invoke(new Action(() => cbTrisA1.Checked = true)); } else { cbTrisA1.Invoke(new Action(() => cbTrisA1.Checked = false)); }
            if ((trisA & 0b0000_0100) == 4) { cbTrisA2.Invoke(new Action(() => cbTrisA2.Checked = true)); } else { cbTrisA2.Invoke(new Action(() => cbTrisA2.Checked = false)); }
            if ((trisA & 0b0000_1000) == 8) { cbTrisA3.Invoke(new Action(() => cbTrisA3.Checked = true)); } else { cbTrisA3.Invoke(new Action(() => cbTrisA3.Checked = false)); }
            if ((trisA & 0b0001_0000) == 16) { cbTrisA4.Invoke(new Action(() => cbTrisA4.Checked = true)); } else { cbTrisA4.Invoke(new Action(() => cbTrisA4.Checked = false)); }
            if ((trisA & 0b0010_0000) == 32) { cbTrisA5.Invoke(new Action(() => cbTrisA5.Checked = true)); } else { cbTrisA5.Invoke(new Action(() => cbTrisA5.Checked = false)); }
            if ((trisA & 0b0100_0000) == 64) { cbTrisA6.Invoke(new Action(() => cbTrisA6.Checked = true)); } else { cbTrisA6.Invoke(new Action(() => cbTrisA6.Checked = false)); }
            if ((trisA & 0b1000_0000) == 128) { cbTrisA7.Invoke(new Action(() => cbTrisA7.Checked = true)); } else { cbTrisA7.Invoke(new Action(() => cbTrisA7.Checked = false)); }

            if ((portA & 0b0000_0001) == 1) { cbPinA0.Invoke(new Action(() => cbPinA0.Checked = true)); } else { cbPinA0.Invoke(new Action(() => cbPinA0.Checked = false)); }
            if ((portA & 0b0000_0010) == 2) { cbPinA1.Invoke(new Action(() => cbPinA1.Checked = true)); } else { cbPinA1.Invoke(new Action(() => cbPinA1.Checked = false)); }
            if ((portA & 0b0000_0100) == 4) { cbPinA2.Invoke(new Action(() => cbPinA2.Checked = true)); } else { cbPinA2.Invoke(new Action(() => cbPinA2.Checked = false)); }
            if ((portA & 0b0000_1000) == 8) { cbPinA3.Invoke(new Action(() => cbPinA3.Checked = true)); } else { cbPinA3.Invoke(new Action(() => cbPinA3.Checked = false)); }
            if ((portA & 0b0001_0000) == 16) { cbPinA4.Invoke(new Action(() => cbPinA4.Checked = true)); } else { cbPinA4.Invoke(new Action(() => cbPinA4.Checked = false)); }

            if ((trisB & 0b0000_0001) == 1) { cbTrisB0.Invoke(new Action(() => cbTrisB0.Checked = true)); } else { cbTrisB0.Invoke(new Action(() => cbTrisB0.Checked = false)); }
            if ((trisB & 0b0000_0010) == 2) { cbTrisB1.Invoke(new Action(() => cbTrisB1.Checked = true)); } else { cbTrisB1.Invoke(new Action(() => cbTrisB1.Checked = false)); }
            if ((trisB & 0b0000_0100) == 4) { cbTrisB2.Invoke(new Action(() => cbTrisB2.Checked = true)); } else { cbTrisB2.Invoke(new Action(() => cbTrisB2.Checked = false)); }
            if ((trisB & 0b0000_1000) == 8) { cbTrisB3.Invoke(new Action(() => cbTrisB3.Checked = true)); } else { cbTrisB3.Invoke(new Action(() => cbTrisB3.Checked = false)); }
            if ((trisB & 0b0001_0000) == 16) { cbTrisB4.Invoke(new Action(() => cbTrisB4.Checked = true)); } else { cbTrisB4.Invoke(new Action(() => cbTrisB4.Checked = false)); }
            if ((trisB & 0b0010_0000) == 32) { cbTrisB5.Invoke(new Action(() => cbTrisB5.Checked = true)); } else { cbTrisB5.Invoke(new Action(() => cbTrisB5.Checked = false)); }
            if ((trisB & 0b0100_0000) == 64) { cbTrisB6.Invoke(new Action(() => cbTrisB6.Checked = true)); } else { cbTrisB6.Invoke(new Action(() => cbTrisB6.Checked = false)); }
            if ((trisB & 0b1000_0000) == 128) { cbTrisB7.Invoke(new Action(() => cbTrisB7.Checked = true)); } else { cbTrisB7.Invoke(new Action(() => cbTrisB7.Checked = false)); }

            if ((portB & 0b0000_0001) == 1) { cbPinB0.Invoke(new Action(() => cbPinB0.Checked = true)); } else { cbPinB0.Invoke(new Action(() => cbPinB0.Checked = false)); }
            if ((portB & 0b0000_0010) == 2) { cbPinB1.Invoke(new Action(() => cbPinB1.Checked = true)); } else { cbPinB1.Invoke(new Action(() => cbPinB1.Checked = false)); }
            if ((portB & 0b0000_0100) == 4) { cbPinB2.Invoke(new Action(() => cbPinB2.Checked = true)); } else { cbPinB2.Invoke(new Action(() => cbPinB2.Checked = false)); }
            if ((portB & 0b0000_1000) == 8) { cbPinB3.Invoke(new Action(() => cbPinB3.Checked = true)); } else { cbPinB3.Invoke(new Action(() => cbPinB3.Checked = false)); }
            if ((portB & 0b0001_0000) == 16) { cbPinB4.Invoke(new Action(() => cbPinB4.Checked = true)); } else { cbPinB4.Invoke(new Action(() => cbPinB4.Checked = false)); }
            if ((portB & 0b0010_0000) == 32) { cbPinB5.Invoke(new Action(() => cbPinB5.Checked = true)); } else { cbPinB5.Invoke(new Action(() => cbPinB5.Checked = false)); }
            if ((portB & 0b0100_0000) == 64) { cbPinB6.Invoke(new Action(() => cbPinB6.Checked = true)); } else { cbPinB6.Invoke(new Action(() => cbPinB6.Checked = false)); }
            if ((portB & 0b1000_0000) == 128) { cbPinB7.Invoke(new Action(() => cbPinB7.Checked = true)); } else { cbPinB7.Invoke(new Action(() => cbPinB7.Checked = false)); }
        }

        public void clearFieldsThread()
        {
            for (int i = 0; i < lvAusgabe.Items.Count; i++)
            {
                lvAusgabe.Invoke(new Action(() => lvAusgabe.Items[i].BackColor = Color.Transparent));
            }
        }

        private bool BreakpointChecked(int counter)
        {
            bool result = false;
            var checkBreakpoint = new Action(() => result = lvAusgabe.Items[counter].Checked);

            if (lvAusgabe.InvokeRequired)
            {
                lvAusgabe.Invoke(checkBreakpoint);
            }

            return result;
        }

        public void UpdateRegisterinhaltThread()
        {
            lblWReg.Invoke(new Action(() => lblWReg.Text = Convert.ToString(umwandlung.gui.getW())));
            lblPCIntern.Invoke(new Action(() => lblPCIntern.Text = Convert.ToString(umwandlung.getPCIntern())));
            lblPCL.Invoke(new Action(() => lblPCL.Text = Convert.ToString(umwandlung.getPCL())));
            lblPCLATCH.Invoke(new Action(() => lblPCLATCH.Text = Convert.ToString(umwandlung.getPCLATCH())));
            lblStatus.Invoke(new Action(() => lblStatus.Text = Convert.ToString(umwandlung.gui.getStatus())));
            lblFSR.Invoke(new Action(() => lblFSR.Text = Convert.ToString(umwandlung.gui.getFSR())));
            lblOption.Invoke(new Action(() => lblOption.Text = Convert.ToString(umwandlung.gui.getOption())));
            lblVorteiler.Invoke(new Action(() => lblVorteiler.Text = "1:" + Convert.ToString(umwandlung.gui.getPrescalerGUI())));
            lblTimer0.Invoke(new Action(() => lblTimer0.Text = Convert.ToString(umwandlung.gui.getTimer0())));
        }

        public void UpdateSFRThread()
        {
            //Status
            lblIRP.Invoke(new Action(() => lblIRP.Text = Convert.ToString(umwandlung.gui.getIRP())));
            lblRP1.Invoke(new Action(() => lblRP1.Text = Convert.ToString(umwandlung.gui.getRP1())));
            lblRP0.Invoke(new Action(() => lblRP0.Text = Convert.ToString(umwandlung.operation.getRP0())));
            lblTO.Invoke(new Action(() => lblTO.Text = Convert.ToString(umwandlung.operation.getTO())));
            lblPD.Invoke(new Action(() => lblPD.Text = Convert.ToString(umwandlung.operation.getPD())));
            lblZ.Invoke(new Action(() => lblZ.Text = Convert.ToString(umwandlung.gui.getZ())));
            lblDC.Invoke(new Action(() => lblDC.Text = Convert.ToString(umwandlung.gui.getDC())));
            lblC.Invoke(new Action(() => lblC.Text = Convert.ToString(umwandlung.operation.getC())));
            //Option
            lblRPu.Invoke(new Action(() => lblRPu.Text = Convert.ToString(umwandlung.gui.getRPu())));
            lblIEg.Invoke(new Action(() => lblIEg.Text = Convert.ToString(umwandlung.operation.getIEg())));
            lblTCs.Invoke(new Action(() => lblTCs.Text = Convert.ToString(umwandlung.gui.getTCs())));
            lblTSe.Invoke(new Action(() => lblTSe.Text = Convert.ToString(umwandlung.gui.getTSe())));
            lblPSA.Invoke(new Action(() => lblPSA.Text = Convert.ToString(umwandlung.operation.getPSA())));
            lblPS2.Invoke(new Action(() => lblPS2.Text = Convert.ToString(umwandlung.operation.getPS2())));
            lblPS1.Invoke(new Action(() => lblPS1.Text = Convert.ToString(umwandlung.operation.getPS1())));
            lblPS0.Invoke(new Action(() => lblPS0.Text = Convert.ToString(umwandlung.operation.getPS0())));
            //Intcon
            lblGIE.Invoke(new Action(() => lblGIE.Text = Convert.ToString(umwandlung.operation.getGIE())));
            lblEIE.Invoke(new Action(() => lblEIE.Text = Convert.ToString(umwandlung.gui.getEIE())));
            lblTIE.Invoke(new Action(() => lblTIE.Text = Convert.ToString(umwandlung.gui.getTIE())));
            lblIE.Invoke(new Action(() => lblIE.Text = Convert.ToString(umwandlung.gui.getIE())));
            lblRIE.Invoke(new Action(() => lblRIE.Text = Convert.ToString(umwandlung.gui.getRIE())));
            lblTIF.Invoke(new Action(() => lblTIF.Text = Convert.ToString(umwandlung.gui.getTIF())));
            lblIF.Invoke(new Action(() => lblIF.Text = Convert.ToString(umwandlung.gui.getIF())));
            lblRIF.Invoke(new Action(() => lblRIF.Text = Convert.ToString(umwandlung.gui.getRIF())));
        }

        public void UpdateStackThread()
        {
            lblStack1.Invoke(new Action(() => lblStack1.Text = Convert.ToString(umwandlung.gui.getStack1())));
            lblStack2.Invoke(new Action(() => lblStack2.Text = Convert.ToString(umwandlung.gui.getStack2())));
            lblStack3.Invoke(new Action(() => lblStack3.Text = Convert.ToString(umwandlung.gui.getStack3())));
            lblStack4.Invoke(new Action(() => lblStack4.Text = Convert.ToString(umwandlung.gui.getStack4())));
            lblStack5.Invoke(new Action(() => lblStack5.Text = Convert.ToString(umwandlung.gui.getStack5())));
            lblStack6.Invoke(new Action(() => lblStack6.Text = Convert.ToString(umwandlung.gui.getStack6())));
            lblStack7.Invoke(new Action(() => lblStack7.Text = Convert.ToString(umwandlung.gui.getStack7())));
            lblStack8.Invoke(new Action(() => lblStack8.Text = Convert.ToString(umwandlung.gui.getStack8())));
        }

        public void UpdateFileThread()
        {
            dgvFileregister.Invoke(new Action(() => InvokeFile()));
            
        }

        public void InvokeFile()
        {
            dgvFileregister.Rows.Clear();

            for (int i = 0; i < 256; i = i + 8)
            {
                int[] inhaltrow = new int[8];

                for (int j = 0; j <= 7; j++)
                {
                    int stelle = i + j;
                    inhaltrow[j] = umwandlung.gui.getBankInhalt(stelle);
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

        public void UpdateTimingThread()
        {
            lblWatchdog.Invoke(new Action(() => lblWatchdog.Text = Convert.ToString(umwandlung.gui.getWatchdog())));
            double result = 0;
            //Console.WriteLine("CBQUARZ" + cbQuarz.SelectedIndex);

            switch (SelectedIndex())
            {
                case -1:
                    //32kHz
                    result = Laufzeit * 32.25;
                    lblLaufzeit.Invoke(new Action(() => lblLaufzeit.Text = Convert.ToString(result)));
                    break;
                case 0:
                    //64kHz
                    result = Laufzeit * 15.625;
                    lblLaufzeit.Invoke(new Action(() => lblLaufzeit.Text = Convert.ToString(result)));
                    break;
                case 1:
                    //1MHz
                    result = Laufzeit * 1;
                    lblLaufzeit.Invoke(new Action(() => lblLaufzeit.Text = Convert.ToString(result)));
                    break;
                case 2:
                    //10MHz
                    result = Laufzeit * 0.1;
                    lblLaufzeit.Invoke(new Action(() => lblLaufzeit.Text = Convert.ToString(result)));
                    break;
                default:
                    break;
            }
        }

        private int SelectedIndex()
        {
            int result = 0;
            var selectedIndex = new Action(() => result = cbQuarz.SelectedIndex);

            if (lvAusgabe.InvokeRequired)
            {
                cbQuarz.Invoke(selectedIndex);
            }

            return result;
        }

        private void gBTiming_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdateFile_Click(object sender, EventArgs e)
        {
            int speicherstelle = Convert.ToInt32(tbSpeicherstelle.Text, 16);
            int wert = Convert.ToInt32(tbWert.Text, 16);

            umwandlung.gui.updateFile(speicherstelle, wert);

            UpdateFile();

            MessageBox.Show("Gespeichert");
        }
    }
}
