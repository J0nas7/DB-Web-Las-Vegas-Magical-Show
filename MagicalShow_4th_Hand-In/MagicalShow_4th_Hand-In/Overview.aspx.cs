using System;
using System.Web;
using System.Web.UI;
namespace MagicalShow_4th_HandIn
{
    public partial class Overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInAs"] != "secretary")
            {
                buttonNewProfile.Style["display"] = "none";
            }
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void ButtonNewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateMagician.aspx");
        }
    }
}
