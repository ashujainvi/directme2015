using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using PARK;
using System.Configuration;


public class user_parking_view
{
   
   public int parking_id { get; set; }
   public string username { get; set; }
   public int index { get; set; }
   public int userid { get; set; }
   public int carid { get; set; }
   
    public List<user_parking_view> GetUsersOnMyParking(int id)
    {
        Connect connect;
        Connect.ConnectPark();
        string insert2 = "Select parking_id from user_parking where user_id=@id";
        string[] s2 = { "@id" };
        connect = new Connect(insert2, s2, id);
        
        List<user_parking_view> lst_user = new List<user_parking_view>();
        index = 0;
        foreach (DataRow row in connect.ds.Tables[0].Rows)
        {
            
            user_parking_view user = new user_parking_view();
            int parkingid = Convert.ToInt32(row["parking_id"]);
            string insert3 = "Select user_id from garage where parking_id=@parkingid && status=0";
            string[] s3 = { "@parkingid" };
            connect = new Connect(insert3, s3, parkingid);
            if(connect.ds.Tables[0].Rows.Count == 1)

            {
                index = index + 1;
                int userid = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);
                string insert4 = "Select username from user where ttid=@ttid";
                string[] s4 = { "@ttid" };
                connect = new Connect(insert4, s4, userid);
                
                user.userid = userid;
                user.username = connect.ds.Tables[0].Rows[0][0].ToString();
                user.parking_id = parkingid;
                user.index = index;
                lst_user.Add(user);
            }
                else
                continue;
           
            //if (userid == 0)
            //{
            //}
        }
        
        return lst_user;
    }
    public List<user_parking_view> MyCarsParked(int ttid)
    {
        Connect connect;
        Connect.ConnectPark();
        string insert2 = "Select car_id from garage where user_id=@id && status=0 && parking_id !=0";
        string[] s2 = { "@id" };
        connect = new Connect(insert2, s2, ttid);

        List<user_parking_view> lst_user = new List<user_parking_view>();
        index = 0;
        foreach (DataRow row in connect.ds.Tables[0].Rows)
        {
            index = index + 1;
            user_parking_view user = new user_parking_view();
            int carid = Convert.ToInt32(row["car_id"]);
            string insert3 = "Select parking_id from garage where car_id=@carid && user_id=@user && status=0";
            string[] s3 = { "@carid", "@user" };
            connect = new Connect(insert3, s3, carid,ttid);
            int parkingid1 =Convert.ToInt32(connect.executescalar());

            string insert4 = "Select user_id from user_parking where parking_id=@p_id";
            string[] s4 = { "@p_id" };
            connect = new Connect(insert4, s4, parkingid1);
            if (connect.ds.Tables[0].Rows.Count > 0)
            {
                user.userid = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);
            }
            
            string query = "select private from parking where Id=@id";
            string[] q = { "@id" };
            connect = new Connect(query, q, parkingid1);
            bool public1=Convert.ToBoolean(connect.ds.Tables[0].Rows[0][0]);

            string insert5 = "Select username from user where ttid=@tid";
            string[] s5 = { "@tid" };
            connect = new Connect(insert5, s5, user.userid);
            if (parkingid1 == 0)
            {
            }
            else
                if(public1 == false)
                {
                    user.username="Public lane";
                }
                else
                    user.username = Convert.ToString(connect.ds.Tables[0].Rows[0][0]);
            user.index = index;
            user.carid = carid;
            user.parking_id = parkingid1;

            lst_user.Add(user);

        }

        return lst_user;
    }
    //public void RemoveParkedCar(int ttid, int carid)
    //{
    //    Connect connect;
    //    Connect.ConnectPark();
        
    //    string q1 = "Select parking_id from garage where user_id=@u_id && car_id=@carid && status=0";
    //    string[] s1 = { "@u_id", "@carid" };
    //    connect = new Connect(q1, s1, ttid, carid);
    //    int parking_id = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);
    //    User u = new User();
    //    int revenue=u.GetRevenueFromPrivateLanes(ttid, parking_id);
    //    string q = "update user set cash=cash+@rev where ttid=@ttid";
    //    string[] s2 = {"@rev","@ttid" };
    //    connect = new Connect(q,s2,revenue,ttid);
    //    string query = "Update garage set parking_id=0 where user_id=@u_id && car_id=@carid && status=0";
    //    string[] s = {"@u_id","@carid"};
    //    connect = new Connect(query, s, ttid, carid);
       
    //}
}