using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoclicksharp
{
    //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    //public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    public partial class Form1 : Form
    {
        //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public int TestClock;
        //public int TestButton;
        public Form1()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.K))
            {
                //bool OldTimer = timer1.Enabled;
                timer1.Interval = int.Parse(textBox1.Text);
                timer1.Enabled = true;
            }
            if (keyData == (Keys.Control | Keys.Shift | Keys.L))
            {
                timer1.Enabled = false;
            }
            if (keyData == (Keys.Control | Keys.Shift | Keys.J))
            {
                timer1.Interval = int.Parse(textBox1.Text);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Add screen position setting?

            int PositionX=Cursor.Position.X, PositionY= Cursor.Position.Y;
            //SetCursorPos(PositionX, PositionY);
            mouse_event(MOUSEEVENTF_LEFTDOWN, PositionX, PositionY, 0, 0);
            //System.Threading.Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTUP, PositionX, PositionY, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //int.Parse(textBox1.Text);
            //timer1.Enabled = true;
            timer1.Interval= int.Parse(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestClock += 1;
            button2.Text = TestClock.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TestClock += 1;
            MessageBox.Show(TestClock.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(textBox1.Text);
            timer1.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            
                
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.K))
            {
                //bool OldTimer = timer1.Enabled;
                timer1.Enabled = true;
            }
            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.L))
            {
                timer1.Enabled = false;
            }
        }
    }
}
