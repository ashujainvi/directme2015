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
        if (Session["ttid"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else if (Session["ttid"] != null)
        {
            int ttid = Convert.ToInt32(Session["ttid"]);
            int i = Convert.ToInt16(Session["oponent"]);
           
            if (ValidateSectorId())
            {

                lbl_sector.InnerText = " " + i.ToString();
                grid_private.DataSource = new Parking().GetPrivateParking(i, ttid);
                grid_private.DataBind();
                grid_public.DataSource = new Parking().GetPublicParking(i);
                grid_public.DataBind();

            }
           
        }
    }
   //protected void btn_public_Click(object sender, EventArgs e)
   //{
   //    if (ValidateSectorId())
   //    {
   //        int i = Convert.ToInt16(Session["oponent"]);
   //        grid_public.DataSource = new Parking().GetPublicParking(i);
   //        grid_public.DataBind();
   //    }
   //}
   //protected void btn_private_Click(object sender, EventArgs e)
   //{
   //    if (ValidateSectorId())
   //    {
   //        int i = Convert.ToInt16(Session["oponent"]);
   //        grid_private.DataSource = new Parking().GetPrivateParking(i, Convert.ToInt32(Session["ttid"]));
   //        grid_private.DataBind();
   //    }
   //}

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
           if (new Cars().IsCarAvailableForParking(Convert.ToInt32(Session["carid"]), Convert.ToInt32(Session["ttid"])))
           {
               Session["logid"] = new Parking().ParkOnPrivateLane(Convert.ToInt32(Session["ttid"]), id, Convert.ToInt32(Session["carid"]));
               grid_private.DataSource = new Parking().GetPrivateParking(Convert.ToInt16(Session["oponent"]), Convert.ToInt32(Session["ttid"]));
               grid_private.DataBind();
               parked_success.Visible = true;
               btn_earn_more.Visible = true;
           }
           else
           {
               parked_success.Visible = true;
               parked_success.InnerText = "Your Car is already Parked";
               
         }
       }
       else
       {
           Response.Write("<script>alert('Not allowed')</script>");
       }
   }






   protected void btn_public_park(object sender, EventArgs e)
   {
       if (new Cars().IsCarAvailableForParking(Convert.ToInt32(Session["carid"]), Convert.ToInt32(Session["ttid"])))
       {
           int id = Convert.ToInt32(((Button)sender).CommandArgument);
           Session["logid"] = new Parking().ParkOnPublicLane(id, Convert.ToInt32(Session["ttid"]), Convert.ToInt32(Session["carid"]));
           grid_public.DataSource = new Parking().GetPublicParking(Convert.ToInt16(Session["oponent"]));
           grid_public.DataBind();
           parked_success.Visible = true;
           btn_earn_more.Visible = true;

       }
       else
       {
           parked_success.Visible = true;
           parked_success.InnerText = "Your Car is already Parked";
       }
   }

   protected bool ValidateSectorId()
   {
       int i = Convert.ToInt16(Session["oponent"]);

       if (i > 0 && i < 5)
       {
           return true;
       }
       else
           return false;
   }

   protected void Unnamed_Click(object sender, EventArgs e)
   {
       int i = new User().GetRobozzleLevel(Convert.ToInt32(Session["logid"]), Convert.ToInt32(Session["ttid"]));
       Session["level"] = i;
       Response.Redirect("robozzle/unknown.aspx");
   }
}