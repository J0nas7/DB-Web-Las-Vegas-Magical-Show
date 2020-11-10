using System;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace MagicalShow_4th_HandIn
{
    public partial class Login : System.Web.UI.Page
    {
        public void ButtonLogin_Click(object sender, EventArgs args)
        {
            string Name = TextBoxName.Text;
            string Password = TextBoxPassword.Text;
            Password = CeasarEncryption.Encrypt(Password);
            string loginSql = "SELECT Magician_ID, Magician_Type FROM "+Global.DB.DBprefix+"Magician WHERE Magician_Name='"+Name+ "' AND Magician_Password='" + Password + "' LIMIT 1";
            MySqlDataReader rdr = Global.DB.dbRead(loginSql);
            if (rdr.HasRows)
            {
                rdr.Read();
                Session["LoggedIn"] = rdr.GetInt32("Magician_ID");
                Session["LoggedInAs"] = rdr.GetString("Magician_Type");
                Global.DB.closeReader();
                Response.Redirect("Overview.aspx");
            }
            else
            {
                Global.DB.closeReader();
                LabelLoginMsg.Text = "Not logged in";
            }
        }
    }
}
