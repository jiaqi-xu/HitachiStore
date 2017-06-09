using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Models;

namespace HitachiStore.formerstage.UserRegister
{
    public partial class PerInf_myorder : System.Web.UI.Page
    {
        public static bool isVisible;
        public static bool isVisible1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    this.Response.Redirect("../UserRegister/Login.aspx");
                }
                else
                {
                    ViewState["PageCount"] = 1;//当前页
                    ViewState["TotalePage"] = 1;//总页数
                    StoreOrderInfo OrderInfo = new StoreOrderInfo();
                    OrderInfo.Username = Session["UserName"].ToString();
                    dlstOrder.DataSource = OrderInfo.OrderInfo();
                    btnUpPage.Enabled = false;
                    dlstOrder.DataBind();//数据绑定
                    //判断有多少页
                    int countPage = OrderInfo.PageCount();
                    if (countPage % 5 == 0)
                    {
                        lbPage.Text = "第1页/共" + countPage / 5 + "页";
                        ViewState["TotalePage"] = countPage / 5;
                    }
                    else if (countPage % 5 == 1)
                    {
                        lbPage.Text = "第1页/共" + (countPage + 4) / 5 + "页";
                        ViewState["TotalePage"] = (countPage + 4) / 5;
                    }
                    else if (countPage % 5 == 2)
                    {
                        lbPage.Text = "第1页/共" + (countPage + 3) / 5 + "页";
                        ViewState["TotalePage"] = (countPage + 3) / 5;
                    }
                    else if (countPage % 5 == 3)
                    {
                        lbPage.Text = "第1页/共" + (countPage + 2) / 5 + "页";
                        ViewState["TotalePage"] = (countPage + 2) / 5;
                    }
                    else if (countPage % 5 == 4)
                    {
                        lbPage.Text = "第1页/共" + (countPage + 1) / 5 + "页";
                        ViewState["TotalePage"] = (countPage + 1) / 5;
                    }
                    if (countPage / 5 <= 0)
                    {
                        lbPage.Text = "第1页/共1页";
                        ViewState["TotalePage"] = 1;
                        btnDwonPage.Enabled = false;
                        btnUpPage.Enabled = false;
                    }
                }
            }
        }
        /// <summary>
        /// 判断是否点单已完成
        /// </summary>
        /// <param name="o">订单状态</param>
        /// <returns>订单状态</returns>
        public string Set(object orderState)
        {
            string lstatue=null;
            if (orderState.ToString() == "3")
            {
                { isVisible = false; }
                { isVisible1 = true; }
                lstatue= "订单已完成";
            }
            else if(orderState.ToString()=="0")
            {
                { isVisible1 = false; }
                { isVisible = true; }
                lstatue= " 买家未付款";
            }
            else if (orderState.ToString() == "1")
            {
                { isVisible1 = false; }
                { isVisible = true; }
                lstatue= " 买家付款";
            }
            else if (orderState.ToString() == "2")
            {
                { isVisible1 = false; }
                { isVisible = true; }
                lstatue= "商城发货";
            }
            return lstatue;
        }
        /// <summary>
        /// 判断是否订单是否已评价过
        /// </summary>
        /// <param name="IsEvaluate">IsEvaluate</param>
        /// <returns>若评价过为null，否则为“评价订单”</returns>
        public string  Set(Object isEvaluate,Object tradeStatue )
        {
            if ((isEvaluate.ToString() == "0" || isEvaluate == null)&&(tradeStatue.ToString()=="3"))
            {
                return "评价订单";
            }
            else
            {
                return null;
            }
        }
        protected void btnDwonPage_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                this.Response.Redirect("../UserRegister/Login.aspx");
            }
            else
            {
                if (Convert.ToInt32(ViewState["PageCount"]) == Convert.ToInt32(ViewState["TotalePage"]) - 1)
                {///最后一页btnDwonPage变灰
                    btnDwonPage.Enabled = false;
                }
                StoreOrderInfo OrderInfo = new StoreOrderInfo();
                OrderInfo.Username = Session["UserName"].ToString();
                dlstOrder.DataSource = OrderInfo.nextPage(Convert.ToInt32(ViewState["PageCount"]));
                dlstOrder.DataBind();
                ViewState["PageCount"] = Convert.ToInt32(ViewState["PageCount"]) + 1;
                btnUpPage.Enabled = true;
                lbPage.Text = "第" + ViewState["PageCount"].ToString() + "页/共"+ViewState["TotalePage"].ToString()+"页";
            }
        }

        protected void btnUpPage_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                this.Response.Redirect("../UserRegister/Login.aspx");
            }
            else
            {
                ViewState["PageCount"] = Convert.ToInt32(ViewState["PageCount"]) - 1;
                lbPage.Text = "第" + ViewState["PageCount"].ToString() + "页/共" + ViewState["TotalePage"].ToString() + "页";
                if (Convert.ToInt32(ViewState["PageCount"]) == 1)
                {///最后一页btnUpPage变灰
                    btnUpPage.Enabled = false;
                }
                StoreOrderInfo OrderInfo = new StoreOrderInfo();
                OrderInfo.Username = Session["UserName"].ToString();
                if (Convert.ToInt32(ViewState["PageCount"]) <= 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是第一页了！！" + "');</script> ");
                }
                else
                {
                    dlstOrder.DataSource = OrderInfo.upPage(Convert.ToInt32(ViewState["PageCount"]));
                }
                dlstOrder.DataBind();
                btnDwonPage.Enabled = true;
            }
        }

    }
}