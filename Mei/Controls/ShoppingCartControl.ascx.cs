using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using Mei.Models;

namespace Mei.Controls
{
    public partial class ShoppingCartControl : System.Web.UI.UserControl
    {
        private decimal total=0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdShoppingCart_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grdShoppingCart.Rows[index];
            BLL bll = new BLL();
            int retVal = 0;
            int productID = int.Parse(row.Cells[0].Text);

            if (e.CommandName == "DeleteCart")
            {          

                retVal = bll.DeleteFromShoppingCart("vistor", productID);
            }
            else if (e.CommandName == "UpdateCart")
            {
                ShoppingCart cart = new ShoppingCart();
                cart.Username = "vistor";
                cart.ProductID = productID;
                TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
                cart.Quantity = int.Parse(txtQuantity.Text);

                retVal = bll.UpdateShoppingCart(cart);

            }
            grdShoppingCart.DataBind();
        }

        protected void grdShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToDecimal(e.Row.Cells [3].Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = total.ToString("#.00");
            }
        }
    }
}