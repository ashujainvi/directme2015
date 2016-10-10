using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ttid"] != null)
        {
            Bind();
        }
        else
        {
            Response.Redirect("index.aspx");
        }
    }



    protected void buy_Click(object sender, EventArgs e)
    {
        if (Session["ttid"] != null)
        {
            int ttid = Convert.ToInt32(Session["ttid"]);
            int cashwithuser = new User().GetCashWithUser(ttid);
            int carid = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            int carcost = new Cars().GetCarCost(carid);
            if (cashwithuser < carcost)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('not enough money');", true);
              
                /// show the error message

            }
            else
            {
                //buys the car
                int cashdiff = cashwithuser - carcost;
                new User().UpdateCash(ttid, cashdiff);
                new User().BuyCar(ttid, carid);
                Bind();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Car Bought');", true);
             
            }
        }
    }

    public void Bind()
    {
        List<Cars> carsownedbyuser = new Cars().GetCarsOwnedByUser(Convert.ToInt32(Session["ttid"]));
        
        d.DataSource = new Cars().GetALl().Where(i => !carsownedbyuser.Any(p => i.carId == p.carId));
        d.DataBind();
        a.DataSource = new Cars().GetALl().Where(i => !carsownedbyuser.Any(p => i.carId == p.carId));
        a.DataBind();
    }
}