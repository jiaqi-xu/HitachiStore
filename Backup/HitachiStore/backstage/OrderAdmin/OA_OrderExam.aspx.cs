using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Models;

namespace HitachiStore.backstage.OrderAdmin
{
    public partial class OA_OrderExam : System.Web.UI.Page
    {
        static int CurrentPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OA mOA = new OA();
                int PageSum = mOA.GetPages();
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + PageSum + "页";


                this.OrderList.DataSource = mOA.DivideShow(CurrentPage);
                this.OrderList.DataBind();
            }
        }
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Enter_Click(object sender, EventArgs e)
        {

            if (tbxOrderID.Text != null)
            {
                Session["hOrderID"] = tbxOrderID.Text;
                OA mExam = new OA();
                SaveOrders hOrder = new SaveOrders();
                hOrder.OrderID = Session["hOrderID"].ToString();
                OAController mCon = new OAController();

                if (mCon.OrderExamController(mExam, hOrder))
                {
                    this.Response.Redirect("OA_OrderInfoma.aspx");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "此订单不存在！！" + "');</script>");
                }

            }



        }

        protected void Last_Click(object sender, EventArgs e)
        {

            if (CurrentPage > 0)
            {
                CurrentPage--;
                OA mOA = new OA();
                int PageSum = mOA.GetPages();
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + PageSum + "页";
                this.OrderList.DataSource = mOA.DivideShow(CurrentPage);
                this.OrderList.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language=javascript>alert('已经是第一页了！！')</script>");
            }
        }

        protected void next_Click(object sender, EventArgs e)
        {

            OA getPage = new OA();
            int page = getPage.GetPages();
            if (CurrentPage < (page - 1))
            {

                CurrentPage++;
                OA mOA = new OA();
                int PageSum = mOA.GetPages();
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + PageSum + "页";
                this.OrderList.DataSource = mOA.DivideShow(CurrentPage);
                this.OrderList.DataBind();

            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language=javascript>alert('已经是最后一页了！！')</script>");

            }

        }

        
    }
}