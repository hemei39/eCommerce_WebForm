using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mei.Models;
using DataAccess;

namespace Mei
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        private string SortDirection
        {
            get
            {
                if (ViewState["SortDirection"] == null)
                {
                    ViewState["SortDirection"] = "ASC";
                }
                return ViewState["SortDirection"].ToString();
            }

            set
            {
                ViewState["SortDirection"] = value;
            }

        }
        protected void ddlstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdProduct.DataBind();
        }

        protected void grdProduct_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdProduct.Rows[index];

                ShoppingCart cart = new ShoppingCart();
                cart.Username = "vistor";
                cart.ProductID = int.Parse(row.Cells[0].Text);
                cart.UnitPrice = decimal.Parse(row.Cells[2].Text);

                BLL bll = new BLL();

                int retVal = bll.AddToShoppingCart(cart);
            }
        }

        
    }
}