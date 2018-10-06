using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mei
{
    public partial class ShoppingCartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (ShoppingCartControl.ItemCount == 0)
            {
                ShoppingCartControl.Visible = false;
                btnCheckout.Visible = false;
                lblMessage.Text = "Your cart is empty";
            }
        }
    }
}