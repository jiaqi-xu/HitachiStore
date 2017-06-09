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
    public partial class ClothesCity : System.Web.UI.Page
    {
        SecondClassDm mSecondClassDm = new SecondClassDm();
        Good mClothGood = new Good();
        ImgInfo mClothImageInfo = new ImgInfo();
        //ThirdClassDm mThirdClassDm = new ThirdClassDm();
        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定服装城二级类目数据
            this.dlClothes.DataSource = mSecondClassDm.GetSecondClothes();
            this.dlClothes.DataBind();
            //绑定商品图片信息
            mClothGood.FirstClassDmID = "003";
            this.dlistProductShow.DataSource = ImgInfo.GoodIDGetImgInfo(Good.FcIDGetGoodID(mClothGood));
            this.dlistProductShow.DataBind();
            //绑定商品宣传图片信息
            //this.dlBigImg.DataSource = mClothImageInfo.GetBigImgAddress();
            //this.dlBigImg.DataBind();
            BigImg mBigImg=new BigImg();
            string mCityType="服装城";
            BigImgController mBigImgController=new BigImgController();
            this.BigImg.ImageUrl = mBigImgController.GetImgUrl(mBigImg,mCityType);
        }
    }
}