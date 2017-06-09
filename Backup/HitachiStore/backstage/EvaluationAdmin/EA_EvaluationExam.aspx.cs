/*
 * 1 功能描述：
 *   实现评价管理员的相应功能
 *   
 * 2 作者：
 *   郝云浩；
   3 创建时间：
 *   2012-08-14-09-00；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.backstage.EvaluationAdmin
{
    public partial class EA_EvaluationExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["surrentPage"] = 0;
                int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
                EA mEA = new EA();
                int Page = mEA.GetPages();
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + Page.ToString() + "页";
                divide mdv = new divide();
                this.EvaluateList.DataSource = mdv.EvaluateShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.EvaluateList.DataBind();
            }
        }

        protected void Enter_Click(object sender, EventArgs e)
        {
            if (txtEvaluateID.Text != null && txtEvaluateID.Text != "")
            {
                Session["EA_EvaluateID"] = txtEvaluateID.Text;
                EA EAadmin = new EA();
                EAController Badmin = new EAController();
                EAadmin.StaffID = Convert.ToInt32(txtEvaluateID.Text);
                GoodEvaluate mEvaluate = new GoodEvaluate();
                mEvaluate.EvaluateID = Convert.ToInt32(txtEvaluateID.Text);
                if (Badmin.IsEvaluateAlive(EAadmin) == true)
                {
                    this.Response.Redirect("EA_EvaluationInfo.aspx");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "该评价不存在！" + "');</script> ");
                }
            }
        }
        /// <summary>
        /// 上一页
        /// 徐嘉琪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void last_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ViewState["surrentPage"]) > 0)
            {
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) - 1;
                int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
                EA mEA = new EA();
                int Page = mEA.GetPages();
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + Page.ToString() + "页";
                divide mdv = new divide();
                this.EvaluateList.DataSource = mdv.EvaluateShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.EvaluateList.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是第一页！！" + "');</script> ");
            }
        }
        /// <summary>
        /// 下一页
        /// 徐嘉琪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void next_Click(object sender, EventArgs e)
        {
            divide pagesum = new divide();
            if (Convert.ToInt32(ViewState["surrentPage"]) < pagesum.PageSumEvaluate() - 1)
            {
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) + 1;
                int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
                EA mEA = new EA();
                int Page = mEA.GetPages();
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + Page.ToString() + "页";
                divide mdv = new divide();
                this.EvaluateList.DataSource = mdv.EvaluateShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.EvaluateList.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是最后一页！！" + "');</script> ");
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void EvaluateList_EditCommand(object source, DataListCommandEventArgs e)
        {
            if (EvaluateList.DataKeys[e.Item.ItemIndex] != null)
            {
                Session["EA_EvaluateID"] = EvaluateList.DataKeys[e.Item.ItemIndex];
                this.Response.Redirect("EA_EvaluationInfo.aspx");
            }
        }
        /// <summary>
        /// 在exam页面里删除评价，徐嘉琪
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void EvaluateList_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            EA EAadmin = new EA();
            EAController EAconn = new EAController();
            if (EvaluateList.DataKeys[e.Item.ItemIndex] != null)
            {
                Session["EA_EvaluateID"] = EvaluateList.DataKeys[e.Item.ItemIndex];
                EAadmin.StaffID = Convert.ToInt32(Session["EA_EvaluateID"]);
                if (EAconn.EA_DeleteEvaluate(EAadmin) == true)
                {
                    this.Response.Redirect("EA_EvaluationExam.aspx");
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "成功删除该评价！" + "');</script> ");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除评价失败！" + "');</script>");
                }
            }
        }
    }
}