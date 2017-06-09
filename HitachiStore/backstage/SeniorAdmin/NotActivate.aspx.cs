using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace HitachiStore.backstage.SeniorAdmin
{
    public partial class NotActivate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SA mSa = new SA();
            int Sum=Convert .ToInt32 (mSa.NotActSum());
            NotActNum.Text = "未激活账号数："+Sum.ToString();
            
        }
    }
}