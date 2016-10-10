using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class oponentsector : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ttid"] != null)
        {
            if(Session["carid"] == null)
            {
                Response.Redirect("garage.aspx");
            }
            //
        }
       else
            Response.Redirect("index.aspx");
      
    }
   protected void Unnamed_Click(object sender, EventArgs e)
   {
       if (Session["ttid"] != null)
       {
           int ttid = Convert.ToInt32(Session["ttid"]);
           int i = Convert.ToInt16(hidden_server.Value);

           if (ValidateSectorId())
           {
               Session["oponent"] = i;
               Response.Redirect("park.aspx");
           }
           else
           {
               // user have changed the html. so show the error
               Response.Write("<script>alert('Invalid')</script>");

           }
       }
       else
       {
           Response.Redirect("index.aspx");
       }
   }
   protected void btn_public_Click(object sender, EventArgs e)
   {
       if (ValidateSectorId())
       {
           int i = Convert.ToInt16(hidden_server.Value);
           grid_public.DataSource = new Parking().GetPublicParking(i);
           grid_public.DataBind();
       }
   }
   protected void btn_private_Click(object sender, EventArgs e)
   {
       if (ValidateSectorId())
       {
           int i = Convert.ToInt16(hidden_server.Value);
           grid_private.DataSource = new Parking().GetPrivateParking(i, Convert.ToInt32(Session["ttid"]));
           grid_private.DataBind();
       }
   }

   protected string IsVacant(bool isvacant)
   {
       if(isvacant)
       {
           return "Yes";
       }
       else
           return "No";
   }
   protected string IsAllowed(bool isallowed)
   {
       if (isallowed)
       {
           return "Yes";
       }
       else
           return "No";
   }
   protected void btn_private_park(object sender, EventArgs e)
   {
       int id = Convert.ToInt32(((Button)sender).CommandArgument);
       if(new Parking().IsAllowed(id,Convert.ToInt32(Session["ttid"])))
       {
           new Parking().ParkOnPrivateLane(Convert.ToInt32(Session["ttid"]), id, Convert.ToInt32(Session["carid"]));
       }
       else
       {
           Response.Write("<script>alert('Not allowed')</script>");
       }
   }

   protected void btn_public_park(object sender, EventArgs e)
   {
       int id = Convert.ToInt32(((Button)sender).CommandArgument);
       new Parking().ParkOnPublicLane(id,Convert.ToInt32(Session["ttid"]), Convert.ToInt32(Session["carid"]));
       
   }

   protected bool ValidateSectorId()
   {
       int i = Convert.ToInt16(hidden_server.Value);

       if (i > 0 && i < 5)
       {
           return true;
       }
       else
           return false;
   }
  
}