using System;
using System.Web;
using System.Web.UI;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections;

namespace MagicalShow_4th_HandIn
{
    public partial class Act : System.Web.UI.Page
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
                if (Session["LoggedInAs"].ToString() != "magician")
                {
                    Response.Redirect("Overview.aspx");
                }

                if (Request.QueryString["aid"] != null && Request.QueryString["aid"].Length > 0)
                {
                    LoadAct();
                }

                DirectoryInfo dir = new DirectoryInfo("Images");
                ArrayList listItems = new ArrayList();
                FileInfo[] Files = dir.GetFiles("*.jpg");
                foreach (FileInfo info in Files)
                {
                    listItems.Add(info);
                }
                Files = dir.GetFiles("*.png");
                foreach (FileInfo info in Files)
                {
                    listItems.Add(info);
                }
                dtlist.DataSource = listItems;
                dtlist.DataBind();
            }
        }

        public void LoadAct()
        {
            ButtonAdd.Style["display"] = "none";
            ButtonEdit.Style["display"] = "block";
            string actSql = "SELECT * FROM " + Global.DB.DBprefix + "Act WHERE Act_ID='" + Request.QueryString["aid"] + "' LIMIT 1";
            MySqlDataReader rdr = Global.DB.dbRead(actSql);
            if (rdr.HasRows)
            {
                rdr.Read();
                TextBoxTitle.Text = rdr.GetString("Act_Title");
                TextBoxShortDescription.Text = rdr.GetString("Act_Sdesc");
                TextBoxDuration.Text = rdr.GetString("Act_Duration");
                string Pic = rdr.GetString("Act_Picture");
                TextBoxPicLink.Text = Pic;
                if (Pic.Length == 0)
                {
                    ActImage.ImageUrl = "200x100.png";
                }
                else
                {
                    ActImage.ImageUrl = "Images/" + Pic;
                }
            }
            Global.DB.closeReader();
        }

        public void ButtonAdd_Click(object sender, EventArgs args)
        {
            string selectSql = "SELECT Program_SequenceNumber FROM " + Global.DB.DBprefix + "Program ORDER BY Program_ID DESC LIMIT 1";
            MySqlDataReader rdr = Global.DB.dbRead(selectSql);
            int SequenceNumber = 0;
            if (rdr.HasRows)
            {
                rdr.Read();
                SequenceNumber = rdr.GetInt32("Program_SequenceNumber");
            }
            Global.DB.closeReader();
            SequenceNumber++;

            string Title = TextBoxTitle.Text;
            string ShortDescription = TextBoxShortDescription.Text;
            string Duration = TextBoxDuration.Text;
            string PicLink = TextBoxPicLink.Text;

            LabelError.Text = "";
            string insertSql =  "INSERT INTO " + Global.DB.DBprefix + "Act (Act_Title, Act_Performing, Act_Sdesc, Act_Duration, Act_Picture) VALUES " +
                                "('" + Title + "', '" + Session["LoggedIn"].ToString() + "', '" + ShortDescription+ "', '" + Duration+ "', '"+PicLink+"')";
            if (Global.DB.dbUpdate(insertSql) == 1)
            {
                int ActID = Global.DB.insertedId();
                if (ActID > 0 && SequenceNumber > 0)
                {
                    insertSql =  "INSERT INTO " + Global.DB.DBprefix + "Program (Program_Act, Program_SequenceNumber) VALUES " +
                                        "('" + ActID + "', '" + SequenceNumber + "')";
                    if (Global.DB.dbUpdate(insertSql) == 1)
                    {
                        Response.Redirect("Overview.aspx");
                    }
                    else
                    {
                        LabelError.Text = "Sorting failed (2). Try again.";
                    }
                }
                else
                {
                    LabelError.Text = "Sorting failed (1). Try again.";
                }
            }
            else
            {
                LabelError.Text = "Creation failed. Try again.";
            }
        }

        public void ButtonEdit_Click(object sender, EventArgs args)
        {
            string Title = TextBoxTitle.Text;
            string ShortDescription = TextBoxShortDescription.Text;
            string Duration = TextBoxDuration.Text;
            string PicLink = TextBoxPicLink.Text;

            LabelError.Text = "";
            string updateSql = "UPDATE " + Global.DB.DBprefix + "Act SET Act_Title='" + Title + "', Act_Sdesc='" + ShortDescription+ "', Act_Duration='"+Duration+"', Act_Picture='"+PicLink+"' WHERE Act_ID='" + Request.QueryString["aid"] + "'";
            if (Global.DB.dbUpdate(updateSql) == 1)
            {
                Response.Redirect("Overview.aspx");
            }
            else
            {
                LabelError.Text = "Update failed. Try again.";
            }
        }

        public void ImageUpload_Click(object sender, EventArgs args)
        {
            if (ImageUpload.HasFile)
            {
                ImageUpload.SaveAs("Images/"+ImageUpload.FileName);
                Response.Redirect("Act.aspx");
            }
        }

        public void GoToOverview_Click(object sender, EventArgs args)
        {
            Response.Redirect("Overview.aspx");
        }
    }
}
