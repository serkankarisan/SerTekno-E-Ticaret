using ETicaret.Entity.Entity;
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
    public partial class OrderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<BasketItem> MyBasket = new List<BasketItem>();
            if (Session["basket"] != null)
            {
                MyBasket = (List<BasketItem>)Session["basket"];
            }
            if (MyBasket.Count != 0)
            {
                pnlContent.Visible = true;
                pnlEmtyList.Visible = false;
                lvProduct.DataSource = MyBasket;
                lvProduct.DataBind();
                BasketItem bskt = new BasketItem();
                lblTotalPrice.Text = bskt.TotalAnmount(MyBasket).ToString();
                lblDeliveryDate.Text = DateTime.Now.AddDays(7).ToShortDateString();
            }
            else
            {
                pnlEmtyList.Visible = true;
                pnlContent.Visible = false;
            }
        }

        protected void btnBasketItemDeleteS_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            List<BasketItem> MyBasket = (List<BasketItem>)Session["basket"];
            BasketItem delItem = MyBasket.Where(w => w.ProductId == Convert.ToInt32(btn.CommandArgument)).FirstOrDefault
                ();
            MyBasket.Remove(delItem);
            Session["basket"] = MyBasket;
            BasketItem bskt = new BasketItem();
            Session["totalcount"] = bskt.TotalCount(MyBasket);
            Session["totalamount"] = bskt.TotalAnmount(MyBasket);
            General.LastUrl = Request.Url.ToString();
            Response.Redirect("http://localhost:51010/OrderPage.aspx");
        }

        protected void btnBasketItemDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            List<BasketItem> MyBasket = (List<BasketItem>)Session["basket"];
            BasketItem delItem = MyBasket.Where(w => w.ProductId == Convert.ToInt32(btn.CommandArgument)).FirstOrDefault
                ();
            MyBasket.Remove(delItem);
            Session["basket"] = MyBasket;
            BasketItem bskt = new BasketItem();
            Session["totalcount"] = bskt.TotalCount(MyBasket);
            Session["totalamount"] = bskt.TotalAnmount(MyBasket);
            General.LastUrl = Request.Url.ToString();
            Response.Redirect("http://localhost:51010/OrderPage.aspx");
        }

        protected void btnAccessOrder_Click(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Session["basket"] != null)
                {
                    BasketItem bskt = new BasketItem();
                    List<BasketItem> MyBasket = (List<BasketItem>)Session["basket"];
                    Order order = new Order();
                    order.UserId = User.Identity.GetUserId();
                    order.TotalProductCount = bskt.TotalCount(MyBasket);
                    order.TotalPrice = bskt.TotalAnmount(MyBasket);
                    order.DeliveryDate = DateTime.Now.AddDays(7);
                    order.OrderCode = "PRDCT" + DateTime.Now.ToString().Replace(" ", "").Replace(".", "").Replace(":", "") + DateTime.Now.Millisecond.ToString();
                    General.Service.Order.Insert(order);
                    foreach (BasketItem item in MyBasket)
                    {
                        OrderDetail od = new OrderDetail();
                        od.OrderId = General.Service.Order.SelectByOrderCode(order.OrderCode).Id;
                        od.Amount = item.Amount;
                        od.Count = item.Count;
                        od.ProductId = item.ProductId;
                        od.UnitPrice = item.UnitPrice;
                        General.Service.OrderDetail.Insert(od);
                    }
                    Session["basket"] = null;
                    Session["totalcount"] = null;
                    Session["totalamount"] = null;
                    General.LastUrl = Request.Url.ToString();
                    Response.Redirect("http://localhost:51010/UserProfile.aspx");
                }
            }
            else
            {
                General.LastUrl = Request.Url.ToString();
                Response.Redirect("http://localhost:51010/Login.aspx");
            }
        }

        protected void btnCountAdd_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            List<BasketItem> MyBasket = (List<BasketItem>)Session["basket"];
            BasketItem Item = MyBasket.Where(w => w.ProductId == Convert.ToInt32(btn.CommandArgument)).FirstOrDefault
                ();
            if (Item.Count <= General.Service.Product.SelectById(Item.ProductId).StockCount)
            {
                Item.Count += 1;
                Item.Amount += Item.UnitPrice;
            }
            Session["basket"] = MyBasket;
            BasketItem bskt = new BasketItem();
            Session["totalcount"] = bskt.TotalCount(MyBasket);
            Session["totalamount"] = bskt.TotalAnmount(MyBasket);
            General.LastUrl = Request.Url.ToString();
            Response.Redirect("http://localhost:51010/OrderPage.aspx");
        }

        protected void btnCountDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            List<BasketItem> MyBasket = (List<BasketItem>)Session["basket"];
            BasketItem Item = MyBasket.Where(w => w.ProductId == Convert.ToInt32(btn.CommandArgument)).FirstOrDefault
                ();
            if (Item.Count > 1)
            {
                Item.Count -= 1;
                Item.Amount -= Item.UnitPrice;
            }
            else if (Item.Count == 1)
            {
                MyBasket.Remove(Item);
            }
            Session["basket"] = MyBasket;
            BasketItem bskt = new BasketItem();
            Session["totalcount"] = bskt.TotalCount(MyBasket);
            Session["totalamount"] = bskt.TotalAnmount(MyBasket);
            General.LastUrl = Request.Url.ToString();
            Response.Redirect("http://localhost:51010/OrderPage.aspx");
        }
    }
}