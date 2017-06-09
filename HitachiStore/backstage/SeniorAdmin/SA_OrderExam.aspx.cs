/*
 * 1 功能描述：
 *    高级管理员管理管理员相关
 * 2 作者：
 *   徐嘉琪；
   3 创建时间：
 *   2012-08-13-14-30；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   1.修改时间:2012-8-17-20-55；2.修改内容：ID和姓名之间的对应；3.修改人：郝云浩.；
 
 */
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
    public partial class SA_OrderExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["surrentPage"] = 0;
                OA mOA = new OA();
                int PageSum = mOA.GetPages();
                ShowPages.Text = "第" + (Convert.ToInt32(ViewState["surrentPage"]) + 1).ToString() + "页/共" + PageSum + "页";
                divide mdv = new divide();
                this.OrderList.DataSource = mdv.OrderShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.OrderList.DataBind();
            }
        }
        /// <summary>
        /// 查询订单信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Enter_Click(object sender, EventArgs e)
        {
            //实例化高级管理员对象
            SA mSa = new SA();
            //实例化方法对象
            SAController mSacontroller = new SAController();
            //判断输入的EvaluateID是否存在 
            Session["hOrderID"] = this.OrderID.Text;
            if (mSacontroller.ExistOrderID(mSa, this.OrderID.Text) == true && (this.OrderID.Text != null))
            {

                Response.Redirect("SA_OrderInfo.aspx");
            }
            else
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "不存在此订单！请重新输入" + "');</script> ");
            }
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void next_Click(object sender, EventArgs e)
        {
            divide pagesum = new divide();
            if (Convert.ToInt32(ViewState["surrentPage"]) < pagesum.PageSumOrder() - 1)
            {
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) + 1;
                divide mdv = new divide();
                this.OrderList.DataSource = mdv.OrderShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.OrderList.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是最后一页！！" + "');</script> ");
            }
            OA mOA = new OA();
            int PageSum = mOA.GetPages();
            ShowPages.Text = "第" + (Convert.ToInt32(ViewState["surrentPage"]) + 1).ToString() + "页/共" + PageSum + "页";
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void last_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ViewState["surrentPage"]) > 0)
            {
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) - 1;
                divide mdv = new divide();
                this.OrderList.DataSource = mdv.OrderShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.OrderList.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是第一页！！" + "');</script> ");
            }
            OA mOA = new OA();
            int PageSum = mOA.GetPages();
            ShowPages.Text = "第" + (Convert.ToInt32(ViewState["surrentPage"]) + 1).ToString() + "页/共" + PageSum + "页";
        }

        /// <summary>
        /// 查看订单详细信息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void OrderList_EditCommand(object source, DataListCommandEventArgs e)
        {
            Session["hOrderID"] = this.OrderList.DataKeys[e.Item.ItemIndex];
            Response.Redirect("SA_OrderInfo.aspx");
        }
    }
}