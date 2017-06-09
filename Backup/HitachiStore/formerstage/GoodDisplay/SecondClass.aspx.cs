using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace HitachiStore.formerstage.GoodDisplay
{
    public partial class SecondClass : System.Web.UI.Page
    {
        public static string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            str = Request.QueryString["SecondName"];
            SecondClassDm secondclassdm = new SecondClassDm();
            secondclassdm.SecondClassDmName =str;
            ThirdClassDm thirdclassdm=new ThirdClassDm();
            this.DataList1.DataSource = SecondClassDm.FcShowContent(thirdclassdm, secondclassdm);
            this.DataList1.DataBind();
            GA gAdmin = new GA();
            Good lGood = new Good();
            lGood.SecondClassDmID = gAdmin.ScNameGetID(secondclassdm);
            List<Good> lGoodList = new List<Good>();
            lGoodList= Good.ScIDGetGoodID (lGood );
            List <ImgInfo > lImgInfo=new List<ImgInfo>() ;
            datalist_good.DataSource = ImgInfo.GoodIDGetImgInfo(lGoodList);
            datalist_good.DataBind();
        }
        public string Set()
        {
            return str;
        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            string Tempstr = DataList1.DataKeys[e.Item.ItemIndex].ToString();
            Response.Redirect("../GoodDisplay/ThirdClass.aspx?ThirdName=" + Tempstr + "");
            
        }
    }
}