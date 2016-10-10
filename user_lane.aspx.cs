using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_lane : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonParking_Click(object sender, EventArgs e)
    {

        int ttid = Convert.ToInt32(Session["ttid"].ToString());
        GridView1.DataSource = new user_parking_view().GetUsersOnMyParking(ttid);
        GridView1.DataBind();

    }
    protected void ButtonCarspasked_Click(object sender, EventArgs e)
    {
        int ttid = Convert.ToInt32(Session["ttid"].ToString());
       // GridView2.DataSource = new user_parking_view().ShowMyCarsParking(ttid);
        GridView2.DataBind();

    }

    protected void Fine_User(object sender, EventArgs e)
    {
        int ttid = Convert.ToInt32(Session["ttid"].ToString());
        Button btn = (Button)sender;
        string[] arguments = btn.CommandArgument.ToString().Split(new char[] { ',' });
        string parkingid = arguments[0];
        int userid = Convert.ToInt32(arguments[1]);
        string name = arguments[1];
        int index = Convert.ToInt32(arguments[2]);
        int parking = Convert.ToInt32(parkingid);
        int user = Convert.ToInt32(userid);
        if (parking == 0 || user == 0)
        {
            Response.Write("there is no user");
        }
        else if (index == 2 || index == 4)
        {
            Response.Write("its parking here u cannot fine the player");
        }
        else
        {
            fine fineuser = new fine();
            fineuser.Finebyuser(ttid, parking, userid);
        }
        GridView1.DataSource = new user_parking_view().GetUsersOnMyParking(ttid);
        GridView1.DataBind();

    }
    protected void Remove(object sender, EventArgs e)
    {
        int ttid = Convert.ToInt32(Session["ttid"].ToString());
        Button btn = (Button)sender;
        string[] arguments = btn.CommandArgument.ToString().Split(new char[] { ',' });
        int carid = Convert.ToInt32(arguments[0]);
        string parkingid = arguments[1];
        string name = arguments[2];
        int parking = Convert.ToInt32(parkingid);
        if (parking == 0)
        {
            Response.Write("there is no car");
        }
        else if (name == "Public lane")
        {

            User tempUser = new User();
            tempUser.pick_from_public(ttid, parking);
        }

        else
        {
            user_parking_view u = new user_parking_view();
           // u.remove(ttid, carid);
        }
      //  GridView2.DataSource = new user_parking_view().ShowMyCarsParking(ttid);
        GridView2.DataBind();
    }
}