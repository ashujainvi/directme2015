using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MySql.Data.MySqlClient;

namespace PARK
{
    /// <summary>
    /// Connect class is used to communicate with the database.
    /// </summary>
    public class Connect
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter ad;
        public static string connectionString;
        public int lastId;
        public DataSet ds = new DataSet();
        public Connect()
        {

            con = new MySqlConnection(connectionString);
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        public Connect(string q)
        {

            con = new MySqlConnection(connectionString);
            cmd = new MySqlCommand(q, con);
            if (q[0] == 's' || q[0] == 'S')
            {
                filldata();
            }
            else
            {
                executenonquery();
            }

        }
       
        public Connect(string q, string[] s, params object[] v)
        {

            con = new MySqlConnection(connectionString);
            cmd = new MySqlCommand(q, con);
            AddParameters(s, v);
            if (q[0] == 's' || q[0] == 'S')
            {
                filldata();
            }
            else
            {
                if (cmd.CommandText[0] == 'i' || cmd.CommandText[0] == 'I')
                {
                    cmd.CommandText += "; SELECT Last_Insert_Id(); ";
                    lastId = executescalar();
                }
                else
                {
                    executenonquery();
                }
            }

        }
        public string executescalar1()
        {
            string name;
            con.Open();
            name= Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return name;
        }
        

        public int executescalar()
        {
            int ID = -1;
            con.Open();
             ID = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return ID;
        }

        public void executenonquery()
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AddParameters(string[] s, params object[] v) //params object[] gives us variable no. of parameters
        {
            for (int i = 0; i < s.Length; i++)
                cmd.Parameters.AddWithValue(s[i], v[i]);
        }
        public void filldata()
        {
            ad = new MySqlDataAdapter();
            ad.SelectCommand = cmd;
            ad.Fill(ds);
        }
        
        
        
        public static void ConnectPark()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Park"].ToString();
        }

        public static void ConnectTT()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TT"].ToString();
        }
    }
}
