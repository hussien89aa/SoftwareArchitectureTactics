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
    public partial class View : System.Web.UI.Page
    {
        DBConnection DBop = new DBConnection();

        private void IsAuthroize()
        {
            DataTable dataTable = DBop.cobject.SelectDataSet("Login", "*", "UserUID like '" + Convert.ToString(Session["UserUID"]) + "'").Tables[0];
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                int AccountTypeID = Convert.ToInt32(dataTable.Rows[0]["AccountTypeID"]);
                if ((int)AccountTypes.Control!= AccountTypeID)
                    Response.Redirect("Login.aspx");
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