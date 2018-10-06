using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mei
{
    public partial class Checkout : System.Web.UI.Page
    {
        private decimal total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdCheckout_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToDecimal(e.Row.Cells[3].Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = total.ToString("#.00");
            }
        }
    }
}