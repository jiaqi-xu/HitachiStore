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
    public partial class Circuit_City : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FirstClassDm LFirstName = new FirstClassDm();
            LFirstName.FirstClassDmName = "家用电器";
            List<SecondClassDm> lSecondClassName = new List<SecondClassDm>();
            lSecondClassName = FirstClassDm.FcNameGetScName(LFirstName);
            dlistClassDm.DataSource = lSecondClassName;
            dlistClassDm.DataBind();
            this.dlistProductShow.DataSource = ImgInfo.CircuitCity();
            this.dlistProductShow.DataBind();
            //大图片
            BigImg mBigImg = new BigImg();
            string mCityType = "电器城";
            BigImgController mBigImgController = new BigImgController();
            this.BigImg.ImageUrl = mBigImgController.GetImgUrl(mBigImg, mCityType);
        }
    }
}