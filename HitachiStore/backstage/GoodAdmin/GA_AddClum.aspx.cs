/*
 * 1 功能描述：
 *   商品添加界面；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-06-11-04；
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
    public partial class GA_AddClum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<FirstClassDm> firstlist = new List<FirstClassDm>();
                firstlist = FirstClassDm.Getlist();
                for (int i = 0; i < firstlist.Count; i++)
                {
                    dlistFirstClumName.Items.Add(new ListItem(firstlist[i].FirstClassDmName, i.ToString()));
                }
                this.dlistFirstClumName.Items.Insert(0, new ListItem(""));
                //List<SecondClassDm> secondlist = new List<SecondClassDm>();
                //secondlist = SecondClassDm.Getlist();
                //for (int i = 0; i < secondlist.Count; i++)
                //{
                //    this.dlistSecondClumName.Items.Add(new ListItem(secondlist[i].SecondClassDmName, i.ToString()));
                //}
            }
        }

        protected void Add1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                this.lblCheck.Text = "添加项为空!";
            }
            else
            {
                FirstClassDm firstclassdm = new FirstClassDm();
                GA gAdmin = new GA();
                firstclassdm.FirstClassDmName = this.TextBox1.Text;
                if (gAdmin.FcIsRepeat(firstclassdm) == true)
                {
                    if (gAdmin.AddClum(firstclassdm) > 0)
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
                    this.lblCheck.Text = "添加项重复!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "添加项重复" + "');</script>");
                }
            }
        }

        protected void dlistFirstClumName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            this.dlistSecondClumName.Items.Clear();
            List<SecondClassDm> secondlist = new List<SecondClassDm>();
            FirstClassDm firstclum = new FirstClassDm();
            firstclum.FirstClassDmName = dlistFirstClumName.SelectedItem.Text;
            SecondClassDm secondclum = new SecondClassDm();
            secondlist = FirstClassDm.FcShowContent(firstclum, secondclum);
            for (int i = 0; i < secondlist.Count; i++)
            {
                ListBox1.Items.Add(secondlist[i].SecondClassDmName);
            }
            for (int i = 0; i < secondlist.Count; i++)
            {
                this.dlistSecondClumName.Items.Add(new ListItem(secondlist[i].SecondClassDmName, i.ToString()));
            }
            this.dlistSecondClumName.Items.Insert(0, new ListItem(""));
        }

        protected void dlistSecondClumName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox2.Items.Clear();
            this.dlistThirdClumName.Items.Clear();
            List<ThirdClassDm> thirdlist = new List<ThirdClassDm>();
            SecondClassDm secondclum = new SecondClassDm();
            secondclum.SecondClassDmName = dlistSecondClumName.SelectedItem.Text;
            ThirdClassDm thirdclum = new ThirdClassDm();
            thirdlist = SecondClassDm.FcShowContent(thirdclum, secondclum);
            for (int i = 0; i < thirdlist.Count; i++)
            {
                ListBox2.Items.Add(thirdlist[i].ThirdClassDmName);
            }
            for (int i = 0; i < thirdlist.Count; i++)
            {
                this.dlistThirdClumName.Items.Add(new ListItem(thirdlist[i].ThirdClassDmName, i.ToString()));
            }
            this.dlistThirdClumName.Items.Insert(0, new ListItem(""));
        }

        protected void Add2_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == "")
            {
                this.lblCheck.Text = "添加项为空!";
            }
            else
            {
                SecondClassDm secondclassdm = new SecondClassDm();
                FirstClassDm firstclassdm = new FirstClassDm();
                firstclassdm.FirstClassDmName = dlistFirstClumName.SelectedItem.Text;
                GA gAdmin = new GA();
                firstclassdm.FirstClassDmID = gAdmin.FcNameGetID(firstclassdm);
                secondclassdm.SecondClassDmName = this.TextBox2.Text;
                if (gAdmin.ScIsRepeat(secondclassdm) == true)
                {
                    if (gAdmin.AddClum(secondclassdm, firstclassdm) > 0)
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
                    this.lblCheck.Text = "添加项重复!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "添加项重复" + "');</script>");
                }
            }
        }

        protected void Add3_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text == "")
            {
                this.lblCheck.Text = "添加项为空!";
            }
            else
            {
                SecondClassDm secondclassdm = new SecondClassDm();
                ThirdClassDm thirdclassdm = new ThirdClassDm();
                secondclassdm.SecondClassDmName = dlistSecondClumName.SelectedItem.Text;
                GA gAdmin = new GA();
                secondclassdm.SecondClassDmID = gAdmin.ScNameGetID(secondclassdm);
                thirdclassdm.ThirdClassDmName = this.TextBox3.Text;
                if (gAdmin.TcIsRepeat(thirdclassdm) == true)
                {
                    if (gAdmin.AddClum(thirdclassdm, secondclassdm) > 0)
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
                    this.lblCheck.Text = "添加项重复!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "添加项重复" + "');</script>");
                }
            }
        }

        protected void Delete1_Click(object sender, EventArgs e)
        {

            if (dlistFirstClumName.SelectedItem.Value == "")
            {
                this.lblCheck.Text = " 选择删除项为空";
            }
            else
            {
                FirstClassDm first = new FirstClassDm();
                SecondClassDm Second = new SecondClassDm();
                first.FirstClassDmName = dlistFirstClumName.SelectedItem.Text;
                GA ga = new GA();
                GAController GA = new GAController();
                if (FirstClassDm.FcShowContent(first, Second).Count != 0)
                {
                    this.lblCheck.Text = "二级类目存在内容!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "二级类目存在内容" + "');</script>");
                }
                else
                {
                    if (GA.DeleteFirstClass(ga, first))
                    {
                        this.lblCheck.Text = "删除成功!";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除成功" + "');</script>");
                    }
                    else
                    {
                        this.lblCheck.Text = "删除失败 !";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除失败 " + "');</script>");
                    }
                }
            }
        }

        protected void Delete2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlistSecondClumName.SelectedItem.Value == "")
                {
                    this.lblCheck.Text = "选择删除项为空";
                }
                else
                {

                    SecondClassDm Second = new SecondClassDm();
                    ThirdClassDm Third = new ThirdClassDm();
                    Second.SecondClassDmName = dlistSecondClumName.SelectedItem.Text;
                    GA ga = new GA();
                    GAController GA = new GAController();
                    if (SecondClassDm.FcShowContent(Third, Second).Count != 0)
                    {
                        this.lblCheck.Text = "三级类目存在内容!";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "三级类目存在内容" + "');</script>");
                    }
                    else
                    {
                        if (GA.DeleteSecondClass(ga, Second))
                        {
                            this.lblCheck.Text = "删除成功!";
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除成功" + "');</script>");
                        }
                        else
                        {
                            this.lblCheck.Text = "删除失败!";
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除失败 " + "');</script>");
                        }
                    }
                }
            }
            catch
            {
                this.lblCheck.Text = "选择删除项为空";
            }
        }

        protected void Delete3_Click(object sender, EventArgs e)
        {
            try
            {

                if (dlistThirdClumName.SelectedItem.Value == "" && dlistThirdClumName.SelectedItem == null)
                {
                    this.lblCheck.Text = "选择删除项为空";
                }
                else
                {
                    ThirdClassDm Third = new ThirdClassDm();
                    GA ga = new GA();
                    GAController GA = new GAController();
                    Third.ThirdClassDmName = dlistThirdClumName.SelectedItem.Text;
                    if (GA.DeleteThirdClass(ga, Third))
                    {
                        this.lblCheck.Text = "删除成功！";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除成功" + "');</script>");
                    }
                    else
                    {
                        this.lblCheck.Text = "删除失败！";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + "删除失败 " + "');</script>");
                    }
                }
            }
            catch
            {
                this.lblCheck.Text = "选择删除项为空";
            }
        }
        //更改一级类目名
        protected void Update1_Click(object sender, EventArgs e)
        {
            if (dlistFirstClumName.SelectedItem.Value == "" && dlistFirstClumName.SelectedItem == null)
            {
                this.lblCheck.Text = "请选择修改项";
            }
            else
            {
                FirstClassDm mFirstClassOld = new FirstClassDm();
                FirstClassDm mFirstClassNew = new FirstClassDm();
                mFirstClassOld.FirstClassDmName = this.dlistFirstClumName.SelectedItem.Text;
                mFirstClassNew.FirstClassDmName = this.TextBox1.Text;
                GA gAdmin = new GA();

                if (gAdmin.FcIsRepeat(mFirstClassNew) == true)
                {
                    if (mFirstClassOld.UpdateFirstClass(mFirstClassNew.FirstClassDmName) == true)
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
        //更改二级类目名
        protected void Update2_Click(object sender, EventArgs e)
        {
            if (dlistSecondClumName.SelectedItem.Value == "" && dlistSecondClumName.SelectedItem == null)
            {
                this.lblCheck.Text = "请选择修改项";
            }
            else
            {
                SecondClassDm mSecondClassDmOld = new SecondClassDm();
                SecondClassDm mSecondClassDmNew = new SecondClassDm();
                mSecondClassDmOld.SecondClassDmName = this.dlistSecondClumName.SelectedItem.Text;
                mSecondClassDmNew.SecondClassDmName = this.TextBox2.Text;
                if (mSecondClassDmNew.SelectSecondClass() == true)
                {
                    if (mSecondClassDmOld.UpdateSecondClass(mSecondClassDmNew.SecondClassDmName))
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
        //更改三级类目名
        protected void Update3_Click(object sender, EventArgs e)
        {
            if (dlistThirdClumName.SelectedItem.Value == "" && dlistThirdClumName.SelectedItem == null)
            {
                this.lblCheck.Text = "请选择修改项";
            }
            else
            {
                ThirdClassDm mThirdClassDmOld = new ThirdClassDm();
                ThirdClassDm mThirdClassDmNew = new ThirdClassDm();
                mThirdClassDmOld.ThirdClassDmName = this.dlistThirdClumName.SelectedItem.Text;
                mThirdClassDmNew.ThirdClassDmName = this.TextBox3.Text;
                if (mThirdClassDmNew.SelectThirdClass() == true)
                {
                    if (mThirdClassDmOld.UpdateThirdClass(mThirdClassDmNew.ThirdClassDmName) == true)
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
}