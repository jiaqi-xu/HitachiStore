/*
 * 1 功能描述：
 *   搜索类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-10-16-07；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;

namespace Models
{
    /// <summary>
    /// 用于搜索的类
    /// </summary>
    public class Select
    {
        /// <summary>
        /// 类目中模糊搜索商品
        /// </summary>
        /// <param name="textBox">搜索框中对应的字符串</param>
        /// <returns>对应的数字</returns>
        public int ClassSelectGood(string textBox)
        {
            string sqlFirstSelect = "select FirstClassDmID from FirstClassDm where FirstClassDmName=N'" + textBox + "'";
            string FirstClassDmID = (string)SqlHelper.ReadSclar(sqlFirstSelect);
            if (FirstClassDmID == null)//填写的值不在一级类目中
            {
                //进行一级类目筛选之后再对二级类目查找
                string sqlSecondSelect = "select SecondClassDmID from SecondClassDm where SecondClassDmName=N'" + textBox + "'";
                string SecondClassDmID = (string)SqlHelper.ReadSclar(sqlSecondSelect);
                if (SecondClassDmID == null)//填写的值不在二级类目中
                {

                    //对二级类目筛选之后再对三级类目查找
                    string sqlThirdSelect = "select ThirdClassDmID from ThirdClassDm where ThirdClassDmName=N'" + textBox + "'";
                    string ThirdClassDmID = (string)SqlHelper.ReadSclar(sqlThirdSelect);
                    if (ThirdClassDmID == null)//填写的值不在三级类目中
                    {
                        if (ReturnThirdClassResult(textBox) == 6)
                        {
                            return 6;
                        }
                        else
                        {
                            if (ReturnSecondClassResult(textBox) == 5)
                            {
                                return 5;
                            }
                            else
                            {
                                if (ReturnFirstClassResult(textBox) == 4)
                                {
                                    return 4;
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        return 3;
                    }

                }
                else
                {
                    //获取二级类目下的所有的三级类目显示在左侧
                    //通过对Good表的搜索找出对应该二级类目下的所有商品显示在右侧的DATALIST中
                    return 2;
                }

            }
            else
            {
                //获取一级类目下的所有的二级类目显示在左侧
                //通过对Good表的搜索找出对应该一级类目下的所有商品显示在右侧的DATALIST中
                return 1;
            }
        }
        /// <summary>
        /// 切割字符串
        /// </summary>
        /// <param name="lRead">商品名称</param>
        /// <returns>返回字</returns>
        public string CutString(string read,int number)
        {
            string lresult;
            if (read.Length > number)
            {
                lresult = read.Substring(0, number);
            }
            else
            {
                lresult = read.Substring(0, read.Length);
            }
            return lresult;
        }
        /// <summary>
        /// 将搜索框中的Text值截取成一位
        /// </summary>
        /// <param name="str">需要截取的字符串</param>
        /// <returns>截取后的字符串</returns>
        public string CutTbxText1(string str)
        {
            string lresult;
            lresult = str.Substring(0, 1);
            return lresult;
        }
        /// <summary>
        /// 在一级类目中进行模糊搜索
        /// </summary>
        /// <param name="textBox">搜索框中的字符串</param>
        /// <returns>二级类目表</returns>
        public List<FirstClassDm> FirstClassSelect(string textBox)
        {
            List<FirstClassDm> lFirstList = new List<FirstClassDm>();
            string lTextBox = this.CutTbxText1(textBox);
            string sqlFirstClassSelect = "select * from FirstClassDm where FirstClassDmName like N'%" + lTextBox + "%'";
            SqlHelper.ReadDateReadBegin(sqlFirstClassSelect);
            while (SqlHelper.SqlReader.Read())
            {
                FirstClassDm lFirstClassDm = new FirstClassDm();
                lFirstClassDm.FirstClassDmID = SqlHelper.SqlReader["FirstClassDmID"].ToString();
                lFirstClassDm.FirstClassDmName = SqlHelper.SqlReader["FirstClassDmName"].ToString();
                lFirstList.Add(lFirstClassDm);
            }
            SqlHelper.ReadDateReadEnd();
            return lFirstList;
        }
        /// <summary>
        /// 对应搜索返回相应的返回值
        /// </summary>
        /// <param name="textBox">对应搜索框中的字符串</param>
        /// <returns>数字</returns>
        public int ReturnFirstClassResult(string textBox)
        {
            if (this.FirstClassSelect(textBox).Count == 0)
            {
                return 0;
            }
            else
            {
                return 4;
            }
        }
        /// <summary>
        /// 在二级类目中进行模糊搜索
        /// </summary>
        /// <param name="textBox">对应搜索框中的字符串</param>
        /// <returns>二级类目表</returns>
        public List<SecondClassDm> SecondClassSelect(string textBox)
        {
            List<SecondClassDm> lSecondList = new List<SecondClassDm>();
            string lTextBox = this.CutTbxText1(textBox);
            string sqlSecondClassSelect = "select * from SecondClassDm where SecondClassDmName like N'%" + lTextBox + "%'";
            SqlHelper.ReadDateReadBegin(sqlSecondClassSelect);
            while (SqlHelper.SqlReader.Read())
            {
                SecondClassDm lSecondClassDm = new SecondClassDm();
                lSecondClassDm.SecondClassDmID = SqlHelper.SqlReader["SecondClassDmID"].ToString();
                lSecondClassDm.SecondClassDmName = SqlHelper.SqlReader["SecondClassDmName"].ToString();
                lSecondList.Add(lSecondClassDm);
            }
            SqlHelper.ReadDateReadEnd();
            return lSecondList;
        }
        /// <summary>
        /// 对应搜索返回相应的返回值
        /// </summary>
        /// <param name="textBox">对应搜索框中的字符串</param>
        /// <returns>数字</returns>
        public int ReturnSecondClassResult(string textBox)
        {
            if (this.SecondClassSelect(textBox).Count == 0)
            {
                return 0;
            }
            else
            {
                return 5;
            }
        }
        /// <summary>
        /// 在三级类目中进行模糊搜索
        /// </summary>
        /// <param name="textBox">对应搜索框中的字符串</param>
        /// <returns>三级类目表</returns>
        public List<ThirdClassDm> ThirdClassSelect(string textBox)
        {
            List<ThirdClassDm> lThirdList = new List<ThirdClassDm>();
            string lTextBox = this.CutTbxText1(textBox);
            string sqlSecondClassSelect = "select * from ThirdClassDm where ThirdClassDmName like N'%" + lTextBox + "%'";
            SqlHelper.ReadDateReadBegin(sqlSecondClassSelect);
            while (SqlHelper.SqlReader.Read())
            {
                ThirdClassDm lThirdClassDm = new ThirdClassDm();
                lThirdClassDm.ThirdClassDmID = SqlHelper.SqlReader["ThirdClassDmID"].ToString();
                lThirdClassDm.ThirdClassDmName = SqlHelper.SqlReader["ThirdClassDmName"].ToString();
                lThirdList.Add(lThirdClassDm);
            }
            SqlHelper.ReadDateReadEnd();
            return lThirdList;
        }
        /// <summary>
        /// 对应搜索返回相应的返回值
        /// </summary>
        /// <param name="textBox">对应搜索框中的字符串</param>
        /// <returns>数字</returns>
        public int ReturnThirdClassResult(string textBox)
        {
            if (this.ThirdClassSelect(textBox).Count == 0)
            {
                return 0;
            }
            else
            {
                return 6;
            }
        }
        /// <summary>
        /// 在Good表中搜索物品
        /// </summary>
        /// <param name="textBox">对应搜索框中的内容</param>
        /// <returns>对应状态</returns>
        public int GoodNameSelectGood(string textBox)
        {
            string lSqlstring = "select GoodName from Good where GoodName=N'" + textBox + "'";
            string lstr = (string)SqlHelper.ReadSclar(lSqlstring);
            if (lstr == null)
            {
                return 0;
            }
            else
            {
                return 7;
            }
        }
        /// <summary>
        /// 搜索对应商品的地址
        /// </summary>
        /// <param name="textBox">对应搜索框中的搜索名字</param>
        /// <returns>地址</returns>
        public string GoodNameRetrunImgAddress(string textBox)
        {
            string lSqlstring1 = "select GoodID from Good where GoodName=N'" + textBox + "'";
            int lTempGoodID = Convert.ToInt32(SqlHelper.ReadSclar(lSqlstring1));
            string lSqlstring2 = "select ImgAddress from ImgInfo where GoodID='" + lTempGoodID + "'";
            string lImgAddress = (string)SqlHelper.ReadSclar(lSqlstring2);
            return lImgAddress;
        }
        //public string PropertyContentReturnGoodID(string textBox)
        //{
        //    string lSqlstring = "select Good";
        //}
    }
}
