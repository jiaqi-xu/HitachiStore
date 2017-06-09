using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Models;

namespace HitachiStore.backstage.GoodAdmin
{
    public partial class GA_UpdateClothesCity : System.Web.UI.Page
    {
        public static int mPageCount = 0;
        public static string[] info;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["PageCount"] = 0;
                ViewState["CurrentPage"] = 0;
                GA Gadmin = new GA();
                GAController gadmin = new GAController();
                FirstClassDm firstClassName = new FirstClassDm();
                firstClassName.FirstClassDmName = "服装鞋帽";
                string lfirstClassDmID = Gadmin.FcNameGetID(firstClassName);
                List<ImgInfo> Furniture = new List<ImgInfo>();
                Furniture = gadmin.Furniture(Gadmin, lfirstClassDmID);
                cblistUpdate.DataSource = Furniture;
                for (int i = 0; i < Furniture.Count; i++)
                {
                    cblistUpdate.DataTextField = "ImgTitle";
                    cblistUpdate.DataValueField = "GoodID";
                }
                cblistUpdate.DataBind();
                dlistPictureShow.DataSource = Furniture;
                dlistPictureShow.DataBind();
                if (gadmin.UpdatePictureShow(Gadmin, 2).Count > 1)
                {
                    drpdownlist.DataSource = gadmin.UpdatePictureShow(Gadmin, 2);
                    drpdownlist.DataTextField = "ImgTitle";
                    drpdownlist.DataValueField = "GoodID";
                    drpdownlist.DataBind();
                    drpdownlist.Items.Insert(0, new ListItem("请选择替换商品"));
                }
                int lPageCount = 0;
                lPageCount = Convert.ToInt32(gadmin.Count(Gadmin, lfirstClassDmID));
                mPageCount = lPageCount;
                info = new string[mPageCount];
                if (lPageCount / 10 == 0)
                {
                    lPageCount = lPageCount / 10;
                }
                if (lPageCount / 10 < 1)
                {
                    lPageCount = 1;
                }
                if (lPageCount % 10 > 1)
                {
                    int lPage = lPageCount % 10;
                    lPageCount = (lPageCount + (10 - lPage)) / 10;
                }
                lbPage.Text = "第1页/共 " + lPageCount.ToString() + "页";
                ViewState["PageCount"] = lPageCount;
                if (mPageCount <= 10)
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    btnUpPage.Enabled = false;
                }
            }
        }

        protected void btnUpPage_Click(object sender, EventArgs e)
        {
            int lCurrentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            for (int i = 0; i < cblistUpdate.Items.Count; i++)//读取CheckBoxList 选中的值,保存起来
            {
                if (cblistUpdate.Items[i].Selected)
                {
                    info[(lCurrentPage * 10) + i] = cblistUpdate.Items[i].Value;
                }
            }
            lCurrentPage--;
            if (lCurrentPage == 0)
            {
                btnUpPage.Enabled = false;
            }
            GA Gadmin = new GA();
            GAController gadmin = new GAController();
            FirstClassDm firstClassName = new FirstClassDm();
            firstClassName.FirstClassDmName = "服装";
            string lfirstClassDmID = Gadmin.FcNameGetID(firstClassName);
            List<ImgInfo> Furniture = new List<ImgInfo>();
            Furniture = gadmin.NextPage(Gadmin, lfirstClassDmID, lCurrentPage);
            cblistUpdate.DataSource = Furniture;
            cblistUpdate.DataTextField = "ImgTitle";
            cblistUpdate.DataValueField = "GoodID";
            cblistUpdate.DataBind();
            dlistPictureShow.DataSource = Furniture;
            dlistPictureShow.DataBind();
            btnDownPage.Enabled = true;
            ViewState["CurrentPage"] = lCurrentPage;
            if (lCurrentPage != 0)
            {
                lbPage.Text = "第" + (lCurrentPage + 1) + "页/共 " + ViewState["PageCount"].ToString() + "页";
            }
            else
            {
                lbPage.Text = "第1页/共 " + ViewState["PageCount"].ToString() + "页";
            }
        }

        protected void btnDownPage_Click(object sender, EventArgs e)
        {
            int lCurrentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            for (int i = 0; i < cblistUpdate.Items.Count; i++)//读取CheckBoxList 选中的值,保存起来
            {
                if (cblistUpdate.Items[i].Selected)
                {
                    info[(lCurrentPage * 10) + i] = cblistUpdate.Items[i].Value;
                }
            }
            lCurrentPage++;
            if (lCurrentPage + 1 == Convert.ToInt32(ViewState["PageCount"]))
            {
                btnDownPage.Enabled = false;
            }
            GA Gadmin = new GA();
            GAController gadmin = new GAController();
            FirstClassDm firstClassName = new FirstClassDm();
            firstClassName.FirstClassDmName = "服装";
            string lfirstClassDmID = Gadmin.FcNameGetID(firstClassName);
            List<ImgInfo> Furniture = new List<ImgInfo>();
            Furniture = gadmin.NextPage(Gadmin, lfirstClassDmID, lCurrentPage);
            cblistUpdate.DataSource = Furniture;
            cblistUpdate.DataTextField = "ImgTitle";
            cblistUpdate.DataValueField = "GoodID";
            cblistUpdate.DataBind();
            dlistPictureShow.DataSource = Furniture;
            dlistPictureShow.DataBind();
            btnUpPage.Enabled = true;
            ViewState["CurrentPage"] = lCurrentPage;
            lbPage.Text = "第" + (lCurrentPage + 1) + "页/共 " + ViewState["PageCount"].ToString() + "页";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int lCurrentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            for (int i = 0; i < cblistUpdate.Items.Count; i++)//读取CheckBoxList 选中的值,保存起来
            {
                if (cblistUpdate.Items[i].Selected)
                {
                    info[(lCurrentPage * 10) + i] = cblistUpdate.Items[i].Value;
                }
            }
            GA Gadmin = new GA();
            GAController gadmin = new GAController();
            if (gadmin.UpdateInterface(Gadmin, info, 2))
            {
                lbPrompt.Text = "修改成功";
            }
            if (gadmin.UpdatePictureShow(Gadmin, 1).Count > 1)
            {
                drpdownlist.DataSource = gadmin.UpdatePictureShow(Gadmin, 2);
                drpdownlist.DataTextField = "ImgTitle";
                drpdownlist.DataValueField = "GoodID";
                drpdownlist.DataBind();
                drpdownlist.Items.Insert(0, new ListItem("请选择替换商品"));
            }
        }

        protected void dlistPictureShow_EditCommand(object source, DataListCommandEventArgs e)
        {
            if (tbxUpdate.Text != "" || tbxUpdate.Text != null)
            {
                tbxUpdate.Text = "";
            }
            string url = this.dlistPictureShow.DataKeys[e.Item.ItemIndex].ToString();
            tbxUpdate.Text = url;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (drpdownlist.SelectedItem.Text != "请选择替换商品" || drpdownlist.SelectedItem.Text != "")
            {
                if (tbxUpdate.Text != "" || tbxUpdate.Text != null)
                {
                    string url = tbxUpdate.Text;
                    string GoodID = drpdownlist.Text;
                    GA Gadmin = new GA();
                    GAController gadmin = new GAController();
                    if (gadmin.UpdateProductShow(Gadmin, 2, url, GoodID))
                    {
                        lbPrompt.Text = "修改成功";
                    }
                }
            }
        }
    }
}