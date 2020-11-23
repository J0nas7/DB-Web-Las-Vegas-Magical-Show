using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace MagicalShow_4th_HandIn
{
    public partial class Overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Session["LoggedIn"] = 5;
            Session["LoggedInAs"] = "manager";*/
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            buttonNewProfile.Style["display"] = "none";
            buttonEditProfile.Style["display"] = "none";
            buttonDeleteProfile.Style["display"] = "none";
            Profiles.Style["display"] = "none";

            buttonNewAct.Style["display"] = "none";
            Acts.Style["display"] = "none";
            buttonEditAct.Style["display"] = "none";
            buttonDeleteAct.Style["display"] = "none";

            buttonMoveUp.Style["display"] = "none";
            buttonMoveDown.Style["display"] = "none";

            if (Session["LoggedInAs"].ToString() == "secretary")
            {
                buttonNewProfile.Style["display"] = "block";
                buttonEditProfile.Style["display"] = "block";
                buttonDeleteProfile.Style["display"] = "block";
                Profiles.Style["display"] = "block";
            }
            if (Session["LoggedInAs"].ToString() == "magician")
            {
                buttonNewAct.Style["display"] = "block";
                buttonEditAct.Style["display"] = "block";
                buttonDeleteAct.Style["display"] = "block";
                Acts.Style["display"] = "block";
            }
            if (Session["LoggedInAs"].ToString() == "manager")
            {
                Acts.Style["display"] = "block";
                buttonMoveUp.Style["display"] = "block";
                buttonMoveDown.Style["display"] = "block";
            }


            if (Session["LoggedInAs"].ToString() == "secretary")
            {
                string profilesSql = "SELECT * FROM " + Global.DB.DBprefix + "Magician";
                MySqlDataReader rdr = Global.DB.dbRead(profilesSql);
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string theName =    rdr.GetString("Magician_Name") +
                                            (rdr.GetString("Magician_ArtistName").Length > 0 ? " \""+rdr.GetString("Magician_ArtistName")+"\"" : "") +
                                            " (" + rdr.GetString("Magician_Type") + ")";
                        ListItem li = new ListItem(theName, rdr.GetInt32("Magician_ID").ToString());
                        Profiles.Items.Add(li);
                    }
                }
                Global.DB.closeReader();
            }
            if (Session["LoggedInAs"].ToString() != "secretary")
            {
                string actsSql = "SELECT * FROM " + Global.DB.DBprefix + "Act " +
                                    "INNER JOIN " + Global.DB.DBprefix + "Program ON " + Global.DB.DBprefix + "Act.Act_ID = " + Global.DB.DBprefix + "Program.Program_Act ";
                if (Session["LoggedInAs"].ToString() == "manager")
                {
                    actsSql += "INNER JOIN " + Global.DB.DBprefix + "Magician ON " + Global.DB.DBprefix + "Act.Act_Performing = " + Global.DB.DBprefix + "Magician.Magician_ID";
                }
                    
                if (Session["LoggedInAs"].ToString() == "magician")
                {
                    actsSql += " WHERE Act_Performing='" + Session["LoggedIn"].ToString() + "'";
                }
                actsSql += " ORDER BY Program_SequenceNumber ASC";
                MySqlDataReader rdr = Global.DB.dbRead(actsSql);
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string theAct =     "#"+rdr.GetString("Program_SequenceNumber") + 
                                            " "+rdr.GetString("Act_Title") +
                                            " (" + rdr.GetString("Act_Sdesc") + ")" +
                                            ", " + rdr.GetString("Act_Duration") + " minutes";
                        if (Session["LoggedInAs"].ToString() == "manager")
                        {
                            theAct += ", by " + rdr.GetString("Magician_ArtistName")+" (" + rdr.GetString("Magician_Name")+")";
                        }

                        ListItem li = new ListItem(theAct, rdr.GetInt32("Act_ID").ToString());
                        Acts.Items.Add(li);
                    }
                }
                Global.DB.closeReader();
            }
        }

        public void ButtonNewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateMagician.aspx");
        }
        public void ButtonNewAct_Click(object sender, EventArgs e)
        {
            Response.Redirect("Act.aspx");
        }

        public void ButtonEditProfile_Click(object sender, EventArgs e)
        {
            string uid = Profiles.SelectedItem.Value.ToString();
            Response.Redirect("CreateMagician.aspx?uid=" + uid);
        }

        public void ButtonDeleteProfile_Click(object sender, EventArgs e)
        {
            string personId = Profiles.SelectedItem.Value.ToString();
            string deleteSql = "DELETE FROM " + Global.DB.DBprefix + "Magician WHERE Magician_ID='" + personId + "'";
            if (Global.DB.dbUpdate(deleteSql) == 1)
            {
                Global.DB.closeReader();
                Response.Redirect("Overview.aspx");
            }
        }

        public void ButtonEditAct_Click(object sender, EventArgs e)
        {
            string aid = Acts.SelectedItem.Value.ToString();
            Response.Redirect("Act.aspx?aid=" + aid);
        }

        public void ButtonDeleteAct_Click(object sender, EventArgs e)
        {
            string aid = Acts.SelectedItem.Value.ToString();
            string deleteSql = "DELETE FROM " + Global.DB.DBprefix + "Act WHERE Act_ID='" + aid+ "'";
            if (Global.DB.dbUpdate(deleteSql) == 1)
            {
                Global.DB.closeReader();
            }

            deleteSql = "DELETE FROM " + Global.DB.DBprefix + "Program WHERE Program_Act='" + aid + "'";
            if (Global.DB.dbUpdate(deleteSql) == 1)
            {
                Global.DB.closeReader();
                Response.Redirect("Overview.aspx");
            }
        }

        public void Logout_Click(object sender, EventArgs e)
        {
            Session["LoggedIn"] = null;
            Session["LoggedInAs"] = null;
            Response.Redirect("Default.aspx");
        }

        public void ButtonMoveUp_Click(object sender, EventArgs e)
        {
            moveAct("UP");
        }

        public void ButtonMoveDown_Click(object sender, EventArgs e)
        {
            moveAct("DOWN");
        }

        public void moveAct(string way)
        {
            string aid = Acts.SelectedItem.Value.ToString();

            string selectSql = "SELECT Program_Act, Program_SequenceNumber FROM " + Global.DB.DBprefix + "Program WHERE Program_Act='" + aid + "' LIMIT 1";
            Boolean move = true;
            int thisSQN = 0;
            MySqlDataReader rdr = Global.DB.dbRead(selectSql);
            if (rdr.HasRows)
            {
                rdr.Read();
                thisSQN = rdr.GetInt32("Program_SequenceNumber");
                Global.DB.closeReader();

                if (way == "UP")
                {
                    if (thisSQN == 1)
                    {
                        move = false;
                        Response.Redirect("Overview.aspx?e=e");
                    }
                }
                else if (way == "DOWN")
                {
                    string countRows = "SELECT COUNT(*) AS COUNTER FROM " + Global.DB.DBprefix + "Program";
                    rdr = Global.DB.dbRead(countRows);
                    int countedRows = 0;
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        countedRows = Convert.ToInt32(rdr["COUNTER"]);
                    }
                    Global.DB.closeReader();
                    if (thisSQN == countedRows)
                    {
                        move = false;
                        Response.Redirect("Overview.aspx?e=e");
                    }
                }
            }
            else
            {
                move = false;
                Response.Redirect("Overview.aspx?e=e");
            }

            if (move)
            {
                int from = 0;
                int to = 0;
                if (way == "DOWN")
                {
                    from = thisSQN;
                    to = (thisSQN + 1);
                }
                else if (way == "UP")
                {
                    from = thisSQN;
                    to = (thisSQN - 1);
                }
                string moveIt = "UPDATE " + Global.DB.DBprefix + "Program " +
                                            "SET Program_SequenceNumber = " +
                                                                            "(case when Program_SequenceNumber = " + from + " then '" + to + "' " +
                                                                            "when Program_SequenceNumber = '" + to + "' then '" + from + "' " +
                                                                            "end) " +
                                            "WHERE Program_SequenceNumber in ('" + from + "', '" + to + "')";
                if (Global.DB.dbUpdate(moveIt) > 0)
                {
                    Response.Redirect("Overview.aspx");
                }
                else
                {
                    Response.Redirect("Overview.aspx?e=e");
                }
            }
        }
    }
}
