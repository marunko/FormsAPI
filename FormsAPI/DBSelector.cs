using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FormsAPI
{
    class DBSelector
    {

        string connectionString = "Server=localhost;Database=office;Trusted_Connection=True;";
        public List<Person> SelectAll()
        {
            List<Person> ts = new List<Person>();
            string query = "Select name, age from users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    object name = reader.GetValue(0);
                    object age = reader.GetValue(1);
                    Person p = new Person((string)name, (int)age);
                    ts.Add(p);
                }
            }

            return ts;
        }

        public string[] SelectAllNames()
        {
            string[] resuslt = new string[databaseSize()];
            string query = "Select name from users order by name";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader reader = comm.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    resuslt[i++] = reader.GetString(0);
                }
            }
            return resuslt;
        }
        public List<Person> SelectByAge()
        {
            List<Person> ts = new List<Person>();
            string query = "select name, age from users where age > 18 order by age";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, con);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        object name = reader.GetValue(0);
                        object age = reader.GetValue(1);
                        Person p = new Person((string)name, (int)age);
                        ts.Add(p);
                    }
                }
            }
            catch(SqlException e) { Console.WriteLine(e.Message); }
            return ts;
        }

        private int databaseSize()
        {
            int n = 0;
            string query = "Select count(*) from users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while(reader.Read()) n = (int)reader.GetValue(0);
            }
            return n;
        }
        //public int FindName()
         
    }
}
