/*
 * 1 功能描述：
 *     用户管理员个人信息显示
 * 2 作者：
 *   徐嘉琪；
   3 创建时间：
 *   2012-08-06-14-30；
 * 4 完成时间：
 *   2012-08-06-17-00；
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
    public partial class UA_AdminInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UA UAadmin = new UA();
                UAController GetInfo = new UAController();
                if (Session["hUserName"] != null)
                {
                    UAadmin.UserName = Session["hUserName"].ToString();
                    string[] temp = GetInfo.UAGetInfo(UAadmin);
                    txtStaffID.Text = temp[0];
                    txtStaffName.Text = temp[1];
                    txtPassword.Text = temp[2];
                    switch (Convert.ToInt32(temp[6]))
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
                    txtName.Text = temp[1];
                    txtIDcardNO.Text = temp[11];
                    txtRegister.Text = temp[7];
                }

            }
        }
        /// <summary>
        /// 修改用户管理员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAlter_Click(object sender, EventArgs e)
        {
            UAController GetInfo = new UAController();
            UA UAadmin = new UA();
            UAController UpdateInfo = new UAController();
            if (Session["hUserName"] != null)
            {
                UAadmin.UserName = Session["hUserName"].ToString();
                UAadmin.TrueName = txtName.Text;
                //switch (txtAdministratorClass.Text)
                //{
                //    case "高级管理员":
                //        UAadmin.StaffType = '1';
                //        break;
                //    case "订单管理员":
                //        UAadmin.StaffType = '2';
                //        break;
                //    case "评价管理员":
                //        UAadmin.StaffType = '3';
                //        break;
                //    case "用户管理员":
                //        UAadmin.StaffType = '4';
                //        break;
                //    case "商品管理员":
                //        UAadmin.StaffType = '5';
                //        break;
                //}

                UAadmin.IdCardNum = txtIDcardNO.Text;
                UAadmin.PassWord = txtPassword.Text;
                if (UpdateInfo.UAUpdateInfo(UAadmin) == true)
                {

                    txtName.Text = GetInfo.UAGetInfo(UAadmin)[1];

                    //switch (Convert.ToInt32(GetInfo.UAGetInfo(UAadmin)[6]))
                    //{
                    //    case 1:
                    //        txtAdministratorClass.Text = "高级管理员";
                    //        break;
                    //    case 2:
                    //        txtAdministratorClass.Text = "订单管理员";
                    //        break;
                    //    case 3:
                    //        txtAdministratorClass.Text = "评价管理员";
                    //        break;
                    //    case 4:
                    //        txtAdministratorClass.Text = "用户管理员";
                    //        break;
                    //    case 5:
                    //        txtAdministratorClass.Text = "商品管理员";
                    //        break;
                    //}

                    txtIDcardNO.Text = GetInfo.UAGetInfo(UAadmin)[11];
                    txtPassword.Text = GetInfo.UAGetInfo(UAadmin)[2];
                    this.lblCheck.Text = "信息修改成功!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "信息修改成功" + "');</script>");
                }
                else
                {
                    this.lblCheck.Text = "信息修改失败!请重新操作！";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "信息修改失败" + "');</script>");
                }
            }
            
        }
    }
}