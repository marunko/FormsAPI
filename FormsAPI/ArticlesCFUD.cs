using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace FormsAPI
{
    class ArticlesCFUD : CFUD
    {
        string database = "Server=localhost;Database=office;Trusted_Connection=True;";

        public bool Create(string title, string body)
        {

            string query = "Insert into articles (Title, Body, UserId) values (@title, @body, @UserId)";
            int userId = Take_user_Id(@"D:\test\session.dat"); if (userId == 0) return false;
            SqlParameter titleP = new SqlParameter("@title",title);
            SqlParameter bodyP = new SqlParameter("@body",body);
            SqlParameter userIdP = new SqlParameter("@userId", userId);

            SqlConnection conn = new SqlConnection(database);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(titleP);
                command.Parameters.Add(bodyP);
                command.Parameters.Add(userIdP);

                command.ExecuteNonQuery();
                return true;
            }
            catch(SqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public int Take_user_Id(string path)
        {
            int n = 0;
            using(BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                n = br.ReadInt32();
            }
            return n;
        }
        //Find 
        public DataSet Find(string input)
        {
            
            string query = $"select articles.id, title, body, users.name as author from articles join users on users.id = articles.userId where title like '{input}%';";
            DataSet ds = queriesAdapter(query);
            if (ds != null) return ds;
            else return null;
        }

        //Update 
        public bool Update()
        {
            return false;
        }

        // Delete
        public bool Delete()
        {
            return false;
        }

        // ALL ARTICLES
        public DataSet ShowAll_Articles()
        {
            string query = $"select articles.id, title, body, users.name as author from articles join users on users.id = articles.userId order by author";
            DataSet ds = queriesAdapter(query);
            if (ds != null) return ds;
            else return null;

        }
        // My Articles
        public DataSet myArticles()
        {
            
            int userId = new DBInserts().UserId(); if (userId == 0) MessageBox.Show("Log in to see your articles");
            string query = $"select articles.id, title, body, users.name as author from articles join users on users.id = articles.userId where userId = {userId};";
            DataSet ds = queriesAdapter(query);
            if (ds != null) return ds;
            else return null;
             
        }
        private DataSet queriesAdapter(string query)
        {
            SqlConnection connection = new SqlConnection(database);
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
         
    }
}
