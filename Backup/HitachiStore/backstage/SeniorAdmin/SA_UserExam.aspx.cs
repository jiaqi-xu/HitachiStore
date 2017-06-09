/*
 * 1 功能描述：
 *    高级管理员管理用户界面相关
 * 2 作者：
 *   徐嘉琪；
   3 创建时间：
 *   2012-08-13-14-30；
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
using Logic;
using Models;

namespace HitachiStore.backstage.SeniorAdmin
{
    public partial class SA_UserExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["surrentPage"] = 0;
                divide mdv = new divide();
                UA mUA = new UA();
                int PageSum = mUA.GetPage();
                int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + PageSum + "页";
                this.UserList.DataSource = mdv.UserShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.UserList.DataBind();
            }
        }
        /// <summary>
        /// 查看用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Enter_Click(object sender, EventArgs e)
        {
            SA mSa = new SA();
            SAController mSaController = new SAController();
            if (mSaController.ExistStoreUser(mSa, this.tbxUserName.Text) == false)
            {
                Session["StoreUserName"] = this.tbxUserName.Text;
                Response.Redirect("SA_StoresUserInfo.aspx");
            }
            else
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "您输入的用户名不存在！" + "');</script> ");
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
            if (Convert.ToInt32(ViewState["surrentPage"]) < pagesum.PageSumUser() - 1)
            {
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) + 1;
                divide mdv = new divide();
                this.UserList.DataSource = mdv.UserShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.UserList.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是最后一页！！" + "');</script> ");
            }
            UA mUA = new UA();
            int PageSum = mUA.GetPage();
            int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
            ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + PageSum + "页";
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
                this.UserList.DataSource = mdv.UserShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.UserList.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是第一页！！" + "');</script> ");
            }
            UA mUA = new UA();
            int PageSum = mUA.GetPage();
            int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
            ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + PageSum + "页";
        }

        protected void UserList_UpdateCommand(object source, DataListCommandEventArgs e)
        {

        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void UserList_EditCommand(object source, DataListCommandEventArgs e)
        {
            Session["StoreUserName"] = UserList.DataKeys[e.Item.ItemIndex];//获取相关对应的值
            this.Response.Redirect("SA_StoresUserInfo.aspx");
        }
    }
}