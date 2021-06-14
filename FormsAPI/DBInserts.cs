using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using System.IO;

namespace FormsAPI
{
    class DBInserts
    {
        // One indication of path for all -->>
        public string path = @"C:\Users\marun\source\repos\FormsAPI\FormsAPI\Files\session.dat"; // <<--

        string connectionString = "Server=localhost;Database=office;Trusted_Connection=True;";
        public bool LogIn(string name, string password)
        {
            password = HashingPass(password);
            string query = $"select id,name, age from users where LOWER(name) like LOWER('{name}') and password like '{password}'";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader read = com.ExecuteReader();
                // save user to session File or DataBase
                int age = 0, id =0;
                while (read.Read())
                {
                    id = read.GetInt32(0);
                    name = read.GetString(1);
                    age = (int)read.GetValue(2);
                }
                if (id == 0) return false;
                if (SessionStore(id, path, name, age))
                {
                    Console.WriteLine("done");
                    return true;
                }

            }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        public void LogOut(string path)
        {

            // Delete user from Cokies/Session
            FileInfo fileInfo = new FileInfo(path);
            if(fileInfo.Exists)
            {
                fileInfo.Delete(); // Remove file 
            }

        }
        //Delete 
        //Update
        public bool Register(string name, int age, string password)
        {

            string hashPass = HashingPass(password);
            string sqlExpression = "INSERT INTO Users (Name, Age, Password) VALUES (@name, @age, @hashPass)";
            SqlParameter sName = new SqlParameter("@name", name);
            SqlParameter sAge = new SqlParameter("@age", age);
            SqlParameter sPass = new SqlParameter("@hashPass", hashPass);

            SqlConnection con = new SqlConnection(connectionString);
            if (CheckName(name))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, con);
                    command.Parameters.Add(sName);
                    command.Parameters.Add(sAge);
                    command.Parameters.Add(sPass);

                    command.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.Write(ex.Message);
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
            Console.WriteLine("The user already exist");
            return false;
        }

        // Without Sult
        private string HashingPass(string pass)
        {
            SHA256 sh = SHA256.Create();
            byte[] bt1 = sh.ComputeHash(Encoding.UTF8.GetBytes(pass));
             
            StringBuilder str = new StringBuilder();
            for(int i = 0; i <bt1.Length; i++)
            {
                str.Append(bt1[i].ToString("x2"));
            }
            pass = str.ToString();
            return pass;
        }
         
        private bool CheckName(string name)
        {
            string query = "select name from users";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (name == reader.GetString(0))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool SessionStore(int id, string path, string name, int age)
        {
            try
            {
                using (BinaryWriter bn = new BinaryWriter(File.Open(path, FileMode.CreateNew)))
                {
                    bn.Write(id);
                    bn.Write(name);
                    bn.Write(age);
                    bn.Write(DateTime.Today.ToString());
                     
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
                 
            }
        }
        public int UserId()
        {
            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    return br.ReadInt32();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }

        }

    }
}
