/*
 * 1 功能描述：
 *   属性添加界面；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-08-14-45；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 
 */
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
    public partial class GA_AddProperty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<FirstClassDm> firstlist = new List<FirstClassDm>();
                firstlist = FirstClassDm.Getlist();
                for (int i = 0; i < firstlist.Count; i++)
                {
                    drpFirstclass.Items.Add(new ListItem(firstlist[i].FirstClassDmName, i.ToString()));
                }
                drpFirstclass.Items.Insert(0, new ListItem("选择一级类目"));
            }
        }

        protected void drpFirstclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.drpSecondclass.Items.Clear();
            List<SecondClassDm> secondlist = new List<SecondClassDm>();
            FirstClassDm firstclum = new FirstClassDm();
            firstclum.FirstClassDmName = drpFirstclass.SelectedItem.Text;
            SecondClassDm secondclum = new SecondClassDm();
            secondlist = FirstClassDm.FcShowContent(firstclum, secondclum);
            for (int i = 0; i < secondlist.Count; i++)
            {
                this.drpSecondclass.Items.Add(new ListItem(secondlist[i].SecondClassDmName, i.ToString()));
            }
            this.drpSecondclass.Items.Insert(0, new ListItem("选择二级类目"));
        }

        protected void drpSecondclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.drpThirdclass.Items.Clear();
            List<ThirdClassDm> thirdlist = new List<ThirdClassDm>();
            SecondClassDm secondclum = new SecondClassDm();
            secondclum.SecondClassDmName = this.drpSecondclass.SelectedItem.Text;
            ThirdClassDm thirdclum = new ThirdClassDm();
            thirdlist = SecondClassDm.FcShowContent(thirdclum, secondclum);
            for (int i = 0; i < thirdlist.Count; i++)
            {
                this.drpThirdclass.Items.Add(new ListItem(thirdlist[i].ThirdClassDmName, i.ToString()));
            }
            this.drpThirdclass.Items.Insert(0, new ListItem("选择三级类目"));
        }

        protected void drpThirdclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            drpNewProname.Items.Clear();
            ThirdClassDm thirdclassdm = new ThirdClassDm();
            GA gAdmin = new GA();
            thirdclassdm.ThirdClassDmName = drpThirdclass.SelectedItem.Text;
            thirdclassdm.ThirdClassDmID = gAdmin.TcNameGetID(thirdclassdm);
            string[] str = Property.PoIDGetPoName(PropertyClassDm.TcIDGetPoID(thirdclassdm));
            for (int i = 0; i < str.Length; i++)
            {
                ListBox1.Items.Add(str[i]);
                drpNewProname.Items.Add(new ListItem(str[i], i.ToString()));
            }
            drpNewProname.Items.Insert(0, new ListItem("选择属性"));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbxAddproname.Text != "")
            {
                Property property = new Property();
                GA gAdmin = new GA();
                ThirdClassDm thirdclassdm = new ThirdClassDm();
                thirdclassdm.ThirdClassDmName = this.drpThirdclass.SelectedItem.Text;
                thirdclassdm.ThirdClassDmID = gAdmin.TcNameGetID(thirdclassdm);
                property.PropertyName = this.tbxAddproname.Text;
                property.PropertyID = gAdmin.PoNameGetID(property);
                if (gAdmin.PoIsRepeat(property) == true)//判断属性名字是否重复 TRUE为不重复
                {
                    if (gAdmin.AddProperty(thirdclassdm, property) == true)//判断添加属性和绑定关系是否成功
                    {
                        this.lblCheck.Text = "添加成功!";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "添加成功" + "');</script>");
                    }
                    else
                    {
                        this.lblCheck.Text = "添加失败!";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "添加失败" + "');</script>");
                    }
                }
                else
                {
                    if (gAdmin.IsTcPoComb(property, thirdclassdm) == true)//判断存不存在绑定关系 TRUE为不存在
                    {
                        if (gAdmin.AddTcPoComb(property, thirdclassdm) == true)//判断添加绑定关系是否成功
                        {
                            this.lblCheck.Text = "添加成功";
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "添加成功" + "');</script>");
                        }
                        else
                        {
                            this.lblCheck.Text = "添加失败";
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "添加失败" + "');</script>");
                        }
                    }
                    else
                    {
                        this.lblCheck.Text = "三级类目已经绑定了该属性!";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "三级类目已经绑定了该属性" + "');</script>");
                    }
                }
            }
            else
            {
                this.lblCheck.Text = "添加不能为空!";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "添加不能为空" + "');</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GA gAdmin = new GA();
            Property propertyAlter = new Property();
            Property propertyNow = new Property();
            propertyNow.PropertyName = drpNewProname.SelectedItem.Text;
            propertyAlter.PropertyName = tbxDelupdate.Text;
            if (gAdmin.PoIsRepeat(propertyAlter) == true)//不重复
            {
                if (gAdmin.AlterPoName(propertyNow, propertyAlter))
                {
                    this.lblCheck.Text = "修改成功!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改成功" + "');</script>");
                }
                else
                {
                    this.lblCheck.Text = "修改失败!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "修改失败" + "');</script>");
                }
            }
            else
            {
                this.lblCheck.Text = "该属性存在无法修改!";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "该属性存在无法修改" + "');</script>");
            }
        }

        protected void btnAdd1_Click(object sender, EventArgs e)
        {
            if (tbxNewcon.Text != "")
            {
                GA gAdmin = new GA();
                PropertyContent procontent = new PropertyContent();
                Property property = new Property();
                property.PropertyName = drpNewProname.SelectedItem.Text;
                procontent.PropertyID = gAdmin.PoNameGetID(property);
                procontent.PropertyContentName = tbxNewcon.Text;
                if (PropertyContent.PcIsRepeat(procontent) == true)//不重复
                {
                    if (gAdmin.AddPoContent(procontent) == true)
                    {
                        this.lblCheck.Text = "添加成功!";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "添加成功" + "');</script>");
                    }
                    else
                    {
                        this.lblCheck.Text = "添加失败!";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "添加失败" + "');</script>");
                    }
                }
                else
                {
                    this.lblCheck.Text = "属性关系已经存在!";
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "属性关系已经存在" + "');</script>");
                }
            }
            else
            {
                this.lblCheck.Text = "添加不能为空!";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "添加不能为空" + "');</script>");
            }
        }

        protected void drpNewProname_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox2.Items.Clear();
            this.drpNewProcon.Items.Clear();
            Property property = new Property();
            PropertyContent procontent = new PropertyContent();
            List<PropertyContent> procontentlist = new List<PropertyContent>();
            GA gAdmin = new GA();
            property.PropertyName = this.drpNewProname.SelectedItem.Text;
            procontent.PropertyID = gAdmin.PoNameGetID(property);
            procontentlist = PropertyContent.PoIDGetPcName(procontent);
            for (int i = 0; i < procontentlist.Count; i++)
            {
                drpNewProcon.Items.Add(new ListItem(procontentlist[i].PropertyContentName, i.ToString()));
                ListBox2.Items.Add(procontentlist[i].PropertyContentName);
            }
            drpNewProcon.Items.Insert(0, new ListItem("请选择属性内容"));
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GA gAdmin = new GA();
            GAController gadmin = new GAController();
            Property pro = new Property();
            pro.PropertyName = drpNewProname.SelectedItem.Text;
            List<PropertyContent> proconlist = new List<PropertyContent>();
            PropertyContent content = new PropertyContent();
            string a = gAdmin.PoNameGetID(pro);
            content.PropertyID = a;
            proconlist = PropertyContent.PoIDGetPcName(content);
            if (proconlist.Count == 0)
            {
                if (gadmin.DeletePrperty(gAdmin, a))
                {
                    this.lblCheck.Text = "删除成功!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除成功" + "');</script>");
                }
                else
                {
                    this.lblCheck.Text = "删除失败!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除失败" + "');</script>");
                }
            }
            else
            {
                this.lblCheck.Text = "该属性下有内容!";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "该属性下有内容" + "');</script>");
            }
        }

        protected void btnDel1_Click(object sender, EventArgs e)
        {
            GA gAdmin = new GA();
            Property pro = new Property();
            pro.PropertyName = drpNewProname.SelectedItem.Text;
            string a = gAdmin.PoNameGetID(pro);
            if (gAdmin.DeletePropertycon(a))
            {
                this.lblCheck.Text = "删除成功!";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除成功" + "');</script>");
            }
            else
            {
                this.lblCheck.Text = "删除失败!";
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除失败" + "');</script>");
            }
        }
        //修改属性内容
        protected void btnUpdate1_Click(object sender, EventArgs e)
        {
            GA gAdmin = new GA();
            PropertyContent proConAlter = new PropertyContent();
            PropertyContent proConNow = new PropertyContent();
            proConAlter.PropertyContentName = this.tbxCondelup.Text;
            proConNow.PropertyContentName = this.drpNewProcon.SelectedItem.Text;
            if (proConAlter.SelectProCon() == true)
            {
                if (proConNow.UpdateProCon(proConAlter.PropertyContentName) == true)
                {
                    this.lblCheck.Text = "修改成功！";
                }
                else
                {
                    this.lblCheck.Text = "修改失败！";
                }
            }
            else
            {
                this.lblCheck.Text = "修改内容已存在！修改无效！";
            }
        }
        
    }
}