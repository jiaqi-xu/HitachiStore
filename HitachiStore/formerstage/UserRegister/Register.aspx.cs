/*
 * 1 功能描述：
 *   注册界面；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-03-16-58；
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
using AjaxControlToolkit;
using System.Drawing;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace HitachiStore.formerstage.UserRegister
{
    public partial class Register : System.Web.UI.Page
    {
        StoreUser user1 = new StoreUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            user1.UserName = this.tbxUserName.Text;
        }
        protected void ButtonOk_Click(object sender, EventArgs e)
        {
            ModalPopupExtender2.Hide();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //验证码验证
            if (Session["valid"].ToString().Trim().ToUpper() != tbxSecutity.Text.Trim().ToUpper())
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "验证码错误" + "');</script> ");
            }
            else
            {
                StoreUser newUser = new StoreUser();//创建新实体类对象
                StoreUserController newUserCon = new StoreUserController();//创建新方法类对象
                newUser.UserName = this.tbxUserName.Text;//传参
                newUser.PassWord = this.tbxPassWord.Text;
                newUser.Email = this.tbxEmail.Text;
                newUser.IdCardNum = this.tbxIdcard.Text;
                newUser.UserTrueName = this.tbxTruename.Text;
                if (newUserCon.RegistStoreUser(newUser) == true)
                {
                    UA uAdmin = new UA();
                    uAdmin.SendEmail(newUser);
                    this.Response.Redirect("tip_register.aspx");//页面跳转
                }
                else
                {
                    Response.Write("插入失败");//提示信息
                }
            }
        }
        protected void btnExamUserName_Click(object sender, EventArgs e)
        {
            StoreUser user = new StoreUser();
            user.UserName = this.tbxUserName.Text;
            StoreUserController StoreUserCon = new StoreUserController();
            if (this.tbxUserName.Text != "")
            {
                if (StoreUserCon.StoreUserNameExam(user))
                {
                    this.labUserName.Text = "√";
                    this.labReturnInfo.Text = "用户名可以使用";
                }
                else
                {
                    this.labReturnInfo.Text = "该用户名已经存在";
                }
            }
            else
            {
                this.labReturnInfo.Text = "用户名不能为空";
            }
            this.ModalPopupExtender2.Show();
        }
        [WebMethod]
        public static string UserNameExam(string UserName)
        {
            string input = UserName;
            string partten1 = @"^([a-z0-9A-Z])+$";//格式
            string partten2 = @"^.{5,}$";//长度
            Regex r1 = new Regex(partten1);
            Regex r2 = new Regex(partten2);
            Match m = r1.Match(input);
            Match m2 = r2.Match(input);
            if (string.IsNullOrEmpty(UserName))//判断是否为空
            {
                return "用户名不能为空";
            }
            else
            {
                if (m2.Success)
                {
                    if (m.Success)
                    {
                        return "请验证：";
                    }
                    else
                    {
                        return "格式错误";
                    }
                }
                else
                {
                    return "用户名不得少于五位";
                }
            }
        }
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
                return "密码不能为空";
            }
            else
            {
                if ((m.Success) && (input.Length < 6))
                {
                    return "√";

                }
                if ((m2.Success) && (input.Length < 6))
                {
                    return "√";
                }
                if ((m3.Success) && (input.Length < 6))
                {
                    return "√";
                }
                if ((m.Success) && (m2.Success) && (input.Length >= 6))
                {
                    return "√";
                }
                if ((m.Success) && (m3.Success) && (input.Length >= 6))
                {
                    return "√";
                }
                if ((m2.Success) && (m3.Success) && (input.Length >= 6))
                {
                    return "√";
                }
                if ((m.Success) && (m2.Success) && (m3.Success) && (input.Length >= 6))
                {
                    return "√";
                }
                return "";
            }
        }
        [WebMethod]
        public static string ConfirmPassWordExam(string PassWord, string cPassWord)
        {
            if (string.IsNullOrEmpty(PassWord))
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
                    return "和密码不一致";
                }
            }
        }
        [WebMethod]
        public static string IdcardExam(string Idcard)
        {
            string input = Idcard;
            string pattern = @"[0-9]{15,18}";
            Regex r = new Regex(pattern);
            Match m = r.Match(input);
            if (string.IsNullOrEmpty(input))
            {
                return "身份证号不能为空";
            }
            else
            {
                if (m.Success)
                {
                    return "√";
                }
                else
                {
                    return "输入的身份证号有误";
                }
            }
        }
        [WebMethod]
        public static string TrueNameExam(string Truename)
        {
            if (string.IsNullOrEmpty(Truename))
            {
                return "真实姓名不能为空";
            }
            else
            {
                return "√";
            }
        }
        [WebMethod]
        public static string EmailExam(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return "电子邮箱不能为空";
            }
            else
            {
                string input = Email;
                string pattern = @"^([a-zA-Z0-9])+\@{1}([a-zA-Z0-9])+\.com|cn$";
                Regex r = new Regex(pattern);
                Match m = r.Match(input);
                if (m.Success)
                {
                    return "√";
                }
                else
                {
                    return "格式输入错误";
                }
            }
        }
        [WebMethod]
        public static string ButtonExam(string UserName, string PassWord, string cPassWord, string Idcard, string Email, string Truename)
        {
            if (UserName == "√" && PassWord == "√" && cPassWord == "√" && cPassWord == "√" && Idcard == "√" && Email == "√" && Truename == "√")
            {
                return "1";
            }
            return "";
        }
    }
}