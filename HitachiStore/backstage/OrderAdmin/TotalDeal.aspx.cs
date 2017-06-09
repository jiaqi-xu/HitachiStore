using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.backstage.OrderAdmin
{
    public partial class TotalDeal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OA mOA = new OA();
            int Sum=mOA.GetNotDeal();
            LTotalDeal.Text ="未处理订单数为："+ Sum.ToString ();

        }
    }
}