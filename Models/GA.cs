/*
 * 1 功能描述：
 *   商品管理员类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-06-10-27；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 *   小菲 2012-8-9-10-01 添加删除功能
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;

namespace Models
{
    /// <summary>
    /// 商品管理员类
    /// </summary>
    public class GA : Admins
    {
        /// <summary>
        /// 获取商品管理员的个人信息
        /// </summary>
        public void Getinfo()
        {
            string sqlstring = "select * from Admin where UserName='" + this.UserName + "'";
            SqlHelper.ReadDateReadBegin(sqlstring);
            while (SqlHelper.SqlReader.Read())
            {
                this.StaffID = Convert.ToInt32(SqlHelper.SqlReader[0]);
                this.TrueName = SqlHelper.SqlReader[1].ToString();
                this.PassWord = SqlHelper.SqlReader[2].ToString();
                this.Age = SqlHelper.SqlReader[3].ToString();
                this.Sex = Convert.ToChar(SqlHelper.SqlReader[4]);
                this.Email = SqlHelper.SqlReader[5].ToString();
                this.StaffType = Convert.ToChar(SqlHelper.SqlReader[6]);
                this.AddTime = SqlHelper.SqlReader[7].ToString();
                this.UserName = SqlHelper.SqlReader[8].ToString();
                this.Phone = SqlHelper.SqlReader[9].ToString();
                this.QQ = SqlHelper.SqlReader[10].ToString();
                this.Address = SqlHelper.SqlReader[11].ToString();
                this.IdCardNum = SqlHelper.SqlReader[12].ToString();
            }
            SqlHelper.ReadDateReadEnd();
        }
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <returns>受到影响的行数</returns>
        public int Alterinfo()
        {
            StringBuilder Sqlstring = new StringBuilder();
            Sqlstring.Append("update Admin set ");
            Sqlstring.Append("TrueName=N'" + this.TrueName + "',");
            Sqlstring.Append("Age='" + this.Age + "',");
            Sqlstring.Append("Email='" + this.Email + "',");
            Sqlstring.Append("Phone='" + this.Phone + "',");
            Sqlstring.Append("QQ='" + this.QQ + "',");
            Sqlstring.Append("IdCardNum='" + this.IdCardNum + "',");
            Sqlstring.Append("PassWord='" + this.PassWord + "',");
            Sqlstring.Append("Address=N'" + this.Address + "'");
            Sqlstring.Append("where UserName=N'" + this.UserName + "'");
            return SqlHelper.ExecuteNonQuery(Sqlstring.ToString());
        }
        /// <summary>
        /// 添加一级类目
        /// </summary>
        /// <returns>收到影响的行数</returns>
        public int AddClum(FirstClassDm firstclassdm)
        {
            string c = null;
            string sql1 = "select top 1 * from FirstClassDm order by FirstClassDmID desc";
            Object obj = SqlHelper.ReadSclar(sql1);
            if (obj == null)
            {
                c = "001";
            }
            else
            {
                string a = obj.ToString();
                int b1 = Convert.ToInt32(a.Substring(2, 1));
                int b2 = Convert.ToInt32(a.Substring(1, 1));
                int b3 = Convert.ToInt32(a.Substring(0, 1));
                if (b1 < 9)
                {
                    b1 = b1 + 1;
                    c = a.Substring(0, 1) + a.Substring(1, 1) + b1.ToString();
                }
                if (b1 == 9 && b2 < 9)
                {
                    b1 = 0;
                    b2 = b2 + 1;
                    c = a.Substring(0, 1) + b2.ToString() + b1.ToString();
                }

                if (b1 == 9 && b2 == 9)
                {
                    b3 = b3 + 1;
                    b2 = 0;
                    b1 = 0;
                    c = b3.ToString() + b2.ToString() + b1.ToString();
                }
            }
            string Sqlstring = "insert FirstClassDm(FirstClassDmID,FirstClassDmName)values('" + c + "',N'" + firstclassdm.FirstClassDmName + "')";
            return SqlHelper.ExecuteNonQuery(Sqlstring);
        }
        /// <summary>
        /// 判断添加的一级类目是否重复
        /// </summary>
        /// <returns>是否重复</returns>
        public bool FcIsRepeat(FirstClassDm firstclassdm)
        {
            string Sqlstring = "select FirstClassDmID from FirstClassDm where FirstClassDmName=N'" + firstclassdm.FirstClassDmName + "'";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            string str = (string)obj;
            if (str == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 由一级类目名称获取一级类目ID
        /// </summary>
        /// <param name="firstclassdm">一级类目对象</param>
        /// <returns>一级类目ID</returns>
        public string FcNameGetID(FirstClassDm firstclassdm)
        {
            string Sqlstring = "select FirstClassDmID from FirstClassDm where FirstClassDmName=N'" + firstclassdm.FirstClassDmName + "'";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            return (string)obj;
        }
        /// <summary>
        /// 添加二级类目
        /// </summary>
        /// <param name="secondclassdm">二级类目对象</param>
        /// <param name="firstclassdm">对应的一级类目对象</param>
        /// <returns></returns>
        public int AddClum(SecondClassDm secondclassdm, FirstClassDm firstclassdm)
        {
            string c = null;
            string sql1 = "select top 1 * from SecondClassDm order by SecondClassDmID desc";
            Object obj = SqlHelper.ReadSclar(sql1);
            if (obj == null)
            {
                c = "001";
            }
            else
            {
                string a = obj.ToString();
                int b1 = Convert.ToInt32(a.Substring(2, 1));
                int b2 = Convert.ToInt32(a.Substring(1, 1));
                int b3 = Convert.ToInt32(a.Substring(0, 1));
                if (b1 < 9)
                {
                    b1 = b1 + 1;
                    c = a.Substring(0, 1) + a.Substring(1, 1) + b1.ToString();
                }
                if (b1 == 9 && b2 < 9)
                {
                    b1 = 0;
                    b2 = b2 + 1;
                    c = a.Substring(0, 1) + b2.ToString() + b1.ToString();
                }

                if (b1 == 9 && b2 == 9)
                {
                    b3 = b3 + 1;
                    b2 = 0;
                    b1 = 0;
                    c = b3.ToString() + b2.ToString() + b1.ToString();
                }
            }

            string Sqlstring = "insert SecondClassDm(SecondClassDmID,FirstClassDmID,SecondClassDmName)values('" + c + "','" + firstclassdm.FirstClassDmID + "',N'" + secondclassdm.SecondClassDmName + "')";
            return SqlHelper.ExecuteNonQuery(Sqlstring);
        }
        /// <summary>
        /// 判断二级类目是否重复
        /// </summary>
        /// <param name="secondclassdm">二级类目对象</param>
        /// <returns>是或否</returns>
        public bool ScIsRepeat(SecondClassDm secondclassdm)
        {
            string Sqlstring = "select SecondClassDmID from SecondClassDm where SecondClassDmName=N'" + secondclassdm.SecondClassDmName + "'";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            string str = (string)obj;
            if (str == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 二级类目名称获取二级类目ID
        /// </summary>
        /// <param name="secondclassdm">二级类目对象</param>
        /// <returns>二级类目ID</returns>
        public string ScNameGetID(SecondClassDm secondclassdm)
        {
            string Sqlstring = "select SecondClassDmID from SecondClassDm where SecondClassDmName=N'" + secondclassdm.SecondClassDmName + "'";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            return (string)obj;
        }
        /// <summary>
        /// 三级类目名称获取三级类目ID
        /// </summary>
        /// <param name="thirdclassdm">三级类目对象</param>
        /// <returns>三级类目ID</returns>
        public string TcNameGetID(ThirdClassDm thirdclassdm)
        {
            string Sqlstring = "select ThirdClassDmID from ThirdClassDm where ThirdClassDmName=N'" + thirdclassdm.ThirdClassDmName + "'";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            return (string)obj;
        }
        /// <summary>
        /// 添加三级类目
        /// </summary>
        /// <param name="thirdclassdm">三级类目对象</param>
        /// <param name="secondclassdm">对应二级类目对象</param>
        /// <returns></returns>
        public int AddClum(ThirdClassDm thirdclassdm, SecondClassDm secondclassdm)
        {
            string c = null;
            string sql1 = "select top 1 * from ThirdClassDm order by ThirdClassDmID desc";
            Object obj = SqlHelper.ReadSclar(sql1);
            if (obj == null)
            {
                c = "001";
            }
            else
            {
                string a = obj.ToString();
                int b1 = Convert.ToInt32(a.Substring(2, 1));
                int b2 = Convert.ToInt32(a.Substring(1, 1));
                int b3 = Convert.ToInt32(a.Substring(0, 1));
                if (b1 < 9)
                {
                    b1 = b1 + 1;
                    c = a.Substring(0, 1) + a.Substring(1, 1) + b1.ToString();
                }
                if (b1 == 9 && b2 < 9)
                {
                    b1 = 0;
                    b2 = b2 + 1;
                    c = a.Substring(0, 1) + b2.ToString() + b1.ToString();
                }

                if (b1 == 9 && b2 == 9)
                {
                    b3 = b3 + 1;
                    b2 = 0;
                    b1 = 0;
                    c = b3.ToString() + b2.ToString() + b1.ToString();
                }
            }

            string Sqlstring = "insert ThirdClassDm(ThirdClassDmID,SecondClassDmID,ThirdClassDmName)values('" + c + "','" + secondclassdm.SecondClassDmID + "',N'" + thirdclassdm.ThirdClassDmName + "')";
            return SqlHelper.ExecuteNonQuery(Sqlstring);
        }
        /// <summary>
        /// 添加的三级类目是否重复
        /// </summary>
        /// <param name="thirdclassdm">三级类目对象</param>
        /// <returns>是或否</returns>
        public bool TcIsRepeat(ThirdClassDm thirdclassdm)
        {
            string Sqlstring = "select ThirdClassDmID from ThirdClassDm where ThirdClassDmName=N'" + thirdclassdm.ThirdClassDmName + "'";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            string str = (string)obj;
            if (str == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///  删除一级类目
        /// </summary>
        /// <returns>是否删除成功</returns>
        public bool DeleteFirstclassdm(FirstClassDm first)
        {
            string str = first.FirstClassDmName;
            string Sql = "delete   from FirstClassDm where FirstClassDmName=N'" + str + "'";
            if (SqlHelper.ExecuteNonQuery(Sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除二级类目
        /// </summary>
        /// <returns>是否删除成功</returns>
        public bool DeleteSecondclassdm(SecondClassDm second)
        {

            string str = second.SecondClassDmName;
            string Sql = "delete  from SecondClassDm where SecondClassDmName=N'" + str + "'";
            if (SqlHelper.ExecuteNonQuery(Sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteThirddm(ThirdClassDm third)
        {
            string SelectSingeID = null, DeleteOrder = null, DeleteGood = null, DeleteSingle = null, DeleteImageinfo = null, DeleteGoodEva = null, DeleteGoodproCom = null;
            Object obj2 = null;
            ThirdClassDm thirdclassdm = new ThirdClassDm();
            string str = third.ThirdClassDmName;
            string SelectThirdID = this.TcNameGetID(third);
            thirdclassdm.ThirdClassDmID = SelectThirdID;
            string SelectGoodID = "select GoodID from Good where ThirdClassDmID=N'" + SelectThirdID + "'";
            Object obj1 = SqlHelper.ReadSclar(SelectGoodID);
            if (obj1 != null)
            {
                SelectSingeID = "select SingleGoodID from SingleGoodInfo where GoodID='" + obj1.ToString() + "'";
                obj2 = SqlHelper.ReadSclar(SelectSingeID);
                DeleteOrder = "delete  from Orders  where SingleGoodID='" + obj2.ToString() + "'";
                DeleteGood = "delete  from Good  where GoodID='" + obj1.ToString() + "'";
                DeleteSingle = "delete  from SingleGoodInfo  where GoodID='" + obj1.ToString() + "'";
                DeleteImageinfo = "delete  from ImgInfo  where GoodID='" + obj1.ToString() + "'";
                DeleteGoodEva = "delete  from GoodEvaluate  where GoodID='" + obj1.ToString() + "'";
                DeleteGoodproCom = "delete  from GoodPropertyComb  where GoodID='" + obj1.ToString() + "'";
            }
            string SelectProperID = "select PropertyID from PropertyClassDm where ThirdClassDm='" + SelectThirdID + "'";
            string DeleteProcla = "delete  from PropertyClassDm  where ThirdClassDmID=N'" + SelectThirdID + "'";
            string DeleteThirdCla = "delete  from ThirdClassDm where ThirdClassDmName=N'" + str + "'";
            List<Property> prolist = new List<Property>();
            prolist = PropertyClassDm.TcIDGetPoID(thirdclassdm);
            if (prolist.Count == 0)
            {
                int b = 0, c = 0, d = 0, i = 0, h = 0, g = 0;
                if (obj2 != null)
                {
                    c = SqlHelper.ExecuteNonQuery(DeleteOrder);
                }
                if (obj1 != null)
                {
                    i = SqlHelper.ExecuteNonQuery(DeleteGoodproCom);
                    h = SqlHelper.ExecuteNonQuery(DeleteGoodEva);
                    g = SqlHelper.ExecuteNonQuery(DeleteImageinfo);
                    b = SqlHelper.ExecuteNonQuery(DeleteGood);
                    d = SqlHelper.ExecuteNonQuery(DeleteSingle);
                }
                int a = SqlHelper.ExecuteNonQuery(DeleteThirdCla);
                if (a > 0)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int b = 0, c = 0, d = 0, i = 0, h = 0, g = 0;
                if (obj2 != null)
                {
                    c = SqlHelper.ExecuteNonQuery(DeleteOrder);
                }
                if (obj1 != null)
                {
                    i = SqlHelper.ExecuteNonQuery(DeleteGoodproCom);
                    h = SqlHelper.ExecuteNonQuery(DeleteGoodEva);
                    g = SqlHelper.ExecuteNonQuery(DeleteImageinfo);
                    b = SqlHelper.ExecuteNonQuery(DeleteGood);
                    d = SqlHelper.ExecuteNonQuery(DeleteSingle);
                }
                int f = SqlHelper.ExecuteNonQuery(DeleteProcla);
                int a = SqlHelper.ExecuteNonQuery(DeleteThirdCla);
                if (a > 0 && f > 0)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="thirdclassdm">三级类目对象</param>
        /// <param name="property">属性对象</param>
        /// <returns>成功或失败</returns>
        public bool AddProperty(ThirdClassDm thirdclassdm, Property property)
        {
            string c = null;
            string sql1 = "select top 1 * from Property order by PropertyID desc";
            Object obj = SqlHelper.ReadSclar(sql1);
            if (obj == null)
            {
                c = "001";
            }
            else
            {
                string a = obj.ToString();
                int b1 = Convert.ToInt32(a.Substring(2, 1));
                int b2 = Convert.ToInt32(a.Substring(1, 1));
                int b3 = Convert.ToInt32(a.Substring(0, 1));
                if (b1 < 9)
                {
                    b1 = b1 + 1;
                    c = a.Substring(0, 1) + a.Substring(1, 1) + b1.ToString();
                }
                if (b1 == 9 && b2 < 9)
                {
                    b1 = 0;
                    b2 = b2 + 1;
                    c = a.Substring(0, 1) + b2.ToString() + b1.ToString();
                }

                if (b1 == 9 && b2 == 9)
                {
                    b3 = b3 + 1;
                    b2 = 0;
                    b1 = 0;
                    c = b3.ToString() + b2.ToString() + b1.ToString();
                }
            }
            string Sql1 = "insert Property(PropertyID,PropertyName)values('" + c + "',N'" + property.PropertyName + "') ";
            string Sql2 = "insert PropertyClassDm(PropertyID,ThirdClassDmID)values('" + c + "','" + thirdclassdm.ThirdClassDmID + "')";
            if ((SqlHelper.ExecuteNonQuery(Sql1) > 0) && (SqlHelper.ExecuteNonQuery(Sql2) > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 属性是否重复
        /// </summary>
        /// <param name="property">属性对象</param>
        /// <returns>是或否</returns>
        public bool PoIsRepeat(Property property)
        {
            string Sqlstring = "select PropertyID from Property where PropertyName=N'" + property.PropertyName + "'";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            string str = (string)obj;
            if (str == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 属性名获取属性ID
        /// </summary>
        /// <param name="property">属性对象</param>
        /// <returns>属性ID</returns>
        public string PoNameGetID(Property property)
        {
            string Sqlstring = "select PropertyID from Property where PropertyName=N'" + property.PropertyName + "'";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            return (string)obj;
        }
        /// <summary>
        /// 是否三级类目与属性有对应关系
        /// </summary>
        /// <param name="property">属性对象</param>
        /// <param name="thirdclassdm">三级类目对象</param>
        /// <returns>是或否</returns>
        public bool IsTcPoComb(Property property, ThirdClassDm thirdclassdm)
        {
            string Sqlstring = "select PropertyID from PropertyClassDm where PropertyID='" + property.PropertyID + "'and ThirdClassDmID='" + thirdclassdm.ThirdClassDmID + "' ";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加三级类目和属性绑定关系
        /// </summary>
        /// <param name="property">属性对象</param>
        /// <param name="thirdclassdm">三级类目对象</param>
        /// <returns>是否添加成功</returns>
        public bool AddTcPoComb(Property property, ThirdClassDm thirdclassdm)
        {
            string Sql = "insert PropertyClassDm(PropertyID,ThirdClassDmID)values('" + property.PropertyID + "','" + thirdclassdm.ThirdClassDmID + "')";
            if (SqlHelper.ExecuteNonQuery(Sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改属性名字
        /// </summary>
        /// <param name="proNow">当前属性的名字</param>
        /// <param name="proAlter">修改后的属性的名字</param>
        /// <returns>是否修改成功</returns>
        public bool AlterPoName(Property proNow, Property proAlter)
        {
            string Sql = "update Property set PropertyName=N'" + proAlter.PropertyName + "' where PropertyName=N'" + proNow.PropertyName + "' ";
            if (SqlHelper.ExecuteNonQuery(Sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加属性内容
        /// </summary>
        /// <param name="procontent">属性内容对象</param>
        /// <returns>成功或失败</returns>
        public bool AddPoContent(PropertyContent procontent)
        {
            string Sql = "insert PropertyContent(PropertyID,PropertyContentName) values('" + procontent.PropertyID + "',N'" + procontent.PropertyContentName + "')";
            if (SqlHelper.ExecuteNonQuery(Sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="a">属性ID</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteProperty(string a)
        {
            string Sql = "delete from PropertyClassDm where PropertyID='" + a + "'";
            if (SqlHelper.ExecuteNonQuery(Sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除属性内容
        /// </summary>
        /// <param name="a">属性ID</param>
        /// <returns>是否删除成功</returns>
        public bool DeletePropertycon(string a)
        {
            string Sql = "delete from PropertyContent where PropertyID='" + a + "'";
            if (SqlHelper.ExecuteNonQuery(Sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="good">商品对象</param>
        /// <returns>成功或失败</returns>
        public bool AddGood(Good good)
        {
            string sqlString = "insert Good(GoodName,GoodPrice,GoodIncentory,SalesVolume,Discount,FirstClassDmID,SecondClassDmID,ThirdClassDmID) values(N'" + good.GoodName + "','" + good.GoodPrice + "','" + good.GoodIncentory + "','0','0.9','" + good.FirstClassDmID + "','" + good.SecondClassDmID + "','" + good.ThirdClassDmID + "') ";
            if (SqlHelper.ExecuteNonQuery(sqlString) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 添加商品图片信息
        /// </summary>
        /// <param name="imginfo">商品图片信息对象</param>
        /// <returns>成功或失败</returns>
        public bool AddImginfo(ImgInfo imginfo)
        {
            string sqlString = "insert Imginfo(ImgAddress,ImgTitle,GoodID) values(N'" + imginfo.ImgAddress + "',N'" + imginfo.ImgTitle + "','" + imginfo.GoodID + "')";
            if (SqlHelper.ExecuteNonQuery(sqlString) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加商品属性结合关系
        /// </summary>
        /// <param name="goodprocomb">商品属性结合对象</param>
        /// <returns>成功或者失败</returns>
        public bool AddGoodPropertyComb(GoodPropertyComb goodprocomb)
        {
            string sqlString = "insert GoodPropertyComb(GoodID,PropertyID,PropertyContent) values('" + goodprocomb.GoodID + "','" + goodprocomb.PropertyID + "',N'" + goodprocomb.PropertyContent + "')";
            if (SqlHelper.ExecuteNonQuery(sqlString) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加单个商品
        /// </summary>
        /// <param name="singleGoodinfo">单个商品对象</param>
        /// <returns>成功或失败</returns>
        public bool AddSingleGoodInfo(SingleGoodInfo singleGoodinfo)
        {
            string sqlString = "insert SingleGoodInfo(GoodID,StaffID) values('" + singleGoodinfo.GoodID + "','" + singleGoodinfo.StaffID + "')";
            if (SqlHelper.ExecuteNonQuery(sqlString) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加单个商品
        /// </summary>
        /// <param name="singleGoodinfo">单个商品对象</param>
        /// <returns>成功或失败</returns>
        public bool AddSaveSingleGoodInfo(SaveSingleGoodInfo savesingleGoodinfo)
        {
            string sqlString = "insert SaveSingleGoodInfo(GoodID,StaffID) values('" + savesingleGoodinfo.GoodID + "','" + savesingleGoodinfo.StaffID + "')";
            if (SqlHelper.ExecuteNonQuery(sqlString) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 商品查看商品信息
        /// </summary>
        /// <param name="thirdClassID">三级类目ID</param>
        /// <returns>商品i信息</returns>
        public List<Good> GoodExaminfo(string thirdClassID)
        {
            List<Good> GoodExamInfo = new List<Good>();
            Select lcutstring = new Select();
            string selectGoodInfo = "select top 10 GoodID,GoodName,GoodPrice,GoodIncentory,SalesVolume from Good where ThirdClassDmID='" + thirdClassID + "'";
            SqlHelper.ReadDateReadBegin(selectGoodInfo);
            while (SqlHelper.SqlReader.Read())
            {
                Good lGood = new Good();
                lGood.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                lGood.GoodName = lcutstring.CutString( SqlHelper.SqlReader["GoodName"].ToString(),10);
                lGood.GoodPrice = SqlHelper.SqlReader["GoodPrice"].ToString();
                lGood.GoodIncentory = Convert.ToInt32(SqlHelper.SqlReader["GoodIncentory"]);
                lGood.SalesVolume = Convert.ToInt32(SqlHelper.SqlReader["SalesVolume"]);
                GoodExamInfo.Add(lGood);
            }
            SqlHelper.ReadDateReadEnd();
            return GoodExamInfo;
        }
        /// <summary>
        /// 商品查看商品详细信息
        /// </summary>
        /// <param name="goodID">GoodID</param>
        /// <returns>商品详细信息</returns>
        public List<Good> Goodinfo(string goodID)
        {
            List<Good> GoodInfo = new List<Good>();
            string SelectGoodInfo = "select GoodName,GoodPrice,GoodIncentory,SalesVolume from Good where GoodID=N'" + goodID + "'";
            SqlHelper.ReadDateReadBegin(SelectGoodInfo);
            while (SqlHelper.SqlReader.Read())
            {
                Good lGood = new Good();
                lGood.GoodName = SqlHelper.SqlReader["GoodName"].ToString();
                lGood.GoodPrice = SqlHelper.SqlReader["GoodPrice"].ToString();
                lGood.GoodIncentory = Convert.ToInt32(SqlHelper.SqlReader["GoodIncentory"]);
                lGood.SalesVolume = Convert.ToInt32(SqlHelper.SqlReader["SalesVolume"]);

                GoodInfo.Add(lGood);
            }
            SqlHelper.ReadDateReadEnd();
            return GoodInfo;
        }
        /// <summary>
        /// 商品查看商品图片详细信息
        /// </summary>
        /// <param name="goodID">商品ID</param>
        /// <returns>商品信息</returns>
        public List<ImgInfo> GoodExam(string goodID)
        {
            List<ImgInfo> GoodInfo = new List<ImgInfo>();
            string selectGoodInfo = "select ImgAddress,ImgTitle from ImgInfo where GoodID='" + goodID + "'";
            SqlHelper.ReadDateReadBegin(selectGoodInfo);
            while (SqlHelper.SqlReader.Read())
            {
                ImgInfo lGoodPictureInfo = new ImgInfo();
                lGoodPictureInfo.ImgTitle = SqlHelper.SqlReader["ImgTitle"].ToString();
                lGoodPictureInfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                GoodInfo.Add(lGoodPictureInfo);
            }
            SqlHelper.ReadDateReadEnd();
            return GoodInfo;
        }
        /// <summary>
        /// 商品查看商品修改
        /// </summary>
        /// <param name="goodInfo">商品图片对象</param>
        /// <param name="goodinfo">商品对象</param>
        /// <returns>是否修改成功</returns>
        public bool UpdateGoodinfo(ImgInfo goodInfo, Good goodinfo)
        {
            string lUpdateGood = "update Good set GoodName=N'" + goodinfo.GoodName + "',GoodPrice='" + goodinfo.GoodPrice + "' where GoodID='" + goodinfo.GoodID + "'";
            string lUpdatePicture = "update ImgInfo set ImgAddress=N'" + goodInfo.ImgAddress + "',ImgTitle=N'" + goodInfo.ImgTitle + "' where GoodID='" + goodInfo.GoodID + "'";
            if (SqlHelper.ExecuteNonQuery(lUpdateGood) > 0 && SqlHelper.ExecuteNonQuery(lUpdatePicture) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 商品查看下一页
        /// </summary>
        /// <param name="thirdClassID">三级类目ID</param>
        /// <param name="Page">当前页</param>
        /// <returns></returns>
        public List<Good> NextPage(string thirdClassID, int Page)
        {
            Page = Page - 1;
            List<Good> GoodExamInfo = new List<Good>();
            string selectGoodInfo = "select top 10 * from Good where ThirdClassDmID='" + thirdClassID + "' and GoodID not in(select top ('" + Page + "'*10) GoodID from Good where ThirdClassDmID='" + thirdClassID + "' ) order by GoodID Desc";
            SqlHelper.ReadDateReadBegin(selectGoodInfo);
            while (SqlHelper.SqlReader.Read())
            {
                Good lGood = new Good();
                lGood.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                lGood.GoodName = SqlHelper.SqlReader["GoodName"].ToString();
                lGood.GoodPrice = SqlHelper.SqlReader["GoodPrice"].ToString();
                lGood.GoodIncentory = Convert.ToInt32(SqlHelper.SqlReader["GoodIncentory"]);
                lGood.SalesVolume = Convert.ToInt32(SqlHelper.SqlReader["SalesVolume"]);
                lGood.GoodInfo = SqlHelper.SqlReader["GoodInfo"].ToString();
                GoodExamInfo.Add(lGood);
            }
            SqlHelper.ReadDateReadEnd();
            return GoodExamInfo;
        }
        /// <summary>
        /// 商品查看上一页
        /// </summary>
        /// <param name="thirdClassID">三级类目ID</param>
        /// <param name="Page">当前页</param>
        /// <returns>上一页信息</returns>
        public List<Good> Uppage(string thirdClassID, int Page)
        {
            Page = Page - 1;
            List<Good> GoodExamInfo = new List<Good>();
            string selectGoodInfo = "select top 10 * from Good where ThirdClassDmID='" + thirdClassID + "' and GoodID not in(select top ('" + Page + "'*10) GoodID from Good where ThirdClassDmID='" + thirdClassID + "' ) order by GoodID Desc";
            SqlHelper.ReadDateReadBegin(selectGoodInfo);
            while (SqlHelper.SqlReader.Read())
            {
                Good lGood = new Good();
                lGood.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                lGood.GoodName = SqlHelper.SqlReader["GoodName"].ToString();
                lGood.GoodPrice = SqlHelper.SqlReader["GoodPrice"].ToString();
                lGood.GoodIncentory = Convert.ToInt32(SqlHelper.SqlReader["GoodIncentory"]);
                lGood.SalesVolume = Convert.ToInt32(SqlHelper.SqlReader["SalesVolume"]);
                lGood.GoodInfo = SqlHelper.SqlReader["GoodInfo"].ToString();
                GoodExamInfo.Add(lGood);
            }
            SqlHelper.ReadDateReadEnd();
            return GoodExamInfo;
        }
        /// <summary>
        /// 商品查看总页数
        /// </summary>
        /// <param name="thirdID">三级类目ID</param>
        /// <returns>总页数</returns>
        public int PageCount(string thirdID)
        {
            string lPageCount = "select count(1) GoodID from Good where ThirdClassDmID='" + thirdID + "'";
            int Count = SqlHelper.ExecuteNonQuery(lPageCount);
            return Count;
        }
        /// <summary>
        /// 商品管理更新家具城首页
        /// </summary>
        /// <param name="secondClassID">二级类目Id</param>
        /// <returns>家具城商品信息</returns>
        public List<ImgInfo> Furniture(string firstClassID)
        {
            Select CutTitle = new Select();
            List<ImgInfo> Furnitureinfo = new List<ImgInfo>();
            List<Good> GoodID = new List<Good>();
            string lselectThirdClassID = "select top 10 GoodID from Good where FirstClassDmID='" + firstClassID + "' order by GoodID desc";
            SqlHelper.ReadDateReadBegin(lselectThirdClassID);
            while (SqlHelper.SqlReader.Read())
            {
                Good ID = new Good();
                ID.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                GoodID.Add(ID);
            }
            SqlHelper.ReadDateReadEnd();
            for (int i = 0; i < GoodID.Count; i++)
            {
                string selectinfo = "select GoodID,ImgTitle,ImgAddress from ImgInfo where GoodID='" + GoodID[i].GoodID + "'";
                SqlHelper.ReadDateReadBegin(selectinfo);
                while (SqlHelper.SqlReader.Read())
                {
                    ImgInfo Imginfo = new ImgInfo();
                    Imginfo.ImgTitle = CutTitle.CutString(SqlHelper.SqlReader["ImgTitle"].ToString(),25);
                    Imginfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                    Imginfo.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                    Furnitureinfo.Add(Imginfo);
                }
                SqlHelper.ReadDateReadEnd();
            }
            return Furnitureinfo;
        }
        /// <summary>
        /// 商品管理更新家具城首页下一页
        /// </summary>
        /// <param name="firstClassID">一级类目ID</param>
        /// <returns>当前页</returns>
        public List<ImgInfo> Nextpage(string firstClassID, int currentPage)
        {
            Select CutTitle = new Select();
            List<ImgInfo> Furnitureinfo = new List<ImgInfo>();
            List<Good> GoodID = new List<Good>();
            string lselectThirdClassID = "select top 10 GoodID from Good where FirstClassDmID='" + firstClassID + "' and GoodID not in (select top('" + currentPage + "'*10)GoodID from Good where FirstClassDmID='" + firstClassID + "' order by GoodID desc ) order by GoodID desc";
            SqlHelper.ReadDateReadBegin(lselectThirdClassID);
            while (SqlHelper.SqlReader.Read())
            {
                Good ID = new Good();
                ID.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                GoodID.Add(ID);
            }
            SqlHelper.ReadDateReadEnd();
            for (int i = 0; i < GoodID.Count; i++)
            {
                string selectinfo = "select GoodID,ImgTitle,ImgAddress from ImgInfo where GoodID='" + GoodID[i].GoodID + "'";
                SqlHelper.ReadDateReadBegin(selectinfo);
                while (SqlHelper.SqlReader.Read())
                {
                    ImgInfo Imginfo = new ImgInfo();
                    Imginfo.ImgTitle = CutTitle.CutString(SqlHelper.SqlReader["ImgTitle"].ToString(),10);
                    Imginfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                    Imginfo.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                    Furnitureinfo.Add(Imginfo);
                }
                SqlHelper.ReadDateReadEnd();
            }
            return Furnitureinfo;
        }
        /// <summary>
        /// 商品管理员对家具城的界面管理信息总条数
        /// </summary>
        /// <param name="firstClassID">一级类目ID</param>
        /// <returns>信息总条数</returns>
        public int Count(string firstClassID)
        {
            string lSql = "select Count(1) GoodID from Good where FirstClassDmID='" + firstClassID + "'";
            int PageCount = Convert.ToInt32(SqlHelper.ReadSclar(lSql));
            return PageCount;
        }
        /// <summary>
        /// 修改前台页面是否成功
        /// </summary>
        /// <param name="goodID">需要修改的GoodID</param>
        /// <returns>是否成功</returns>
        public bool UpdateInterface(string[] goodID, int choose)
        {
            bool listrue = true;
            int lCount = DatabaseCount(choose);
            int lCountGoodID = 0;
            string[] GoodInfo;
            for (int i = 0; i < goodID.Length; i++)
            {
                if (goodID[i] != null && goodID[i] != "")
                {
                    lCountGoodID++;
                }
            }
            GoodInfo = new string[lCountGoodID];
            lCountGoodID = 0;
            for (int i = 0; i < goodID.Length; i++)
            {
                if (goodID[i] != null && goodID[i] != "")
                {
                    GoodInfo[lCountGoodID] = goodID[i];
                    lCountGoodID++;
                }
            }
            string lChoose = null;
            if (choose == 1)
            {
                lChoose = "HomePageProductShow";
            }
            if (choose == 2)
            {
                lChoose = "ClothesCityProductShow";
            }
            if (choose == 3)
            {
                lChoose = "CircuitCityProductShow";
            }
            if (choose == 4)
            {
                lChoose = "FurnitureCityProductShow";
            }
            string ldelete = "delete from " + lChoose + "";
            if (SqlHelper.ExecuteNonQuery(ldelete) > 0 || lCount == 1)
            {
                lCount = 1;
                for (int i = 0; i < GoodInfo.Length; i++)
                {
                    string lSql = "insert into " + lChoose + " (ImgID,ImgAddress,ImgTitle,GoodID) select * from ImgInfo where GoodID='" + GoodInfo[i] + "'";
                    string lUpdate = "update " + lChoose + " set Count= '" + lCount + "' where GoodID='" + GoodInfo[i] + "'";
                    if (SqlHelper.ExecuteNonQuery(lSql) > 0 && SqlHelper.ExecuteNonQuery(lUpdate) > 0)
                    {
                        listrue = true;
                    }
                    else
                    {
                        listrue = false;
                    }
                    lCount++;
                }
            }
            return listrue;
        }
        /// <summary>
        /// 确定每个商城主页在数据库中的数据条数
        /// </summary>
        /// <param name="number">哪个商场</param>
        /// <returns>有多少条</returns>
        public int DatabaseCount(int number)
        {
            int lCount = -1;
            if (number == 1)
            {
                string lSql = "select top 1 Count from HomePageProductShow order by Count desc";
                lCount = Convert.ToInt32(SqlHelper.ReadSclar(lSql));
                if (lCount == 0)
                {
                    lCount++;
                }
                else if (lCount < 20)
                {
                    lCount++;
                }
            }
            if (number == 2)
            {
                string lSql = "select top 1 Count from ClothesCityProductShow order by Count desc";
                lCount = Convert.ToInt32(SqlHelper.ReadSclar(lSql));
                if (lCount == 0)
                {
                    lCount++;
                }
                else if (lCount < 20)
                {
                    lCount++;
                }
            }
            if (number == 3)
            {
                string lSql = "select top 1 Count from CircuitCityProductShow order by Count desc";
                lCount = Convert.ToInt32(SqlHelper.ReadSclar(lSql));
                if (lCount == 0)
                {
                    lCount++;
                }
                else if (lCount < 20)
                {
                    lCount++;
                }
            }
            if (number == 4)
            {
                string lSql = "select top 1 Count from FurnitureCityProductShow order by Count desc";
                lCount = Convert.ToInt32(SqlHelper.ReadSclar(lSql));
                if (lCount == 0)
                {
                    lCount++;
                }
                else if (lCount < 20)
                {
                    lCount++;
                }
            }
            return lCount;
        }
        /// <summary>
        /// 主页商品展示更换商品
        /// </summary>
        /// <returns>商品信息</returns>
        public List<ImgInfo> HomePage()
        {
            Select CutTitle = new Select();
            List<ImgInfo> lHomePage = new List<ImgInfo>();
            string lSql = "select top 10 GoodID,ImgTitle,ImgAddress from ImgInfo order by GoodID desc";
            SqlHelper.ReadDateReadBegin(lSql);
            while (SqlHelper.SqlReader.Read())
            {
                ImgInfo Imginfo = new ImgInfo();
                Imginfo.ImgTitle = CutTitle.CutString(SqlHelper.SqlReader["ImgTitle"].ToString(),30);
                Imginfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                Imginfo.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                lHomePage.Add(Imginfo);
            }
            SqlHelper.ReadDateReadEnd();
            return lHomePage;
        }
        /// <summary>
        /// 商品管理员对首页的界面管理信息总条数
        /// </summary>
        /// <param name="firstClassID">一级类目ID</param>
        /// <returns>信息总条数</returns>
        public int HomeCount()
        {
            string lSql = "select Count(1) GoodID from Good";
            int PageCount = Convert.ToInt32(SqlHelper.ReadSclar(lSql));
            return PageCount;
        }
        /// <summary>
        /// 商品管理更新家具城首页下一页
        /// </summary>
        /// <param name="firstClassID">一级类目ID</param>
        /// <returns>当前页</returns>
        public List<ImgInfo> HomeNextpage(int currentPage)
        {
            Select CutTitle = new Select();
            List<ImgInfo> Furnitureinfo = new List<ImgInfo>();
            List<Good> GoodID = new List<Good>();
            string lselectThirdClassID = "select top 10 * from Good where GoodID not in (select top ('" + currentPage + "'*10)  GoodID from Good order by GoodID desc)order by GoodID desc";
            SqlHelper.ReadDateReadBegin(lselectThirdClassID);
            while (SqlHelper.SqlReader.Read())
            {
                Good ID = new Good();
                ID.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                GoodID.Add(ID);
            }
            SqlHelper.ReadDateReadEnd();
            for (int i = 0; i < GoodID.Count; i++)
            {
                string selectinfo = "select GoodID,ImgTitle,ImgAddress from ImgInfo where GoodID='" + GoodID[i].GoodID + "'";
                SqlHelper.ReadDateReadBegin(selectinfo);
                while (SqlHelper.SqlReader.Read())
                {
                    ImgInfo Imginfo = new ImgInfo();
                    Imginfo.ImgTitle = CutTitle.CutString(SqlHelper.SqlReader["ImgTitle"].ToString(),10);
                    Imginfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                    Imginfo.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                    Furnitureinfo.Add(Imginfo);
                }
                SqlHelper.ReadDateReadEnd();
            }
            return Furnitureinfo;
        }
        /// <summary>
        /// 存储HTML
        /// </summary>
        /// <param name="htmlEdit">单个商品HTML代码</param>
        /// <returns>成功失败</returns>
        public bool SaveHtml(SingleGoodHtmlEdit htmlEdit)
        {
            string lSqlstring = "insert SingleGoodHtmlEdit(GoodID,EditText,EditImg) values('" + htmlEdit.GoodID + "',N'" + htmlEdit.EditText + "',N'" + htmlEdit.EditImg + "')";
            if (SqlHelper.ExecuteNonQuery(lSqlstring) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询前台显示的图片
        /// </summary>
        /// <param name="choose">哪个商场</param>
        /// <returns>图片信息</returns>
        public List<ImgInfo> UpdatePictureShow(int choose)
        {
            List<ImgInfo> Update = new List<ImgInfo>();
            string lChoose = null;
            if (choose == 1)
            {
                lChoose = "HomePageProductShow";
            }
            if (choose == 2)
            {
                lChoose = "ClothesCityProductShow";
            }
            if (choose == 3)
            {
                lChoose = "CircuitCityProductShow";
            }
            if (choose == 4)
            {
                lChoose = "FurnitureCityProductShow";
            }
            string lSql = "select ImgTitle,GoodID from " + lChoose + " ";
            SqlHelper.ReadDateReadBegin(lSql);
            while (SqlHelper.SqlReader.Read())
            {
                Select lCutstring = new Select();
                ImgInfo img = new ImgInfo();
                img.ImgTitle = lCutstring.CutString( SqlHelper.SqlReader["ImgTitle"].ToString(),50);
                img.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                Update.Add(img);
            }
            SqlHelper.ReadDateReadEnd();
            return Update;
        }
        public bool updateProductShow(int choose, string goodID, string url)
        {
            string lChoose = null;
            string[] Goodinfo = new string[3];
            if (choose == 1)
            {
                lChoose = "HomePageProductShow";
            }
            if (choose == 2)
            {
                lChoose = "ClothesCityProductShow";
            }
            if (choose == 3)
            {
                lChoose = "CircuitCityProductShow";
            }
            if (choose == 4)
            {
                lChoose = "FurnitureCityProductShow";
            }
            string lSelect = "select ImgTitle,ImgID,GoodID from ImgInfo where ImgAddress=N'" + url + "'";
            SqlHelper.ReadDateReadBegin(lSelect);
            while (SqlHelper.SqlReader.Read())
            {
                Goodinfo[0] = SqlHelper.SqlReader["GoodID"].ToString();
                Goodinfo[1] = SqlHelper.SqlReader["ImgTitle"].ToString();
                Goodinfo[2] = SqlHelper.SqlReader["ImgID"].ToString();
            }
            SqlHelper.ReadDateReadEnd();
            string lUpdate = "update " + lChoose + " set GoodID=N'" + Goodinfo[0] + "',ImgTitle=N'" + Goodinfo[1] + "',ImgID='" + Goodinfo[2] + "',imgAddress=N'" + url + "' where GoodID='" + goodID + "'";
            if (SqlHelper.ExecuteNonQuery(lUpdate) > 0)
                return true;
            else
                return false;
        }
    }
}
