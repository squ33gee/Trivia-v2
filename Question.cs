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
    public partial class Question : Form
    {
        string[] massiv = new string[5000];
        string Answer_Text = "";
        string text = "";

        int mass_not = 0;
        int number_mass = 1;
        int END = 0;
        int trueAnsw = 0;
        int button = 0;

        public Question()
        {
            InitializeComponent();
        }

        private void Question_Load(object sender, EventArgs e)
        {
            this.Text = "Викторина: " + Path.GetFileNameWithoutExtension(@Null.Darth_Veider);

            //=================================================================
            // Вопрос
            Encoding enc = Encoding.GetEncoding(1251);

            string[] mass = new string[5];
      
            int first_pod = 0;
            int second_pod = 0;
            int third_pod = 0;
            int fourth_pod = 0;
            int fifth_pod = 0;

            string line = "";

            using (StreamReader fs = new StreamReader(@Null.Darth_Veider))
            {
                while ((line = fs.ReadLine()) != null)
                {
                    END++;
                }
                fs.Close();
            }
            

            using (StreamReader fs = new StreamReader(@Null.Darth_Veider))
            {
                while (true)
                {

                    // Читаем строку из файла во временную переменную.
                    string temp = fs.ReadLine();

                    // Если достигнут конец файла, прерываем считывание.
                    if (temp == null) break;

                    // Пишем считанную строку в итоговую переменную.
                    text += temp;

                    massiv[mass_not] = temp;
                    mass_not++;

                    int test = 1;
                    int test_vvI = 0;
                    bool test_test = false;
                    int testing = 0;

                    for (int vvI = 0; test_test == false; vvI++)
                    {
                        if(text.Substring(vvI, 1) == " ")
                        {
                            test_test = true;
                            testing = vvI - 1;
                        }
                    }

                    trueAnsw = Convert.ToInt32(text.Substring(testing, 1));

                    for (int vvI = 0; vvI < testing; vvI++)
                    {
                        if (text.Substring(vvI, 1) == "_" && test == 1)
                        {
                            first_pod = vvI;
                            label5.Text = text.Substring(0, vvI) + "/" + END;
                            test_vvI = vvI;
                            test++;
                            vvI++;
                        }

                        if (text.Substring(vvI, 1) == "_" && test == 2)
                        {
                            first_pod = vvI;
                            label2.Text = text.Substring(2, vvI-2);
                            test_vvI = vvI;
                            test++;
                            vvI++;
                        }

                        if (text.Substring(vvI, 1) == "_" && test == 3)
                        {
                            second_pod = vvI;
                            button1.Text = text.Substring(test_vvI+1, second_pod - (first_pod+1));
                            test_vvI = vvI;
                            test++;
                            vvI++;
                        }

                        if (text.Substring(vvI, 1) == "_" && test == 4)
                        {
                            third_pod = vvI;
                            button2.Text = text.Substring(test_vvI + 1, third_pod - (second_pod+1));
                            test_vvI = vvI;
                            test++;
                            vvI++;
                        }

                        if (text.Substring(vvI, 1) == "_" && test == 5)
                        {
                            fourth_pod = vvI;
                            button3.Text = text.Substring(test_vvI + 1, fourth_pod - (third_pod + 1));
                            test_vvI = vvI;
                            test++;
                            vvI++;
                        }

                        if (text.Substring(vvI, 1) == "_" && test == 6)
                        {
                            fifth_pod = vvI;
                            button4.Text = text.Substring(test_vvI + 1, fifth_pod - (fourth_pod + 1));
                            test_vvI = vvI;
                            test++;
                        }
                    }
                }
            }
            //==================================================================

            if (Null.Picture == 3)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;

                Null.Picture = 3;
            }
            else if (Null.Picture == 2)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;

                Null.Picture = 2;
            }
            else if (Null.Picture == 1)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;

                Null.Picture = 1;
            }
            else if (Null.Picture == 0)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;

                Null.Picture = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trueAnsw == 1)
            {
                Check();
            }
            else
            {
                button = 1;
                Check_Fail();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (trueAnsw == 2)
            {
                Check();
            }
            else
            {
                button = 2;
                Check_Fail();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (trueAnsw == 3)
            {
                Check();
            }
            else
            {
                button = 3;
                Check_Fail();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (trueAnsw == 4)
            {
                Check();
            }
            else
            {
                button = 4;
                Check_Fail();
            }
        }

        private void Answer_Click(object sender, EventArgs e)
        {
            if(trueAnsw == 1)
            {
                button1.BackColor = Color.Green;
                Answer.Enabled = false;
                Null.Answer = 0;
                Null.Answer_Num = 1;
            }
            else if (trueAnsw == 2)
            {
                button2.BackColor = Color.Green;
                Answer.Enabled = false;
                Null.Answer = 0;
                Null.Answer_Num = 1;
            }
            else if (trueAnsw == 3)
            {
                button3.BackColor = Color.Green;
                Answer.Enabled = false;
                Null.Answer = 0;
                Null.Answer_Num = 1;
            }
            else if (trueAnsw == 4)
            {
                button4.BackColor = Color.Green;
                Answer.Enabled = false;
                Null.Answer = 0;
                Null.Answer_Num = 1;
            }
        }

        private void fifty_Click_1(object sender, EventArgs e)
        {
            if (trueAnsw == 1)
            {
                m1:
                Random rnd = new Random();
                int value1 = rnd.Next(1, 4);
                int value2 = rnd.Next(1, 4);

                //Если попался правильный
                if (value1 == 1 || value2 == 1 || value1 == value2 || value1 == value2)
                {
                    goto m1;
                }
                else
                {
                    //Правильный ответ - 1
                    //25% = 2 и 25% = 3 или 4
                    if (value1 == 2 && value2 == 3)
                    {
                        button2.Visible = false;
                        button3.Visible = false;
                    }
                    if (value1 == 2 && value2 == 4)
                    {
                        button2.Visible = false;
                        button4.Visible = false;
                    }

                    //Правильный ответ - 1
                    //25% = 3 и 25% = 2 или 4
                    if (value1 == 3 && value2 == 2)
                    {
                        button3.Visible = false;
                        button2.Visible = false;
                    }
                    if (value1 == 3 && value2 == 4)
                    {
                        button3.Visible = false;
                        button4.Visible = false;
                    }

                    //Правильный ответ - 1
                    //25% = 4 и 25% = 2 или 3
                    if (value1 == 3 && value2 == 2)
                    {
                        button3.Visible = false;
                        button2.Visible = false;
                    }
                    if (value1 == 3 && value2 == 4)
                    {
                        button3.Visible = false;
                        button4.Visible = false;
                    }
                    //==========================
                }
            }
            else if (trueAnsw == 2)
            {
                m2:
                Random rnd = new Random();
                int value1 = rnd.Next(1, 4);
                int value2 = rnd.Next(1, 4);

                //Если попался правильный
                if (value1 == 2 || value2 == 2 || value1 == value2 || value1 == value2)
                {
                    goto m2;
                }
                else
                {
                    //Правильный ответ - 2
                    //25% = 1 и 25% = 3 или 4
                    if (value1 == 1 && value2 == 3)
                    {
                        button1.Visible = false;
                        button3.Visible = false;
                    }
                    if (value1 == 1 && value2 == 4)
                    {
                        button1.Visible = false;
                        button4.Visible = false;
                    }

                    //Правильный ответ - 2
                    //25% = 3 и 25% = 1 или 4
                    if (value1 == 3 && value2 == 1)
                    {
                        button3.Visible = false;
                        button1.Visible = false;
                    }
                    if (value1 == 3 && value2 == 4)
                    {
                        button3.Visible = false;
                        button4.Visible = false;
                    }

                    //Правильный ответ - 2
                    //25% = 4 и 25% = 1 или 3
                    if (value1 == 4 && value2 == 1)
                    {
                        button4.Visible = false;
                        button1.Visible = false;
                    }
                    if (value1 == 4 && value2 == 3)
                    {
                        button4.Visible = false;
                        button3.Visible = false;
                    }
                    //==========================
                }
            }
            else if (trueAnsw == 3)
            {
                m3:
                Random rnd = new Random();
                int value1 = rnd.Next(1, 4);
                int value2 = rnd.Next(1, 4);

                //Если попался правильный
                if (value1 == 3 || value2 == 3 || value1 == value2 || value1 == value2)
                {
                    goto m3;
                }
                else
                {
                    //Правильный ответ - 3
                    //25% = 1 и 25% = 2 или 4
                    if (value1 == 1 && value2 == 2)
                    {
                        button1.Visible = false;
                        button2.Visible = false;
                    }
                    if (value1 == 1 && value2 == 4)
                    {
                        button1.Visible = false;
                        button4.Visible = false;
                    }

                    //Правильный ответ - 3
                    //25% = 2 и 25% = 1 или 4
                    if (value1 == 2 && value2 == 1)
                    {
                        button2.Visible = false;
                        button1.Visible = false;
                    }
                    if (value1 == 2 && value2 == 4)
                    {
                        button2.Visible = false;
                        button4.Visible = false;
                    }

                    //Правильный ответ - 3
                    //25% = 4 и 25% = 1 или 2
                    if (value1 == 4 && value2 == 1)
                    {
                        button4.Visible = false;
                        button1.Visible = false;
                    }
                    if (value1 == 4 && value2 == 2)
                    {
                        button1.Visible = false;
                        button2.Visible = false;
                    }
                    //==========================
                }
            }
            else if (trueAnsw == 4)
            {
                m4:
                Random rnd = new Random();
                int value1 = rnd.Next(1, 4);
                int value2 = rnd.Next(1, 4);

                //Если попался правильный
                if (value1 == 4 || value2 == 4 || value1 == value2 || value1 == value2)
                {
                    goto m4;
                }
                else
                {
                    //Правильный ответ - 4
                    //25% = 1 и 25% = 2 или 3
                    if (value1 == 1 && value2 == 2)
                    {
                        button1.Visible = false;
                        button2.Visible = false;
                    }
                    if (value1 == 1 && value2 == 3)
                    {
                        button1.Visible = false;
                        button3.Visible = false;
                    }

                    //Правильный ответ - 4
                    //25% = 2 и 25% = 1 или 3
                    if (value1 == 2 && value2 == 1)
                    {
                        button2.Visible = false;
                        button1.Visible = false;
                    }
                    if (value1 == 2 && value2 == 3)
                    {
                        button2.Visible = false;
                        button3.Visible = false;
                    }

                    //Правильный ответ - 4
                    //25% = 3 и 25% = 1 или 2
                    if (value1 == 3 && value2 == 1)
                    {
                        button3.Visible = false;
                        button1.Visible = false;
                    }
                    if (value1 == 3 && value2 == 2)
                    {
                        button3.Visible = false;
                        button2.Visible = false;
                    }
                    //==========================
                }
            }

            //==================================

            if (Null.Num == 3)
            {
                Null.NumText = "x2";
                Null.Num -= 1;
                label4.Text = Null.NumText;
            }
            else if (Null.Num == 2)
            {
                Null.NumText = "x1";
                Null.Num -= 1;
                label4.Text = Null.NumText;
            }
            else if (Null.Num == 1)
            {
                Null.NumText = "x0";
                Null.Num -= 1;
                label4.Text = Null.NumText;
            }

            fifty.Enabled = false;
            Null.Fifty = 1;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Form f = new Surrender();
            f.Show();
            this.Hide();
        }      

        public void Check ()
        {
            if (Null.Q != END)
            {
                if (Null.Answer == 1)
                {
                    Answer.Enabled = true;
                }
                else
                {
                    Answer.Enabled = false;
                }

                if (Null.Num == 0)
                {
                    fifty.Enabled = false;
                }
                else
                {
                    fifty.Enabled = true;
                }

                // Право на ошибку

                if (Null.Picture == 3)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;

                    Null.Picture = 3;
                }
                else if (Null.Picture == 2)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = false;

                    Null.Picture = 2;
                }
                else if (Null.Picture == 1)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;

                    Null.Picture = 1;
                }
                else if (Null.Picture == 0)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;

                    Null.Picture = 0;
                }

                //===============================================

                for (int vvI = number_mass; vvI < mass_not; vvI++)
                {
                    Answer_Text = massiv[vvI];

                    int first_pod = 0;
                    int second_pod = 0;
                    int third_pod = 0;
                    int fourth_pod = 0;
                    int fifth_pod = 0;

                    int test = 1;
                    int test_vvJ = 0;
                    bool test_test = false;
                    int testing = 0;

                    for (int vvK = 0; test_test == false; vvK++)
                    {
                        if (Answer_Text.Substring(vvK, 1) == " ")
                        {
                            test_test = true;
                            testing = vvK - 1;
                        }
                    }

                    for (int vvJ = 0; vvJ < Answer_Text.Length; vvJ++)
                    {
                        if (Answer_Text.Substring(vvJ, 1) == "_" && test == 1)
                        {
                            first_pod = vvJ;
                            label5.Text = Answer_Text.Substring(0, vvJ) + "/" + END;
                            test_vvJ = vvJ;
                            test++;
                            vvJ++;
                        }

                        if (Answer_Text.Substring(vvJ, 1) == "_" && test == 2)
                        {
                            first_pod = vvJ;
                            label2.Text = Answer_Text.Substring(2, vvJ - 2);
                            test_vvJ = vvJ;
                            test++;
                            vvJ++;
                        }

                        if (Answer_Text.Substring(vvJ, 1) == "_" && test == 3)
                        {
                            second_pod = vvJ;
                            button1.Text = Answer_Text.Substring(test_vvJ + 1, second_pod - (first_pod + 1));
                            test_vvJ = vvJ;
                            test++;
                            vvJ++;
                        }

                        if (Answer_Text.Substring(vvJ, 1) == "_" && test == 4)
                        {
                            third_pod = vvJ;
                            button2.Text = Answer_Text.Substring(test_vvJ + 1, third_pod - (second_pod + 1));
                            test_vvJ = vvJ;
                            test++;
                            vvJ++;
                        }

                        if (Answer_Text.Substring(vvJ, 1) == "_" && test == 5)
                        {
                            fourth_pod = vvJ;
                            button3.Text = Answer_Text.Substring(test_vvJ + 1, fourth_pod - (third_pod + 1));
                            test_vvJ = vvJ;
                            test++;
                            vvJ++;
                        }

                        if (Answer_Text.Substring(vvJ, 1) == "_" && test == 6)
                        {
                            fifth_pod = vvJ;
                            button4.Text = Answer_Text.Substring(test_vvJ + 1, fifth_pod - (fourth_pod + 1));
                            test_vvJ = vvJ;
                            test++;
                        }
                    }

                    button1.BackColor = Color.Gainsboro;
                    button2.BackColor = Color.Gainsboro;
                    button3.BackColor = Color.Gainsboro;
                    button4.BackColor = Color.Gainsboro;

                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;

                    Null.Q++;
                    label1.Text = "Вопрос №" + Convert.ToString(Null.Q);

                    Null.Score += 10;
                    label3.Text = "Очки:" + Null.Score;

                    Null.ScoreTrue++;

                    trueAnsw = Convert.ToInt32(Answer_Text.Substring(testing, 1));
                    number_mass++;
                    break;
                }
            }
            else
            {
                Null.Score += 10;

                this.Hide();
                Form f = new Win();
                f.Show();
            }
        }

        public void Check_Fail()
        {
            //Какая кнопка была нажата
            if (button == 1)
            {
                button1.BackColor = Color.Red;
            }
            if (button == 2)
            {
                button2.BackColor = Color.Red;
            }
            if (button == 3)
            {
                button3.BackColor = Color.Red;
            }
            if (button == 4)
            {
                button4.BackColor = Color.Red;
            }
            //================================

            if (Null.Picture == 3)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;

                Null.Picture = 2;
            }
            else if (Null.Picture == 2)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;

                Null.Picture = 1;
            }
            else if (Null.Picture == 1)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;

                Null.Picture = 0;
            }
            else if (Null.Picture == 0)
            {
                this.Hide();
                Form f = new Fail();
                f.Show();
            }
        }
    }
}
