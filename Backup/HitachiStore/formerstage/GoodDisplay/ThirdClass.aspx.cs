using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace HitachiStore.formerstage.GoodDisplay
{
    public partial class ThirdClass : System.Web.UI.Page
    {
        public static string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            str = this.Request.QueryString["ThirdName"];
            ThirdClassDm mThirdClassDm = new ThirdClassDm();
            mThirdClassDm.ThirdClassDmName = str;
            DataList1.DataSource = ThirdClassDm.Getlist(str);
            DataList1.DataBind();
            GA gAdmin = new GA();
            Good lGood = new Good();
            lGood.ThirdClassDmID  = gAdmin.TcNameGetID(mThirdClassDm);
            List<Good> lGoodList = new List<Good>();
            lGoodList = Good.TcIDGetGoodID(lGood);
            List<ImgInfo> lImgInfo = new List<ImgInfo>();
            datalist_good.DataSource = ImgInfo.GoodIDGetImgInfo(lGoodList);
            datalist_good.DataBind();
            //得到属性ID
            mThirdClassDm.ThirdClassDmID=mThirdClassDm.GetThirdClassDmId(str).ToString();
            PropertyNameandContent mpnc = new PropertyNameandContent();
            //this.dlProperty.DataSource = mpnc.GetPropertyAll(PropertyClassDm.TcIDGetPoID(mThirdClassDm));
            //this.dlProperty.DataBind(); 
        }
        public string Set()
        {
            return str;
        }
    }
}