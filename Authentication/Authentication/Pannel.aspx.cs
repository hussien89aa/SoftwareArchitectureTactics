using Authentication.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Authentication
{
    public partial class Pannel : System.Web.UI.Page
    {
        DBConnection DBop = new DBConnection();

        private void IsAuthroize()
        {
            DataTable dataTable = DBop.cobject.SelectDataSet("Login", "*", "UserUID like '" + Convert.ToString(Session["UserUID"]) + "'").Tables[0];
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                int AccountTypeID = Convert.ToInt32(dataTable.Rows[0]["AccountTypeID"]);
                LAuthenticat.Text = "<h1>Authentication</h1></br>";
                if (AccountTypeID == 1)
                {
                    LAuthenticat.Text += "<a href='Manage.aspx'>Manage Bus <a/>";
                 
                }

                else if (AccountTypeID == 2)
                    LAuthenticat.Text = "<h1>this person isnot authenticated to do any operation </h1>";
                else if (AccountTypeID == 3)
                {
                    LAuthenticat.Text += "<a href='Control.aspx'>Add Bus <a/></br>";
                    LAuthenticat.Text += "<a href='Driver.aspx'> View Bus List<a/>";

                }

                    //LAuthenticat.Text = "";
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserUID"] == null)
                Response.Redirect("Login.aspx");
            IsAuthroize();
        }
    }
}