using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace callSystem
{
    public partial class Phone : Form
    {
        string str = "";
        public Phone()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {              
            textBox1.Text = str + button1.Text;
            str = textBox1.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = str + button2.Text;
            str = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = str + button3.Text;
            str = textBox1.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = str + button4.Text;
            str = textBox1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = str + button5.Text;
            str = textBox1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = str + button6.Text;
            str = textBox1.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = str + button7.Text;
            str = textBox1.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = str + button8.Text;
            str = textBox1.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = str + button9.Text;
            str = textBox1.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = str + button10.Text;
            str = textBox1.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = str.Remove(str.Length - 1);
            str = textBox1.Text;
           
        }

        private void button14_Click(object sender, EventArgs e)
        {

            textBox1.Text = str + button14.Text;
            str = textBox1.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (str.Length<11)
            {
                MessageBox.Show("Неверный номер телефона");
            }
            else
            MessageBox.Show("Вызов абонента:" + str + "......");
        }
    }
}
