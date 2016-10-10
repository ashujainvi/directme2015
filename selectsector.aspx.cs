using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class selectsector : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ttid"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            if (new User().IsSectorSelected(Convert.ToInt32(Session["ttid"])))
            {
                Response.Redirect("garage.aspx");
            }

        }
    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        if (Session["ttid"] != null)
        {
            int ttid = Convert.ToInt32(Session["ttid"]);
            int i = Convert.ToInt16(hidden_server.Value);

            if (i > 0 && i < 5)
            {
                new User().SelectSector(ttid, i);
                if (new Cars().GetCarsOwnedByUser(ttid).Count == 0)
                {
                    Response.Redirect("shop.aspx");
                }
                else
                {
                    Response.Redirect("garage.aspx");
                }
            }
            else
            {
                // user have changed the html. so show the error
                
            }
        }
        else
        {
            Response.Redirect("index.aspx");
        }

    }
}