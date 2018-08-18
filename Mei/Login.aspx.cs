using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Mei
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text))
            {
                // Valid login
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
            }
            else
            {
                // Invalid login
                lblMessage.Text = "Login failed";
            }
        }
    }
}