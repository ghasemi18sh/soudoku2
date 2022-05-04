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

namespace soudoko2 {
  public partial class Form1: Form {
    TextBox[, ] cells;
    public Form1() {
      InitializeComponent();
      cells = new TextBox[9, 9];
    }
    private void Form1_Load(object sender, EventArgs e) {
      for (int i = 0; i < 9; i++) {
        for (int j = 0; j < 9; j++) {
          cells[i, j] = new TextBox();
          cells[i, j].Multiline = true;
          cells[i, j].TextAlign = HorizontalAlignment.Center;
          cells[i, j].Font = new Font("Tahoma", 20);
          cells[i, j].ForeColor = Color.WhiteSmoke;
          cells[i, j].BackColor = Color.FromArgb(52, 73, 94);
          cells[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
          tableLayoutPanel1.Controls.Add(cells[i, j], i, j);

        }
      }
    }

    private void button1_Click(object sender, EventArgs e) {
      OpenFileDialog x = new OpenFileDialog();
      if (x.ShowDialog() == DialogResult.OK) {
        reset();
        string file_path = x.FileName;
        StreamReader my_file_reader = new StreamReader(file_path);
        string big_text = my_file_reader.ReadToEnd();
        char[] my_file_seprator = {
          ' ',
          '\r'
        };
        big_text = big_text.Replace("\n", "");

        string[] numbers = big_text.Split(my_file_seprator);
        int index = 0;
        for (int i = 0; i < 9; i++) {
          for (int j = 0; j < 9; j++) {
            if (numbers[index] != "0") {
              cells[j, i].ReadOnly = true;
              cells[j, i].Text = numbers[index];
            }
            index++;
          }
        }
      }

    }
    public void reset() {
      for (int i = 0; i < 9; i++) {
        for (int j = 0; j < 9; j++) {
          cells[j, i].ReadOnly = false;
          cells[j, i].Text = "";
        }
      }
    }

    private void button2_Click_1(object sender, EventArgs e) {
      int[] row, col, sq;
      int index;
      for (int i = 0; i < 9; i++) {
        row = new int[9];
        col = new int[9];
        for (int j = 0; j < 9; j++) {
          if (cells[j, i].ReadOnly == false) {
            int rowCell = Convert.ToInt32(cells[j, i].Text);
            int colCell = Convert.ToInt32(cells[i, j].Text);
            if (!row.Contains(rowCell) && !col.Contains(colCell)) {
              row[j] = rowCell;
              col[j] = colCell;
              continue;
            }
          }
          MessageBox.Show("Eshtebah ast.");
          return;
        }
      }
      for (int h = 1, s1 = 0, e1 = 3, s2 = 0, e2 = 3; h <= 9; h++, s2 += 3, e2 += 3) {
        if ((h - 1) % 3 == 0) {
          s2 = 0;
          e2 = 3;
        }
        sq = new int[9];
        index = 0;
        for (int i = s1; i < e1; i++) {
          for (int j = s2; j < e2; j++) {
            int cell = Convert.ToInt32(cells[j, i].Text);
            if (!sq.Contains(cell)) {
              sq[index++] = cell;
              continue;
            }
            MessageBox.Show("Eshtebah ast.");
            return;
          }
        }
        if (h % 3 == 0) {
          s1 += 3;
          e1 += 3;
        }
      }
      MessageBox.Show("Dorost bood !");
    }
  }
}
