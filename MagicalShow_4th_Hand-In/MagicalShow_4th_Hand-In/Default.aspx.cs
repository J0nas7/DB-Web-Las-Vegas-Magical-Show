using System;
using System.Data;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace MagicalShow_4th_HandIn
{

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string actsSql = "SELECT * FROM " + Global.DB.DBprefix + "Act " +
                                    "INNER JOIN " + Global.DB.DBprefix + "Program ON " + Global.DB.DBprefix + "Act.Act_ID = " + Global.DB.DBprefix + "Program.Program_Act " +
                                    "INNER JOIN " + Global.DB.DBprefix + "Magician ON " + Global.DB.DBprefix + "Act.Act_Performing = " + Global.DB.DBprefix + "Magician.Magician_ID " +
                            "ORDER BY Program_SequenceNumber ASC";
            MySqlDataAdapter da = Global.DB.dbAdapt(actsSql);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtlist.DataSource = ds.Tables[0].DefaultView;
            dtlist.DataBind();

            string durationSql = "SELECT SUM(Act_Duration) AS TotalDuration FROM " + Global.DB.DBprefix + "Act";
            MySqlDataReader rdr = Global.DB.dbRead(durationSql);
            rdr.Read();
            TotalDuration.Text = "Las Vegas Magical Show "+rdr.GetString("TotalDuration")+" minutes";
            Global.DB.closeReader();
        }

        public void button1Clicked(object sender, EventArgs args)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
