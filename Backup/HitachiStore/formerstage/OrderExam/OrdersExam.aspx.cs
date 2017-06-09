using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;
using System.Data;

namespace HitachiStore.formerstage.OrderExam
{
    public partial class OrdersExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["SaveOrderID"] == null)
            {
                Response.Redirect("../UserRegister/PerInf_myorder.aspx");
            }
            else
            {
                string str = Request.QueryString["SaveOrderID"];
                StoreUser User = new StoreUser();
                StoreUserController user = new StoreUserController();
                Order orderExam = new Order();
                OrderController orderexam = new OrderController();
                string[] orderInfo = user.OrderInfo(User, str);
                tbxUserName.Text = orderInfo[1];
                tbxPhoneNumber.Text = orderInfo[2];
                tbxEmail.Text = orderInfo[0];
                tbxReveiveAddress.Text = orderInfo[3];
                orderExam.OrderID = str;
                OrderLisstview.DataSource = orderexam.OrderExam(orderExam);
                OrderLisstview.DataBind();
            }
        }
        public string Set(object lMoney,object lCount )
        {
            int money = Convert.ToInt32(lMoney);
            int count = (int)lCount;
            TotalPrice.Text = (money * count).ToString();
            return lMoney.ToString();
        }

        protected void ConfirmBtn_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("../UserRegister/PerInf_myorder.aspx");
        }
    }
}