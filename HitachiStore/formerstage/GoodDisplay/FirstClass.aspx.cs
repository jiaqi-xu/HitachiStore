using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace HitachiStore.formerstage.GoodDisplay
{
    public partial class FirstClass : System.Web.UI.Page
    {
        public static string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            str = Request.QueryString["FirstName"];
            FirstClassDm first=new FirstClassDm();
            first.FirstClassDmName = str;
            this.DataList1.DataSource = FirstClassDm.FcNameGetScName(first);
            this.DataList1.DataBind();
            GA gAdmin = new GA();
            Good lGood = new Good();
            lGood.FirstClassDmID = gAdmin.FcNameGetID(first);
            List<Good> lGoodList = new List<Good>();
            lGoodList= Good.FcIDGetGoodID(lGood);
            List<ImgInfo> lImgInfo = new List<ImgInfo>();
            this.datalist_good.DataSource = ImgInfo.GoodIDGetImgInfo(lGoodList);
            this.datalist_good.DataBind();

        }
        public string Set()
        {
            return str;
        }
        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            string Tempstr=DataList1.DataKeys[e.Item.ItemIndex].ToString();
            Response.Redirect("../GoodDisplay/SecondClass.aspx?SecondName=" + Tempstr + "");
        }

        protected void datalist_good_DeleteCommand(object source, DataListCommandEventArgs e)
        {

        } 

    }
}