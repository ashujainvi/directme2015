using PARK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ParkingLog
/// </summary>
public class ParkingLog
{
    public string UserName { get; set; }
    public string ParkedOn { get; set; }
    public DateTime ParkingDate { get; set; }
    public string IsSuccess { get; set; }
    public int Revenue { get; set; }
    public int Fine { get; set; }


	public List<ParkingLog> GetLogs(int ttid)
    {
        string q = "select timestamp,is_successful,allowed,username,parking_log.id from parking_log  inner join parking on parking_owner_id = parking.Id inner join user_parking on parking_log.parking_owner_id = user_parking.parking_id inner join user on user_parking.user_id = user.ttid  where parking_log.user_id = @ttid";
            string[] s = {"@ttid"};
        Connect c = new Connect(q,s,ttid);
        List<ParkingLog> lst = new List<ParkingLog>();
        foreach (DataRow row in c.ds.Tables[0].Rows)
	{
        int logid = Convert.ToInt32(row[4]);
            ParkingLog p = new ParkingLog();
            p.Fine = GetFine(logid);
            p.Revenue = GetRevenue(logid);
            p.ParkingDate = Convert.ToDateTime(row[0]);
            p.IsSuccess = int.Parse(row[1].ToString()) == 0 ? "Unsuccessfull" : "Successfull";
            p.UserName = row[3].ToString();
            if(row[2].ToString() == "1")
            {
                p.ParkedOn = "Parking Zone";
            }
            else
                p.ParkedOn = "Non Parking Zone";
            lst.Add(p);
	}
        return lst;
    }

        public int GetFine(int logid)
        {
            string q = "Select fine from fine_log where id = "+logid.ToString();
            Connect c = new Connect(q);
            if (c.ds.Tables[0].Rows.Count > 0)
                return Int32.Parse(c.ds.Tables[0].Rows[0][0].ToString());
            else
                return 0;
        }

        public int GetRevenue(int logid)
        {
            string q = "Select revenue from revenuelog where logid = " + logid.ToString();
            Connect c = new Connect(q);
            if (c.ds.Tables[0].Rows.Count > 0)
                return Int32.Parse(c.ds.Tables[0].Rows[0][0].ToString());
            else
                return 0;
        }

        public List<ParkingLog> GetLogsPublic(int ttid)
        {
            string q = "select * from parking_log inner join parking on parking_owner_id = parking.Id where private = 0 and user_id = @ttid";
            string[] s = { "@ttid" };
            Connect c = new Connect(q, s, ttid);
            List<ParkingLog> lst = new List<ParkingLog>();
            foreach (DataRow row in c.ds.Tables[0].Rows)
            {
                int logid = Convert.ToInt32(row[3]);
                ParkingLog p = new ParkingLog();
                p.Fine = GetFine(logid);
                p.Revenue = GetRevenue(logid);
                p.ParkingDate = Convert.ToDateTime(row[2]);
                p.IsSuccess = int.Parse(row[4].ToString()) == 0 ? "Unsuccessfull" : "Successfull";
                
                lst.Add(p);
            }
            return lst;
        }
}