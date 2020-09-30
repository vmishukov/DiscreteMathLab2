using MetroFramework.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            BitArray bits;

            bits = GrayCode.IntToGray(int.Parse(metroTextBox1.Text));
            metroLabel1.Text = bits.ToString();
        }
    }
}
