
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace FirstForm
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RegisterWindowMessage(string lpString);
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys ArrowKeys);
        //memory stuff
        const int PROCESS_WM_READ = 0x0010;
        Process targetProcess;
        IntPtr processHandle;
        //addresses
        IntPtr life_BaseAddr;
        int[] life_offsets = { 0x8, 0x4, 0x24, 0x0, 0xBC, 0x4, 0x3C };
        IntPtr maxLife_BaseAddr;
        int[] maxLife_offsets = { 0x8, 0x4, 0x24, 0x0, 0xBC, 0x4, 0x40 };

        IntPtr mana_BaseAddr;
        int[] mana_offsets = { 0x8, 0x10, 0x48, 0x18, 0x0, 0xC4, 0xE50 };
        IntPtr maxMana_BaseAddr;
        int[] maxMana_offsets = { 0x8, 0x10, 0x48, 0x18, 0x0, 0xC4, 0xE58 };

        IntPtr maxUtamo_BaseAddr;
        int[] maxUtamo_offsets = { 0x1d0 };
       

        //game stats
        private float life=0;
        private float maxLife=0;
        private float mana=0;
        private float maxMana=0;
        private float maxUtamo=0;
        const string windowClassName = "Qt5QWindowOwnDCIcon"; //taleon window class name

        //hotkeys
        public string selectedHtck_cura1;
        public string selectedHtck_cura2;
        public string selectedHtck_cura3;
        public float cura_1;
        public float cura_2;
        public float cura_3;

        public string selectedHtck_mana1;
        public string selectedHtck_mana2;
        public string selectedHtck_mana3;

        
        bool running = false;
        
        //CAVEBOT
        Cavebot cavebot;
        
        public Form1()
        {
            InitializeComponent();
            setupMemoryReading();
            InitializeBackgroundWorker();
            
            cbox_Play.Checked = true;
            
            //MessageBox.Show("Finished");
        }

        private void InitHotkeys()
        {
            Console.WriteLine("htk_cura1.Text: " + htk_cura1.Text);
            selectedHtck_cura1 = htk_cura1.Text;
            selectedHtck_cura2 = htk_cura2.Text;
            selectedHtck_cura3 = htk_cura3.Text;
        }

        public void setupMemoryReading()
        {
            try
            {
                targetProcess = Process.GetProcessesByName("taleon")[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            processHandle = OpenProcess(PROCESS_WM_READ, false, targetProcess.Id);


            var baseAddr = targetProcess.MainModule.BaseAddress;
            
            int bytesRead = 0;
            byte[] buffer = new byte[4];
            mana_BaseAddr = baseAddr + 0x00E1D260;
            mana = MemoryUtils.ReadMemoryWithOffsets(processHandle, (int)mana_BaseAddr, mana_offsets);
            maxMana_BaseAddr = baseAddr + 0x00E1D260;
            maxMana = MemoryUtils.ReadMemoryWithOffsets(processHandle, (int)maxMana_BaseAddr, maxMana_offsets);
           // MessageBox.Show("maxMana: " + maxMana);

            life_BaseAddr = baseAddr + 0x00E1A8AC; 
            //ReadProcessMemory((int)processHandle, (life_BaseAddr, buffer, buffer.Length, ref bytesRead);
            //life = BitConverter.ToInt32(buffer, 0);
            //MessageBox.Show("life: " + life);

            maxLife_BaseAddr = baseAddr + 0x00E1A8AC;
            maxLife = MemoryUtils.ReadMemoryWithOffsets(processHandle, (int)maxLife_BaseAddr, maxLife_offsets);
       

            maxUtamo_BaseAddr = baseAddr + 0xE171FC;
            maxUtamo = MemoryUtils.ReadMemoryWithOffsets(processHandle, (int)maxUtamo_BaseAddr, maxUtamo_offsets);
      

           
            MemoryUtils.SendKeyToWindow(windowClassName, MemoryUtils.VK_N);

            //Init cavebot
            
            cavebot = new Cavebot(processHandle,baseAddr, this.listBox1);

        }

        //UTAMO VITA CD: 180sec

        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;
            doSomething(worker);
            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
        }
        private int progress = 0;
        private void doSomething(BackgroundWorker worker)
        {
            while (running)
            {
                //Thread.Sleep(2000);
                //Console.WriteLine("Thread Running");
                Life();
                Mana();
                cavebot.updateCords();
                if (cavebot.running) cavebot.caveRun();

               
                //worker.ReportProgress(progress);
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.

            }
            else
            {
                Console.WriteLine("BackgroundWorker finished its job");
                // Finally, handle the case where the operation 
                // succeeded.

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.progressBar1.Value = e.ProgressPercentage;
        }
        private void Life()
        {
            life = MemoryUtils.ReadMemoryWithOffsets(processHandle, (int)life_BaseAddr, life_offsets);
            //Console.WriteLine(life);
            //float percentage = (life / maxLife) * 100;
            //Console.WriteLine(percentage);
            string htkToSend = "";

            List<Tuple<float, string>> ordemDeCura = new List<Tuple<float, string>>
            {
             new Tuple<float, string>(cura_1, selectedHtck_cura1),
             new Tuple<float, string>(cura_2, selectedHtck_cura2),
             new Tuple<float, string>(cura_3, selectedHtck_cura3)
            };
            ordemDeCura = ordemDeCura.OrderByDescending(x => x.Item1).ToList();


           foreach(Tuple<float, string> tuple in ordemDeCura)
            {
                if (life <= tuple.Item1)
                {
                    htkToSend = tuple.Item2;
                }
            }
            if (htkToSend != "")
            {
                Console.WriteLine(htkToSend);
                MemoryUtils.SendKeyToWindow(windowClassName, MemoryUtils.getKeyCodeFromString(htkToSend)); 
            }

        }
        private void Mana()
        {
            mana = MemoryUtils.ReadMemoryWithOffsets(processHandle, (int)mana_BaseAddr, mana_offsets);
            float percentage = (mana / maxMana) * 100;
            //Console.WriteLine(mana);
            if (percentage <= 30)
            {
                MemoryUtils.SendKeyToWindow(windowClassName, MemoryUtils.VK_F4);
            }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void Form1_Shown(Object sender, EventArgs e)
        {

           // MessageBox.Show("You are in the Form.Shown event.");
            InitHotkeys();
        }


        private void cboxPlay_CheckedChanged(object sender, EventArgs e)
        {
            if(backgroundWorker1.IsBusy)
            {
                running = false;
            }
            else
            {
                running = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void htk_cura1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedHtck_cura1 = comboBox.Text;
            Console.WriteLine("item changed: " + comboBox.Text);
            
            
            
        }
        private void htk_cura2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedHtck_cura2 = comboBox.Text;
            Console.WriteLine("item changed: " + comboBox.Text);

        }
        private void htk_cura3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedHtck_cura3 = comboBox.Text;
            Console.WriteLine("item changed: " + comboBox.Text);

        }
        private void valor_cura1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            float.TryParse(textBox.Text, out cura_1);
            Console.WriteLine("cura_1: " + textBox.Text);
            

        }
        private void valor_cura2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            float.TryParse(textBox.Text, out cura_2);
            Console.WriteLine("cura_2: " + textBox.Text);
        }
        private void valor_cura3_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            float.TryParse(textBox.Text, out cura_3);
            Console.WriteLine("cura_3: " + textBox.Text);
        }
        private void arrow_up_Click(object sender, EventArgs e)
        {
            this.cavebot.addStep(DIR.UP);
            
        }
        private void arrow_left_Click(object sender, EventArgs e)
        {
           this.cavebot.addStep(DIR.LEFT);
        }

        private void arrow_down_Click(object sender, EventArgs e)
        {
            this.cavebot.addStep(DIR.DOWN);
        }
        private void arrow_right_Click(object sender, EventArgs e)
        {
            this.cavebot.addStep(DIR.RIGHT);
        }
        private void btn_clearList_Click(object sender, EventArgs e)
        {
            cavebot.removeStepAt(listBox1.SelectedIndex);
           // listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            
        }
        private void cbox_caveRun_CheckedChanged(object sender, EventArgs e)
        {
           cavebot.running = !cavebot.running;
        }

    }
}
