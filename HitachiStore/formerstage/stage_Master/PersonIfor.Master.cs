using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace HitachiStore.formerstage.stage_Master
{
    public partial class PersonIfor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["UserName"] != null)
            {
                lbUserName.Text = Session["UserName"].ToString();
                //lbLogin.Text = "";
                
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Clear();
            this.Response.Redirect("../GoodDisplay/ProductShow.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "")
            {
                Select lselect = new Select();
                int SelectNum = lselect.ClassSelectGood(this.TextBox1.Text);
                if (SelectNum == 0)
                {
                    Response.Redirect("../GoodDisplay/NoGood.aspx");
                }
                if (SelectNum == 1)
                {
                    Response.Redirect("../GoodDisplay/FirstClass.aspx?FirstName=" + this.TextBox1.Text + "");
                }
                if (SelectNum == 2)
                {
                    Response.Redirect("../GoodDisplay/SecondClass.aspx?SecondName=" + this.TextBox1.Text + "");
                }
                if (SelectNum == 3)
                {
                    Response.Redirect("../GoodDisplay/ThirdClass.aspx?ThirdName=" + this.TextBox1.Text + "");
                }
                if (SelectNum == 4)
                {
                    Response.Redirect("../GoodDisplay/FirstSelectGood.aspx?List=" + lselect.CutTbxText1(this.TextBox1.Text) + "");
                }
                if (SelectNum == 5)
                {
                    Response.Redirect("../GoodDisplay/SecondSelectGood.aspx?List=" + lselect.CutTbxText1(this.TextBox1.Text) + "");
                }
                if (SelectNum == 6)
                {
                    Response.Redirect("../GoodDisplay/ThirdSelectGood.aspx?List=" + lselect.CutTbxText1(this.TextBox1.Text) + "");
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language=javascript>alert('" + "搜索条件不能为空" + "');</script>");
            }
        }
    }
}