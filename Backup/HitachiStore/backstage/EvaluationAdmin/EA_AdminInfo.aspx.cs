/*
 * 1 功能描述：
 *     用户管理员个人信息显示
 * 2 作者：
 *   徐嘉琪；
   3 创建时间：
 *   2012-08-08-10-30；
 * 4 完成时间：
 *  
 * 5 修改记录：
 *   修改时间：2012-8-13-16-00；2.修改内容：多余信息的删改；3.修改人：郝云浩；
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
    public partial class EA_AdminInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EA EAadmin = new EA();
                EAController GetInfo = new EAController();
                if (Session["hUserName"] != null)
                {
                    EAadmin.UserName = Session["hUserName"].ToString();
                    string[] temp = GetInfo.EAGetInfo(EAadmin);
                    txtStaffID.Text = temp[0];
                    tbxUserName.Text = temp[5];
                    txtPassword.Text = temp[2];
                    switch (Convert.ToInt32(temp[3]))
                    {
                        case 1:
                            txtAdministratorClass.Text = "高级管理员";
                            break;
                        case 2:
                            txtAdministratorClass.Text = "订单管理员";
                            break;
                        case 3:
                            txtAdministratorClass.Text = "评价管理员";
                            break;
                        case 4:
                            txtAdministratorClass.Text = "用户管理员";
                            break;
                        case 5:
                            txtAdministratorClass.Text = "商品管理员";
                            break;
                    }
                    tbxTrueName.Text = temp[1];
                    tbxIDcardNum.Text = temp[6];
                    tbxAddTime.Text = temp[4];
                }
            }
        }
        /// <summary>
        /// 修改评价管理员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAlter_Click(object sender, EventArgs e)
        {
            EAController GetInfo = new EAController();
            EA EAadmin = new EA();
            EAController UpdateInfo = new EAController();
            if (Session["hUserName"] != null)
            {
                EAadmin.UserName = Session["hUserName"].ToString();
                EAadmin.TrueName = tbxTrueName.Text;
                EAadmin.IdCardNum = tbxIDcardNum.Text;
                EAadmin.PassWord = txtPassword.Text;
                if (UpdateInfo.EAUpdateInfo(EAadmin) == true)
                {

                    tbxTrueName.Text = GetInfo.EAGetInfo(EAadmin)[1];
                    tbxIDcardNum.Text = GetInfo.EAGetInfo(EAadmin)[6];
                    txtPassword.Text = GetInfo.EAGetInfo(EAadmin)[2];
                    this.lblCheck.Text = "修改成功!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "信息修改成功" + "');</script>");
                }
                else
                {
                    this.lblCheck.Text = "修改失败!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "信息修改失败" + "');</script>");
                }

            }

        }
    }
}