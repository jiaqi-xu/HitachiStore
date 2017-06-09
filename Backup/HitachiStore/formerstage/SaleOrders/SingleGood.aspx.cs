using System;
using System.Collections.Generic;
using System.Web.Services;
using Models;
using Logic;

namespace HitachiStore.formerstage.SaleOrders
{
    public partial class SingleGood : System.Web.UI.Page
    {
        public static int mSingleGoodID;
        public static double mGoodCount;
        public static int mClick = 0;
        public static int lAddressNumber = 0;
        public static int mGoodIncontory;
        public static string mUserName = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ImageAddress"] == null)
                {
                    Response.Redirect("../GoodDisplay/ProductShow.aspx");
                }
                else
                {
                    if (Session["UserName"] == null || Session["UserName"] == "")
                    {
                        mUserName = null;
                    }
                    else
                    {
                        mUserName = Session["UserName"].ToString();
                    }
                    StoreUser User = new StoreUser();
                    StoreUserController User1 = new StoreUserController();
                    string ImageAddress = Request.QueryString["ImageAddress"];
                    imgGoodShow.Src = ImageAddress;
                    ImgInfo imgInfo = new ImgInfo();
                    imgInfo.ImgAddress = ImageAddress;
                    int GoodID = ImgInfo.ImgAddressGetGoodID(imgInfo);
                    SingleGoodInfo singleGoodinfo = new SingleGoodInfo();
                    singleGoodinfo.GoodID = GoodID;
                    int SingleGoodID = SingleGoodInfo.mGoodIDGetSingleGoodID(singleGoodinfo);
                    mSingleGoodID = SingleGoodID;
                    if (GoodID == 0 || GoodID == null)
                    {
                        Response.Redirect("../GoodDisplay/ProductShow.aspx");  
                    }
                    List<Good> goodInfo = new List<Good>();
                    List<ImgInfo> imgTiele = new List<ImgInfo>();
                    Order Goodinfo = new Order();
                    OrderController GoodInfo = new OrderController();
                    goodInfo = GoodInfo.Goodinfo(Goodinfo, GoodID);
                    imgTiele = GoodInfo.GoodTitle(Goodinfo, GoodID);
                    lbGoodPrice.Text = goodInfo[0].GoodPrice;
                    lbGoodID.Text = goodInfo[0].GoodID.ToString();
                    lbFirstName.Text = goodInfo[0].GoodName;
                    lbSecondName.Text = imgTiele[0].ImgTitle;
                    lbMoney.Text = lbGoodPrice.Text;
                    mGoodCount = Convert.ToDouble(lbGoodPrice.Text);
                    mGoodIncontory = goodInfo[0].GoodIncentory;
                    this.linkbtn_FirstName.Text = Good.GoodIDGetFirstClassName(GoodID);
                    this.linkbtn_SecondName.Text = Good.GoodIDGetSecondClassName(GoodID);
                    this.linkbtn_ThirdName.Text = Good.GoodIDGetThirdClassName(GoodID);
                    this.linkbtn_FirstName.PostBackUrl = "~/formerstage/GoodDisplay/FirstClass.aspx?FirstName=" + this.linkbtn_FirstName.Text + "";
                    this.linkbtn_SecondName.PostBackUrl = "~/formerstage/GoodDisplay/SecondClass.aspx?SecondName=" + this.linkbtn_SecondName.Text + "";
                    this.linkbtn_ThirdName.PostBackUrl = "~/formerstage/GoodDisplay/ThirdClass.aspx?ThirdName=" + this.linkbtn_ThirdName.Text + "";
                    this.DataList1.DataSource = SingleGoodInfo.GetSingleGoodInfo(GoodID);
                    DataList1.DataBind();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int lCount = Convert.ToInt32(tbxGoodCount.Text);
            lCount++;
            tbxGoodCount.Text = lCount.ToString();
            string lmomeny = lbGoodPrice.Text;
            double lMomeny = Convert.ToDouble(lmomeny);
            mGoodCount = Convert.ToInt32(lMomeny) * lCount;
            lbMoney.Text = mGoodCount.ToString();
        }

        protected void btnReduce_Click(object sender, EventArgs e)
        {
            int lCount = Convert.ToInt32(tbxGoodCount.Text);
            if (lCount == 1)
            { }
            else if (lCount > 1)
            {
                lCount--;
            }
            tbxGoodCount.Text = lCount.ToString();
            string lmoment = lbGoodPrice.Text;
            double lMoment = Convert.ToDouble(lmoment);
            mGoodCount = Convert.ToInt32(lMoment) * lCount;
            lbMoney.Text = mGoodCount.ToString();
        }

