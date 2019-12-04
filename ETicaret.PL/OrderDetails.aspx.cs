using ETicaret.Entity.Entity;
using ETicaret.Entity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETicaret.PL
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                General.LastUrl = Request.Url.ToString();
                Response.Redirect("http://localhost:51010/Login.aspx");
            }
            else
            {
                int OrderID = Convert.ToInt32(Request.QueryString["OrderId"]);
                List<OrderDetail> OrderDetailList = General.Service.OrderDetail.ListByOrderId(OrderID);
                if (OrderDetailList.Count != 0)
                {
                    pnlOrderDetailContent.Visible = true;
                    pnlEmtyList.Visible = false;
                    lvOrderDetails.DataSource = OrderDetailList;
                    lvOrderDetails.DataBind();
                }
                else
                {
                    pnlOrderDetailContent.Visible = false;
                    pnlEmtyList.Visible = true;
                }
            }
        }
    }
}