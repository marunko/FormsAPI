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
    public partial class Articles : Form
    {
        public Articles()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
        }
        // Find article
        private void button3_Click(object sender, EventArgs e)
        {
            // Find
            ArticlesCFUD art = new ArticlesCFUD();
            DataTable table = tableSet();
            table = art.Find(textBox1.Text).Tables[0];
            dataGridView1.DataSource = table;
        }

        private DataTable tableSet()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] {new DataColumn("Id"), 
            new DataColumn("Title"), new DataColumn("Body"), new DataColumn("Author"), 
            new DataColumn("Delete"), new DataColumn("Update") });
             
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show All
            ArticlesCFUD art = new ArticlesCFUD();
            DataTable table = tableSet();
            table = art.ShowAll_Articles().Tables[0];
            dataGridView1.DataSource = table;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Write new 
            new WriteArticle().Show();

        }
        // Grid click 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string title = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string body = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if(body!=null || body != "")
                MessageBox.Show(body, title);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArticlesCFUD art = new ArticlesCFUD();
            DataTable table = tableSet();
            table = art.myArticles().Tables[0];
            dataGridView1.DataSource = table;
        }
    }
}
