/*
 * 1 功能描述：
 *   商品管理员个人信息
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-06-10-06；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.backstage.GoodAdmin
{
    public partial class GA_AdminInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["hUserName"] == null)
                {

                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "加载失败" + "');</script>");

                }
                else
                {
                    string username = Session["hUserName"].ToString();
                    GA gAdmin = new GA();
                    gAdmin.UserName = username;
                    GAController gAdminCon = new GAController();
                    gAdminCon.GAGetinfo(gAdmin);
                    this.txtStaffID.Text = gAdmin.StaffID.ToString();
                    this.txtStauffName.Text = gAdmin.UserName;
                    this.txtPassword.Text = gAdmin.PassWord;
                    switch (gAdmin.StaffType.ToString())
                    {
                        case "9":
                            this.txtAdministratorClass.Text = "未激活";
                            break;
                        case "1":
                            this.txtAdministratorClass.Text = "高级管理员";
                            break;
                        case "2":
                            this.txtAdministratorClass.Text = "订单管理员";
                            break;
                        case "3":
                            this.txtAdministratorClass.Text = "评价管理员";
                            break;
                        case "4":
                            this.txtAdministratorClass.Text = "用户管理员";
                            break;
                        case "5":
                            this.txtAdministratorClass.Text = "商品管理员";
                            break;




                    }

                    this.txtName.Text = gAdmin.TrueName;
                    this.txtIDcardNO.Text = gAdmin.IdCardNum;
                    this.txtRegister.Text = gAdmin.AddTime;
                }
            }
        }

        protected void btnAlter_Click(object sender, EventArgs e)
        {
            GA gAdmin = new GA();
            gAdmin.UserName = txtStauffName.Text;
            gAdmin.TrueName = txtName.Text;
            gAdmin.IdCardNum = txtIDcardNO.Text;
            gAdmin.PassWord = txtPassword.Text;
            GAController gAdminCon = new GAController();
            if (gAdminCon.GAAlterinfo(gAdmin) != 0)
            {
                this.lblCheck.Text = "修改成功!";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改成功" + "');</script>");
            }
            else
            {
                this.lblCheck.Text = "修改失败!";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改失败" + "');</script>");
            }
        }
        
    }
}