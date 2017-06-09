using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;
using System.Drawing;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace HitachiStore.formerstage.UserRegister
{
    public partial class AlterPassWord : System.Web.UI.Page
    {
        private static string  PW,Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StoreUser User = new StoreUser();
                StoreUserController IdCard = new StoreUserController();
                User.UserName = Session["UserName"].ToString();
                string a = IdCard.Idcard(User);
                string[] ab = a.Split('m');
                PW = ab[1];
                Id = ab[0];
                if (ab[0].Length == 15)
                {
                    string b = ab[0].Substring(0, 3);
                    string c = ab[0].Substring(11, 3);
                    string d = b + "*********" + c;
                    this.tbxFormerIdCard.Text = d;
                }
                if (ab[0].Length == 18)
                {
                    string b = ab[0].Substring(0, 3);
                    string c = ab[0].Substring(15, 3);
                    string d = b + "************" + c;
                    tbxFormerIdCard.Text = d;
                }
            }
        }
        protected void btnView1Next_Click(object sender, EventArgs e)
        {
            if (this.tbxInputIdcard.Text == Id)
            {
                MultiView1.ActiveViewIndex = 1;
            }
        }

        protected void btnView2Next_Click(object sender, EventArgs e)
        {
            StoreUser User = new StoreUser();
            StoreUserController user = new StoreUserController();
            User.UserName = Session["UserName"].ToString();
            if (tbxPassWord.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "原不能为空" + "');</script> ");
            }
            else
            {
                if (tbxPassWord.Text == PW)
                {
                    User.PassWord = this.tbxAgainPassWord.Text;
                    if (user.ChangeIdCard(User))
                    {
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改成功" + "');</script> ");
                        MultiView1.ActiveViewIndex = 2;
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改失败" + "');</script> ");
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "原密码输入错误" + "');</script> ");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("./PerInf_information.aspx");
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
                    return "可以使用";

                }
                if ((m2.Success) && (input.Length < 6))
                {
                    return "可以使用";
                }
                if ((m3.Success) && (input.Length < 6))
                {
                    return "可以使用";
                }
                if ((m.Success) && (m2.Success) && (input.Length >= 6))
                {
                    return "可以使用";
                }
                if ((m.Success) && (m3.Success) && (input.Length >= 6))
                {
                    return "可以使用";
                }
                if ((m2.Success) && (m3.Success) && (input.Length >= 6))
                {
                    return "可以使用";
                }
                if ((m.Success) && (m2.Success) && (m3.Success) && (input.Length >= 6))
                {
                    return "可以使用";
                }
                return "";
            }
        }
        [WebMethod]
        public static string ConfirmPassWordExam(string PassWord, string cPassWord)
        {
            if (PassWord == null)
            {
                return "请先填写密码";
            }
            else
            {
                if (PassWord == cPassWord)
                {
                    return "可以使用";
                }
                else
                {
                    return "和密码不一致";
                }
            }
        }
    }
}