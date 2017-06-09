/*
 * 1 功能描述：
 *     评价管理员对评价管理：显示评价信息，删除评价信息
 * 2 作者：
 *   徐嘉琪；
   3 创建时间：
 *   2012-08-09-10-30；
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

namespace HitachiStore.backstage.EvaluationAdmin
{
    public partial class EA_EvaluationInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EA EAadmin = new EA();
            EAController EACon = new EAController();
            if (Session["EA_EvaluateID"] != null)
            {
                EAadmin.StaffID = Convert.ToInt32(Session["EA_EvaluateID"]);
                string[] temp = EACon.EvaluateInfoShow(EAadmin);
                txtEvaluateID.Text = temp[0];
                txtGoodID.Text = temp[1];
                txtEvaluateContent.Text = temp[2];
                txtEvaluateTime.Text = temp[3];
                txtUserID.Text = temp[4];
                switch (temp[5])
                {
                    case "1":
                        lbGoodEvaluateGrade.Text = "好评";
                        break;
                    case "2":
                        lbGoodEvaluateGrade.Text = "中评";
                        break;
                    case "3":
                        lbGoodEvaluateGrade.Text = "差评";
                        break;
                }
            }
        }
        /// <summary>
        /// 删除评价信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAlter_Click(object sender, EventArgs e)
        {
            EA EAadmin = new EA();
            EAController EAconn = new EAController();
            if (Session["EA_EvaluateID"] != null)
            {
                EAadmin.StaffID = Convert.ToInt32(Session["EA_EvaluateID"]);
                if (EAconn.EA_DeleteEvaluate(EAadmin) == true)
                {
                    this.lblCheck.Text = "成功删除该评价！";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "成功删除该评价！" + "');</script> ");
                    this.Response.Redirect("EA_EvaluationExam.aspx");
                }
                else
                {
                    this.lblCheck.Text = "删除评价失败！请重新操作！";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除评价失败！" + "');</script>");
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EA_EvaluationExam.aspx");
        }
    }
}