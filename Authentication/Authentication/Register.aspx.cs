using Authentication.Classes;
using DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Authentication
{
    public partial class Register : System.Web.UI.Page
    {
        DBConnection DBop = new DBConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buRegister_Click(object sender, EventArgs e)
        {
            ColoumnParam[] Coloumns = new ColoumnParam[3];
            Coloumns[0] = new ColoumnParam("UserEmail", ColoumnType.NVarChar, txtUserName.Text);
            Coloumns[1] = new ColoumnParam("Password", ColoumnType.NVarChar, txtPassword.Text);
            Coloumns[2] = new ColoumnParam("AccountTypeID", ColoumnType.Int, DDLAccountType.SelectedValue);
            if (DBop.cobject.InsertRow("Login", Coloumns))
            {
                // LiMessage.Text = "<strong>Success!</strong> Password is changed successfully.";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowModalSucces();", true);
                Response.Write("Thanks,account is created ");
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Write("cannot register ");
            }
        }

    }
}