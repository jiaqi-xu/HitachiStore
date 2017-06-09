using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Models;

namespace HitachiStore.backstage.SeniorAdmin
{
    public partial class SA_StoresUserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SA mSa = new SA();
                SAController mSaController = new SAController();
                StoreUser mStoreUser = new StoreUser();
                //传进相对应的UserName
                if (Session["StoreUserName"] != null)
                {
                    mStoreUser.UserName = Session["StoreUserName"].ToString();
                    //得到StoreUser的详细信息
                    string[] mStoreUserInfo = mSaController.GetStoreUserInfo(mSa, mStoreUser.UserName);
                    this.tbxUserName.Text = mStoreUserInfo[0];

                    this.tbxUserID.Text = mStoreUserInfo[2];
                    this.lbStoreType.Text = mStoreUserInfo[3];
                    this.tbxTrueName.Text = mStoreUserInfo[4];
                    this.tbxCreditCard.Text = mStoreUserInfo[5];
                    this.tbxAge.Text = mStoreUserInfo[6];
                    this.tbxSex.Text = mStoreUserInfo[7];
                    this.tbxEmail.Text = mStoreUserInfo[8];
                    this.tbxPhone.Text = mStoreUserInfo[9];
                    this.tbxRegisterTime.Text = mStoreUserInfo[10];
                    this.tbxQQ.Text = mStoreUserInfo[11];
                    this.tbxTotalConsum.Text = mStoreUserInfo[12];


                }

            }
        }
        protected void BtnBack_Click1(object sender, EventArgs e)
        {
            this.Response.Redirect("SA_UserExam.aspx");

        }
    }
}