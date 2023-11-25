using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_lab2.Models
{
    public class Triangle
    {
        private static string server = "localhost";
        private static string database = "Trade";
        private static string username = "root";
        private static string password = "";
        private static string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password;
        public static MySqlDataReader? all()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constring);
                con.Open();
                string query = "SELECT * FROM Triangle";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch
            {
                return null;
            }
        }
        public static MySqlDataReader? findBySides(string sideA, string sideB, string sideC)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constring);
                con.Open();
                string query = $"SELECT * FROM Triangle WHERE sideA = '{sideA}' AND sideB = '{sideB}' AND sideC = '{sideC}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    con.Close();
                    return reader;
                }
                else
                {
                    con.Close();
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public static bool deleteBySides(string sideA, string sideB, string sideC)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constring);
                con.Open();
                string query = $"DELETE FROM Triangle WHERE sideA = '{sideA}' AND sideB = '{sideB}' AND sideC = '{sideC}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int rowCount = cmd.ExecuteNonQuery();
                if (rowCount > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static MySqlDataReader? add(string sideA, string sideB, string sideC, string type = "", string error = "")
        {
            try
            {
                if(findBySides(sideA, sideB, sideC) != null ? true : false)
                {
                    return findBySides(sideA, sideB, sideC);
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(constring);
                    con.Open();
                    string query;
                    if (error != null)
                    {
                        query = $"INSERT INTO Triangle (sideA, sideB, sideC, type, message_error) VALUES ('{sideA}', '{sideB}', '{sideC}', '{type}', '')";
                    }
                    else
                    {
                        query = $"INSERT INTO Triangle (sideA, sideB, sideC, type, message_error) VALUES ('{sideA}', '{sideB}', '{sideC}', '', '{error}')";
                    }
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    int rowCount = cmd.ExecuteNonQuery();
                    if (rowCount > 0)
                    {
                        return findBySides(sideA, sideB, sideC);
                    }
                    return null;
                }
                
            }
            catch
            {
                return null;
            }
        }
        public static bool updateBySides(string sideA, string sideB, string sideC, string _sideA, string _sideB, string _sideC)
        {
            try
            {

                MySqlConnection con = new MySqlConnection(constring);
                con.Open();
                string query = $"UPDATE Triangle SET sideA = {_sideA}, sideB = {_sideB}, sideC = {_sideC} WHERE sideA = '{sideA}' AND sideB = '{sideB}' AND sideC = '{sideC}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int rowCount = cmd.ExecuteNonQuery();
                if (rowCount > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
