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
    public partial class GeneralAdminInfo : System.Web.UI.Page
    {
        AdminController mAdminController = new AdminController();
        DayBook mDayBook = new DayBook();     //日志表对象
        DayBookController mDayBookController = new DayBookController();     //日志表方法对象
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SA mSa = new SA();  //高级管理员对象
                SAController mSaController = new SAController();
                //与相应的查询相对应
                if (Session["UserName"] != null)
                {
                    mSa.UserName = Session["UserName"].ToString();
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
        /// 高级管理员修改管理员信息
        /// </summary>
        protected void btnAlter_Click(object sender, EventArgs e)
        {

            SA mSa = new SA();
            SAController mSaController = new SAController();
            //传进UserName的值
            if (Session["UserName"] != null)
            {
                mSa.UserName = Session["UserName"].ToString();
                mSa.PassWord = this.txtPassword.Text;
                switch (this.txtAdministratorClass.Text)
                {
                    case "订单管理员":
                        mSa.StaffType = '2';
                        break;
                    case "评价管理员":
                        mSa.StaffType = '3';
                        break;
                    case "用户管理员":
                        mSa.StaffType = '4';
                        break;
                    case "商品管理员":
                        mSa.StaffType = '5';
                        break;
                    default:
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "您输入的管理员类型无效！请重新输入！" + "');</script> ");
                        break;
                }
                if (mSaController.AlterAdmin(mSa) == true)
                {
                    this.lblCheck.Text = "修改成功！";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改成功！" + "');</script> ");
                    //在日志表中记录此次操作
                    mDayBook.StaffID = mAdminController.GetStaffID(mSa, mSa.UserName);
                    mDayBook.UserName = mSa.UserName;
                    mDayBook.HandleTime = DateTime.Now.ToString();
                    mDayBook.HandleObjects = "普通管理员：" + this.txtStaffName.Text;
                    mDayBook.DayBookVersion = "2";
                    mDayBookController.AddDayBook(mDayBook);
                }
                else
                {
                    this.lblCheck.Text = "修改失败！请重新操作！";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改失败！请重新操作！" + "');</script> ");
                }
            }


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminExam.aspx");
        }
    }
}