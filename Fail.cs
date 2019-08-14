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
    public partial class Fail : Form
    {
        public Fail()
        {
            InitializeComponent();
            
            label1.Text += Convert.ToString(Null.Score);
            label3.Text += Convert.ToString(Null.ScoreTrue);

            StreamWriter textFile = new StreamWriter(@"Text\Records.txt", true);

            textFile.WriteLine(Null.global_record + " | Очков: " + Null.Score + " | Викторина: " + Path.GetFileNameWithoutExtension(Null.Darth_Veider));
            textFile.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Null.Score = 0;
            Null.ScoreTrue = 0;
            Null.Q = 1;
            Null.NumText = "x3";
            Null.Num = 3;
            Null.Answer = 1;
            Null.Picture = 3;

            Form f = new Menu();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
