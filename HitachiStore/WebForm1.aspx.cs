/*
 * 1 功能描述
 * 
 * 2 作者

 * 
 * 3 创建时间
 * 
 * 4 完成时间
 * 
 * 5 修改记录 1）修改原因 2）修改内容 3）修改时间

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Models;
namespace HitachiStore
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Logic.UserController Usecon = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            Models.User firstUser = new User();
            firstUser.UserName = fefw.Text;
            firstUser.PassWord=TextBox1.Text;
            //Usecon.RegisterUser(firstUser);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}