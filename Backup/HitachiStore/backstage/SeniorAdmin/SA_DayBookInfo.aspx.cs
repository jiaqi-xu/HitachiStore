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
    public partial class SA_DayBookInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DayBook mDayBook = new DayBook();
                DayBookController mDayBookController = new DayBookController();
                if (Session["HandleTime"] != null)
                {
                    mDayBook.HandleTime = Session["HandleTime"].ToString();
                    string[] mDayBookInfo = mDayBookController.GetDayBookInfo(mDayBook);
                    this.txtStaffID.Text = mDayBookInfo[0];
                    this.txtUserName.Text = mDayBookInfo[1];
                    this.txtHandleTime.Text = mDayBookInfo[2];
                    this.txtHandleObjects.Text = mDayBookInfo[3];
                    this.txtDayBookType.Text = mDayBookInfo[4];
                    this.txtHandleContent.Text = mDayBookInfo[5];
                }
            }
        }
        //返回到所有日志界面
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SA_DailyRecord.aspx");
        }
        //返回到当前日期界面
        protected void btnBackDay_Click(object sender, EventArgs e)
        {
            DayBook mDayBook = new DayBook();
            DayBookController mDayBookController = new DayBookController();
            mDayBook.HandleTime = this.txtHandleTime.Text;
            Session["HandleDay"] = mDayBookController.GetHandleDay(mDayBook);
            Response.Redirect("SA_DayBookDay.aspx");
        }
    }
}