using Newtonsoft.Json;
using PARK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Connect con;
    class JsonClass
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int EventId { get; set; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (new User().ValidateUser(txt_email.Value, txt_password.Value))
        {
            int ttid = new User().getTTId(txt_email.Value);

            if (new User().IsSectorSelected(ttid))
            {
                Session["ttid"] = ttid;
                Response.Redirect("garage.aspx");

            }
            else
            {
                Session["ttid"] = ttid;
                //Redirect user to the sector select
                Response.Redirect("selectsector.aspx");
            }


        }
        else if (!new User().ValidateUser(txt_email.Value, txt_password.Value))
        {
          
            JsonClass jc = new JsonClass();
            jc.Email = txt_email.Value;
            jc.Password = txt_password.Value;
            jc.EventId = 22;

            string json_data = JsonConvert.SerializeObject(jc);
            WebClient c = new WebClient();
            c.Encoding = System.Text.Encoding.UTF8;
            c.Headers[HttpRequestHeader.ContentType] = "application/json";
            try
            {
                string cs = c.UploadString("http://www.silive.in/tt15.rest/api/Student/GetStudent", json_data);
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                Student stud = new Student();
                stud = json_serializer.Deserialize<Student>(cs);
                var i = c.ResponseHeaders;


               
                string query = "insert into user(ttid,username,password,email,cash,sector_id,confirmed) values(" + stud.TTId + ",'" + stud.Name + "','" + txt_password.Value + "','" + stud.Email + "',100000,0,1" + ")";

                con = new Connect(query);
                Session["ttid"] = stud.TTId;
                Response.Redirect("selectsector.aspx");


            }
            catch (WebException ex)
            {
                HttpWebResponse response = ex.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    lbl_error.Text = "You are not registered on Techtrishna. Register Now at techtrishna 2015 website.";
                    lbl_error.Visible = true;
                }
                if (response.StatusCode == HttpStatusCode.Found)
                {
                    con = new Connect();
                    string q = "update user set password= '" + txt_password.Value + "' where email='" + txt_email.Value + "'";
                    con = new Connect(q);
                    int ttid = new User().getTTId(txt_email.Value);
                    if (new User().IsSectorSelected(ttid))
                    {
                        Session["ttid"] = ttid;
                        Response.Redirect("garage.aspx");

                    }
                    else
                    {
                        Session["ttid"] = ttid;
                        //Redirect user to the sector select
                        Response.Redirect("selectsector.aspx");
                    }
                }
                //lbl_error.Text = "Invalid credentials";
            }

        }
    }
}