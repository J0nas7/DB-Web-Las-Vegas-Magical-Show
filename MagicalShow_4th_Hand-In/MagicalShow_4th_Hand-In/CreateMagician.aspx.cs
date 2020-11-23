using System;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace MagicalShow_4th_HandIn
{
    public partial class CreateMagician : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ButtonEdit.Style["display"] = "none";
                if (Session["LoggedIn"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                if (Session["LoggedInAs"].ToString() != "secretary")
                {
                    Response.Redirect("Overview.aspx");
                }

                if (Request.QueryString["uid"] != null && Request.QueryString["uid"].Length > 0)
                {
                    LoadPerson();
                }
            }
        }

        private void LoadPerson()
        {
            ButtonAdd.Style["display"] = "none";
            ButtonEdit.Style["display"] = "block";
            TextBoxPassword.Style["display"] = "none";
            LabelPassword.Style["display"] = "none";
            string personSql = "SELECT * FROM " + Global.DB.DBprefix + "Magician WHERE Magician_ID='" + Request.QueryString["uid"] + "' LIMIT 1";
            MySqlDataReader rdr = Global.DB.dbRead(personSql);
            if (rdr.HasRows)
            {
                rdr.Read();
                TextBoxName.Text = rdr.GetString("Magician_Name");
                TextBoxArtistName.Text = rdr.GetString("Magician_ArtistName");

                string ProfileType = rdr.GetString("Magician_Type");
                int ProfileTypeIndex = 0;
                switch (ProfileType)
                {
                    case "magician":
                        ProfileTypeIndex = 0;
                        break;
                    case "manager":
                        ProfileTypeIndex = 1;
                        break;
                    case "secretary":
                        ProfileTypeIndex = 2;
                        break;
                }
                RdBtnProfileType.SelectedIndex = ProfileTypeIndex;
            }
            Global.DB.closeReader();
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
                Response.Redirect("Overview.aspx");
            }
            else
            {
                LabelError.Text = "Creation failed. Try again.";
            }
        }

        public void ButtonEdit_Click(object sender, EventArgs args)
        {
            string Name = TextBoxName.Text;
            string ProfileType = RdBtnProfileType.SelectedItem.Value.ToString();
            string ArtistName = (ProfileType == "manager" || ProfileType == "secretary") ? "" : TextBoxArtistName.Text;

            LabelError.Text = "";
            string updateSql = "UPDATE " + Global.DB.DBprefix + "Magician SET Magician_Name='" + Name + "', Magician_ArtistName='" + ArtistName + "', Magician_Type='" + ProfileType + "' WHERE Magician_ID='"+ Request.QueryString["uid"] + "'";
            if (Global.DB.dbUpdate(updateSql) == 1)
            {
                Response.Redirect("Overview.aspx");
            }
            else
            {
                LabelError.Text = "Update failed. Try again.";
            }
        }
    }
}
