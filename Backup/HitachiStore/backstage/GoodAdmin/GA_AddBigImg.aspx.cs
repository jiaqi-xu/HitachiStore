using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Models;
using System.Xml.Linq;


namespace HitachiStore.backstage.GoodAdmin
{
    public partial class GA_AddBigImg : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Image1.Visible = false;
                Image2.Visible = false;
                Image3.Visible = false;
            }
        }
        //为首页添加多个图片
        private void SaveFile()
        {
            
            //遍历表单元素
            HttpFileCollection files = HttpContext.Current.Request.Files;
            //状态信息
            string strOut = "<br>上传成功！上传的文件分别是：<hr color=red> <table Style='width:500px>'";
            strOut += "<tr> <td>上传文件名</td></tr>";
            try
            {
                for (int iFile = 0; iFile < files.Count-3; iFile++)
                {
                    //访问单独文件
                    HttpPostedFile postedFile = files[iFile];
                    string fileName, fileExtension;
                    fileName = System.IO.Path.GetFileName(postedFile.FileName);
                    if (fileName != "")
                    {
                        //fileExtension = System.IO.Path.GetExtension(fileName); 
                        strOut += "<tr><td>" + fileName + "</td></tr></table>";
                        //保存文件到服务器
                        postedFile.SaveAs(Server.MapPath("~/image/") + fileName);
                        BigImg mBigImg = new BigImg();
                        BigImgController mBigImgcontroller = new BigImgController();
                        mBigImg.AddTime = DateTime.Now.ToString();
                        mBigImg.ImgUrl = "~/image/" + fileName;
                        mBigImg.BigImgType = "首页";
                        mBigImgcontroller.AddBigImg(mBigImg);
                    }
                    else
                    {
                        strOut = "<br> 请您选择一个文件！";
                    }
                }
                Label3.Text = strOut.ToString();
            }
            catch (Exception Ex)
            {
                Label3.Text = Ex.Message.ToString();
            }
        }
        /// <summary>
        /// 为首页添加大图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
        /// <summary>
        /// 为服装城上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submit1(object sender, EventArgs e)
        {
            //是否允许上传，默认为false
            bool isAllow = false;
            //上传文件保存路径
            string mPath = Server.MapPath("~/image/");
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
            if (isAllow == true)
            {
                try
                {
                    //保存文件到服务器
                    FileUpload1.PostedFile.SaveAs(mPath + FileUpload1.FileName);
                    //提示信息
                    Label4.Text = "上传成功！";
                    //图片显示
                    Image1.ImageUrl = "~/image/" + FileUpload1.FileName;
                    Image1.Visible = true;
                    //添加到数据库
                    BigImg mBigImg = new BigImg();
                    BigImgController mBigImgcontroller = new BigImgController();
                    mBigImg.AddTime = DateTime.Now.ToString();
                    mBigImg.ImgUrl = "~/image/" + FileUpload1.FileName;
                    mBigImg.BigImgType = "服装城";
                    mBigImgcontroller.AddBigImg(mBigImg);
                }
                catch (HttpException ex)
                {
                    Label4.Text = "上传失败！";
                }
            }
            else
            {
                Label4.Text = "不可接受的文件类型！";
            }
        }
        /// <summary>
        /// 为电器城上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submit2(object sender, EventArgs e)
        {
            //是否允许上传，默认为false
            bool isAllow = false;
            //上传文件保存路径
            string mPath = Server.MapPath("~/image/");
            //FileLoad控件不为空
            if (this.FileUpload2.HasFile)
            {
                //文件类型
                string fileType = System.IO.Path.GetExtension(FileUpload2.FileName).ToLower();
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
            if (isAllow == true)
            {
                try
                {
                    //保存文件到服务器
                    FileUpload2.PostedFile.SaveAs(mPath + FileUpload2.FileName);
                    //提示信息
                    Label5.Text = "上传成功！";
                    //图片显示
                    Image2.ImageUrl = "~/image/" + FileUpload2.FileName;
                    Image2.Visible = true;
                    //添加到数据库
                    BigImg mBigImg = new BigImg();
                    BigImgController mBigImgcontroller = new BigImgController();
                    mBigImg.AddTime = DateTime.Now.ToString();
                    mBigImg.ImgUrl = "~/image/" + FileUpload2.FileName;
                    mBigImg.BigImgType = "电器城";
                    mBigImgcontroller.AddBigImg(mBigImg);
                }
                catch (HttpException ex)
                {
                    Label5.Text = "上传失败！";
                }
            }
            else
            {
                Label5.Text = "不可接受的文件类型！";
            }
        }
        /// <summary>
        /// 为家具城上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submit3(object sender, EventArgs e)
        {
            //是否允许上传，默认为false
            bool isAllow = false;
            //上传文件保存路径
            string mPath = Server.MapPath("~/image/");
            //FileLoad控件不为空
            if (this.FileUpload3.HasFile)
            {
                //文件类型
                string fileType = System.IO.Path.GetExtension(FileUpload3.FileName).ToLower();
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
            if (isAllow == true)
            {
                try
                {
                    //保存文件到服务器
                    FileUpload3.PostedFile.SaveAs(mPath + FileUpload3.FileName);
                    //提示信息
                    Label6.Text = "上传成功！";
                    //图片显示
                    Image3.ImageUrl = "~/image/" + FileUpload3.FileName;
                    Image3.Visible = true;
                    //添加到数据库
                    BigImg mBigImg = new BigImg();
                    BigImgController mBigImgcontroller = new BigImgController();
                    mBigImg.AddTime = DateTime.Now.ToString();
                    mBigImg.ImgUrl = "~/image/" + FileUpload3.FileName;
                    mBigImg.BigImgType = "家具城";
                    mBigImgcontroller.AddBigImg(mBigImg);
                }
                catch (HttpException ex)
                {
                    Label6.Text = "上传失败！";
                }
            }
            else
            {
                Label6.Text = "不可接受的文件类型！";
            }
        }
    }
}