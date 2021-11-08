using AutoItX3Lib;
using Interceptor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
namespace colorblinded
{
    public partial class Form1 : Form
    {
        AutoItX3 au3 = new AutoItX3();


        public Form1()
        {
            InitializeComponent();
        }

        bool isRunning = true;
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        Input input = new Input();

        private void aim_Tick(object sender, EventArgs e)
        {
            try
            {
                int hex = 0xFFDBC3;
                object pix = au3.PixelSearch(0, 0, 1919, 1079, hex);
                if (pix.ToString() != "1")
                {
                    object[] pixCoord = (object[])pix;
                    // If the pixel with that color is found then: 
                    input.MoveMouseTo((int)pixCoord[0], (int)pixCoord[1]);  // Please note this doesn't use the driver to move the mouse; it uses System.Windows.Forms.Cursor.Position
                    au3.MouseClick("LEFT");

                }
            }
            catch { }
            // If key {} is pressed, do:

            Thread.Sleep(55);
        }

        private void start_Click(object sender, EventArgs e)
        {
            aim.Start();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            aim.Stop();
        }
    }
}
