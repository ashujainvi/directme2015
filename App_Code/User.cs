using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using PARK;
using System.Timers;



public class User
{


    
    
     public int ttid{ get; set; }
     public string username{ get; set; }
     public string password { get; set; }
     public int contactNo { get; set; }
     public int cash { get; set; }
     public int sectorId { get; set; }
     public int level { get; set; }
     public bool confirmed { get; set; }
     public int networth { get; set; }

    public User()
    {
        cash = 100000;
        sectorId = 0;
        level = 0;
        confirmed = true; 
    }


  

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool ValidateUser(string userName, string password)
    {

        //const double time = 2 * 1000;
        //Timer checkForTime = new Timer(time);
        
        Connect.ConnectPark();
        string query = "select * from user where email=@email and password = @password";
        string[] param = {"@email","@password" };
        Connect con = new Connect(query,param,userName,password);

        if (con.ds.Tables[0].Rows.Count != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public int getTTId(string username)
    {
        Connect.ConnectPark();
        string query = "select ttid from user where email=@email";
        string[] param = { "@email" };
        Connect con = new Connect(query,param,username);

        return Convert.ToInt32(con.ds.Tables[0].Rows[0]["TTID"]);
    }

    public string getName(int ttid)
    {
        Connect.ConnectPark();
        string query = "select username from user where ttid=@ttid";
        string[] param = { "@ttid" };
        Connect con = new Connect(query, param, ttid);

        return con.ds.Tables[0].Rows[0][0].ToString();
    }



    public bool IsUserValid(int ttid)
    {
        Connect.ConnectPark();
        string insert4 = "select confirmed from user where ttid=@ttid";
        string[] s4 = { "@ttid" };
        Connect  con= new Connect(insert4, s4, ttid);
        int confirmation = Convert.ToInt32(con.ds.Tables[0].Rows[0][0]);

        if (confirmation == 1)

            return true;
        else
            return false;
    }

    public bool IsSectorSelected(int ttid)
    {
       
        Connect.ConnectPark();
        string insert4 = "select sector_id from user where ttid=@ttid";
        string[] s4 = { "@ttid" };
        Connect  con= new Connect(insert4, s4, ttid);
      
            int sectorid = Convert.ToInt32(con.ds.Tables[0].Rows[0][0]);
       
       
        if (sectorid != 0)

            return true;
        else
            return false;
        }



    //public void SelectSector(int ttid, int selected_sector)
    //{

    //    Connect connect;
    //    Connect.ConnectPark();
    //    string update = "UPDATE user SET sector_id=@selected_sector WHERE ttid=@user_id";
    //    string[] s = { "@selected_sector", "@user_id" };
    //    connect = new Connect(update, s, selected_sector, ttid);
    //    Parking park = new Parking();
    //    park.AssignParking(ttid, selected_sector);
    //}

    public int GenerateRandomCode()
    {
        Random rand = new Random(5760);
       // char a = (char)new Random().Next(26);
        return rand.Next();
       
    }


    /// <summary>
    /// /Selects sector for user.
    /// </summary>
    /// <param name="ttid">TT id of player, passed from session</param>
    /// <param name="selected_sector">Gives value of sector selected(1-A,2-B..).</param>
    public void SelectSector(int ttid, int selected_sector)
    {
        
        Connect connect;
        Connect.ConnectPark();
        string update = "UPDATE user SET sector_id=@selected_sector WHERE ttid=@user_id";
        string[] s = { "@selected_sector", "@user_id" };
        connect = new Connect(update, s, selected_sector, ttid);
        Parking park = new Parking();
        park.AssignParking(ttid, selected_sector);
    }


    public int GetCashWithUser(int ttid)
    {
        string str = "SELECT cash FROM user WHERE ttid=@ttid";
        string[] s1 = { "@ttid" };
        Connect con = new Connect(str, s1, ttid);
        return Convert.ToInt32(con.ds.Tables[0].Rows[0][0]);
       
    }


    /// <summary>
    /// User buys a car
    /// Changes
    /// =======
    /// user table -> cash, level
    /// garage table -> status = 0, parking = 0
    /// 
    /// Returns 0 is buyi
    /// </summary>
    /// <param name="ttid">User's TT is(passed from session)</param>
    /// <param name="carid">Obtains id of car from radio button</param>
    public void BuyCar(int ttid, int carid)
    {

        Connect connect;
        Connect.ConnectPark();
       
            string insert = "Insert into garage(user_id,car_id,parking_id,time_stamp,status) values(@ttid,@car,@parking,@time,@car_status)";
            string[] s3 = { "@ttid", "@car", "@parking", "@time", "@car_status" };
            connect = new Connect(insert, s3, ttid, carid, '0', DateTime.Now, 0);

        }


    public void UpdateCash(int ttid,int newcash)
    {
        Connect connect;
        Connect.ConnectPark();
        string str = "UPDATE user SET cash=@nw_cash  WHERE ttid=@uid";
        string[] s2 = { "@nw_cash", "@uid" };
     

        // Inserts new column in user garage table
        connect = new Connect(str,s2, newcash, ttid);
    }

    public int RemoveParkedCar(int ttid, int carid)
    {
        Connect connect;
        Connect.ConnectPark();

        string q1 = "Select parking_id from garage where user_id=@u_id && car_id=@carid && status=0";
        string[] s1 = { "@u_id", "@carid" };
        connect = new Connect(q1, s1, ttid, carid);
        int parking_id = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);
       
        User u = new User();
        int revenue = u.GetRevenueFromPrivateLanes(ttid, parking_id);
        new User().UpdateCash(ttid, new User().GetCashWithUser(ttid) + revenue);

        //string q = "update user set cash=cash+@rev where ttid=@ttid";
        //string[] s2 = { "@rev", "@ttid" };
        //connect = new Connect(q, s2, revenue, ttid);


        string query = "Update garage set parking_id=0 where user_id=@u_id && car_id=@carid && status=0";
        string[] s = { "@u_id", "@carid" };
        connect = new Connect(query, s, ttid, carid);

        string selectid = "select id from parking_log where is_successful=0 && user_id=@ownerid and parking_owner_id = @parkingid ORDER BY timestamp DESC";
        string[] s5 = { "ownerid", "@parkingid" };
        connect = new Connect(selectid, s5, ttid, parking_id);
        int logid = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);

        Connect connect4 = new Connect();
        string insert = "update parking_log set is_successful = 1 where id = @id";
        string[] s4 = { "@id" };
        connect4 = new Connect(insert, s4, logid);

        string q = "insert into revenuelog(logid,revenue) values(@logid,@revenue)";
        string[] param = { "@logid", "@revenue" };
        connect = new Connect(q, param, logid, revenue);

        new Parking().ChangeLaneStatusToVacant(parking_id);
        return logid;

    }



