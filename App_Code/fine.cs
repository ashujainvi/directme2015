using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using PARK;

/// <summary>
/// Summary description for fine
/// </summary>
public class fine
{
/// <summary>
/// ttid --> owner of the lane
/// parkingid-->id of the lane on which he has parked
/// ownerid-->owner of the car
/// </summary>
/// <param name="laneownerttid"></param>
/// <param name="parkingid"></param>
/// <param name="carownerid"></param>
/// <returns></returns>
    public void Finebyuser(int laneownerttid, int parkingid, int carownerid)
    {
        Connect connect;
        Connect.ConnectPark();
        string query1 = "Select car_id from garage where parking_id=@parkingid && user_id=@userid && status=0";
        string[] s1 = { "@parkingid", "@userid" };
        connect = new Connect(query1, s1, parkingid, carownerid);
        int carid = Convert.ToInt32(connect.executescalar());

       // User u=new User();
        int revenue=new User().GetRevenueFromPrivateLanes(carownerid, parkingid);

        
        //string query3 = "SELECT  cash from user where ttid=@id ";
        //string[] s3 = { "@id" };
        //connect = new Connect(query3, s3, laneownerttid);
      //  int cash = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);

        int cash = new User().GetCashWithUser(laneownerttid);
        new User().UpdateCash(laneownerttid, cash + revenue);

       //string query4 = "update user set cash= @cost where ttid=@id ";
       //string[] s4 = { "@cost", "@id"  };
       //connect = new Connect(query4, s4, (revenue+cash), laneownerttid);


       string query5 = "Update garage set parking_id=0 where car_id=@carid && user_id=@owner && status=0";
       string[] s2 = { "@carid", "@owner" };
       connect=new Connect(query5,s2,carid,carownerid);

      // int deduct = new User().Deduction_From_Carowner(carownerid,revenue);


       int cash_with_car_owner = new User().GetCashWithUser(carownerid);
       // int cash = Convert.ToInt32(connect.executescalar());
       int currentcash = 0;
       int fine = Convert.ToInt32(0.05 * revenue);
       if (cash_with_car_owner > fine)
       {
           currentcash = (cash_with_car_owner - fine);
       }
       else
       {
           currentcash = 0;
       }
       new User().UpdateCash(carownerid, currentcash);

       //string query6 = "update user set cash=@deduct where ttid=@ownerid";
       //string[] s5 = {"deduct","ownerid"};
       //connect = new Connect(query6,s5,deduct,carownerid);

       string selectid = "select id from parking_log where is_successful=0 && user_id=@ownerid and parking_owner_id = @parkingid ORDER BY timestamp DESC";
       string[] s3 = { "@ownerid", "@parkingid" };
       connect = new Connect(selectid, s3, carownerid,parkingid);
       int Id = Convert.ToInt32(connect.ds.Tables[0].Rows[0][0]);

       string insertfine = "insert into fine_log (id,fine) values (@id,@fine)";
       string[] s4 = { "@id", "@fine" };
       connect = new Connect(insertfine, s4, Id, fine);

       string insertrevenue = "insert into revenuebyfine (logid,revenue) values (@id,@revenue)";
       string[] s5 = { "@id", "@revenue" };
       connect = new Connect(insertrevenue, s5, Id, revenue);



       
    }
}