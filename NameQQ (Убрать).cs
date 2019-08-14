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

namespace Trivia
{
    public partial class NameQQ : Form
    {
        public NameQQ()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                FileStream file1 = File.Create("Text\\Questions\\" + textBox1.Text + ".txt");
                file1.Close();
                FileStream file2 = System.IO.File.Create("Text\\Questions\\Num\\Num" + textBox1.Text + ".txt");
                file2.Close();

                StreamWriter file = new StreamWriter("Text\\Questions\\Num\\Num" + textBox1.Text + ".txt");
                file.Write("0");
                file.Close();

                this.Close();
                Form f = new Setting();
                f.Show();
            }
            else
            {
                MessageBox.Show("Введите название!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form f = new Setting();
            f.Show();
        }
    }
}
