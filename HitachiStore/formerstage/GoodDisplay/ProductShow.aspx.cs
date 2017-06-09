using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.formerstage.GoodDisplay
{
    public partial class ProductShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ImgInfo> adressList = new List<ImgInfo>();
                adressList = ImgInfo.HomePageProductShow();
                dlistProductShow.DataSource = adressList;
                dlistProductShow.DataBind();
                //商城大图片
                BigImg mBigImg = new BigImg();
                BigImgController mBigImgController = new BigImgController();
                string[] mUrl= mBigImgController.GetFirstBigImg(mBigImg);
                this.a1.HRef = mUrl[0];
                this.a2.HRef = mUrl[1];
                this.a3.HRef = mUrl[2];
                this.a4.HRef = mUrl[3];
                this.a5.HRef = mUrl[4];
                //this.img6.Src = mUrl[0];
                
            }
        }
    }
}