/*
 * 1 功能描述：
 *   用户管理员管理用户相关
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
using Models;
using Logic;

namespace HitachiStore.backstage.UserAdmin
{
    public partial class UA_UserExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["surrentPage"] = 0;
                UA mUA = new UA();
                int PageSum = mUA.GetPage();
                int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + PageSum + "页";
                divide mdv = new divide();
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
            if (tbxUserName.Text != null)
            {
                Session["UA_UserName"] = tbxUserName.Text;//获取查询界面输入框的用户名
                UA UAadmin = new UA();
                UAController Badmin = new UAController();
                UAadmin.UserName = tbxUserName.Text;
                if (Badmin.IsUserAlive(UAadmin) == true)
                {
                    this.Response.Redirect("UA_UserInfo.aspx");
                }
                else
                {
                   // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "该用户不存在！" + "');</script> ");

                }
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

        protected void UserList_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            UA mUA = new UA();
            UAController mUACon = new UAController();
            mUA.UserName = UserList.DataKeys[e.Item.ItemIndex].ToString();
            if (mUACon.DeleteUser(mUA))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "成功删除！" + "');</script> ");

            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除失败！" + "');</script>");
            }
        }
        /// <summary>
        /// 进入用户信息修改
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void UserList_EditCommand(object source, DataListCommandEventArgs e)
        {
            Session["UA_UserName"] = UserList.DataKeys[e.Item.ItemIndex];//获取相关对应的值
            this.Response.Redirect("UA_UserInfo.aspx");
        }
    }
}