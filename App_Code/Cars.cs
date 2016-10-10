using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using PARK;
using Newtonsoft.Json;

public class Cars
{


    public int carId { get; set; }
    public string carname { get; set; }
    public int cost { get; set; }
    public int level { get; set; }
    public int base_revenue { get; set; }
    public string car_icon { get; set; }


    public int GetCarCost(int carid)
    {
        string insert = "SELECT value FROM car WHERE id=@id";  //value= car_cost
        string[] s = { "@id" };
        Connect.ConnectPark();
        Connect con = new Connect(insert, s, carid);
        return Convert.ToInt32(con.ds.Tables[0].Rows[0][0]);


    }
    public int GetCarBaseRevenue(int carid)
    {
        string insert = "SELECT base_revenue FROM car WHERE id=@id";  //value= car_cost
        string[] s = { "@id" };
        Connect.ConnectPark();
        Connect con = new Connect(insert, s, carid);
        return Convert.ToInt32(con.ds.Tables[0].Rows[0][0]);


    }

    public List<Cars> GetALl()
    {
        Connect connect;
        Connect.ConnectPark();
        string q = "Select * from car";
        string[] s = { "@id" };
        connect = new Connect(q);

        List<Cars> lst_cars = new List<Cars>();

        foreach (DataRow row in connect.ds.Tables[0].Rows)
        {
            Cars c = new Cars();
            c.carname = row[3].ToString();
            c.car_icon = row[4].ToString();
            c.base_revenue = Convert.ToInt32(row[2]);
            c.cost = Convert.ToInt32(row[1]);
            c.carId = Convert.ToInt32(row[0]);
            lst_cars.Add(c);

        }
        //con.Close();
        return lst_cars;
    }



    public int money(int ttid)
    {
        Connect connect;
        Connect.ConnectPark();
        string insert = "select cash from user where ttid=@tid";
        string[] s = { "@tid" };
        connect = new Connect(insert, s, ttid);
        int cash = Convert.ToInt32(connect.executescalar());
        return cash;
    }

    /// <summary>
    /// temp-> checking whether this car is with user or not
    /// count-> total no of cars user has
    /// </summary>
    /// <param name="carid"></param>
    /// <param name="ttid"></param>
    //public int shop(int carid, int ttid)
    //{
    //    int Temp = 0;
    //    Connect connect;
    //    Connect.ConnectPark();


    //    string insert_1 = "select count(user_id) from garage where car_id=@carid && user_id=@id && status=0";
    //    string[] s1 = { "@carid", "@id" };
    //    connect = new Connect(insert_1, s1, carid, ttid);
    //    Temp = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);

    //    string insert_2 = "select count(user_id) from garage where user_id=@uid && status=0 ";
    //    string[] s2 = { "@uid" };
    //    connect = new Connect(insert_2, s2, ttid);
    //    int count = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);

    //    if (Temp == 1)
    //    {
    //        return 2;     // user already has that car
    //    }
    //    else if (count == 5)
    //    {
    //        return 3;      //u  already have 5 cars
    //    }
    //    else
    //    {
    //        User u = new User();
    //    bool message=u.IsCarBuyingSuccessfull(ttid, carid);
    //    if (message == true)
    //        return 1;     //car khareed li :p :D
    //    else
    //        return 0;      //cash lower than cost


    //    }
    //}
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ttid"></param>
    /// <returns></returns>

    public List<Cars> GetCarsOwnedByUser(int ttid)
    {
        Connect connect;
        Connect.ConnectPark();
        string q = "Select car_id from garage where user_id=@id && status=0";
        string[] s = { "@id" };
        connect = new Connect(q, s, ttid);
        List<Cars> lst_cars = new List<Cars>();

        foreach (DataRow row in connect.ds.Tables[0].Rows)
        {
            string q1 = "SELECT * FROM car WHERE id=" + row[0].ToString();
            Connect con = new Connect(q1);
            DataRow car = con.ds.Tables[0].Rows[0];

            Cars c = new Cars();
            c.carname = car[3].ToString();
            c.car_icon = car[4].ToString();
            c.base_revenue = Convert.ToInt32(car[2]);
            c.cost = Convert.ToInt32(car[1]);
            c.carId = Convert.ToInt32(car[0]);
            lst_cars.Add(c);

        }

        return lst_cars;
    }


    public int GetCarsCountOwnedByUser(int ttid)
    {
        Connect connect;
        Connect.ConnectPark();
        string q = "Select count(car_id) from garage where user_id=@id && status=0";
        string[] s = { "@id" };
        connect = new Connect(q, s, ttid);
        return Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);
    }
    public bool IsCarAvailableForParking(int carid, int ttid)
    {
        Connect connect;
        Connect.ConnectPark();
        string insert = "select parking_id from garage where car_id=@carid && user_id=@uid && status=@status";
        string[] s = { "@carid", "@uid", "@status" };
        connect = new Connect(insert, s, carid, ttid, 0);
        int id = Convert.ToInt32(connect.executescalar());
        if (id == 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// Function for selling the car
    ///status 1->car is sold
    /// </summary>
    /// <param name="car_id"></param>
    /// <param name="ttid"></param>
    public void Sell(int car_id, int ttid)
    {
        Connect connect;
        Connect.ConnectPark();
        string q = "Update garage set status=1, parking_id=0 where car_id=@carid && user_id=@uid && status=0";
        string[] s = { "@carid", "@uid" };
        connect = new Connect(q, s, car_id, ttid);
        int cost = new Cars().GetCarCost(car_id);

        int cashobtained = Convert.ToInt32(0.5 * cost);
        int cash = new User().GetCashWithUser(ttid);

        int money = cash + cashobtained;
        new User().UpdateCash(ttid, money);


    }
}