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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validator vl = new Validator();

            if (vl.Name(name.Text) == 1)
            {
                if (vl.age(Int32.Parse(age.Text)))
                {
                    if (vl.Password(pass1.Text) == 1)
                    {
                        if (pass1.Text == pass2.Text)
                        {
                            DBInserts db = new DBInserts();

                            if (db.Register(name.Text, Int32.Parse(age.Text), pass1.Text))
                            {
                                MessageBox.Show("User where added");
                                this.Close();
                            }
                            else
                            {
                                var result = MessageBox.Show("Some thing gone wrong. \n Press Yes to repeate ot No to exit", "...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.No) this.Close();

                            }
                        }
                        else MessageBox.Show("Repeat password correctly");
                    }
                    else MessageBox.Show("Wrong password");
                }
                else MessageBox.Show("Wrong age");
            }
            else MessageBox.Show("Wrong name");
        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void age_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
