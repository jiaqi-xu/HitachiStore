using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Models;

namespace HitachiStore.backstage.SeniorAdmin
{
    public partial class SA_DayBookDay : System.Web.UI.Page
    {
        DayBook mDayBook = new DayBook();
        DayBookController mDayBookController = new DayBookController();
        divide mDivide = new divide();
        protected void Page_Load(object sender, EventArgs e)
        {
            string mDate = Session["HandleDay"].ToString();
            //第一次加载显示第一页
            if (!IsPostBack)
            {
                ViewState["surrentPage"] = 1;
                DayBookList.DataSource = mDivide.DayBookDateShow(Convert.ToInt32(ViewState["surrentPage"]), mDate);
                DayBookList.DataBind();
            }
        }
        //查看相应页面
        protected void DayBookList_EditCommand(object source, DataListCommandEventArgs e)
        {
            // string mDate = Session["HandleDay"].ToString();
            Session["HandleTime"] = DayBookList.DataKeys[e.Item.ItemIndex];
            Response.Redirect("SA_DayBookInfo.aspx");
        }
        //上一页
        protected void last_Click(object sender, EventArgs e)
        {
            string mDate = Session["HandleDay"].ToString();
            int gPageSum = mDivide.PageSumDayBookDate(mDate);
            if (Convert.ToInt32(ViewState["surrentPage"]) > 1)
            {
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) - 2;
                DayBookList.DataSource = mDivide.DayBookDateShow(Convert.ToInt32(ViewState["surrentPage"]), mDate);
                DayBookList.DataBind();
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) + 1;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是第一页!" + "');</script> ");
            }
        }
        //下一页
        protected void next_Click(object sender, EventArgs e)
        {
            string mDate = Session["HandleDay"].ToString();
            int gPageSum = mDivide.PageSumDayBookDate(mDate);     //总共页数
            if (Convert.ToInt32(ViewState["surrentPage"]) < gPageSum)
            {
                DayBookList.DataSource = mDivide.DayBookDateShow(Convert.ToInt32(ViewState["surrentPage"]), mDate);
                DayBookList.DataBind();
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) + 1;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是最后一页!" + "');</script> ");
            }
        }
        //返回到所有日志查询界面
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SA_DailyRecord.aspx");
        }
    }
}