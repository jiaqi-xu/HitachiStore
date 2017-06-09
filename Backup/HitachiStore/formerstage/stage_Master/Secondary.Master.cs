using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
namespace HitachiStore.formerstage.stage_Master
{
    public partial class Secondary : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.time.InnerText = DateTime.Now.ToString();
            if (Session["UserName"] != null)
            {
                lbUserName.Text = Session["UserName"].ToString();
                lbLogin.Text = "注销";
                lbShow.Text = "您要注销吗？";
            }
            if (this.lbUserName.Text == "账号")
            {
                this.a_Personinfo.HRef = "../UserRegister/Login.aspx";
                lbLogin.Text = "登陆";
                ModalPopupExtender1.Enabled = false;
                palShow.Visible = false;
            }
            else
            {
                this.a_Personinfo.HRef = "../UserRegister/PerInf_information.aspx";
            }
        }

        protected void OKbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Clear();
            lbLogin.Text = "登陆";
            ModalPopupExtender1.Enabled = false;
            palShow.Visible = false;
        }
    }
}