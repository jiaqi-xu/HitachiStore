using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;

namespace HitachiStore.backstage.GoodAdmin
{
    public partial class GA_GoodExam : System.Web.UI.Page
    {
        public static int mPage = 1;
        public static int mPageCount = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<FirstClassDm> firstlist = new List<FirstClassDm>();
                firstlist = FirstClassDm.Getlist();
                for (int i = 0; i < firstlist.Count; i++)
                {
                    this.ddlFirstClum.Items.Add(new ListItem(firstlist[i].FirstClassDmName, i.ToString()));
                }
                this.ddlFirstClum.Items.Insert(0, new ListItem("请选择一级类目"));
                btnNextpage.Visible = false;
                btnUppage.Visible = false;

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {

        }

        protected void ddlFirstClum_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlSecondClum.Items.Clear();
            List<SecondClassDm> secondlist = new List<SecondClassDm>();
            FirstClassDm firstclum = new FirstClassDm();
            firstclum.FirstClassDmName = this.ddlFirstClum.SelectedItem.Text;
            SecondClassDm secondclum = new SecondClassDm();
            secondlist = FirstClassDm.FcShowContent(firstclum, secondclum);
            for (int i = 0; i < secondlist.Count; i++)
            {
                this.ddlSecondClum.Items.Add(new ListItem(secondlist[i].SecondClassDmName, i.ToString()));
            }
            this.ddlSecondClum.Items.Insert(0, new ListItem("请选择二级类目"));
        }

        protected void ddlSecondClum_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlThirdClum.Items.Clear();
            List<ThirdClassDm> thirdlist = new List<ThirdClassDm>();
            SecondClassDm secondclum = new SecondClassDm();
            secondclum.SecondClassDmName = ddlSecondClum.SelectedItem.Text;
            ThirdClassDm thirdclum = new ThirdClassDm();
            thirdlist = SecondClassDm.FcShowContent(thirdclum, secondclum);
            for (int i = 0; i < thirdlist.Count; i++)
            {
                this.ddlThirdClum.Items.Add(new ListItem(thirdlist[i].ThirdClassDmName, i.ToString()));
            }
            this.ddlThirdClum.Items.Insert(0, new ListItem("选择三级类目"));
        }

        protected void ddlThirdClum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlThirdClum.SelectedItem.Text == "" || ddlThirdClum.SelectedItem.Text == "选择三级类目")
            {
            }
            else
            {
                GA lGoodinfo = new GA();
                ThirdClassDm lThirdName = new ThirdClassDm();
                GAController Gadmin = new GAController();
                lThirdName.ThirdClassDmName = ddlThirdClum.SelectedItem.Text;
                string lThirdID = lGoodinfo.TcNameGetID(lThirdName);
                List<Good> GoodExamInfo = new List<Good>();
                GoodExamInfo = Gadmin.GoodExam(lGoodinfo, lThirdID);
                dlistGoodShow.DataSource = GoodExamInfo;
                dlistGoodShow.DataBind();
                int lPageCount = Gadmin.PageCount(lGoodinfo, lThirdID);
                if (lPageCount % 10 == 0)
                {
                    mPageCount = lPageCount / 10;
                }
                if (lPageCount / 10 < 1)
                {
                    mPageCount = 1;
                }
                if (lPageCount / 10 > 1)
                {
                    int lPage = lPageCount % 10;
                    mPageCount = (lPageCount + (10 - lPage)) / 10;
                }
                if (GoodExamInfo.Count <= 10)
                {
                    btnNextpage.Enabled = false;
                    btnUppage.Enabled = false;
                }
                else
                {
                    btnUppage.Enabled = false;
                }
                btnNextpage.Visible = true;
                btnUppage.Visible = true;
                ShwoPages.Text = "第" + mPage + "页/共" + mPageCount.ToString() + "页";
            }
        }

        protected void dlistGoodShow_EditCommand(object source, DataListCommandEventArgs e)
        {
            Session["GoodID"] = dlistGoodShow.DataKeys[e.Item.ItemIndex];
            Response.Redirect("GA_GoodExamInfo.aspx");
        }

        protected void btnNextpage_Click(object sender, EventArgs e)
        {
            mPage++;
            btnUppage.Enabled = true;
            GA lGoodinfo = new GA();
            ThirdClassDm lThirdName = new ThirdClassDm();
            GAController Gadmin = new GAController();
            lThirdName.ThirdClassDmName = ddlThirdClum.SelectedItem.Text;
            string lThirdID = lGoodinfo.TcNameGetID(lThirdName);
            List<Good> GoodExamInfo = new List<Good>();
            GoodExamInfo = Gadmin.Nextpage(lGoodinfo, lThirdID, mPage);
            dlistGoodShow.DataSource = GoodExamInfo;
            dlistGoodShow.DataBind();
            btnUppage.Enabled = true;
            if (mPage == mPageCount)
            {
                btnNextpage.Enabled = false;
            }
            ShwoPages.Text = "第" + mPage.ToString() + "页/共" + mPageCount.ToString() + "页";
        }

        protected void btnUppage_Click(object sender, EventArgs e)
        {
            mPage--;
            GA lGoodinfo = new GA();
            ThirdClassDm lThirdName = new ThirdClassDm();
            GAController Gadmin = new GAController();
            lThirdName.ThirdClassDmName = ddlThirdClum.SelectedItem.Text;
            string lThirdID = lGoodinfo.TcNameGetID(lThirdName);
            List<Good> GoodExamInfo = new List<Good>();
            GoodExamInfo = Gadmin.Uppage(lGoodinfo, lThirdID, mPage);
            dlistGoodShow.DataSource = GoodExamInfo;
            dlistGoodShow.DataBind();
            btnNextpage.Enabled = true;
            if (mPage == 1)
            {
                btnUppage.Enabled = false;
            }
            ShwoPages.Text = "第" + mPage.ToString() + "页/共" + mPageCount.ToString() + "页";
        }
        
    }
}