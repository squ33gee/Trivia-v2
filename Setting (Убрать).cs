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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();

            DirectoryInfo di = new DirectoryInfo(@"Text\Questions\");

            foreach (var fi in di.GetFiles("*.txt"))
            {
                comboBox1.Items.Add(fi.Name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Menu();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true || radioButton4.Checked == true)
                    {
                        StreamWriter textFile = new StreamWriter(@"Text\Questions\" + comboBox1.Text, true);

                        textFile.Write(textBox1.Text + "_");
                        textFile.Write(textBox2.Text + "_");
                        textFile.Write(textBox3.Text + "_");
                        textFile.Write(textBox4.Text + "_");
                        textFile.Write(textBox5.Text + "_");

                        if (radioButton1.Checked == true)
                        {
                            textFile.Write("1");
                        }
                        if (radioButton2.Checked == true)
                        {
                            textFile.Write("2");
                        }
                        if (radioButton3.Checked == true)
                        {
                            textFile.Write("3");
                        }
                        if (radioButton4.Checked == true)
                        {
                            textFile.Write("4");
                        }

                        textFile.Write(";");
                        textFile.Write("\r\n");

                        Null.FileQnum++;

                        StreamReader f = File.OpenText(@"Text\\Questions\\Num\\Num" + comboBox1.Text);
                        string read = null;
                        while ((read = f.ReadLine()) != null)
                        {
                            Null.Kolvo = Convert.ToInt32(read);
                        }
                        f.Close();


                        Null.Kolvo++;

                        textFile.Close();

                        StreamWriter textNum2 = new StreamWriter(@"Text\\Questions\\Num\\Num" + comboBox1.Text);
                        textNum2.Write(Null.Kolvo);
                        textNum2.Close();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";

                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;

                        MessageBox.Show("Вопрос создан!");
                    }
                    else
                    {
                        MessageBox.Show("Выберите правильный вариант ответа!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            else
            {
                MessageBox.Show("Выберите файл!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form f = new NameQQ();
            f.Show();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                string sourceDir = @"Text\Questions\";
                string sourceNum = @"Text\Questions\Num";

                string monika;
                string sayori;

                monika = sourceDir + comboBox1.Text;
                sayori = sourceNum + comboBox1.Text;

                System.IO.File.Delete(monika);
                System.IO.File.Delete(sayori);

                MessageBox.Show("Викторина " + comboBox1.Text + " успешно удален.");
                comboBox1.Text = "";
            }
        }
    }
}
