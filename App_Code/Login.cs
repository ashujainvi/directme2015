using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using PARK;


public class Login
{
    public int message;
    public string pass { get; set; }
    public int user(string ttid, string password)
    {

        Connect connect;
        Connect.ConnectPark();
        string insert = " select count(ttid) from user where ttid =@ttid";
        string[] s = { "@ttid" };
        connect = new Connect(insert, s, ttid);
        int countuser = Convert.ToInt32(connect.executescalar());
        if (countuser == 1)
        {
            //Connect connect1;
            //Connect.ConnectPark();

            string insert1 = " select password from user where ttid =@ttid";
            string[] s1 = { "@ttid" };
            connect = new Connect(insert1, s1, ttid);
            pass = Convert.ToString(connect.executescalar1());
            if (pass == password)
            {
                //Connect connect2;
                //Connect.ConnectPark();
                string insert4 = "select confirmed from user where ttid=@ttid";
                string[] s4 = { "@ttid" };
                connect = new Connect(insert4, s4, ttid);
                int confirmation = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);

                if (confirmation == 1)

                    return 0;
                else
                    return 1;
            }
            else
                return 4;
        }
        else
        {
            Connect connect1;
            Connect.ConnectTT();
            string insert1 = "select count(TTID) from participants where TTID=@ttid";
            string[] s1 = { "@ttid" };
            connect1 = new Connect(insert1, s1, ttid);
            int countparticipants = Convert.ToInt32(connect1.executescalar());

            if (countparticipants == 0)
                return 2;
            else
            {
                Connect.ConnectTT();
                string insert3 = " select Password from participants where TTID =@ttid";
                string[] s3 = { "@ttid" };
                connect1 = new Connect(insert3, s3, ttid);
                string passw = Convert.ToString(connect1.executescalar1());
                if (passw == password)
                {
                    string insert2 = "SELECT Name,password FROM participants WHERE TTid=@ttid";
                    string[] s2 = { "@ttid" };
                    connect1 = new Connect(insert2, s2, ttid);
                    string name = Convert.ToString(connect1.ds.Tables[0].Rows[0][0]);
                    string pass = Convert.ToString(connect1.ds.Tables[0].Rows[0][1]);
                    Connect.ConnectPark();
                    string insert4 = "INSERT INTO user(ttid,username,password) values(@ttid,@name,@pass) ";
                    string[] s4 = { "@ttid", "@name", "@pass" };
                    connect = new Connect(insert4, s4, ttid, name, pass);
                    return 3;

                }
                else
                    return 5;
            }

        }
    }
}