using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.backstage.SeniorAdmin
{
    public partial class SA_OrderInfo : System.Web.UI.Page
    {
        string[] arry = new string[13];
        string receive = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["hOrderID"] != null)
                {
                    tbxOrderID.Text = Session["hOrderID"].ToString();

                }
                SaveOrders hOrder = new Models.SaveOrders();
                hOrder.OrderID = tbxOrderID.Text;
                OA mOrder = new OA();
                OAController mController = new OAController();
                arry = mController.SearchOrder(mOrder, hOrder);
                tbxAddress.Text = arry[1];
                tbxCalloffReason.Text = arry[7];
                tbxEndTime.Text = arry[9];
                tbxNumber.Text = arry[2];
                tbxSendTime.Text = arry[8];
                tbxStaffID.Text = arry[10];
                tbxSubmitTime.Text = arry[5];
                tbxToTalPrice.Text = arry[3];
                tbxUserID.Text = arry[0];
                switch (arry[6])
                {
                    case "0":
                        //TradeStatus.SelectedIndex = 0;
                        this.lblTradeStatus.Text = "买家未付款";
                        break;
                    case "1":
                        //TradeStatus.SelectedIndex = 1;
                        this.lblTradeStatus.Text = "买家付款";
                        break;
                    case "2":
                        // TradeStatus.SelectedIndex = 2;
                        this.lblTradeStatus.Text = "商城发货";
                        break;
                    case "3":
                        //TradeStatus.SelectedIndex = 3;
                        this.lblTradeStatus.Text = "交易完成";
                        break;
                }
            }
            Session["hOrder"] = "";
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("SA_OrderExam.aspx");
        }
    }
}