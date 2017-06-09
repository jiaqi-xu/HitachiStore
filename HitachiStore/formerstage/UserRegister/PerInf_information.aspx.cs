using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HitachiStore.formerstage.stage_Master;
using Models;
using Logic;
using System.Web.Services;

namespace HitachiStore.formerstage.UserRegister
{
    public partial class PerInf_information : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    this.Response.Redirect("../UserRegister/Login.aspx");
                }
                else
                {
                    btnSubmit.Enabled = false;
                    PerInf_information Infomation = new PerInf_information();
                    StoreUser Userinfo = new StoreUser();
                    StoreUserController Getinfo = new StoreUserController();
                    Userinfo.UserName = Session["UserName"].ToString();
                    string[] lTemp = Getinfo.GetInfo(Userinfo);
                    if (lTemp[11] != null)
                    {
                        tbxTrueName.Text = lTemp[11];
                        tbxTrueName.Enabled = false;
                    }
                    if (lTemp[4] != null)
                    {
                        if (lTemp[4] == "0")
                        {
                            rbtnMen.Checked = true;
                        }
                        else
                        {
                            rbtnWoman.Checked = true;
                        }
                    }
                    if (lTemp[8] == "1")
                    {
                        rbtnAddress1.Checked = true;
                    }
                    else
                    {
                        if (lTemp[9] == "1")
                        {
                            rbtnAddress2.Checked = true;
                        }
                        else
                        {
                            if (lTemp[10] == "1")
                            {
                                rbtnAddress3.Checked = true;
                            }
                        }
                    }
                    tbxAddress1.Text = lTemp[0];
                    tbxAddress2.Text = lTemp[1];
                    tbxAddress3.Text = lTemp[2];
                    tbxNickName.Text = lTemp[3];
                    tbxAge.Text = lTemp[5];
                    tbxPhone.Text = lTemp[6];
                    tbxQQ.Text = lTemp[7];
                }
            }
        }
        /// <summary>
        /// ajax判断
        /// </summary>
        /// <param name="content">年龄</param>
        /// <returns>是否正确</returns>
        [WebMethod]
        public static string a(string content)
        {
            string err = null;
            try
            {
                int a = Convert.ToInt32(content);
            }
            catch
            {
                err = "年龄输入错误";
            }
            if (err == null)
            {
                err = "√";
            }
            return err;
        }
        [WebMethod]
        public static string b(string content)
        {
            string err = null;
            try
            {
                string exam = content;
                if (exam.Length <= 10)
                {
                    int a = Convert.ToInt32(exam.Substring(0, exam.Length));
                }
                if (exam.Length > 10)
                {
                    int b = Convert.ToInt32(exam.Substring(10, 1));
                }
            }
            catch
            {
                err = "电话号码输入错误";
            }
            if (err == null)
            {
                err = "√";
            }
            return err;
        }
        [WebMethod]
        public static string c(string content)
        {
            string err = null;
            try
            {
                string exam = content;
                if (exam.Length <= 10)
                {
                    int a = Convert.ToInt32(exam.Substring(0, exam.Length));
                }
                if (exam.Length > 10)
                {
                    int b = Convert.ToInt32(exam.Substring(10, exam.Length - 10));
                }
            }
            catch
            {
                err = "QQ输入错误";
            }
            if (err == null)
            {
                err = "√";
            }
            return err;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(tbxAge.Text);
                if ((tbxAddress1.Text == "" && tbxAddress3.Text == "" && tbxAddress2.Text == "") || (rbtnAddress1.Checked == false && rbtnAddress2.Checked == false && rbtnAddress3.Checked == false))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "请填写地址并选择默认送货地址" + "');</script> ");
                }
                else
                {
                    if (tbxAddress1.Text != null)
                    {
                        if (tbxAddress2.Text == "" && tbxAddress3.Text == "")
                        {
                            if (rbtnAddress2.Checked == true || rbtnAddress3.Checked == true)
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "默认地址不能为空" + "');</script> ");
                            }
                            else
                            {
                                ModalPopupExtender1.Show();
                            }
                        }
                        else if (tbxAddress2.Text == "")
                        {
                            if (rbtnAddress2.Checked == true)
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "默认地址不能为空" + "');</script> ");
                            }
                            else
                            {
                                ModalPopupExtender1.Show();
                            }
                        }
                        else if (tbxAddress3.Text == "")
                        {
                            if (rbtnAddress3.Checked == true)
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "默认地址不能为空" + "');</script> ");
                            }
                            else
                            {
                                ModalPopupExtender1.Show();
                            }
                        }
                        else
                        {
                            ModalPopupExtender1.Show();
                        }
                    }
                }
            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "年龄输入有误" + "');</script> ");
            }
        }

        protected void OkButton_Click(object sender, EventArgs e)
        {
            StoreUser Userinfo = new StoreUser();
            StoreUserController UserInfo = new StoreUserController();
            //修改信息

            Userinfo.UserName = Session["UserName"].ToString();
            Userinfo.Address1 = tbxAddress1.Text;
            Userinfo.Address2 = tbxAddress2.Text;
            Userinfo.Address3 = tbxAddress3.Text;
            Userinfo.NickName = tbxNickName.Text;
            Userinfo.Phone = tbxPhone.Text;
            Userinfo.QQ = tbxQQ.Text;
            Userinfo.Age = tbxAge.Text;
            if (rbtnAddress1.Checked == true)
            {
                Userinfo.IsDafult1 = "1";
                if (rbtnAddress2.Checked == true)
                {
                    Userinfo.IsDafult2 = "1";
                    if (rbtnAddress3.Checked == true)
                    {
                        Userinfo.IsDafult3 = "1";
                    }
                    else
                    {
                        Userinfo.IsDafult3 = "0";
                    }
                }
                else
                {
                    Userinfo.IsDafult2 = "0";
                    if (rbtnAddress3.Checked == true)
                    {
                        Userinfo.IsDafult3 = "1";
                    }
                    else
                    {
                        Userinfo.IsDafult3 = "0";
                    }
                }
            }
            else
            {
                Userinfo.IsDafult1 = "0";
                if (rbtnAddress2.Checked == true)
                {
                    Userinfo.IsDafult2 = "1";
                    if (rbtnAddress3.Checked == true)
                    {
                        Userinfo.IsDafult3 = "1";
                    }
                    else
                    {
                        Userinfo.IsDafult3 = "0";
                    }
                }
                else
                {
                    Userinfo.IsDafult2 = "0";
                    if (rbtnAddress3.Checked == true)
                    {
                        Userinfo.IsDafult3 = "1";
                    }
                    else
                    {
                        Userinfo.IsDafult3 = "0";
                    }
                }
            }
            if (rbtnMen.Checked == true)
            {
                Userinfo.Sex = "0";
            }
            else
            {
                if (rbtnWoman.Checked == true)
                {
                    Userinfo.Sex = "1";
                }
            }
            if (UserInfo.Update(Userinfo))
            {
                lbtext.Text = "修改成功";
                OkButton.Visible = false;
                CancelButton.Text = "确定";
                ModalPopupExtender1.Show();
            }
            else
            {
                lbtext.Text = "修改失败";
                OkButton.Visible = false;
                CancelButton.Text = "确定";
                ModalPopupExtender1.Show();
            }

        }
        //protected void tbxNickname_TextChanged(object sender, EventArgs e)
        //{

        //    btnSubmit.Enabled = true;
        //}
    }
}