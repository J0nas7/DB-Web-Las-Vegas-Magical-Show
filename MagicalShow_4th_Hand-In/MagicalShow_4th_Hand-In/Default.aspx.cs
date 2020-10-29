using System;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace MagicalShow_4th_HandIn
{

    public partial class Default : System.Web.UI.Page
    {
        public void button1Clicked(object sender, EventArgs args)
        {
            button1.Text = "You clicked me";
            string connectionString =   "Server = mysql78.unoeuro.com; " +
                                        "Port = 3306; " +
                                        "Database = seobetter_dk_db_seobtr; " +
                                        "Uid = seobetter_dk; " +
                                        "Pwd = hidden; ";
            MySqlConnection DBconn = new MySqlConnection(connectionString);
            MySqlCommand query = null;
            MySqlDataReader rdr = null;

            string sqlsel = "select * from Petshop";

            try
            {
                DBconn.Open();
                Response.Write("Connection Open");
                query = DBconn.CreateCommand();
                query.CommandText = sqlsel;
                rdr = query.ExecuteReader();

                while (rdr.Read())
                {
                    Response.Write(" test "+(string)rdr["Petshop_Name"]);
                }

                GridViewShops.DataSource = rdr;
                GridViewShops.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                DBconn.Close();
            }
        }

        protected void GridViewShops_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
