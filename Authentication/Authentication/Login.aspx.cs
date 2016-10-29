using Authentication.Classes;
using DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Authentication
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnection DBop = new DBConnection();

        private bool InjectString(string value)
        {

            bool HasInject = false;

            if (value.ToLower().IndexOf("=") >= 0 || value.ToLower().IndexOf("'") >= 0)
                HasInject = true;
            return HasInject;

        }
        private void  IsAdminExists(string userName, string password)
        {
            if (InjectString(userName) || InjectString(password))
            {
                return;
            }
             DataTable dataTable = DBop.cobject.SelectDataSet("Login", "*", "UserEmail like '" + userName + "' AND Password like '" + password + "'").Tables[0];
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {

                Session["UserUID"] = dataTable.Rows[0]["UserUID"];
                Session.Timeout = 2; // set time out for session after 2 minutes
              
              //  int AccountTypeID = Convert.ToInt32(dataTable.Rows[0]["AccountTypeID"]);
                Response.Redirect("Pannel.aspx");
           

            }

            //======================================
            Response.Write("User name or password isnot correct");

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserUID"] = null;
        }
 
        protected void buRegister0_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void buRegister_Click(object sender, EventArgs e)
        {
            IsAdminExists(txtUserName.Text, txtPassword.Text);
             

 
        }
    }
}