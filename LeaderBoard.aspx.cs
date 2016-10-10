using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LeaderBoard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User u = new User();
        grid_leaders.DataSource = u.GetLeaderBoard();
        grid_leaders.DataBind();

    }
    protected void grid_leaders_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_leaders.PageIndex = e.NewPageIndex;
        grid_leaders.DataBind();
    }
}