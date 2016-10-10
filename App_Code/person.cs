using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using PARK;

public class person
{
    
    public String username { get; set; }
    public List<person> getpersonbylevel(int radiobtnvalue,int ttid)
    {
        Connect connect;
        Connect.ConnectPark();
        string q = "Select username from user where sector_id=@sectorid && ttid!=@ttid";
        string[] s = { "@sectorid","@ttid" };
        connect = new Connect(q, s, radiobtnvalue,ttid);
        //string constr = ConfigurationManager.ConnectionStrings["Park"].ConnectionString;
        //MySqlConnection con = new MySqlConnection(constr);
        //con.Open();
        //string query1 = "Select username from user where sector_id=@sectorid && ttid!=@ttid";
        //MySqlCommand com = new MySqlCommand(query1, con);
        //com.Parameters.AddWithValue("@sectorid", radiobtnvalue);
        //com.Parameters.AddWithValue("@ttid", ttid);
        //DataSet dst = new DataSet();
        //MySqlDataAdapter sda = new MySqlDataAdapter(com);
        //sda.Fill(dst);
        List<person> lst_person = new List<person>();

        foreach (DataRow row in connect.ds.Tables[0].Rows)
        {
            
            person person = new person();
            string username = Convert.ToString(row["username"]);
            
            person.username = username;
            lst_person.Add(person);

        }
       
        return lst_person;
    }
    public static int getparkingownerid(string name_owner)
    {
        Connect connect;
        Connect.ConnectPark();
        string insert = "Select ttid from user where username=@name";
        string[] s = { "@name" };
        connect = new Connect(insert, s, name_owner);
        int ttid = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);
        return ttid;
    }
}