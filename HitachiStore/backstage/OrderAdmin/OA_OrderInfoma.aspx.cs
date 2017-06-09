using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Models;

namespace HitachiStore.backstage.OrderAdmin
{
    public partial class OA_OrderInfoma : System.Web.UI.Page
    {
        string[] arry = new string[13];
        string receive = "";
        string StrUserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = Request.QueryString["OrderID"];
            receive = str;

            if (!IsPostBack)
            {
                if (Session["hOrderID"] != null)
                {
                    tbxOrderID.Text = Session["hOrderID"].ToString();

                }
                else
                {
                    tbxOrderID.Text = str;
                }


                SaveOrders hOrder = new Models.SaveOrders();
                OA mOrder = new OA();
                OAController mController = new OAController();
                hOrder.OrderID = tbxOrderID.Text;
                arry = mController.SearchOrder(mOrder, hOrder);

                if (arry[6] == "3")
                {

                    TradeStatus.Enabled = false;

                }
                hOrder.IsDeal = arry[12];
                if (hOrder.IsDeal == "2")
                {
                    this.TradeStatus.Enabled = false;
                }

                tbxAddress.Text = arry[1];
                tbxCalloffReason.Text = arry[7];
                tbxEndTime.Text = arry[9];
                tbxNumber.Text = arry[2];
                tbxSendTime.Text = arry[8];
                tbxStaffID.Text = arry[10];
                tbxSubmitTime.Text = arry[5];
                tbxToTalPrice.Text = arry[3];
                tbxUserID.Text = arry[0];
                Session["SingleGoodID"] = arry[4];
                switch (arry[6])
                {
                    case "0":
                        TradeStatus.SelectedIndex = 0;
                        break;
                    case "1":
                        TradeStatus.SelectedIndex = 1;
                        break;
                    case "2":
                        TradeStatus.SelectedIndex = 2;
                        break;
                    case "3":
                        TradeStatus.SelectedIndex = 3;
                        break;


                }
                Session["hOrder"] = "";



            }






        }
        static string Status = "0";
        protected void Alter_Click(object sender, EventArgs e)
        {

            if (Session["hUserName"] != null)
            {
                StrUserName = Session["hUserName"].ToString();
            }
            OA m = new OA();
            SaveOrders status = new SaveOrders();
            Admins madmin = new Admins();
            madmin.UserName = StrUserName;
            madmin.StaffID = Admins.UserNameGetStaffID(madmin);
            status.StaffID = madmin.StaffID;
            status.TradeStatus = Convert.ToChar(Status);

            if (Status == "3")
            {
                TradeStatus.Enabled = false;
            }
            if (Session["hOrderID"] != null)
            {
                tbxOrderID.Text = Session["hOrderID"].ToString();
            }
            else
            {
                tbxOrderID.Text = receive;
            }
            status.OrderID = tbxOrderID.Text;

            if (tbxNumber.Text == null)
            {
                tbxNumber.Text = "0";
            }
            else
            {
                status.Number = Convert.ToInt32(tbxNumber.Text);
            }
            status.Number = Convert.ToInt32(tbxNumber.Text);
            status.SingleGoodID = Convert.ToInt32(Session["SingleGoodID"]);
            status.IsDeal = Deal;
            OAController mCon = new OAController();
            if (Status == "3")
            {
                status.TotalPrices = Convert.ToDouble(tbxToTalPrice.Text);
                status.ReceiveStr = tbxUserID.Text;

                //将用户用户名传入

            }



            if (mCon.TradeStatus(m, status) && mCon.GetTimeCon(m, status))
            {
                Tip.Text = "修改成功";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "修改成功！！" + "');</script>");
            }
            else
            {

                Tip.Text = "修改失败";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "修改失败！！" + "');</script>");
            }
            //读取数据代码
            {
                if (Session["hOrderID"] != null)
                {
                    tbxOrderID.Text = Session["hOrderID"].ToString();
                }
                else
                {
                    tbxOrderID.Text = receive;
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
                        TradeStatus.SelectedIndex = 0;
                        break;
                    case "1":
                        TradeStatus.SelectedIndex = 1;
                        break;
                    case "2":
                        TradeStatus.SelectedIndex = 2;
                        break;
                    case "3":
                        TradeStatus.SelectedIndex = 3;
                        break;
                }
            }

        }
        static string Deal = "0";
        protected void TradeStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Status = TradeStatus.SelectedValue;
            Deal = "1";




        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            SaveOrders mSave = new SaveOrders();
            mSave.OrderID = tbxOrderID.Text;
            OAController mController = new OAController();
            OA mOA = new OA();
            arry = mController.SearchOrder(mOA, mSave);
            if (arry[12] == "2")
            {
                if (mOA.DeleteOrder(mSave))
                {
                    Tip.Text = "删除成功";
                    Response.Redirect("OA_OrderExam.aspx");

                }
                else
                {
                    Tip.Text = "删除失败";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "删除失败！！" + "');</script>");
                }
            }
            else
            {
                Tip.Text = "订单未取消，不能删除";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "删除失败！！" + "');</script>");
            }


        }

        
    }
}