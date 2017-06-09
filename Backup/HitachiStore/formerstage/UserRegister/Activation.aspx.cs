using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace HitachiStore.formerstage.UserRegister
{
    public partial class Activation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UserName"] == null)
            {
                this.labActivation.Text = "激活失败";
            }
            else
            {
                string lstrUserName = Request.QueryString["UserName"];
                StoreUser lUser = new StoreUser();
                lUser.UserName = lstrUserName;
                lUser.IsConfim = '1';
                if (lUser.Active(lUser))
                {
                    this.labActivation.Text = "激活成功";
                }
                else
                {
                    this.labActivation.Text = "激活失败";
                }
            }
        }
    }
}