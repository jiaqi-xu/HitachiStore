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
    public partial class SA_AdminInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SA mSa = new SA();
                SAController mSaController = new SAController();
                //与相应的查询相对应
                if (Session["hUserName"] != null)
                {
                    mSa.UserName = Session["hUserName"].ToString();
                    string[] mStaffInfo = mSaController.FindAdmin(mSa);
                    //显示查到的信息
                    this.txtStaffID.Text = mStaffInfo[0];
                    this.txtName.Text = mStaffInfo[1];
                    this.txtPassword.Text = mStaffInfo[2];
                    this.txtAdministratorClass.Text = mStaffInfo[6];
                    this.txtRegister.Text = mStaffInfo[7];
                    this.txtStaffName.Text = mStaffInfo[8];
                    this.txtIDcardNO.Text = mStaffInfo[12];
                }

            }
        }
        /// <summary>
        ///  高级管理员修改个人信息
        /// </summary>
        protected void btnAlter_Click(object sender, EventArgs e)
        {
            SA mSa = new SA();
            SAController mSaController = new SAController();
            //传进更新后的值 
            mSa.UserName = this.txtStaffName.Text;
            mSa.PassWord = this.txtPassword.Text;
            mSa.TrueName = this.txtName.Text;
            mSa.IdCardNum = this.txtIDcardNO.Text;
            if (mSaController.AlterSaInfo(mSa) == true)
            {
                this.lblCheck.Text = "修改成功！";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改成功！" + "');</script> ");
            }
            else
            {
                this.lblCheck.Text = "修改失败！请重新操作！";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改失败！请重新操作！" + "');</script> ");
            }
        }       
    }
}