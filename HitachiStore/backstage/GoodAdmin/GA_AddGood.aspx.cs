/*
 * 1 功能描述：
 *   商品添加界面类；
 * 2 作者：
 *   
   3 创建时间：
 *   2012-08-06-15-48；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 *   郭正肖  2012-8-20 添加该界面的功能
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Logic;
using System.Data;

namespace HitachiStore.backstage.GoodAdmin
{
    public partial class GA_AddGood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<FirstClassDm> firstlist = new List<FirstClassDm>();
                firstlist = FirstClassDm.Getlist();
                for (int i = 0; i < firstlist.Count; i++)
                {
                    this.dplFirstClum.Items.Add(new ListItem(firstlist[i].FirstClassDmName, i.ToString()));
                }
                this.dplFirstClum.Items.Insert(0, new ListItem("选择一级类目"));
            }


        }

        protected void dplFirstClum_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dplSecondClum.Items.Clear();
            List<SecondClassDm> secondlist = new List<SecondClassDm>();
            FirstClassDm firstclum = new FirstClassDm();
            firstclum.FirstClassDmName = dplFirstClum.SelectedItem.Text;
            SecondClassDm secondclum = new SecondClassDm();
            secondlist = FirstClassDm.FcShowContent(firstclum, secondclum);
            for (int i = 0; i < secondlist.Count; i++)
            {
                this.dplSecondClum.Items.Add(new ListItem(secondlist[i].SecondClassDmName, i.ToString()));
            }
            this.dplSecondClum.Items.Insert(0, new ListItem("选择二级类目"));
        }

        protected void dplSecondClum_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dplThirdClum.Items.Clear();
            List<ThirdClassDm> thirdlist = new List<ThirdClassDm>();
            SecondClassDm secondclum = new SecondClassDm();
            secondclum.SecondClassDmName = dplSecondClum.SelectedItem.Text;
            ThirdClassDm thirdclum = new ThirdClassDm();
            thirdlist = SecondClassDm.FcShowContent(thirdclum, secondclum);
            for (int i = 0; i < thirdlist.Count; i++)
            {
                this.dplThirdClum.Items.Add(new ListItem(thirdlist[i].ThirdClassDmName, i.ToString()));
            }
            this.dplThirdClum.Items.Insert(0, new ListItem("选择三级类目"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (lbl_tip.Text == "")
            {

                this.ModalPopup2.Show();
            }
            else
            {
                lbl_tip.Text = "请先选择三级类目";
                this.ModalPopup2.Show();
            }
        }

        protected void dplThirdClum_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThirdClassDm third = new ThirdClassDm();
            third.ThirdClassDmName = dplThirdClum.SelectedItem.Text;
            GA gAdmin = new GA();
            third.ThirdClassDmID = gAdmin.TcNameGetID(third);
            PropertyClassDm propertyclass = new PropertyClassDm();
            List<Property> prolist = new List<Property>();
            prolist = PropertyClassDm.TcIDGetPoID(third);
            DataList1.DataSource = Property.PoIDGetPoNameList(prolist);
            DataList1.DataBind();
            for (int i = 0; i < prolist.Count; i++)
            {
                PropertyContent proCont = new PropertyContent();
                proCont.PropertyID = prolist[i].PropertyID;
                List<PropertyContent> proConList = new List<PropertyContent>();
                proConList = PropertyContent.PoIDGetPcName(proCont);
                DropDownList ddl = (DropDownList)DataList1.Items[i].FindControl("dpl_PropertyContent");
                for (int j = 0; j < proConList.Count; j++)
                {

                    ddl.Items.Add(new ListItem(proConList[j].PropertyContentName, j.ToString()));

                }
                ddl.Items.Insert(0, new ListItem("选择属性内容"));
                ddl.DataBind();
            }
            this.lbl_tip.Text = "";

        }
        /// <summary>
        /// 将LIST变成DATATABLE
        /// </summary>
        /// <param name="proConList"></param>
        /// <returns></returns>
        private DataTable ListConvertDataTable(List<PropertyContent> proConList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PropertyContentName");
            PropertyContent proCont = new PropertyContent();
            if (proConList != null || proConList.Count > 0)
            {
                for (int i = 0; i < proConList.Count; i++)
                {
                    proCont = proConList[i];
                    DataRow dr = dt.NewRow();
                    dr["PropertyContentName"] = proCont.PropertyContentName;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        /// <summary>
        /// Dropdownlist数据源
        /// </summary>
        private DataTable _DropDownSource = null;
        public DataTable DropDownSource
        {
            get
            {
                return _DropDownSource;
            }
            set
            {
                _DropDownSource = value;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (this.tbxName.Text != "" && this.tbxCount.Text != "" && this.tbxPicexplain.Text != "" && this.tbxPrice.Text != "" && this.tbxPriurl.Text != "")
            {
                GA gAdmin = new GA();
                Good good = new Good();//定义对象
                good.GoodName = this.tbxName.Text;
                good.GoodIncentory = Convert.ToInt32(this.tbxCount.Text);
                good.GoodPrice = this.tbxPrice.Text;
                FirstClassDm first = new FirstClassDm();
                first.FirstClassDmName = this.dplFirstClum.SelectedItem.Text;
                SecondClassDm second = new SecondClassDm();
                second.SecondClassDmName = this.dplSecondClum.SelectedItem.Text;
                ThirdClassDm Third = new ThirdClassDm();
                Third.ThirdClassDmName = this.dplThirdClum.SelectedItem.Text;
                good.FirstClassDmID = gAdmin.FcNameGetID(first);//传一、二、三级类目ID
                good.SecondClassDmID = gAdmin.ScNameGetID(second);
                good.ThirdClassDmID = gAdmin.TcNameGetID(Third);
                if (gAdmin.AddGood(good) == true)//添加商品表
                {
                    for (int GoodCount = 0; GoodCount < good.GoodIncentory; GoodCount++)//添加单个商品
                    {
                        SingleGoodInfo singleGoodinfo = new SingleGoodInfo();
                        singleGoodinfo.StaffID = Convert.ToInt32(Session["hStaffID"].ToString());
                        singleGoodinfo.GoodID = Good.GoodNameGetID(good);
                        gAdmin.AddSingleGoodInfo(singleGoodinfo);
                        SaveSingleGoodInfo saveSinGoodinfo = new SaveSingleGoodInfo();
                        saveSinGoodinfo.StaffID = Convert.ToInt32(Session["hStaffID"].ToString());
                        saveSinGoodinfo.GoodID = Good.GoodNameGetID(good);
                        gAdmin.AddSaveSingleGoodInfo(saveSinGoodinfo);
                    }
                    ImgInfo imginfo = new ImgInfo();
                    imginfo.GoodID = Good.GoodNameGetID(good);
                    imginfo.ImgAddress = this.tbxPriurl.Text;
                    imginfo.ImgTitle = this.tbxPicexplain.Text;
                    if (gAdmin.AddImginfo(imginfo) == true)//添加商品图片信息表
                    {
                        GoodPropertyComb goodprocomb = new GoodPropertyComb();
                        ThirdClassDm third = new ThirdClassDm();
                        third.ThirdClassDmName = dplThirdClum.SelectedItem.Text;
                        third.ThirdClassDmID = gAdmin.TcNameGetID(third);
                        PropertyClassDm propertyclass = new PropertyClassDm();
                        List<Property> prolist = new List<Property>();
                        prolist = PropertyClassDm.TcIDGetPoID(third);
                        int count = 0;
                        for (int i = 0; i < prolist.Count; i++)
                        {
                            PropertyContent proCont = new PropertyContent();
                            goodprocomb.GoodID = Good.GoodNameGetID(good);
                            goodprocomb.PropertyID = prolist[i].PropertyID;
                            DropDownList ddl = (DropDownList)DataList1.Items[i].FindControl("dpl_PropertyContent");//在datalist中找dropdownlist
                            goodprocomb.PropertyContent = ddl.SelectedItem.Text;
                            if (gAdmin.AddGoodPropertyComb(goodprocomb))//绑定属性、属性内容、和商品的关系
                            {
                                count += 1;
                            }
                        }
                        if (count == prolist.Count)
                        {
                            this.lblCheck.Text = "添加成功!";
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language=javascript>alert('" + "添加成功" + "'); </script>");
                        }
                    }
                    else
                    {
                        this.lblCheck.Text = "添加失败";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language=javascript>alert('" + "添加失败" + "'); </script>");
                    }

                }
                else
                {
                    this.lblCheck.Text = "添加失败!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language=javascript>alert('" + "添加失败" + "'); </script>");
                }
            }
            else
            {
                this.lblCheck.Text = "添加项不能为空!";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

    }
}