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
    public partial class Form2 : Form
    {
        DBSelector dB = new DBSelector();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Person> list = dB.SelectAll();
            //DataSet ds = new DataSet();
            DataTable table = new DataTable();
            DataColumn name = new DataColumn("Name");
            DataColumn age = new DataColumn("Age");
            
            table.Columns.Add(name);
            table.Columns.Add(age);

            DataRow row;
            for(int i =0; i < 10; i++)
            {
                row = table.NewRow();
                row["Name"] = " ";
                table.Rows.Add(row);
            }
             
            int j = 0;
            foreach(var t in list)
            {
                table.Rows[j][name] = t.name;
                table.Rows[j][age] = t.age;
                ++j;
            }
            dataGridView1.DataSource = table;

        }
         
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
