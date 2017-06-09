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
    public partial class UA_UserInfo : System.Web.UI.Page
    {
        int RadioJudge = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                UA UAadmin = new UA();
                UAController GetUserInfo = new UAController();
                UAController GetAddress = new UAController();
                if (Session["UA_UserName"] != null)
                {
                    UAadmin.UserName = Session["UA_UserName"].ToString();
                    string[] ltemp = GetUserInfo.UserGetInfo(UAadmin);
                    //   string[] tempAddress = GetAddress.UserAddress(UAadmin);
                    tbxUserName.Text = ltemp[0];
                    tbxUserID.Text = ltemp[2];
                    switch (ltemp[3])
                    {
                        case "0":
                            No.Checked = true;
                            break;
                        case "1":
                            Yes.Checked = true;
                            break;
                    }
                    tbxTrueName.Text = ltemp[4];
                    tbxCreditCard.Text = ltemp[5];
                    tbxAge.Text = ltemp[6];
                    switch (ltemp[7])
                    {
                        case "0":
                            tbxSex.Text = "男";
                            break;
                        case "1":
                            tbxSex.Text = "女";
                            break;
                    }

                    tbxPhone.Text = ltemp[9];
                    tbxRegisterTime.Text = ltemp[10];
                    tbxQQ.Text = ltemp[11];
                    tbxTotalConsum.Text = ltemp[12];
                    //this.gvAddress.DataSource = GetAddress.UserAddress(UAadmin);
                    //this.gvAddress.DataMember = "table1";
                    // this.gvAddress.DataSource = GetAddress.GetAddressList(UAadmin);

                    //判断初始化时用户的类型
                    if (Yes.Checked)
                    {
                        RadioJudge = 1;
                    }
                    else
                    {
                        RadioJudge = 2;
                    }

                    if (tbxTotalConsum.Text == "" || tbxTotalConsum.Text == null)
                    {
                        Yes.Enabled = false;
                        No.Enabled = false;
                    }
                    else
                    {
                        if (Convert.ToDouble(tbxTotalConsum.Text) > 10000.00)
                        {
                            Yes.Checked = true;
                        }
                        else
                        {
                            No.Checked = true;
                        }
                        Yes.Enabled = false;
                        No.Enabled = false;
                    }
                }
            }
        }
        /// <summary>
        /// 修改用户类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Alter_Click(object sender, EventArgs e)
        {
            //int temp = 0;
            UA UAadmin = new UA();
            UAController ChangeType = new UAController();
            if (Session["UA_UserName"] != null)
            {
                UAadmin.UserName = Session["UA_UserName"].ToString();
                if (Yes.Checked == true)
                {
                    UAadmin.StaffType = '1';
                }
                else
                {
                    UAadmin.StaffType = '0';
                }
                if (ChangeType.UpdateUserInfo(UAadmin) == true)
                {
                    this.lblCheck.Text = "用户信息修改成功！";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "用户信息修改成功！" + "');</script> ");
                }
                else
                {
                    this.lblCheck.Text = "信息修改失败！";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "信息修改失败！" + "');</script> ");
                }
            }
        }
        ///// <summary>
        ///// 删除用户所有信息
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void Delete_Click(object sender, EventArgs e)
        //{
        //    UA UAadmin = new UA();
        //    UAController DeleteUser = new UAController();
        //    UAadmin.UserName = Session["UA_UserName"].ToString();
        //    if (DeleteUser.DeleteUser(UAadmin) == true)
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "该用户信息已完全清除！" + "');</script> ");
        //        this.Response.Redirect("UA_UserExam.aspx");
        //    }
        //    else
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除失败！" + "');</script> ");
        //    }
        //}
        /// <summary>
        /// 改变用户类型时进行修改验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Yes_CheckedChanged(object sender, EventArgs e)
        {
        //    if (tbxTotalConsum.Text == "" || tbxTotalConsum.Text == null)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        Convert.ToDouble(tbxTotalConsum.Text);
        //        if (Convert.ToDouble(tbxTotalConsum.Text) >= 10000.00)
        //        {
        //            if (RadioJudge == 1)
        //            {
        //                this.lblCheck.Text = "该用户级别已为会员！！无法更改！";
        //                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "该用户级别已为会员！！无法更改！" + "');</script>");
        //                Yes.Checked = true;
        //            }
        //        }
        //        else
        //        {
        //            if (RadioJudge == 0)
        //            {
        //                this.lblCheck.Text = "该用户名未满足会员要求！无法更改！";
        //                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "该用户名未满足会员要求！无法更改！" + "');</script>");
        //                No.Checked = true;
        //            }
        //        }
        //    }
        }
    }
}