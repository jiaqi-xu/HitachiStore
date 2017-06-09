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
    public partial class SA_EvaluaInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //实例化高级管理员对象
                SA mSa = new SA();
                //实例化高级管理员方法对象
                SAController mSaController = new SAController();
                //传进EvaluateID
                if (Session["EvaluateID"] != null)
                {
                    this.txtEvaluateID.Text = Session["EvaluateID"].ToString();
                    //得到评价信息
                    string[] mEvaluate = mSaController.GetEvaluateInfo(mSa, this.txtEvaluateID.Text);
                    this.txtEvaluateID.Text = mEvaluate[0];
                    this.txtSingleGoodID.Text = mEvaluate[1];
                    this.txtEvaluateContent.Text = mEvaluate[2];
                    this.txtEvaluateTime.Text = mEvaluate[3];
                    this.txtUserID.Text = mEvaluate[4];
                    this.lbGrade.Text = mEvaluate[5];
                }

            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("SA_EvaluationExam.aspx");
        }
    }
}