    /// <summary>
    /// User picks up his car from public lanes.
    /// </summary>
    /// <param name="ttid">User's TT is(passed from session)</param>
    /// <param name="parkingid">Id of public parking </param>
    public void pick_from_public(int ttid, int parkingid)
    {

        Connect connect;
        Connect.ConnectPark();
      //  int cash = 0;
        string update1 = "SELECT car_id FROM garage WHERE user_id=@user_id AND parking_id=@park_id";
        string[] s1 = { "@user_id", "@park_id" };
        connect = new Connect(update1, s1, ttid, parkingid);
        int car_id = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);   //Car_id parked at that parking

        int rev = GetRevenueFromPublicLanes(ttid, parkingid);                          //Revenue generated for that car_id

        //Selects cash from user table for that id
        //string select = "SELECT cash FROM user WHERE ttid=@user_id";
        //string[] s4 = { "@user_id" };
        //connect = new Connect(select, s4, ttid);
        //cash = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);
        int cash = new User().GetCashWithUser(ttid);
        cash = cash + rev;
        new User().UpdateCash(ttid, cash);

        ////Updation in user table cash=cash+rev 
        //string update2 = "UPDATE user SET cash=@cash where ttid=@user_id ";
        //string[] s2 = { "@cash", "@user_id" };
        //connect = new Connect(update2, s2, cash, ttid);

        // Updation in garage table parking =0
        string update3 = "UPDATE garage SET parking_id=0 where parking_id=@park_id";
        string[] s3 = { "@park_id" };
        connect = new Connect(update3, s3, parkingid);



