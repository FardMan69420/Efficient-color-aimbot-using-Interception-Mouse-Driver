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
        // Made By Cuciu | https://github.com/cuciuu
        // AutoItX3

        AutoItX3 au3 = new AutoItX3();

        public Form1()
        {InitializeComponent();}

        private void Form1_Load(object sender, EventArgs e){}

        Input input = new Input();

        //Timer (Interval 55)
        private void aim_Tick(object sender, EventArgs e)
        {
            try
            {
                // Pixel Color

                int hex = 0xFFDBC3;

                // 0, 0, 1919, 1079

                // 0, 0 Top Left Coord
                // 1919, 1079 Right Down Coord

                object pix = au3.PixelSearch(0, 0, 1919, 1079, hex);

                if (pix.ToString() != "1")
                {
                    object[] pixCoord = (object[])pix;
                    // If the pixel with that color is found then: 
                    input.MoveMouseTo((int)pixCoord[0], (int)pixCoord[1]);  // Please note this doesn't use the driver to move the mouse; it uses System.Windows.Forms.Cursor.Position
                    //Click Event
                    au3.MouseClick("LEFT");
                }
            }
            catch { }
            Thread.Sleep(10);
        }

        // Start Button | Start Timer
        private void start_Click(object sender, EventArgs e)
        {
            aim.Start();
        }

        // Stop Button | Stop Timer
        private void stop_Click(object sender, EventArgs e)
        {
            aim.Stop();
        }
    }
}
