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


namespace SUDOKU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox t = new TextBox();
                    t.TextAlign = HorizontalAlignment.Center;


                    t.Font = new Font("Tahoma", 25);
                    t.Multiline = true;

                    t.Anchor = AnchorStyles.Top |
                                   AnchorStyles.Bottom |
                                       AnchorStyles.Right |
                                             AnchorStyles.Left;

                    tableLayoutPanel1.Controls.Add(t, i, j);
                }

            }
        }

        private void btn_New_Game_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            if (x.ShowDialog() == DialogResult.OK)
            {
                string file_path = x.FileName;
                //MessageBox.Show(file_path);

                StreamReader my_life_reader = new StreamReader(file_path);

                string big_text= my_life_reader.ReadToEnd();
                MessageBox.Show(big_text);

                char[] my_seperatos = { ' ', '\n' };
                string[] numbers = big_text.Split(my_seperatos);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
