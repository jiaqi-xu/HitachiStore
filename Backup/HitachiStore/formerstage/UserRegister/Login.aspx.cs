/*
 * 1 功能描述：
 *   登陆界面；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-03-14-09；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
     郭正肖 2012-8-12-11-00 修改界面
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace HitachiStore.formerstage.UserRegister
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //跳转到注册
        protected void registerBtn_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Register.aspx");
        }
        //登录
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            //验证码对比
            if (Session["valid"].ToString().ToUpper() != tbxSecurity.Text.Trim().ToUpper())
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "验证码无效！" + "');</script> ");
            }
            else
            {
                StoreUser newUser = new StoreUser();
                StoreUserController newUserCon = new StoreUserController();
                newUser.UserName = this.txbUserName.Text;
                newUser.PassWord = this.txbPassWord.Text;
                //判断是否激活
                if (newUserCon.StoreUserConfirm(newUser) == true)
                {
                    //判断是否密码一致
                    if (newUserCon.StoreUserLogin(newUser) == true)
                    {

                        Session["UserName"] = this.txbUserName.Text;
                        Response.Redirect("PerInf_information.aspx");
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "密码错误" + "');</script> ");
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "您的账号没有激活" + "');</script>");
                }
            }
          
        }
    }
}