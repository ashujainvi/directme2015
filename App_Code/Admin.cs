using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using PARK;

/// <summary>
/// Summary description for Admin
/// </summary>
public class Admin
{

    public Admin()
    {

    }

    public void CarGen(Cars c)
    {

        Connect connect;
        Connect.ConnectPark();
        string insert = "INSERT INTO car(name,value,base_revenue,car_icon,level) values(@name,@cost,@base_revenue,@car_icon,@level)";
        string[] s = { "@name", "@cost", "@base_revenue", "@car_icon", "@level" };
        connect = new Connect(insert, s, c.carname, c.cost, c.base_revenue, c.car_icon, c.level);

    }

    public void Parking_Gen(int x)
    {
        int i = 0;
        Connect connect;
        Connect.ConnectPark();
        string insert = "INSERT INTO parking(private,sector_id,allowed) values(0,@sector,0)";
        string[] s = { "@sector" };

        for (i = 0; i < x; i++)
        {
            connect = new Connect(insert, s, 1);
        }
        for (i = 0; i < x; i++)
        {
            connect = new Connect(insert, s, 2);
        }
        for (i = 0; i < x; i++)
        {
            connect = new Connect(insert, s, 3);
        }
        for (i = 0; i < x; i++)
        {
            connect = new Connect(insert, s, 4);
        }
    }

    /// <summary>
    /// Bot removes all cars from public lanes and fines user
    /// If bots hits car for more than 3 times, it gets confesticated
    /// </summary>
    /// 
    public void Send_Bot()   //Testing Remaining
    {

        Connect connect = new Connect();
        Connect.ConnectPark();
        string select = "SELECT count(id) FROM parking WHERE private=0";
        connect = new Connect(select);
        int count = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);  // No of public parkings
        int parking_id = 0;

        Connect connect01 = new Connect();
        Connect.ConnectPark();
        string select01 = "SELECT id FROM parking WHERE private=0";    // Pick up ids of public parking
        connect01 = new Connect(select01);
        int hits = 0, car_id = 0, user_id = 0;


        for (int i = 0; i < count; i++)
        {
            parking_id = Convert.ToInt32(connect01.ds.Tables[0].Rows[i][0]);     // Assigning id of ith parking 

            Connect connect1 = new Connect();

            string query = "Select count(parking_id) from  garage where parking_id=@parking_id && status=0"; //Checks whether that parking_id has any car or not
            string[] s1 = { "@parking_id" };
            connect1 = new Connect(query, s1, parking_id);
            int count1 = Convert.ToInt32(connect1.ds.Tables[0].Rows[0][0]);

            if (count1 == 1)                                                                     // If parking has car
            {
                string select1 = "SELECT hits,car_id,user_id from garage WHERE parking_id=@parking_id && status=0";  //Selects hits,car_id and user_id from gargae table for that parking
                string[] s = { "@parking_id" };
                connect1 = new Connect(select1, s, parking_id);

                hits = Convert.ToInt32(connect1.ds.Tables[0].Rows[0][0]);
                car_id = Convert.ToInt32(connect1.ds.Tables[0].Rows[0][1]);
                user_id = Convert.ToInt32(connect1.ds.Tables[0].Rows[0][2]);

                if (hits < 2)                                                                     // If hits is less than 2
                {
                    Connect connect2 = new Connect();
                    string update = "UPDATE garage SET parking_id=0, hits=@hits WHERE parking_id=@parking_id";
                    string[] s2 = {  "@hits", "@parking_id" };
                    connect2 = new Connect(update, s2, (hits + 1), parking_id);
                    User u = new User();
                    int fine = Convert.ToInt32((u.GetRevenueFromPublicLanes(user_id,parking_id)) * 0.07);        // Generate fine

                    Connect connect3 = new Connect();
                    string update1 = "UPDATE user SET cash=cash-@fine WHERE ttid=@user_id";        // Updates fine
                    string[] s3 = { "@fine", "@user_id" };
                    connect3 = new Connect(update1, s3, fine, user_id);

                    //Connect connect4 = new Connect();
                    //string insert = "INSERT into parking_log(user_id,parking_owner_id,timestamp,is_successful) values(@user_id,@parking_id,@time_stamp,@is_successful)";
                    //string[] s4 = { "@user_id", "@parking_id", "@time_stamp", "@is_successful" };
                    //connect4 = new Connect(insert, s4, user_id, 0, (DateTime.Now), 0);
                }

                else
                {

                    Connect connect2 = new Connect();
                    string update = "UPDATE garage SET parking_id=0, hits=@hits, status=@status WHERE parking_id=@parking_id";
                    string[] s2 = { "@hits", "@status", "@parking_id" };
                    connect2 = new Connect(update, s2, (hits + 1), 2, parking_id);              // Set status = 2 (confesticated)
                    
                    User u = new User();
                    int fine = Convert.ToInt32((u.GetRevenueFromPublicLanes(user_id, parking_id)) * 0.07);        // Generate fine

                    Connect connect3 = new Connect();
                    string update1 = "UPDATE user SET cash=cash-@fine WHERE ttid=@user_id";        // Updates cash by debbting fine
                    string[] s3 = { "@fine", "@user_id" };
                    connect3 = new Connect(update1, s3, fine, user_id);

                    //Connect connect4 = new Connect();
                    //string insert = "INSERT into parking_log(user_id,parking_owner_id,timestamp,is_successful) values(@user_id,@parking_id,@time_stamp,@is_successful)";
                    //string[] s4 = { "@user_id", "@parking_id", "@time_stamp", "@is_successful" };
                    //connect4 = new Connect(insert, s4, user_id, 0, (DateTime.Now), 0);
                }
            }


        }
    }
}