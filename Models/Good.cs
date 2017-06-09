/*
 * 1 功能描述：
 *   商品管理员类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-15-09-14；
 * 4 完成时间：
 *   2012-08-16-21-38；    
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
    /// 商品类
    /// </summary>
    public class Good
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        private int goodID;
        public int GoodID
        {
            set { goodID = value; }
            get { return goodID; }
        }
        /// <summary>
        /// 商品名字
        /// </summary>
        private string goodName;
        public string GoodName
        {
            set { goodName = value; }
            get { return goodName; }
        }
        /// <summary>
        /// 商品价格
        /// </summary>
        private string goodPrice;
        public string GoodPrice
        {
            set { goodPrice = value; }
            get { return goodPrice; }
        }
        /// <summary>
        /// 商品库存
        /// </summary>
        private int goodIncentory;
        public int GoodIncentory
        {
            set { goodIncentory = value; }
            get { return goodIncentory; }
        }
        /// <summary>
        /// 商品销量
        /// </summary>
        private int salesVolume;
        public int SalesVolume
        {
            set { salesVolume = value; }
            get { return salesVolume; }
        }
        /// <summary>
        /// 商品详细说明
        /// </summary>
        private string goodInfo;
        public string GoodInfo
        {
            set { goodInfo = value; }
            get { return goodInfo; }
        }
        /// <summary>
        /// 对应详细说明的图片
        /// </summary>
        private string goodImgInfo;
        public string GoodImgInfo
        {
            set { goodImgInfo = value; }
            get { return goodImgInfo; }
        }
        /// <summary>
        /// 折扣
        /// </summary>
        private float discount;
        public float Discount
        {
            set { discount = value; }
            get { return discount; }
        }
        /// <summary>
        /// 一级类目ID
        /// </summary>
        private string firstClassDmID;
        public string FirstClassDmID
        {
            set { firstClassDmID = value; }
            get { return firstClassDmID; }
        }
        /// <summary>
        /// 二级类目ID
        /// </summary>
        private string secondClassDmID;
        public string SecondClassDmID
        {
            set { secondClassDmID = value; }
            get { return secondClassDmID; }
        }
        /// <summary>
        /// 三级类目ID
        /// </summary>
        private string thirdClassDmID;
        public string ThirdClassDmID
        {
            set { thirdClassDmID = value; }
            get { return thirdClassDmID; }
        }
        /// <summary>
        /// 用商品名字获取ID
        /// </summary>
        /// <param name="good">商品对象</param>
        /// <returns>商品ID</returns>
        public static int GoodNameGetID(Good good)
        {
            string lSqlstring = "select GoodID from Good where GoodName=N'" + good.GoodName + "'";
            Object obj = SqlHelper.ReadSclar(lSqlstring);
            int TempGoodID = Convert.ToInt32(obj);
            return TempGoodID;
        }
        /// <summary>
        /// 由商品ID获取商品名字
        /// </summary>
        /// <param name="good">商品对象</param>
        /// <returns>商品名字</returns>
        public static string GoodIDGetName(Good good)
        {
            string lSqlstring = "select GoodName from Good where GoodID='" + good.GoodName + "'";
            Object obj = SqlHelper.ReadSclar(lSqlstring);
            string TempGoodName = (string)obj;
            return TempGoodName;
        }
        /// <summary>
        /// 由一级类目ID获取商品ID
        /// </summary>
        /// <param name="good">商品对象</param>
        /// <returns>商品列表</returns>
        public static List<Good> FcIDGetGoodID(Good good)
        {
            List<Good> lGoodList = new List<Good>();
            string lSqlstring = "select GoodID from Good where FirstClassDmID='" + good.FirstClassDmID + "'";
            SqlHelper.ReadDateReadBegin(lSqlstring);
            while (SqlHelper.SqlReader.Read())
            {
                Good lGood = new Good();
                lGood.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                lGoodList.Add(lGood);
            }
            SqlHelper.ReadDateReadEnd();
            return lGoodList;
        }
        /// <summary>
        ///  由二级类目ID获取商品ID
        /// </summary>
        /// <param name="good">商品对象</param>
        /// <returns>商品列表</returns>
        public static List<Good> ScIDGetGoodID(Good good)
        {
            List<Good> lGoodList = new List<Good>();
            string lString = "select GoodID from Good where SecondClassDmID='" + good.SecondClassDmID + "'";
            SqlHelper.ReadDateReadBegin(lString);
            while (SqlHelper.SqlReader.Read())
            {
                Good lGood = new Good();
                lGood.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                lGoodList.Add(lGood);
            }
            SqlHelper.ReadDateReadEnd();
            return lGoodList;
        }
        /// <summary>
        /// 三级类目ID获取商品ID
        /// </summary>
        /// <param name="good">商品对象</param>
        /// <returns>商品列表</returns>
        public static List<Good> TcIDGetGoodID(Good good)
        {
            List<Good> lGoodList = new List<Good>();
            string lString = "select GoodID from Good where ThirdClassDmID='" + good.ThirdClassDmID + "'";
            SqlHelper.ReadDateReadBegin(lString);
            while (SqlHelper.SqlReader.Read())
            {
                Good lGood = new Good();
                lGood.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                lGoodList.Add(lGood);
            }
            SqlHelper.ReadDateReadEnd();
            return lGoodList;
        }
        public static string GoodIDGetFirstClassName(int GoodID)
        {
            string lSqlstring1 = "select FirstClassDmID from Good where GoodID='" + GoodID + "' ";
            string lStr = (string)SqlHelper.ReadSclar(lSqlstring1);
            string lSqlstring2 = "select FirstClassDmName from FirstClassDm where FirstClassDmID='"+lStr+"'";
            string lTempFirstClassDmName = (string)SqlHelper.ReadSclar(lSqlstring2);
            return lTempFirstClassDmName;
        }
        public static string GoodIDGetSecondClassName(int GoodID)
        {
            string lSqlstring1 = "select SecondClassDmID from Good where GoodID='" + GoodID + "' ";
            string lStr = (string)SqlHelper.ReadSclar(lSqlstring1);
            string lSqlstring2 = "select SecondClassDmName from SecondClassDm where SecondClassDmID='" + lStr + "'";
            string lTempFirstClassDmName = (string)SqlHelper.ReadSclar(lSqlstring2);
            return lTempFirstClassDmName;
        }
        public static string GoodIDGetThirdClassName(int GoodID)
        {
            string lSqlstring1 = "select ThirdClassDmID from Good where GoodID='" + GoodID + "' ";
            string lStr = (string)SqlHelper.ReadSclar(lSqlstring1);
            string lSqlstring2 = "select ThirdClassDmName from ThirdClassDm where ThirdClassDmID='" + lStr + "'";
            string lTempFirstClassDmName = (string)SqlHelper.ReadSclar(lSqlstring2);
            return lTempFirstClassDmName;
        }
    }
}
