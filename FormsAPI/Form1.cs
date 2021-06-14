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

namespace FormsAPI
{
    public partial class Form1 : Form
    {
        Button button2;
        public Form1()
        {
            InitializeComponent();
            //
             
        }
        /*
         F2.show all users, articles ect
         F3.registration form 
         F4.Find article by tag name 
         F5. Write and upload article (save user id from session file)
         */
        private void button1_Click(object sender, EventArgs e)
        {
            // To DataBase 
            new Form2().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //new Form2().Show();
            Person p = checkFile();
            if (p != null)
            { 
                CreateMyLabel(p.name);
                InitButton();
            }  
            else
            {
                InitializeMyButton();
            }
            // Add current tim
        }
        private void InitializeMyButton()
        {
            // Create and initialize a Button.
            button2 = new Button();

            // Set the button to return a value of OK when clicked.
            button2.DialogResult = DialogResult.OK;
            button2.Location = new Point(10, 10);
            button2.Size = new Size(100, 30);
            button2.BackColor = Color.BlueViolet;
            button2.Text = "Log In";
            // Add the button to the form.
            Controls.Add(button2);
            button2.Click += new EventHandler(button2_Click);
             
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LogIn f2 = new LogIn();
            f2.ShowDialog();

        }
        
        private void InitButton()
        {
            Button logout = new Button();

            logout.Location = new Point(10, 25);
            logout.Size = new Size(100, 30);
            logout.BackColor = Color.HotPink;
            logout.Text = "Log Out";
            // Add the button to the form.
            Controls.Add(logout);
            logout.Click += new EventHandler(logout_Click);
        }
        private void logout_Click(object sender, EventArgs e)
        {
            DBInserts db = new DBInserts();
            db.LogOut(db.path); // write path to file
            Application.Restart();
        }
        private Person checkFile()
        {
            Person p = new Person();
            try
            {
                // change file location
                using (BinaryReader br = new BinaryReader(File.Open(new DBInserts().path, FileMode.Open)))
                {
                    // 
                    p.id = br.ReadInt32();
                    p.name = br.ReadString();
                    p.age = br.ReadInt32();
                }
                
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
            return p;
        }
        private void CreateMyLabel(string name)
        {
            // Create an instance of a Label.
            Label label1 = new Label();

            // Align the image to the top left corner.
            label1.ImageAlign = ContentAlignment.TopLeft;

         
            // Set the text of the control and specify a mnemonic character.
            label1.Text = "Hello:" + name;

            /* Set the size of the control based on the PreferredHeight and PreferredWidth values. */
            label1.Size = new Size(100, 20);
            label1.Location = new Point(10,5);
            label1.ForeColor = Color.Black;
            //...Code to add the control to the form...
            this.Controls.Add(label1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new Articles().Show();
        }
    }
}
