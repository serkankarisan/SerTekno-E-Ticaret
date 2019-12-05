using ETicaret.Entity.Entity;
using ETicaret.Entity.Identity;
using ETicaret.PL.Models;
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
                if (Request.QueryString["OrderId"] == null)
                {
                    General.LastUrl = Request.Url.ToString();
                    Response.Redirect("http://localhost:51010/UserProfile.aspx");
                }
                else
                {
                    int OrderID = Convert.ToInt32(Request.QueryString["OrderId"]);
                    List<OrderDetail> OrderDetailList = General.Service.OrderDetail.ListByOrderId(OrderID);
                    List<OrderDetailView> OrderDetailViewList = new List<OrderDetailView>();
                    if (OrderDetailList.Count != 0)
                    {
                        foreach (OrderDetail od in OrderDetailList)
                        {
                            OrderDetailView odv = new OrderDetailView();
                            odv.Id = od.Id;
                            odv.Amount = od.Amount;
                            odv.Count = od.Count;
                            odv.ProductId = od.ProductId;
                            odv.UnitPrice = od.UnitPrice;
                            odv.Brand = General.Service.Brand.SelectByProductID(od.ProductId).BrandName;
                            odv.Category = General.Service.Category.SelectByProductID(od.ProductId).CategoryName;
                            odv.ProductName = General.Service.Product.SelectById(od.ProductId).ProductName;
                            odv.DifferentProductCount = OrderDetailList.Count();
                            OrderDetailViewList.Add(odv);
                        }
                        pnlOrderDetailContent.Visible = true;
                        pnlEmtyList.Visible = false;
                        lvOrderDetails.DataSource = OrderDetailViewList;
                        lvOrderDetails.DataBind();
                        Order o = General.Service.Order.SelectById(OrderID);
                        lblDeliveryDate.Text = o.DeliveryDate.ToShortDateString();
                        lblOrderDate.Text = o.AddedDate.ToString();
                        lblProductCount.Text = o.TotalProductCount.ToString();
                        lblTotalPrice.Text = o.TotalPrice.ToString("C");
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
}