using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.formerstage.UserRegister
{
    public partial class FindPassWord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            StoreUser User = new StoreUser();
            StoreUserController user = new StoreUserController();
            User.UserName =this.tbxUserName.Text;
            User.Email = this.tbxgEmail. Text;
            User.Idcard = this.tbxIdCard.Text;
            if (Session["valid"].ToString().Trim().ToUpper() != tbxSecurity.Text.ToUpper())
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "验证码错误" + "');</script> ");
            }
            else
            {
                if (user.FindPassword(User))
                {
                    UA uAdmin = new UA();
                    //uAdmin.SendEmail2(User);
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "邮件已发送到您的邮箱请验证" + "');</script> ");
                    Response.Redirect("./Login.aspx");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "请确保所填的所有信息和注册时相同" + "');</script> ");
                }
            }
        }
    }
}