        string selectid = "select id from parking_log where is_successful=0 && user_id=@ownerid and parking_owner_id = @parkingid ORDER BY timestamp DESC";
        string[] s5 = { "ownerid", "@parkingid" };
        connect = new Connect(selectid, s5, ttid, parkingid);
        int logid = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);

        Connect connect4 = new Connect();
        string insert = "update parking_log set is_successful = 1 where id = @id";
        string[] s4 = { "@id" };
        connect4 = new Connect(insert, s4, logid);

        new Parking().ChangeLaneStatusToVacant(parkingid);

        string q = "insert into revenuelog(logid,revenue) values(@logid,@revenue)";
        string[] param = { "@logid", "@revenue" };
        connect = new Connect(q, param, logid, rev);

        //Insertion in parking_log table
        //string insert = "INSERT into parking_log (user_id, parking_owner_id,timestamp, is_successful ) values(@user_id,@parking_owner_id,@time_stamp,@is_successful)";
        //string[] s5 = { "@user_id", "@parking_owner_id", "@time_stamp", "@is_successful" };
        //connect = new Connect(insert, s5, ttid, 0, (DateTime.Now), 0);    // parking_owner_id=0(public lane), is_successful=0(unsuccessful parking)
    }


    /// <summary>
    /// Restarts the game if user has no cars left and his/her cash is less than cost of 1st car
    /// </summary>
    /// <param name="ttid">User's TT is(passed from session)</param>
    /// <returns>-1 if game is restarted</returns>
    public int Restart(int ttid) //On Page Load
    {
        Connect connect;
        Connect.ConnectPark();
        string select1 = "SELECT COUNT(car_id) FROM garage where user_id=@user_id && status=0 ";
        string[] s1 = { "@user_id" };
        connect = new Connect(select1, s1, ttid);
        int count = connect.executescalar();

        if (count == 0)
        {
            string select2 = "SELECT cash from user WHERE ttid=@user_id";
            string[] s2 = { "@user_id" };
            connect = new Connect(select2, s2, ttid);
            int cash = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);

            string select3 = "SELECT value from car WHERE id=@id";
            string[] s3 = { "@id" };
            connect = new Connect(select3, s3, 1);
            int cost = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);

            if (cost > cash)
            {
                string update = "UPDATE user SET cash=10000 WHERE ttid=@user_id";
                string[] s4 = { "@user_id" };
                connect = new Connect(update, s4, ttid);
                return -1;
            }
        }

        return 0;
    }

    /// <summary>
    ///  Updates all cars; status of user
    /// </summary>
    /// <param name="ttid">User's TT is(passed from session)</param>
    public void CheckUsers() //On Page Load
    {
        Connect connect01;
        Connect.ConnectPark();
        string select = "SELECT g.time_stamp, g.parking_id,g.user_id FROM garage g, parking p WHERE p.private=1 AND g.parking_id=p.Id AND g.status=0";
        
        connect01 = new Connect(select);
        // DateTime[] dt= null;
        int parking_id = 0;
        ///int i = 0;

        foreach (DataRow row in connect01.ds.Tables[0].Rows)
        {
            // var x = connect.ds.Tables[0].Rows[i][0];
            DateTime dt = Convert.ToDateTime(row[0]);
            int ttid = Convert.ToInt32(row[2]);

            if (((Convert.ToInt32(DateTime.Now.Hour) - Convert.ToInt32(dt.Hour)) >= 1) )
            {

                parking_id = Convert.ToInt32(row[1]);
                User u = new User();
                int rev = u.GetRevenueFromPrivateLanes(ttid, parking_id);

                Connect connect;
                Connect.ConnectPark();

                string selectid = "select id from parking_log where is_successful=0 && user_id=@ownerid and parking_owner_id = @parkingid ORDER BY timestamp DESC";
                string[] s5 = { "ownerid", "@parkingid" };
                connect = new Connect(selectid, s5, ttid, parking_id);
                int logid = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);

                //Insertion in parking_log table
                //string insert = "INSERT into parking_log (user_id, parking_owner_id,timestamp, is_successful ) values(@user_id,@parking_owner_id,@time_stamp,@is_successful)";
                //string[] s5 = { "@user_id", "@parking_owner_id", "@time_stamp", "@is_successful" };
                //connect = new Connect(insert, s5, ttid, parking_id, dt, 1);    // is_successful=1(successful parking)

                //int logid = connect.lastId;
                string update1 = "UPDATE garage SET parking_id=0 WHERE parking_id=@park_id";
                string[] s1 = { "@park_id" };
                connect = new Connect(update1, s1, parking_id);

                Connect connect4 = new Connect();
                string insert = "update parking_log set is_successful = 1 where id = @id)";
                string[] s4 = { "@id" };
                connect4 = new Connect(insert, s4, logid);

                string q = "insert into revenuelog(logid,revenue) values(@logid,@revenue)";
                string[] param = { "@logid", "@revenue" };
                connect = new Connect(q, param, logid,rev);
                //Connect connect1;
                //Connect.ConnectPark();
                //string select3 = "SELECT cash FROM user WHERE ttid=@user_id ";
                //string[] s3 = { "@user_id" };
                //connect1 = new Connect(select3, s3, ttid);
             //   int cash = Convert.ToInt32(connect1.ds.Tables[0].Rows[0][0]);
                int cash = new User().GetCashWithUser(ttid);

                cash = cash + rev;
                new User().UpdateCash(ttid, cash);
                //string update2 = "UPDATE user SET cash=@cash WHERE ttid=@user_id";
                //string[] s4 = { "@cash", "@user_id" };
                //connect1 = new Connect(update2, s4, cash, ttid);
               
            }
        }

    }


    /// <summary>
    /// Updates all log of cars parked on users' lane
    /// </summary>
    /// <param name="ttid">User's TT is(passed from session)</param>
    public void Updations1(int ttid)// On Page Load
    {
        Connect connect1;
        Connect.ConnectPark();
        string query1 = "SELECT g.user_id, g.time_stamp, g.parking_id From user_parking u inner join garage g where u.user_id=@user_id AND u.parking_id=g.parking_id AND g.status=0;";
        string[] s1 = { "@user_id" };
        connect1 = new Connect(query1, s1, ttid);
        int i = 0;

        foreach (DataRow row in connect1.ds.Tables[0].Rows)
        {
            DateTime dt = Convert.ToDateTime(connect1.ds.Tables[0].Rows[i][1]);
            int diff = Convert.ToInt32((DateTime.Now - dt).TotalHours);

            if (diff >= 1)
            {
                string user_id = connect1.ds.Tables[0].Rows[i][0].ToString();
                int parking_id = Convert.ToInt32(connect1.ds.Tables[0].Rows[i][2]);
                Connect connect2;
                Connect.ConnectPark();

                int rev = GetRevenueFromPrivateLanes(ttid, parking_id);
                string query2 = "UPDATE garage SET parking_id=0 WHERE parking_id=@park ";
                string[] s2 = { "@park" };
                connect2 = new Connect(query2, s2, parking_id);


                string query3 = "UPDATE user SET cash=cash+@rev WHERE ttid=@user_id";
                string[] s3 = { "@rev", "@user_id" };
                connect2 = new Connect(query3, s3, rev, user_id);

                //Insertion in parking_log table
                string insert = "INSERT into parking_log (user_id, parking_owner_id,time_stamp, is_successful ) values(@user_id,@parking_owner_id,@time_stamp,@is_successful)";
                string[] s5 = { "@user_id", "@parking_owner_id", "@time_stamp", "@is_successful" };
                connect2 = new Connect(insert, s5, user_id, ttid, dt, 1);    // is_successful=1(successful parking)


            }

        }

    }


    /// <summary>
    /// Generates revenue for public parkings for a particular car
    /// </summary>
    /// <param name="ttid">User's TT is(passed from session)</param>
    /// <param name="car_id">Car id of car for which revenue is generated</param>
    /// <returns></returns>
    public int GetRevenueFromPublicLanes(int ttid, int parking_id)
    {
        Connect connect;
        Connect.ConnectPark();
        int revenue = 0;
       // string type = string.Empty;
   //     double inc = 0;
      //  int level = 0;
     //   double lev_fact = 0;
        //Select time_stamp
        string select1 = "SELECT time_stamp, car_id, class,robo_level FROM garage WHERE user_id=@user_id AND parking_id=@park_id AND status=0";
        string[] s1 = { "@user_id", "@park_id", };
        connect = new Connect(select1, s1, ttid, parking_id);
        DateTime time_stamp = Convert.ToDateTime(connect.ds.Tables[0].Rows[0][0]);
        int car_id = Convert.ToInt32(connect.ds.Tables[0].Rows[0][1]);
       // type = (connect.ds.Tables[0].Rows[0][2]).ToString();
       // level = Convert.ToInt32(connect.ds.Tables[0].Rows[0][3]);

        

        string select2 = "SELECT base_revenue FROM car WHERE Id=@car_id";
        string[] s2 = { "@car_id" };
        connect = new Connect(select2, s2, car_id);
        int base_revenue = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]); // Base Revenue of car from car table


        DateTime time_now = DateTime.Now;
        var time_diff = (time_now - time_stamp).TotalMinutes;                // Time difference (now ~ when car was parked) 
        //if (type == "A")
        //{
        //    inc = 0.1;
        //    lev_fact = inc*level;
        //}
        //else if (type == "B")
        //{
        //    inc = 0.2;
        //    lev_fact = inc * level;
        //}
        //else if (type == "C")
        //{
        //    inc = 0.4;
        //    lev_fact = inc * level;
        //}
        //else if (type == "D")
        //{
        //    inc = 0.6;
        //    lev_fact = inc * level;
        //}
        

        if (time_diff < 30)                                                  // Time Constration 30 minutes
        {
            revenue = Convert.ToInt32(base_revenue * (time_diff/60) * 0.7);       // If time is less than 30, user gets omly 70% of rev gen.
        }

        else
        {
            revenue = Convert.ToInt32(base_revenue *(time_diff/60));            // Full value of cash
        }
        return revenue;                                                     // Returns Cash
    }
    /// <summary>
    /// </summary>
    /// <param name="user_id">owner of the car</param>
    /// <param name="parking_id"></param>
    /// <returns>revenue</returns>
    public int GetRevenueFromPrivateLanes(int user_id, int parking_id)/// Check Function
    {
        Connect connect;
        Connect.ConnectPark();
        int revenue = 0;
        string type = string.Empty;
        //double inc = 0;
       // int level = 0;
      //  double lev_fact = 0;
        //Select time_stamp
        string select1 = "SELECT time_stamp, car_id, class,robo_level FROM garage WHERE user_id=@user_id AND parking_id=@park_id AND status=0";
        string[] s1 = { "@user_id", "@park_id" };
        connect = new Connect(select1, s1, user_id, parking_id);
        DateTime time_stamp = Convert.ToDateTime(connect.ds.Tables[0].Rows[0][0]);
        int car_id = Convert.ToInt32(connect.ds.Tables[0].Rows[0][1]);
        type = (connect.ds.Tables[0].Rows[0][2]).ToString();
       // level = Convert.ToInt32(connect.ds.Tables[0].Rows[0][3]);           // level initialized to 0 when games starts
      
        string select3 = "Select c.base_revenue FROM car c inner join garage g WHERE g.car_id = c.id AND g.parking_id=@parking_id AND g.user_id=@user_id AND g.status=0 ";
        string[] s3 = { "@parking_id", "@user_id" };
        connect = new Connect(select3, s3, parking_id, user_id);
        int base_revenue = Convert.ToInt32(connect.executescalar());     // base_revenue

        string select4 = "SELECT allowed FROM parking WHERE id=@park_id";
        string[] s4 = { "@park_id" };
        connect = new Connect(select4, s4, parking_id);
        bool allow = Convert.ToBoolean(connect.executescalar());           // boolean allowed
        

        DateTime time_now = DateTime.Now;
        var time_diff = (time_now - time_stamp).TotalMinutes;                // Time difference (now ~ when car was parked) 

        //if (type == "A")
        //{
        //    inc = 0.1;
        //    lev_fact = inc * level;
        //}
        //else if (type == "B")
        //{
        //    inc = 0.2;
        //    lev_fact = inc * level;
        //}
        //else if (type == "C")
        //{
        //    inc = 0.4;
        //    lev_fact = inc * level;
        //}
        //else if (type == "D")
        //{
        //    inc = 0.6;
        //    lev_fact = inc * level;
        //}

        if (time_diff < 30)
        {
            if (allow == true) //Parking
            {
                revenue = Convert.ToInt32(0.3 * base_revenue * (time_diff/60)*0.5);  //penality for not completing time constrain -0.5
               // revenue = revenue + Convert.ToInt32(revenue * lev_fact);
            }
            else              //Non-Parking
            {
                revenue = Convert.ToInt32(0.7 * base_revenue * (time_diff / 60) * 0.7);  //penality for not completing time constrain -0.7
               // revenue = revenue + Convert.ToInt32(revenue * lev_fact);
            }
        }
        else
        {
            if (allow == true) //Parking
            {
                revenue = Convert.ToInt32(0.3 * base_revenue * (time_diff / 60));
               // revenue = revenue + Convert.ToInt32(revenue * lev_fact);
            }
            else              //Non-Parking
            {
                revenue = Convert.ToInt32(0.7 * base_revenue * (time_diff / 60));
                //revenue = revenue + Convert.ToInt32(revenue * lev_fact);
            }

        }


        return revenue;
    }

    ///// <summary>
    ///// ownerid-->owner of the car
    ///// revenue-->revenue generated in the meantime
    ///// </summary>
    ///// <param name="ownerid"></param>
    ///// <param name="revenue"></param>
    ///// <returns></returns>
    //public int Deduction_From_Carowner(int ownerid, int revenue)
    //{
    //    Connect connect;
    //    Connect.ConnectPark();

    //    //string selectcash = "SELECT cash from user where ttid=@ownerid";
    //    //string[] s = { "@ownerid" };
    //    //connect = new Connect(selectcash, s, ownerid);

    //    int cash = new User().GetCashWithUser(ownerid);

    //   // int cash = Convert.ToInt32(connect.executescalar());
    //    int currentcash = 0;
    //    int fine = Convert.ToInt32(0.05 * revenue);
    //    if (cash > fine)
    //    {
    //        currentcash = (cash - fine);
    //    }
    //    else 
    //    {
    //        currentcash = 0;
    //    }

    //    string selectid = "select id from parking_log where is_successful=0 && user_id=@ownerid ORDER BY timestamp DESC";
    //    string[] s1 = { "ownerid" };
    //    connect = new Connect(selectid, s1, ownerid);
    //    int Id = Convert.ToInt32(connect.executescalar());

    //    string insertfine = "insert into fine_log (id,fine) values (@id,@fine)";
    //    string[] s3 = { "@id", "@fine" };
    //    connect = new Connect(insertfine, s3, Id, fine);

    //    return currentcash;
    //}


    public void GetRobozzleScore(int logid,int score,int level,int ttid,string src)
    {
        string q = "Insert into robozzle_score(logid,score,level,ttid,script) values(@logid,@score,@level,@ttid,@script)";
        string[] param = { "@logid", "@score", "@level", "@ttid", "@script" };
        Connect connect = new Connect(q, param, logid, score, level,ttid,src);
    }

    public int GetRobozzleLevel(int logid, int ttid)
    {
        string q = "select count(*) from robozzle_score where logid = @logid and ttid =@ttid";
        string[] param = { "@logid", "@ttid" };
        Connect connect = new Connect(q, param, logid, ttid);
        if (connect.ds.Tables[0].Rows.Count > 0)
        {
            return int.Parse(connect.ds.Tables[0].Rows[0][0].ToString());
        }
        else
            return 0;
    }

    public ParkingStaus CheckStatus(int logid)
    {
        int count = 0;
        string q = "select is_successful from parking_log where id = "+logid.ToString();
        count = int.Parse(new Connect(q).ds.Tables[0].Rows[0][0].ToString());
        if (count == 1)
            return ParkingStaus.HasRemoved;
        else
        {
            string q1 = "select count(*) from fine_log where id = " + logid.ToString();
            count = int.Parse(new Connect(q1).ds.Tables[0].Rows[0][0].ToString());
            if (count == 1)
                return ParkingStaus.IsFined;
            else
                return ParkingStaus.IsParked;
        }
        
            
    }

   public enum ParkingStaus
    {
    IsParked,IsFined,HasRemoved    
    }

   public List<User> GetLeaderBoard()
   {
       
       Connect connect;
       Connect.ConnectPark();
       string s = "select ttid from user";
       connect = new Connect(s);
       int netcash = 0;
       List<User> lst_leaderboard = new List<User>();
       foreach (DataRow row in connect.ds.Tables[0].Rows)
       {
           User u = new User();
           int ttid = Convert.ToInt32(row["ttid"]);
           string query = "select car_id from garage where user_id=@id && status=0";
           string[] s1 = { "@id" };
           connect = new Connect(query, s1, ttid);

           foreach (DataRow row1 in connect.ds.Tables[0].Rows)
           {

               int c_id = Convert.ToInt32(row1["car_id"]);
               string query4 = "select value from car where Id=@carid ";
               string[] s4 = { "@carid" };
               connect = new Connect(query4, s4, c_id);
               int net = Convert.ToInt32(connect.executescalar());
               netcash = netcash + net;
           }


           string query5 = "select cash from user where ttid=@id";
           string[] s5 = { "@id" };
           connect = new Connect(query5, s5, ttid);
           int cash = Convert.ToInt32(connect.executescalar());

          int  net_worth = netcash + cash;


           string query1 = "select username from user where ttid=@id";
           string[] s2 = { "@id" };
           connect = new Connect(query1, s2, ttid);
           username = Convert.ToString(connect.ds.Tables[0].Rows[0][0]);
           u.username = username;
           u.networth = net_worth;
          
           lst_leaderboard.Add(u);
       }
       return lst_leaderboard.OrderByDescending(m => m.networth).ToList();

   }
}