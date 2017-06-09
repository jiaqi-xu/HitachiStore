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
    public partial class SA_EvaluationExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["surrentPage"] = 0;
                divide mdv = new divide();
                int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
                EA mEA = new EA();
                int Page = mEA.GetPages();
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + Page.ToString() + "页";
                this.EvaluateList.DataSource = mdv.EvaluateShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.EvaluateList.DataBind();
            }
        }
        /// <summary>
        /// 根据EvaluateID查询相应信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Enter_Click(object sender, EventArgs e)
        {
            //实例化高级管理员对象
            SA mSa = new SA();
            //实例化方法对象
            SAController mSacontroller = new SAController();
            //判断输入的EvaluateID是否存在
            if (mSacontroller.ExistEvaluateID(mSa, this.tbxEvaluateID.Text) == true)
            {
                Session["EvaluateID"] = this.tbxEvaluateID.Text;
                Response.Redirect("SA_EvaluaInfo.aspx");
            }
            else
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "不存在此EvaluateID！请重新输入" + "');</script> ");
            }

        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void next_Click(object sender, EventArgs e)
        {
            divide pagesum = new divide();
            if (Convert.ToInt32(ViewState["surrentPage"]) < pagesum.PageSumEvaluate() - 1)
            {
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) + 1;
                divide mdv = new divide();
                int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
                EA mEA = new EA();
                int Page = mEA.GetPages();
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + Page.ToString() + "页";
                this.EvaluateList.DataSource = mdv.EvaluateShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.EvaluateList.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是最后一页！！" + "');</script> ");
            }
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void last_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ViewState["surrentPage"]) > 0)
            {
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) - 1;
                divide mdv = new divide();
                int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
                EA mEA = new EA();
                int Page = mEA.GetPages();
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + Page.ToString() + "页";
                this.EvaluateList.DataSource = mdv.EvaluateShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.EvaluateList.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是第一页！！" + "');</script> ");
            }
        }


        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void EvaluateList_EditCommand1(object source, DataListCommandEventArgs e)
        {
            Session["EvaluateID"] = EvaluateList.DataKeys[e.Item.ItemIndex];
            this.Response.Redirect("SA_EvaluaInfo.aspx");
        }
        ///// <summary>
        ///// 在exam页面里删除评价，郝云浩
        ///// </summary>
        ///// <param name="source"></param>
        ///// <param name="e"></param>
        //protected void EvaluateList_DeleteCommand(object source, DataListCommandEventArgs e)
        //{
        //    EA EAadmin = new EA();
        //    EAController EAconn = new EAController();
        //    Session["EA_EvaluateID"] = EvaluateList.DataKeys[e.Item.ItemIndex];
        //    EAadmin.StaffID = Convert.ToInt32(Session["EA_EvaluateID"]);
        //    if (EAconn.EA_DeleteEvaluate(EAadmin) == true)
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "成功删除该评价！" + "');</script> ");
        //        this.Response.Redirect("EA_EvaluationExam.aspx");
        //    }
        //    else
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除评价失败！" + "');</script>");
        //    }
        //}
    }
}