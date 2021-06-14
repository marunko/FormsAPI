using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAPI
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration f2 = new Registration(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 
            string name = textBox1.Text;
            string password = textBox2.Text;
            DBInserts dB = new DBInserts();
            if (dB.LogIn(name, password))
            {
                MessageBox.Show("Good");

                Application.Restart();
                this.Close();

            }
            else MessageBox.Show("Something wrong");
        }
    }
}
