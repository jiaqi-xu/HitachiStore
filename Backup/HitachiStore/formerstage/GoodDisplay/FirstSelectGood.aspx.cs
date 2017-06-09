using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace HitachiStore.formerstage.GoodDisplay
{
    public partial class FirstSelectGood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Select lselect = new Select();
            String lstr;
            lstr = Request.QueryString["List"];
            this.DataList1.DataSource = lselect.FirstClassSelect(lstr);
            this.DataList1.DataBind();
        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            string Tempstr = DataList1.DataKeys[e.Item.ItemIndex].ToString();
            Response.Redirect("../GoodDisplay/FirstClass.aspx?FirstName=" + Tempstr + "");
        }
    }
}