        protected void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (lbUserName.Text == "" || (tbxAddress1.Text == "" && tbxAddress2.Text == "" && tbxAddress3.Text == ""))
                {
                    //lbShow.Text = "请填写信息";
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "请填写信息" + "');</script>");
                }
                else
                {
                    if (tbxUserPhone.Text == "")
                    {
                        //lbShow.Text = "请填写电话";
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "请填写电话" + "');</script>");
                    }
                    else
                    {
                        int lCount = Convert.ToInt32(tbxGoodCount.Text);
                        double lPrice = Convert.ToDouble(lbGoodPrice.Text);
                        string userName = Session["UserName"].ToString();
                        Order order = new Order();
                        OrderController Order = new OrderController();
                        StoreUser user = new StoreUser();
                        StoreUserController user1 = new StoreUserController();
                        user.UserName = userName;
                        user.Address1 = tbxAddress1.Text;
                        user.Address2 = tbxAddress2.Text;
                        user.Address3 = tbxAddress3.Text;
                        user.Phone = tbxUserPhone.Text;
                        lbMoney.Text = mGoodCount.ToString();
                        if (user1.OrderUpdateUserinfo(user))
                        {
                            order.Number = Convert.ToInt32(tbxGoodCount.Text);
                            order.TotalPrices = lCount * lPrice;
                            order.UserID = StoreUser.UserNameGetID(user);
                            order.SingleGoodID = mSingleGoodID;
                            if ((rbtnAddress1.Checked == true && tbxAddress1.Text == ""))
                            {
                                //lbShow.Text = "请选择正确的地址";
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "请选择正确的地址" + "');</script>");
                            }
                            else
                            {
                                if ((rbtnAddress2.Checked == true && tbxAddress2.Text == ""))
                                {
                                    //lbShow.Text = "请选择正确的地址";
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "请选择正确的地址" + "');</script>");
                                }
                                else
                                {
                                    if ((rbtnAddress3.Checked == true && tbxAddress3.Text == ""))
                                    {
                                        //lbShow.Text = "请选择正确的地址";
                                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "请选择正确的地址" + "');</script>");
                                    }
                                    else
                                    {
                                        if (rbtnAddress1.Checked == false && rbtnAddress2.Checked == false && rbtnAddress3.Checked == false)
                                        {
                                            //lbShow.Text = "请选择发货地址";
                                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "请选择发货地址" + "');</script>");
                                        }
                                        else
                                        {
                                            if (mGoodIncontory <= 3 || Convert.ToInt32(tbxGoodCount.Text) > mGoodIncontory)
                                            {
                                                //lbShow.Text = "库存不足";
                                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "库存不足" + "');</script>");
                                            }
                                            else
                                            {
                                                if (Order.CreateOrder(order, lAddressNumber))
                                                {
                                                    //lbShow.Text = "订单发送成功";
                                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "订单发送成功" + "');</script>");
                                                    ModalPopupExtender1.Hide();
                                                }
                                                else
                                                {
                                                    //lbShow.Text = "订单发送失败";
                                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "订单发送失败" + "');</script>");
                                                    ModalPopupExtender1.Hide();
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            //lbShow.Text = "信息提交错误";
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "信息提交错误" + "');</script>");
                        }
                    }
                }
            }
        }
        [WebMethod]
        public static string Add(int count)
        {
            count++;
            return count.ToString();
        }
        [WebMethod]
        public static string Reduce(int count)
        {
            string influence = null;
            if (count == 1)
            {
                influence = count.ToString();
            }
            else if (count > 1)
            {
                count--;
                influence = count.ToString();
            }
            else if (count < 1)
            {
                influence = "1";
            }
            return influence;
        }
        [WebMethod]
        public static string b()
        {
            string a = mUserName;
            return a;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }

        protected void palConfirmInfo_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    //this.Response.Redirect("../UserRegister/Login.aspx");
                }
                else
                {
                    StoreUser User = new StoreUser();
                    StoreUserController User1 = new StoreUserController();
                    string ImageAddress = Request.QueryString["ImageAddress"];
                    ImgInfo imgInfo = new ImgInfo();
                    imgInfo.ImgAddress = ImageAddress;
                    int GoodID = ImgInfo.ImgAddressGetGoodID(imgInfo);
                    SingleGoodInfo singleGoodinfo = new SingleGoodInfo();
                    singleGoodinfo.GoodID = GoodID;
                    int SingleGoodID = SingleGoodInfo.mGoodIDGetSingleGoodID(singleGoodinfo);
                    mSingleGoodID = SingleGoodID;
                    User.UserName = Session["UserName"].ToString();
                    List<StoreUser> order = new List<StoreUser>();
                    order = User1.OrderConfirm(User);
                    lbUserName.Text = order[0].UserTrueName;
                    tbxUserPhone.Text = order[0].Phone;
                    lbMoney.Text = mGoodCount.ToString();
                    if (tbxUserPhone.Text != "")
                    {
                        if (order[0].Address1 != "")
                        {
                            tbxAddress1.Text = order[0].Address1;
                            if (order[0].IsDafult1 == "1")
                            {
                                rbtnAddress1.Checked = true;
                            }
                        }
                        if (order[0].Address2 != "")
                        {
                            tbxAddress2.Text = order[0].Address2;
                            if (order[0].IsDafult2 == "1")
                            {
                                rbtnAddress2.Checked = true;
                            }
                        }
                        if (order[0].Address3 != "")
                        {
                            tbxAddress3.Text = order[0].Address3;
                            if (order[0].IsDafult3 == "1")
                            {
                                rbtnAddress3.Checked = true;
                            }
                        }
                    }
                }
            }
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            //lbShow.Text = "";
            //lbShow.Dispose();
            ModalPopupExtender1.Hide();
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"] == "")
            {
                this.Response.Redirect("../UserRegister/Login.aspx");
            }
            else
            {
                ModalPopupExtender1.Show();
            }
        }
    }
}