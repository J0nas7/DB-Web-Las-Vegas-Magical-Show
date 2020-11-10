using System;
using System.Web;
using System.Web.UI;
namespace MagicalShow_4th_HandIn
{
    public partial class CreateMagician : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInAs"] != "secretary")
            {
                Response.Redirect("Overview.aspx");
            }
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void GoToOverview_Click(object sender, EventArgs args)
        {
            Response.Redirect("Overview.aspx");
        }

        public void ButtonAdd_Click(object sender, EventArgs args)
        {
            string Name = TextBoxName.Text;
            string Password = TextBoxPassword.Text;
            string ProfileType = RdBtnProfileType.SelectedItem.Value.ToString();
            string ArtistName = (ProfileType == "manager" || ProfileType == "secretary") ? "" : TextBoxArtistName.Text;

            LabelError.Text = "";
            Password = CeasarEncryption.Encrypt(Password);
            string insertSql = "INSERT INTO " + Global.DB.DBprefix + "Magician (Magician_Name, Magician_ArtistName, Magician_Password, Magician_Type) VALUES ('"+Name+"', '"+ArtistName+"', '"+Password+"', '"+ProfileType+"')";
            if (Global.DB.dbUpdate(insertSql) == 1)
            {
                Global.DB.closeReader();
                Response.Redirect("Overview.aspx");
            }
            else
            {
                LabelError.Text = "Creation failed. Try again.";
            }
        }
    }
}
