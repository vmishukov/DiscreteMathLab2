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
 
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            GrayCodeGenerator.generateGrayarr(int.Parse(InputTextBox.Text));
            outputGrid.Columns.Clear();
            outputGrid.Rows.Clear();
            outputGrid.Refresh();
            outputGrid.ColumnCount = 3;
            outputGrid.RowCount = GrayCodeGenerator.arr.Count;
            outputGrid.Columns[0].HeaderText = "i";
            outputGrid.Columns[1].HeaderText = "p";
            outputGrid.Columns[2].HeaderText = "B";
            double Power = 2;
            int i = 0;
            foreach (var num in GrayCodeGenerator.arr)
            {
                outputGrid.Rows[i].Cells[0].Value = i;
                if ((double)i == Math.Pow(2,Power))
                {
                    outputGrid.Rows[i].Cells[1].Value = 2+Power-1;
                    Power++;
                }
                else
                {
                    if ((i%2)>0)
                    {
                        outputGrid.Rows[i].Cells[1].Value = 1;
                    }
                    else
                    {
                        outputGrid.Rows[i].Cells[1].Value = 2;
                    }
                }
                outputGrid.Rows[i].Cells[2].Value = num;
                i++;
            }
        }

        private void InputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar))))
            {

                e.Handled = true;
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            //This line of code creates a text file for the data export.
            System.IO.StreamWriter file = new System.IO.StreamWriter("../../Results/save.txt");
            try
            {
                string sLine = "";

                //This for loop loops through each row in the table
                for (int r = 0; r <= outputGrid.Rows.Count - 1; r++)
                {
                    //This for loop loops through each column, and the row number
                    //is passed from the for loop above.
                    for (int c = 0; c <= outputGrid.Columns.Count - 1; c++)
                    {
                        sLine = sLine + outputGrid.Rows[r].Cells[c].Value;
                        if (c != outputGrid.Columns.Count - 1)
                        {
                            //A comma is added as a text delimiter in order
                            //to separate each field in the text file.
                            //You can choose another character as a delimiter.
                            sLine = sLine + ",";
                        }
                    }
                    //The exported text is written to the text file, one line at a time.
                    file.WriteLine(sLine);
                    sLine = "";
                }

                file.Close();
                System.Windows.Forms.MessageBox.Show("Export Complete.", "Program Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                file.Close();
            }
        }
    }
}
