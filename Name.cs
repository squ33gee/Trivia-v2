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
using System.Media;

namespace Trivia
{
    public partial class Name : Form
    {
        public Name()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                SystemSounds.Exclamation.Play();
            }
            else
            {
                if (label3.Text == "Викторина выбрана!")
                {                    
                    this.Hide();
                    Form f = new Question();
                    f.Show();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                }            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Menu();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Stream myStream = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "trivia file (*.trv)|*.trv";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Null.Darth_Veider = openFileDialog1.FileName;

                            DateTime date1 = DateTime.Today;
                            Console.WriteLine(date1.ToString());
                            DateTime dateOnly = date1.Date;
                            Null.global_record = dateOnly.ToString("d") + " | " + "Имя: " + textBox1.Text;

                            label3.Text = "Викторина выбрана!";
                            label3.ForeColor = Color.LimeGreen;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
