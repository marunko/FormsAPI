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
    public partial class WriteArticle : Form
    {
        public WriteArticle()
        {
            InitializeComponent();
        }
        // this is title textBox2
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.TextLength > 255) 
            { 
                MessageBox.Show("Title should not exceed length of 255");
                
                textBox2.Text.Remove(255);
            }
        }
        // body textBox1
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Save to DB
            Validator vl = new Validator();
            ArticlesCFUD art = new ArticlesCFUD();
            if (vl.Body(textBox1.Text) && vl.Title(textBox2.Text) )
            {
                bool result = art.Create(textBox2.Text, textBox1.Text);
                if (result) { MessageBox.Show("title where added"); this.Close(); }
                else MessageBox.Show("Not added");
            }
            else { MessageBox.Show("Wrong title or body"); }
        }
    }
}
