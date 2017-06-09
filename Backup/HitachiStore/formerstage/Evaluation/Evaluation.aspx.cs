using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;


namespace HitachiStore.formerstage.Evaluation
{
    public partial class Evaluation : System.Web.UI.Page
    {
        static string mOrderID;
        protected void Page_Load(object sender, EventArgs e)
        {
            mOrderID = Request.QueryString["SaveOrderID"];
            txbOrderID.Text = mOrderID;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GoodEvaluate orderEvaluate = new GoodEvaluate();
            EvaluateController orderEvaluate1 = new EvaluateController();
            StoreUser user = new StoreUser();
            user.UserName = Session["UserName"].ToString();
            int userID = StoreUser.UserNameGetID(user);
            orderEvaluate.UserID = userID;
            orderEvaluate.OrderID = mOrderID;
            if (rbtnEvaluateGood.Checked == true)
            {
                orderEvaluate.EvaluateGrade = '1';
                if (txaEvaluateContent.Value == "")
                {
                    lbShowMessage.Text = "请输入评价内容";
                    ModalPopupExtender1.Show();
                }
                else
                {
                    orderEvaluate.EvaluateContent = txaEvaluateContent.Value;
                    if (orderEvaluate1.Evaluat(orderEvaluate))
                    {
                        if (btnSubmit.Text == "返回")
                        {
                            Response.Redirect("../UserRegister/PerInf_myorder.aspx");
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "评价成功" + "');</script>");
                            btnSubmit.Text = "返回";
                        }
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "评价失败" + "');</script>");
                    }
                }
            }
            else
            {
                if (rbtnEvaluateMiddle.Checked == true)
                {
                    orderEvaluate.EvaluateGrade = '2';
                    if (txaEvaluateContent.Value == "")
                    {
                        lbShowMessage.Text = "请输入评价内容";
                        ModalPopupExtender1.Show();
                    }
                    else
                    {
                        orderEvaluate.EvaluateContent = txaEvaluateContent.Value;
                        if (orderEvaluate1.Evaluat(orderEvaluate))
                        {
                            if (btnSubmit.Text == "返回")
                            {
                                Response.Redirect("../UserRegister/PerInf_myorder.aspx");
                            }
                            else
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "评价成功" + "');</script>");
                                btnSubmit.Text = "返回";
                            }
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "评价失败" + "');</script>");
                        }
                    }
                }
                else
                {
                    if (rbtnEvaluateBad.Checked == true)
                    {
                        orderEvaluate.EvaluateGrade = '3';
                        if (txaEvaluateContent.Value == "")
                        {
                            lbShowMessage.Text = "请输入评价内容";
                            ModalPopupExtender1.Show();
                        }
                        else
                        {
                            orderEvaluate.EvaluateContent = txaEvaluateContent.Value;
                            if (orderEvaluate1.Evaluat(orderEvaluate))
                            {
                                if (btnSubmit.Text == "返回")
                                {
                                    Response.Redirect("../UserRegister/PerInf_myorder.aspx");
                                }
                                else
                                {
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "评价成功" + "');</script>");
                                    btnSubmit.Text = "返回";
                                }
                            }
                            else
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "评价失败" + "');</script>");
                            }
                        }
                    }
                    else
                    {
                        lbShowMessage.Text = "请选择评价等级";
                        ModalPopupExtender1.Show();
                    }
                }
            }

        }

        protected void Ok_Click(object sender, EventArgs e)
        {

        }
    }
}