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
    public partial class Record : Form
    {
        public Record()
        {
            InitializeComponent();

            using (StreamReader fs = new StreamReader(@"Text\Records.txt"))
            {
                while (true)
                {
                    string text = "";

                    // Читаем строку из файла во временную переменную.
                    string temp = fs.ReadLine();

                    // Если достигнут конец файла, прерываем считывание.
                    if (temp == null) break;

                    text += temp;
                    
                    if (text.Substring(text.Length-2, 2) == " 0")
                    {

                    }
                    else
                    {
                        listBox1.Items.Add(text);
                    }               
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
