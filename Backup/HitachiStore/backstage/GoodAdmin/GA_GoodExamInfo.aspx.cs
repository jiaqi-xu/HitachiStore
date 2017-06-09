using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.backstage.GoodAdmin
{
    public partial class GA_GoodExamInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["GoodID"] == null)
                {
                    Response.Redirect("GA_GoodExam.aspx");
                }
                else
                {
                    string lGoodID = Session["GoodID"].ToString();
                    GA Gadmin = new GA();
                    GAController gadim = new GAController();
                    List<Good> GoodInfo = new List<Good>();
                    List<ImgInfo> GoodPictureInfo = new List<ImgInfo>();
                    GoodInfo = gadim.GoodInfo(Gadmin, lGoodID);
                    GoodPictureInfo = gadim.GoodPictureInfo(Gadmin, lGoodID);
                    tbxGoodName.Text = GoodInfo[0].GoodName;
                    tbxGoodPrice.Text = GoodInfo[0].GoodPrice;
                    tbxGoodIncontory.Text = GoodInfo[0].GoodIncentory.ToString();
                    tbxGoodSales.Text = GoodInfo[0].SalesVolume.ToString();
                    tbxGoodImgTitle.Text = GoodPictureInfo[0].ImgTitle;
                    tbxGoodImgUrl.Text = GoodPictureInfo[0].ImgAddress;
                    tbxGoodIncontory.Enabled = false;
                    tbxGoodSales.Enabled = false;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Good lGood = new Good();
            ImgInfo lGoodinfo = new ImgInfo();
            lGood.GoodName = tbxGoodName.Text;
            lGood.GoodPrice = tbxGoodPrice.Text;
            lGood.GoodID = Convert.ToInt32(Session["GoodID"]);
            lGoodinfo.ImgAddress = tbxGoodImgUrl.Text;
            lGoodinfo.ImgTitle = tbxGoodImgTitle.Text;
            lGoodinfo.GoodID = Convert.ToInt32(Session["GoodID"]);
            GA Gadmin = new GA();
            GAController gadmin = new GAController();
            if ( tbxGoodImgTitle.Text == "" || tbxGoodImgUrl.Text == "" || tbxGoodName.Text == "" || tbxGoodPrice.Text == "")
            {
                lbShow.Text = "信息不能为空";
            }
            else
            {
                if (gadmin.UpdateGoodinfo(Gadmin, lGoodinfo, lGood))
                {
                    lbShow.Text = "修改成功";
                }
                else
                {
                    lbShow.Text = "修改失败";
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int lTempGoodID = Convert.ToInt32(Session["GoodID"]);
            Response.Redirect("GoodHtmlEdit2.aspx?GoodID=" + lTempGoodID + "");
        }
        
    }
}