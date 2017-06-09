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
    public partial class PerInf_myaccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    this.Response.Redirect("../UserRegister/Login.aspx");
                }
                else
                {
                    StoreUser UserCount = new StoreUser();
                    StoreUserController Usercount = new StoreUserController();
                    tbxUserName.Text = Session["UserName"].ToString();
                    UserCount.UserName = Session["UserName"].ToString();
                    string[] ITemp = Usercount.UserCount(UserCount);
                    if (ITemp[0] == "0")
                    {
                        tbxUserType.Text = "普通会员";
                    }
                    else
                    {
                        tbxUserType.Text = "高级会员";
                    }
                    tbxTotalConsum.Text = ITemp[1];
                    tbxTotalConsum.Enabled = false;
                    tbxUserName.Enabled = false;
                    tbxUserType.Enabled = false;
                }
            }
        }

        protected void AlterPwd_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                this.Response.Redirect("../UserRegister/Login.aspx");
            }
            else
            {
                this.Response.Redirect("AlterPassWord.aspx");
            }
        }
    }
}