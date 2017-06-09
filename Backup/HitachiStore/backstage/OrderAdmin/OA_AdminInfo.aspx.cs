using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.backstage.OrderAdmin
{
    public partial class OA_AdminInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OAController mOACon = new OAController();
                OA obj = new OA();
                OA OAdmin = new OA();
                if (Session["hUserName"] != null)
                {
                    obj.UserName = Session["hUserName"].ToString();
                    OAdmin = mOACon.ReadOAInfo(obj);

                    txtStaffID.Text = OAdmin.StaffID.ToString();
                    txtPassword.Text = OAdmin.PassWord;
                    tbxUserName.Text = Session["hUserName"].ToString();
                    tbxTrueName.Text = OAdmin.TrueName;
                    tbxIDcardNum.Text = OAdmin.IdCardNum;
                    tbxAddTime.Text = OAdmin.AddTime;

                    char flag = OAdmin.StaffType;
                    switch (flag)
                    {
                        case '1':
                            txtAdministratorClass.Text = "高级管理员";
                            break;
                        case '2':
                            txtAdministratorClass.Text = "订单管理员";
                            break;
                        case '3':
                            txtAdministratorClass.Text = "评价管理员";
                            break;
                        case '4':
                            txtAdministratorClass.Text = "用户管理员";
                            break;
                        case '5':
                            txtAdministratorClass.Text = "商品管理员";
                            break;
                        default:
                            txtAdministratorClass.Text = "系统错误！！";
                            break;


                    }
                }

            }

        }

        protected void btnAlter_Click(object sender, EventArgs e)
        {
            OAController mCon = new OAController();
            OA mOA = new OA();
            if (Session["hUserName"] != null)
            {
                mOA.UserName = Session["hUserName"].ToString();
                if (tbxTrueName.Text != "" && tbxIDcardNum.Text != "" && txtPassword.Text != "")
                {
                    mOA.TrueName = tbxTrueName.Text;

                    mOA.IdCardNum = tbxIDcardNum.Text;

                    mOA.PassWord = txtPassword.Text;
                    if (mCon.AlterInfo(mOA) == true)
                    {
                        tbxTrueName.Text = mOA.TrueName;
                        tbxIDcardNum.Text = mOA.IdCardNum;
                        txtPassword.Text = mOA.PassWord;
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "信息修改成功！！" + "');</script>");
                        this.lblCheck.Text = "修改成功!";
                    }
                    else
                    {
                        this.lblCheck.Text = "修改失败!";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "未做任何修改！！" + "');</script>");
                    }
                }
                else
                {
                    this.lblCheck.Text = "修改信息内容不能为空!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "修改信息内容不能为空！！" + "');</script>");

                }
            }




        }

        
    }
}