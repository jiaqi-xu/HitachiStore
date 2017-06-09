/*
 * 1 功能描述：
 *    登陆界面的实现，实现管理员登陆后对应界面的跳转.
 * 2 作者：
 *   郝云浩；
   3 创建时间：
 *   2012-08-04-15-15；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *  1.修改时间:2012-8-6-9-30；2.修改内容：添加用户名验证；3.修改人：徐嘉琪.
    2.修改时间：2012-8-6-10-00；2.修改内容：加传参容器；3.修改人：郭正肖.
 *  3.修改时间：2012-8-10-9-00；2.修改内容：弹出层注册。实现注册功能和验证码功能；3.修改人：郝云浩.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;
using System.Drawing;

namespace HitachiStore.backstage.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Admins admin = new Admins();

            admin.UserName = this.TbxUserName.Text;
            Session["hUserName"] = this.TbxUserName.Text;//将用户名存入容器中
            Session["hStaffID"] = Admins.UserNameGetStaffID(admin);
        }

        /// <summary>
        /// 登陆及其验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoginImBtn_Click(object sender, ImageClickEventArgs e)
        {

            Text text = new Text();
            Admins admin = new Admins();
            AdminController admincon = new AdminController();

            if (this.TbxPassWord.Text != "" && this.TbxUserName.Text != "")
            {
                admin.UserName = this.TbxUserName.Text;
                admin.PassWord = this.TbxPassWord.Text;
                //调用Model类中的LoginText方法，将管理员的用户名和密码进行验证，完成登陆验证。

                bool flag1 = admincon.AdminLoginText(admin);

                //调用Model类中的StaffType方法，判断管理员类型及权限。

                string flag2 = admincon.AdminStaffType(admin);

                //判断登陆的用户名是否是激活状态。。
                if (flag2 == "9")
                {
                    if (rbnUA.Checked == false && rbnSA.Checked == false && rbnOA.Checked == false && rbnGA.Checked == false && rbnEA.Checked == false)
                    {
                        LoginTip.Text = "请选择权限";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "请选择权限" + "');</script>");
                    }
                    else
                    {
                        LoginTip.Text = "用户名未激活";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "该用户名未激活，请联系高级管理员" + "');</script>");
                    }
                }
                else
                {
                    //判断管理员权限和radiobutton的选择是否是对应关系，不对应则不能登陆。。

                    if (rbnSA.Checked == true && rbnSA.Text == flag2)
                    {
                        if (flag1 == true)
                        {
                            Response.Redirect("~/backstage/SeniorAdmin/SA_SubTree.aspx");
                        }
                        else
                        {
                            LoginTip.Text = "用户名或密码错误";
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "用户名或密码错误" + "');</script>");
                        }
                    }
                    else if (rbnEA.Checked == true && rbnEA.Text == flag2)
                    {
                        if (flag1 == true)
                        {
                            Response.Redirect("~/backstage/EvaluationAdmin/EA_SubTree.aspx");
                        }
                        else
                        {
                            LoginTip.Text = "用户名或密码错误";
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "用户名或密码错误" + "');</script>");
                        }
                    }
                    else if (rbnGA.Checked == true && rbnGA.Text == flag2)
                    {
                        if (flag1 == true)
                        {
                            Response.Redirect("~/backstage/GoodAdmin/GA_SubTree.aspx");
                        }
                        else
                        {
                            LoginTip.Text = "用户名或密码错误";
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "用户名或密码错误" + "');</script>");
                        }
                    }
                    else if (rbnOA.Checked == true && rbnOA.Text == flag2)
                    {
                        if (flag1 == true)
                        {
                            Response.Redirect("~/backstage/OrderAdmin/OA_SubTree.aspx");

                        }
                        else
                        {
                            LoginTip.Text = "用户名或密码错误";
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "用户名或密码错误" + "');</script>");
                        }
                    }

                    else if (rbnUA.Checked == true && rbnUA.Text == flag2)
                    {
                        if (flag1 == true)
                        {
                            Response.Redirect("~/backstage/UserAdmin/UA_SubTree.aspx");
                        }
                        else
                        {
                            LoginTip.Text = "用户名或密码错误";
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "用户名或密码错误" + "');</script>");
                        }
                    }
                    else
                    {
                        LoginTip.Text = "权限不符";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script language='javascript'>alert('" + "权限不符" + "');</script>");
                    }
                }
            }
            else
            {
                LoginTip.Text = "登陆信息不能为空";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "登陆信息不能为空！！" + "');</script>");
            }




        }

        protected void Register1_Click(object sender, EventArgs e)
        {
            da.Show();
        }
        /// <summary>
        /// 比对验证码
        /// </summary>
        /// <returns></returns>

        public bool CheckValidate()
        {
            if (tbxValidate.Text != "")
            {
                if (tbxValidate.Text.Trim().ToUpper() == Session["Valid"].ToString().ToUpper())
                {

                    return true;
                }
                else
                {

                    return false;

                }
            }
            else
            {

                return false;
            }


        }
        /// <summary>
        /// 验证注册时，用户名是否重复，此方法需要调用Model中的类
        /// </summary>

        protected void BtnCheckUName_Click(object sender, ImageClickEventArgs e)
        {
            if (tbxRUserName.Text != "")
            {
                Admins madmins = new Admins();
                AdminController mAdminController = new AdminController();
                madmins.UserName = tbxRUserName.Text;

                if (mAdminController.AdminRegistText(madmins) == true)
                {


                    Tip.Text = "用户名可用";


                }
                else
                {
                    Tip.Text = "用户名不可用";
                }

            }
            else
            {
                Tip.Text = "用户名不能为空";
            }




        }
        /// <summary>
        /// 提交注册信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnRegister_Click(object sender, ImageClickEventArgs e)
        {
            if ((tbxRUserName.Text != "") && (tbxRPassWord.Text != "") && (tbxRPassWord.Text != "") && (tbxRPassWord2.Text != "") && (tbxIDCardNum.Text != ""))
            {
                if (tbxRPassWord.Text == tbxRPassWord2.Text)
                {
                    // 新建一个管理员对象
                    Admins madmins = new Admins();
                    //给新建的管理员对象的属性传参            
                    madmins.UserName = tbxRUserName.Text;
                    madmins.PassWord = tbxRPassWord.Text;
                    madmins.TrueName = tbxTrueName.Text;
                    madmins.IdCardNum = tbxIDCardNum.Text;
                    if (this.male.Checked == true)
                    {
                        madmins.Sex = '0';
                    }
                    else
                    {
                        madmins.Sex = '1';
                    }
                    //实例化管理员方法类
                    AdminController mAdminController = new AdminController();
                    //判断是否注册成功
                    try
                    {
                        if (CheckValidate())
                        {
                            if ((mAdminController.AdminRegistText(madmins) == true))
                            {
                                if ((mAdminController.RegisterAdmin(madmins) == true))
                                {
                                    try
                                    {
                                        //跳转到另一页面
                                        this.Response.Redirect("AdminRegisterSuccess.htm");
                                    }
                                    catch
                                    {
                                    }
                                }
                                //注册失败提示信息并将其已填内容置空
                                else
                                {
                                    Tip.Text = "注册失败";
                                    this.tbxTrueName.Text = null;
                                    this.tbxRPassWord = null;
                                    this.tbxRUserName = null;
                                    this.tbxIDCardNum.Text = null;
                                    tbxValidate.Text = null;
                                }

                            }
                            else
                            {
                                Tip.Text = "用户名不可用";
                                this.tbxTrueName.Text = null;
                                this.tbxRPassWord = null;
                                this.tbxRUserName = null;
                                this.tbxIDCardNum.Text = null;
                                tbxValidate.Text = null;
                            }


                        }
                        else
                        {
                            Tip.Text = "验证码错误";

                        }

                    }
                    catch (Exception h)
                    {
                        throw h;
                        //发布时用以下注释掉得异常处理
                        //this.Response.Redirect("ExceptionHandler.htm");
                    }
                }
                else
                {
                    Tip.Text = "两次密码不一致";
                }

            }
            else
            {
                Tip.Text = "注册信息不能为空";
            }

        }

    }
}