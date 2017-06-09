/*
 * 1 功能描述：
 *   单个商品类；
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
    public class SingleGoodInfo
    {

        /// <summary>
        /// 单个商品ID
        /// </summary>
        private int singleGoodID;
        public int SingleGoodID
        {
            set { singleGoodID = value; }
            get { return singleGoodID; }
        }
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
        /// 管理员ID
        /// </summary>
        private int staffID;
        public int StaffID
        {
            set { staffID = value; }
            get { return staffID; }
        }
        /// <summary>
        /// 商品ID获取单个商品ID
        /// </summary>
        /// <param name="singleGoodinfo">单个商品信息</param>
        /// <returns>单个商品ID</returns>
        public static int GoodIDGetSingleGoodID(SingleGoodInfo singleGoodinfo)
        {
            string sqlstring = "select SingleGoodID from SaveSingleGoodInfo where GoodID='" + singleGoodinfo.GoodID + "'";
            Object obj = SqlHelper.ReadSclar(sqlstring);
            int TempSingleGoodID = Convert.ToInt32(obj);
            return TempSingleGoodID;
        }
        /// <summary>
        /// 单个商品ID获取商品ID
        /// </summary>
        /// <param name="singleGoodinfo">单个商品对象</param>
        /// <returns>商品ID</returns>
        public static int SingleGoodIDGetGood(SingleGoodInfo singleGoodinfo)
        {
            string sqlstring = "select GoodID from SaveSingleGoodInfo where SingleGoodID='" + singleGoodinfo.SingleGoodID + "'";
            Object obj = SqlHelper.ReadSclar(sqlstring);
            int TempGoodID = Convert.ToInt32(obj);
            return TempGoodID;
        }
        /// <summary>
        /// 获得商品ID
        /// </summary>
        /// <param name="singleGoodinfo">单个商品对象</param>
        /// <returns>商品id</returns>
        public static int SingleGoodIDGetGoodFromSingleGood(SingleGoodInfo singleGoodinfo)
        {
            string sqlstring = "select GoodID from SingleGoodInfo where SingleGoodID='" + singleGoodinfo.SingleGoodID + "'";
            Object obj = SqlHelper.ReadSclar(sqlstring);
            int TempGoodID = Convert.ToInt32(obj);
            return TempGoodID;
        }
        public static List<SingleGoodHtmlEdit> GetSingleGoodInfo(int GoodID)
        {
            List<SingleGoodHtmlEdit> SingleGoodHtmlList = new List<SingleGoodHtmlEdit>();
            string lSqlString = "select * from SingleGoodHtmlEdit where GoodID='"+GoodID+"'";
            SqlHelper.ReadDateReadBegin(lSqlString);
            while (SqlHelper.SqlReader.Read())
            {
                SingleGoodHtmlEdit lSingleGoodHtmlEdit = new SingleGoodHtmlEdit();
                lSingleGoodHtmlEdit.EditImg = SqlHelper.SqlReader["EditImg"].ToString();
                lSingleGoodHtmlEdit.EditText = SqlHelper.SqlReader["EditText"].ToString();
                SingleGoodHtmlList.Add(lSingleGoodHtmlEdit);
            }
            SqlHelper.ReadDateReadEnd();
            return SingleGoodHtmlList;
        }
        /// <summary>
        /// 商品ID获取单个商品ID
        /// </summary>
        /// <param name="singleGoodinfo">单个商品信息</param>
        /// <returns>单个商品ID</returns>
        public static int mGoodIDGetSingleGoodID(SingleGoodInfo singleGoodinfo)
        {
            string sqlstring = "select SingleGoodID from SaveSingleGoodInfo where GoodID='"+singleGoodinfo.GoodID+"' and IsDeal =0";
            Object obj = SqlHelper.ReadSclar(sqlstring);
            int TempSingleGoodID = Convert.ToInt32(obj);
            return TempSingleGoodID;
        }
    }
}
