using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.backstage.SeniorAdmin
{
    public partial class SA_DailyRecord : System.Web.UI.Page
    {
        ////记录当前页的索引
        //int lPageIndex = 0;
        divide mDivide = new divide();
        DayBook mDayBook = new DayBook();
        DayBookController mDayBookController = new DayBookController();
        protected void Page_Load(object sender, EventArgs e)
        {
            //第一次加载显示第一页
            if (!IsPostBack)
            {
                //lPageIndex = 0;
                ViewState["surrentPage"] = 0;
                int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
                int PageSum = mDayBook.GetPages();
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + PageSum + "页";

                DayBookList.DataSource = mDivide.DayBookShow(Convert.ToInt32(ViewState["surrentPage"]));
                DayBookList.DataBind();
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) + 1;
            }
            //DayBookList.DataSource = mDivide.DayBookShow(lPageIndex);
            //DayBookList.DataBind();
            //lPageIndex++;
        }
        //上一页
        protected void last_Click(object sender, EventArgs e)
        {
            int gPageSum = mDivide.PageSumDayBook();     //总共页数
            if (Convert.ToInt32(ViewState["surrentPage"]) > 1)
            {
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) - 2;
                DayBookList.DataSource = mDivide.DayBookShow(Convert.ToInt32(ViewState["surrentPage"]));
                DayBookList.DataBind();
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) + 1;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是第一页!" + "');</script> ");
            }
            int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
            int PageSum = mDayBook.GetPages();
            ShowPages.Text = "第" + (CurrentPage).ToString() + "页/共" + PageSum + "页";
        }
        //下一页
        protected void next_Click(object sender, EventArgs e)
        {
            int gPageSum = mDivide.PageSumDayBook();     //总共页数
            if (Convert.ToInt32(ViewState["surrentPage"]) < (gPageSum))
            {
                DayBookList.DataSource = mDivide.DayBookShow(Convert.ToInt32(ViewState["surrentPage"]));
                DayBookList.DataBind();
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) + 1;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是最后一页!" + "');</script> ");
            }
            int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
            int PageSum = mDayBook.GetPages();
            ShowPages.Text = "第" + (CurrentPage).ToString() + "页/共" + PageSum + "页";
        }
        //查看相应页面
        protected void DayBookList_EditCommand(object source, DataListCommandEventArgs e)
        {

            Session["HandleTime"] = DayBookList.DataKeys[e.Item.ItemIndex];
            Response.Redirect("SA_DayBookInfo.aspx");
        }
        //根据输入的日期查出当天所有的记录
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if (this.tbxHandleTime.Text != null && this.tbxHandleTime.Text != "")
            {
                Session["HandleDay"] = this.tbxHandleTime.Text;
                Response.Redirect("SA_DayBookDay.aspx");
            }
            else
            { }
        }
    }
}