using System;
using System.Web;
using System.Web.UI;

namespace MagicalShow_4th_HandIn
{

    public partial class Default : System.Web.UI.Page
    {
        public void button1Clicked(object sender, EventArgs args)
        {
            Response.Redirect("Login.aspx");
        }

        protected void GridViewShops_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
