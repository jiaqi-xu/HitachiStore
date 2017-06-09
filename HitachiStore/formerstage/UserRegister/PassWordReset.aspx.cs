using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text.RegularExpressions;
using Models;

namespace HitachiStore.formerstage.UserRegister
{
    public partial class PassWordReset : System.Web.UI.Page
    {
        public static string mUserName;
        protected void Page_Load(object sender, EventArgs e)
        {
            mUserName = Request.QueryString["UserName"];
        }
        //密码格式的限制
        [WebMethod]
        public static string PassWordExam(string PassWord)
        {
            string input = PassWord;
            string pattern = "([a-zA-Z])+";
            string pattern2 = "([0-9])+";
            string pattern3 = @".+";
            Regex r = new Regex(pattern);
            Regex r2 = new Regex(pattern2);
            Regex r3 = new Regex(pattern3);
            Match m = r.Match(input);
            Match m2 = r2.Match(input);
            Match m3 = r3.Match(input);
            if (string.IsNullOrEmpty(input))
            {
                return "请输入密码";
            }
            else
            {
                if ((m.Success) && (input.Length < 6))
                {
                    return "弱";

                }
                if ((m2.Success) && (input.Length < 6))
                {
                    return "弱";
                }
                if ((m3.Success) && (input.Length < 6))
                {
                    return "弱";
                }
                if ((m.Success) && (m2.Success) && (input.Length >= 6))
                {
                    return "中";
                }
                if ((m.Success) && (m3.Success) && (input.Length >= 6))
                {
                    return "中";
                }
                if ((m2.Success) && (m3.Success) && (input.Length >= 6))
                {
                    return "中";
                }
                if ((m.Success) && (m2.Success) && (m3.Success) && (input.Length >= 6))
                {
                    return "强";
                }
                return "";
            }
        }
        //验证在此输入的密码
        [WebMethod]
        public static string ConfirmPassWordExam(string PassWord, string cPassWord)
        {
            if (PassWord == null||PassWord=="")
            {
                return "请先填写密码";
            }
            else
            {
                if (PassWord == cPassWord)
                {
                    return "√";
                }
                else
                {
                    return "两次输入密码不一致";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            StoreUser lUser = new StoreUser();
            lUser.UserName = mUserName;
            lUser.PassWord = this.tbxResetPassword.Text;
            if (lUser.ChangeIdCard())
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "设置成功" + "');</script> ");
                Response.Redirect("./Login.aspx");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "失败" + "');</script> ");                        
            }
        }
    }
}