using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace HitachiStore.backstage.GoodAdmin
{
    public partial class GoodHtmlEdit2 : System.Web.UI.Page
    {
        public static int mTempGoodID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["GoodID"] != null)
                {
                    mTempGoodID = Convert.ToInt32(Request.QueryString["GoodID"]);
                }
                datalist_exam.DataSource = SingleGoodHtmlEdit.getSingleGoodHtmlEditInfo(mTempGoodID);
                datalist_exam.DataBind();
            }
        }

        protected void datalist_exam_DeleteCommand(object source, DataListCommandEventArgs e)
        {

            TextBox txb = (TextBox)e.Item.FindControl("TextBox2");
            SingleGoodHtmlEdit singleGoodHtmlEdit = new SingleGoodHtmlEdit();
            singleGoodHtmlEdit.EditImg = txb.Text;
            if (singleGoodHtmlEdit.DeleteGoodHtml())
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除成功！" + "');</script> ");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除失败！" + "');</script> ");
            }


        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            //是否允许上传，默认为false
            bool isAllow = false;
            //上传文件保存路径
            string mPath = Server.MapPath("~/GoodImg/");
            //FileLoad控件不为空
            if (this.FileUpload1.HasFile)
            {
                //文件类型
                string fileType = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                //定义允许上传的文件的类型
                string[] allowFile = { ".png", ".gif", ".jpeg", ".jpg" };
                //检查文件的类型是否被允许
                for (int i = 0; i < allowFile.Length; i++)
                {
                    //如果允许
                    if (fileType == allowFile[i])
                    {
                        //允许上传
                        isAllow = true;
                    }
                }
            }
            //如果允许上传
            if (this.EditText.Value != null)
            {
                if (isAllow == true)
                {
                    try
                    {
                        //保存文件到服务器
                        FileUpload1.PostedFile.SaveAs(mPath + FileUpload1.FileName);
                        //提示信息
                        GA gAdmin = new GA();
                        SingleGoodHtmlEdit lSingleGoodHtml = new SingleGoodHtmlEdit();
                        lSingleGoodHtml.GoodID = mTempGoodID;
                        lSingleGoodHtml.EditImg = "~/GoodImg/" + FileUpload1.FileName;
                        lSingleGoodHtml.EditText = this.EditText.Value;
                        if (gAdmin.SaveHtml(lSingleGoodHtml))
                        {
                            this.tip.Text = "添加成功";
                        }
                        else
                        {
                            this.tip.Text = "添加失败";
                        }
                    }
                    catch (HttpException ex)
                    {
                        tip.Text = "上传失败！";
                    }
                }
                else
                {
                    tip.Text = "不可接受的文件类型！";
                }
            }
            else
            {
                tip.Text = "输入说明为空";
            }
        }

        protected void datalist_exam_EditCommand(object source, DataListCommandEventArgs e)
        {
            TextBox txb = (TextBox)e.Item.FindControl("TextBox1");
            TextBox txb2 = (TextBox)e.Item.FindControl("TextBox2");
            SingleGoodHtmlEdit singleGoodHtmlEdit = new SingleGoodHtmlEdit();
            singleGoodHtmlEdit.EditText = txb.Text;
            singleGoodHtmlEdit.EditImg = txb2.Text;
            if (singleGoodHtmlEdit.AlterGoodHtml())
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改成功！" + "');</script> ");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改成功！" + "');</script> ");
            }
        }
    }
}