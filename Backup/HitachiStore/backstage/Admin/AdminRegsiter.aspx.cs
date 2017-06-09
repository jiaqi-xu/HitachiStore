/*
 * 1 功能描述: 管理员注册
 * 
 * 2 作者：王晶晶
 * 
 * 3 创建时间：2012/8/3
 * 
 * 4 完成时间
 * 
 * 5 修改记录:1.修改时间:2012-8-6-9-30；2.修改内容：添加用户名验证；3.修改人：徐嘉琪.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.backstage.Admin
{
    public partial class AdminRegsiter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ///生成注册时间
            txtRegister.Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// 提交注册信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAlter_Click(object sender, EventArgs e)
        {
            // 新建一个管理员对象
            Admins madmins = new Admins();     
            //给新建的管理员对象的属性传参            
            madmins.UserName = this.txtStaffName.Text;
            madmins.PassWord = this.txtPassword.Text;
            madmins.TrueName = this.txtName.Text;
            madmins.IdCardNum = this.txtIDcardNO.Text;
            madmins.Age = this.txtAge.Text;
            madmins.Email = this.txtEmail.Text;
            madmins.Phone = this.txtPhone.Text;
            madmins.Address = this.txtAddress.Text;
            madmins.QQ = this.txtQQ.Text;
            madmins.AddTime = this.txtRegister.Text;
            if (this.rbnMan.Checked == true)
            {
                madmins.Sex = '0';
            }
            else
            {
                madmins.Sex = '1';
            }
            //实例化管理员方法类
            AdminController mAdminController = new AdminController();     
            //判断是否注册成功
            try
            {
                if ((mAdminController.AdminRegistText(madmins) == true)&&(mAdminController.RegisterAdmin(madmins) == true))
                {
                    try
                    {
                        //跳转到另一页面
                        this.Response.Redirect("AdminRegisterSuccess.htm");
                    }
                    catch
                    {
                    }
                }
                //注册失败提示信息并将其已填内容置空
                else     
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "注册失败！" + "');</script> ");
                    this.txtStaffName = null;
                    this.txtPassword = null;
                    this.txtName = null;
                    this.txtIDcardNO = null;
                    this.txtAge = null;
                    this.txtEmail = null;
                    this.txtPhone = null;
                    this.txtAddress = null;
                    this.txtQQ = null;
                }
            }
            catch (Exception h)
            {
                throw h;
                //发布时用以下注释掉得异常处理
                //this.Response.Redirect("ExceptionHandler.htm");
            }
        }


        /// <summary>
        /// 验证注册时，用户名是否重复，此方法需要调用Model中的类
        /// </summary>
        protected void btnStaffName_Click(object sender, EventArgs e)
        {
            Admins madmins = new Admins();
            AdminController mAdminController = new AdminController();
            madmins.UserName = this.txtStaffName.Text;
            if (mAdminController.AdminRegistText(madmins) == true)
            {
                this.btnAlter.Enabled = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "该用户名可用" + "');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "该用户名已存在" + "');</script>");
            }
        }
    }
}