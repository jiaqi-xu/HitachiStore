using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.formerstage.OrderExam
{
    public partial class CancelOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["SaveOrderID"] == null)
            {
                Response.Redirect("../UserRegister/PerInf_myorder.aspx");
            }
            else
            {
                string str = Request.QueryString["SaveOrderID"];//获取OrderID
                StoreUser User = new StoreUser();
                StoreUserController user = new StoreUserController();
                if (txareCancleReson.Value != "")
                {
                    if (user.cancelOrder(User, txareCancleReson.Value, str))
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "取消理由提交成功" + "');</script>");
                        CancleBtn.Text = "返回";
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "取消理由提交失败" + "');</script>");
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "请输入取消理由" + "');</script>");
                }
            }
        }

        protected void CancleBtn_Click(object sender, EventArgs e)
        {
            if (CancleBtn.Text == "返回")
            {
                this.Response.Redirect("../UserRegister/PerInf_myorder.aspx");
            }
        }
    }
}