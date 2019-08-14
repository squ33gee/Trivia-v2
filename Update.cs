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
    public partial class Update : Form
    {
        int combo1 = 0;

        public Update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (add1.Text == "" || add2.Text == "" || add3.Text == "" || add4.Text == "" || add5.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                comboDel.Items.Clear();

                string name = add1.Text;
                string true_q = add2.Text;
                string test3 = add3.Text;
                string test4 = add4.Text;
                string test5 = add5.Text;
                string test6 = "";
                //==============================
                if (comboAdd.Text == "Ответ 1")
                {
                    test6 = "1";
                }
                else if (comboAdd.Text == "Ответ 2")
                {
                    test6 = "2";
                }
                else if (comboAdd.Text == "Ответ 3")
                {
                    test6 = "3";
                }
                else if (comboAdd.Text == "Ответ 4")
                {
                    test6 = "4";
                }
                else
                {
                    MessageBox.Show("Не выбран правильный ответ!");
                }

                dataGridView1.Rows.Add("", name, true_q, test3, test4, test5, test6);
                //==============================

                //счетчик
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                }
                //==============================

                for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                {
                    comboDel.Items.Add(dataGridView1.Rows[j].Cells[0].Value);
                    comboRed.Items.Add(dataGridView1.Rows[j].Cells[0].Value);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboDel.Text != "")
                {
                    dataGridView1.Rows.RemoveAt(Convert.ToInt32(comboDel.SelectedIndex));
                    comboDel.Items.Remove(Convert.ToInt32(comboDel.Text));
                    comboDel.Items.Clear();

                    for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                    {
                        comboDel.Items.Add(dataGridView1.Rows[j].Cells[0].Value);
                        comboRed.Items.Add(dataGridView1.Rows[j].Cells[0].Value);
                    }

                }
                else
                {
                    MessageBox.Show("Вы не выбрали вопрос!");
                }
            }
            catch
            {
                //добавить!
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Menu();
            f.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            combo1 = Convert.ToInt32(comboRed.Text);
            string combo = "";

            comboDel.Items.Clear();

            red1.Text = Convert.ToString(dataGridView1.Rows[combo1 - 1].Cells[1].Value);
            red2.Text = Convert.ToString(dataGridView1.Rows[combo1 - 1].Cells[2].Value);
            red3.Text = Convert.ToString(dataGridView1.Rows[combo1 - 1].Cells[3].Value);
            red4.Text = Convert.ToString(dataGridView1.Rows[combo1 - 1].Cells[4].Value);
            red5.Text = Convert.ToString(dataGridView1.Rows[combo1 - 1].Cells[5].Value);

            combo = Convert.ToString(dataGridView1.Rows[combo1 - 1].Cells[6].Value);

            if (combo.Trim() == "1")
            {
                comboRed2.SelectedIndex = 0;
            }
            if (combo.Trim() == "2")
            {
                comboRed2.SelectedIndex = 1;
            }
            if (combo.Trim() == "3")
            {
                comboRed2.SelectedIndex = 2;
            }
            if (combo.Trim() == "4")
            {
                comboRed2.SelectedIndex = 3;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[combo1 - 1].Cells[1].Value = Convert.ToString(red1.Text);
            dataGridView1.Rows[combo1 - 1].Cells[2].Value = Convert.ToString(red2.Text);
            dataGridView1.Rows[combo1 - 1].Cells[3].Value = Convert.ToString(red3.Text);
            dataGridView1.Rows[combo1 - 1].Cells[4].Value = Convert.ToString(red4.Text);
            dataGridView1.Rows[combo1 - 1].Cells[5].Value = Convert.ToString(red5.Text);

            if (comboRed2.Text == "Ответ 1")
            {
                dataGridView1.Rows[combo1 - 1].Cells[6].Value = "1 ";
            }
            else if (comboRed2.Text == "Ответ 2")
            {
                dataGridView1.Rows[combo1 - 1].Cells[6].Value = "2 ";
            }
            else if (comboRed2.Text == "Ответ 3")
            {
                dataGridView1.Rows[combo1 - 1].Cells[6].Value = "3 ";
            }
            else if (comboRed2.Text == "Ответ 4")
            {
                dataGridView1.Rows[combo1 - 1].Cells[6].Value = "4 ";
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboDel.Items.Clear();

            Stream mystr = null;

            openFileDialog1.Filter = "trivia file (*.trv)|*.trv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystr = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader myread = new StreamReader(mystr);
                    string[] str;
                    int num = 0;

                    try
                    {
                        string[] str1 = myread.ReadToEnd().Split('\n');
                        num = str1.Count();
                        dataGridView1.RowCount = num;
                        for (int i = 0; i < num; i++)
                        {
                            str = str1[i].Split('_');

                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                try
                                {
                                    dataGridView1.Rows[i].Cells[j].Value = str[j];
                                }
                                catch
                                {
                                    //чтобы не вылетала ошибка
                                }
                            }
                        }

                        for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                        {
                            comboDel.Items.Add(dataGridView1.Rows[j].Cells[0].Value);
                            comboRed.Items.Add(dataGridView1.Rows[j].Cells[0].Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myread.Close();
                    }
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;

            saveFileDialog1.Filter = "trivia file (*.trv)|*.trv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWrite = new StreamWriter(myStream);

                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {

                                myWrite.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());

                                if(j < dataGridView1.ColumnCount - 1)
                                {
                                    myWrite.Write("_");
                                }
                            }

                            myWrite.Write(" \n");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWrite.Close();
                    }
                    myStream.Close();
                }
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboDel.Items.Clear();
            dataGridView1.Rows.Clear();
        }
    }
}
