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
 *  1.修改时间：2012-08-20-20-00；2.修改内容：添加iframe实现回传数据库未激活管理员数；
 
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
    public partial class AdminExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["surrentPage"] = 0;
                divide mdv = new divide();
                this.AdminList.DataSource = mdv.AdminShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.AdminList.DataBind();
                SA mSA = new SA();
                int PageSum = mSA.GetPage();
                int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
                ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + PageSum + "页";
            }
        }

        //新建一个高级管理员对象
        SA mSa = new SA();     //输入的管理员
        SA mSaLogin = new SA();    //登录的管理员
        DayBook mDayBook = new DayBook();     //日志表对象
        DayBookController mDayBookController = new DayBookController();     //日志表方法对象
        //实例化高级管理员方法类
        SAController mSaController = new SAController();
        SAController mSaLogincontroller = new SAController();
        AdminController mAdminController = new AdminController();     //管理员方法对象
        /// <summary>
        /// 激活管理员
        /// </summary>
        protected void btnActive_Click(object sender, EventArgs e)
        {
            mSa.UserName = this.tbxUserName.Text;
            mSa.StaffType = (this.dplStaffType.SelectedValue).ToCharArray()[0];
            //判断此用户名是否存在
            if (mSaController.AdminRegistText(mSa) == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "此用户名不存在！" + "');</script> ");
            }
            else
            {
                //判断此用户名是否被激活过
                if (mSaController.AdminStaffType(mSa) != "9")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "此用户名已被激活！" + "');</script> ");
                }
                else
                {
                    if (Session["hUserName"] != null)
                    {
                        mSaLogin.UserName = Session["hUserName"].ToString();
                        mSaController.ActiveAdmin(mSa);
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "激活成功！" + "');</script> ");
                        divide mdv = new divide();
                        //数据重新绑定更新页面数据
                        this.AdminList.DataSource = mdv.AdminShow(Convert.ToInt32(ViewState["surrentPage"]));
                        this.AdminList.DataBind();
                        //在日志表中记录此次操作
                        mDayBook.StaffID = mAdminController.GetStaffID(mSaLogin, mSaLogin.UserName);
                        mDayBook.UserName = mSaLogin.UserName;
                        mDayBook.HandleTime = DateTime.Now.ToString();
                        mDayBook.HandleObjects = "普通管理员：" + mSa.UserName;
                        mDayBook.DayBookVersion = "1";
                        mDayBookController.AddDayBook(mDayBook);
                    }

                }
            }
        }
        /// <summary>
        /// 查询修改管理员信息
        /// </summary>
        protected void btnEnter_Click(object sender, EventArgs e)
        {
            mSa.UserName = this.tbxUserName.Text;

            mSaLogin.UserName = Session["hUserName"].ToString();
            mSa.UserName = this.tbxUserName.Text;

            //判断此用户名是否存在
            if (mSaController.AdminRegistText(mSa) == true)
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "此用户名不存在！" + "');</script> ");
            }
            //判断管理员类型
            else if (mSaController.GetAdminType(mSa, mSa.UserName) == "1")
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "输入的用户名不在查询范围内！" + "');</script> ");
            }
            else
            {
                //导出此管理员所有信息
                Session["UserName"] = this.tbxUserName.Text;
                Response.Redirect("GeneralAdminInfo.aspx");
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
            if (Convert.ToInt32(ViewState["surrentPage"]) < pagesum.PageSumAdmin() - 1)
            {
                ViewState["surrentPage"] = Convert.ToInt32(ViewState["surrentPage"]) + 1;
                divide mdv = new divide();
                this.AdminList.DataSource = mdv.AdminShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.AdminList.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是最后一页！！" + "');</script> ");
            }
            SA mSA = new SA();
            int PageSum = mSA.GetPage();
            int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
            ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + PageSum + "页";

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
                this.AdminList.DataSource = mdv.AdminShow(Convert.ToInt32(ViewState["surrentPage"]));
                this.AdminList.DataBind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "已经是第一页！！" + "');</script> ");
            }
            SA mSA = new SA();
            int PageSum = mSA.GetPage();
            int CurrentPage = Convert.ToInt32(ViewState["surrentPage"]);
            ShowPages.Text = "第" + (CurrentPage + 1).ToString() + "页/共" + PageSum + "页";
        }
        /// <summary>
        /// 删除普通管理员
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void AdminList_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            if (((Label)e.Item.FindControl("lblUserName")).Text != null)
            {
                string gGeneralAdminID = ((Label)e.Item.FindControl("lblUserName")).Text;
                string gStaffType = ((Label)e.Item.FindControl("lblStaffType")).Text;
                string gStaffID = ((Label)e.Item.FindControl("lblStaffID")).Text;
                if (mSaController.RemoveGeneralAdmin(mSa, gGeneralAdminID) == true)
                {
                    if (Session["hUserName"] != null)
                    {
                        if (gStaffType == "订单管理员")
                        {
                            if (mSaController.RemoveOrder(mSa, gStaffID) == true)
                            {
                                mSaLogin.UserName = Session["hUserName"].ToString();
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除成功！" + "');</script> ");
                                //在日志表中记录此次操作
                                mDayBook.StaffID = mAdminController.GetStaffID(mSaLogin, mSaLogin.UserName);
                                mDayBook.UserName = mSaLogin.UserName;
                                mDayBook.HandleTime = DateTime.Now.ToString();
                                mDayBook.HandleObjects = "普通管理员：" + ((Label)e.Item.FindControl("lblUserName")).Text;
                                mDayBook.DayBookVersion = "0";
                                mDayBookController.AddDayBook(mDayBook);
                            }
                        }
                        else
                        {
                            mSaLogin.UserName = Session["hUserName"].ToString();
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除成功！" + "');</script> ");
                            //在日志表中记录此次操作
                            mDayBook.StaffID = mAdminController.GetStaffID(mSaLogin, mSaLogin.UserName);
                            mDayBook.UserName = mSaLogin.UserName;
                            mDayBook.HandleTime = DateTime.Now.ToString();
                            mDayBook.HandleObjects = "普通管理员：" + ((Label)e.Item.FindControl("lblUserName")).Text;
                            mDayBook.DayBookVersion = "0";
                            mDayBookController.AddDayBook(mDayBook);
                        }
                    }

                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除失败！" + "');</script> ");
                }
            }

        }
        /// <summary>
        /// 修改普通管理员信息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void AdminList_EditCommand(object source, DataListCommandEventArgs e)
        {
            if (((Label)e.Item.FindControl("lblUserName")).Text != null)
            {

                string gGeneralAdminID = ((Label)e.Item.FindControl("lblUserName")).Text;
                Session["UserName"] = gGeneralAdminID;
                Response.Redirect("GeneralAdminInfo.aspx");


            }

        }
    }
}