using ETicaret.PL.Models;
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

        }
    }
}