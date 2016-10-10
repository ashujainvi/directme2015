using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class garage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["ttid"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                
                ////Redirect user to the game
                name.InnerText = new User().getName(Convert.ToInt32(Session["ttid"]));
                money.InnerText = money.InnerText + new User().GetCashWithUser(Convert.ToInt32(Session["ttid"]));
                var i = new Cars().GetCarsOwnedByUser(Convert.ToInt32(Session["ttid"]));
                gris_cars_with_user.DataSource = i;
                gris_cars_with_user.DataBind();
               
                d.DataSource = i;
                d.DataBind();
                a.DataSource = i;
                a.DataBind();
              
                //GridView2.DataSource = new user_parking_view().GetUsersOnMyParking(Convert.ToInt32(Session["ttid"]));
                //GridView2.DataBind();
            }
            GridView_public_logs.DataSource = new ParkingLog().GetLogsPublic(Convert.ToInt32(Session["ttid"]));
            GridView_public_logs.DataBind();
            grid_previous.DataSource = new ParkingLog().GetLogs(Convert.ToInt32(Session["ttid"]));
            grid_previous.DataBind();
            grid_view_parked_cars.DataSource = new user_parking_view().MyCarsParked(Convert.ToInt32(Session["ttid"]));
            grid_view_parked_cars.DataBind();

        }
    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        if (new Cars().GetCarsCountOwnedByUser(Convert.ToInt32(Session["ttid"])) == 0)
                {
                    //Redirect user to the shop
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(),"none", "<script>$('#NoCarsModal').modal('show');</script>",false);
                  //  Response.Redirect("shop.aspx");
                }
                else
                {
                        //
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#ChooseCarsModal').modal('show');</script>", false);
                   // Response.Redirect("oponentsector.aspx");
                    //Redirect user to the garage
                    //Response.Redirect("garage.aspx");
                }
       
    }
    protected void btn_sell_car_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["caridforselling"]);
        new Cars().Sell(id, Convert.ToInt32(Session["ttid"]));
        gris_cars_with_user.DataSource = new Cars().GetCarsOwnedByUser(Convert.ToInt32(Session["ttid"]));
        gris_cars_with_user.DataBind();
        money.InnerText = "";
        money.InnerText = money.InnerText + new User().GetCashWithUser(Convert.ToInt32(Session["ttid"]));
               
    }
    protected void btn_choose_car_Click(object sender, EventArgs e)
    {
        string s = ((LinkButton)sender).CommandArgument.ToString();
        int id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
        Session["carid"] = id;
        Response.Redirect("oponentsector.aspx");
    }

    protected void Unnamed_Click1(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(((Button)sender).CommandArgument);

        var lst = new user_parking_view().MyCarsParked(Convert.ToInt32(Session["ttid"]));
        user_parking_view parking = lst.Find(m => m.carid == id);

        if (parking.username != "Public lane")
        {
            int logid = new User().RemoveParkedCar(Convert.ToInt32(Session["ttid"]), id);
        }
        else
        {
            new User().pick_from_public(Convert.ToInt32(Session["ttid"]), parking.parking_id);
        }

        grid_previous.DataSource = new ParkingLog().GetLogs(Convert.ToInt32(Session["ttid"]));
        grid_previous.DataBind();
        money.InnerText = "";
        money.InnerText = money.InnerText + new User().GetCashWithUser(Convert.ToInt32(Session["ttid"]));
        grid_view_parked_cars.DataSource = new user_parking_view().MyCarsParked(Convert.ToInt32(Session["ttid"]));
        grid_view_parked_cars.DataBind();
        var i = new Cars().GetCarsOwnedByUser(Convert.ToInt32(Session["ttid"]));
     
        d.DataSource = i;
        d.DataBind();
        a.DataSource = i;
        a.DataBind();

        GridView2.DataSource = new user_parking_view().GetUsersOnMyParking(Convert.ToInt32(Session["ttid"]));
        GridView2.DataBind();

    }

    protected void btn_fine_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(((Button)sender).CommandArgument);
       // GridViewRow row = GridView2.SelectedRow;
        //Label l = (Label)row.FindControl("lbl_car_owner_id");
        var i = new user_parking_view().GetUsersOnMyParking(Convert.ToInt32(Session["ttid"]));
        var u = i.Find(l => l.parking_id == id);
        new fine().Finebyuser(Convert.ToInt32(Session["ttid"]), id,u.userid);
        money.InnerText = "";
        money.InnerText = money.InnerText + new User().GetCashWithUser(Convert.ToInt32(Session["ttid"]));
        GridView2.DataSource = new user_parking_view().GetUsersOnMyParking(Convert.ToInt32(Session["ttid"]));
        GridView2.DataBind();
    }

    protected bool GetCarStatus(int carid,int ttid)
    {
        return new Cars().IsCarAvailableForParking(carid, ttid);
    }

   
    protected void btn_sell_car_modal_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(((Button)sender).CommandArgument);
        Session["caridforselling"] = id;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#sell_car').modal('show');</script>", false);
    }
    protected void grid_previous_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_previous.PageIndex = e.NewPageIndex;
        grid_previous.DataBind();
    }
    protected void GridView_public_logs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView_public_logs.PageIndex = e.NewPageIndex;
        GridView_public_logs.DataBind();

    }
    protected void Unnamed_Click2(object sender, EventArgs e)
    {
        GridView2.DataSource = new user_parking_view().GetUsersOnMyParking(Convert.ToInt32(Session["ttid"]));
        GridView2.DataBind();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#PreviousParkingLog').modal('show');</script>", false);
    }
}