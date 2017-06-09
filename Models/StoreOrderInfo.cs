/*
 * 功能描述：

 * 将Order和StoreUser中的部分信息结合
 * 
 * 作者：
 * 李霏
 * 
 * 创建时间：

 * 2012-08-11-14-13
 * 
 * 完成时间：

 * 
 * 修改记录：

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;

namespace Models
{
    public class StoreOrderInfo : Order
    {
        /// <summary>
        /// 用户名
        /// </summary>
        private string UserName;
        public string Username
        {
            set { UserName = value; }
            get { return UserName; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        private string GoodName;
        public string Goodname
        {
            set { GoodName = value; }
            get { return GoodName; }
        }
        /// <summary>
        /// OrderID
        /// </summary>
        private int SaveOrderID;
        public int SaveorderID
        {
            set { SaveOrderID = value; }
            get { return SaveOrderID; }
        }
        /// <summary>
        /// 是否评价
        /// </summary>
        private char IsEvaluate;
        public char isEvaluate
        {
            set { IsEvaluate = value; }
            get { return IsEvaluate; }
        }
        private string ImgAddress;
        public string imgAddress
        {
            set { ImgAddress = value; }
            get { return ImgAddress; }
        }
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <returns>订单信息</returns>
        public List<StoreOrderInfo> OrderInfo()
        {
            Select lcutstring = new Select();
            List<StoreOrderInfo> OrderList = new List<StoreOrderInfo>();
            string Sql = "select UserID from StoreUser where UserName='" + this.UserName + "'";//查询UserID
            Object obj = SqlHelper.ReadSclar(Sql);
            string Sql1 = "select top 5 * from StoreOrderInfo where Ltrim(UserID)='" + obj.ToString() + "'";//查出前五条信息
            SqlHelper.ReadDateReadBegin(Sql1);
            while (SqlHelper.SqlReader.Read())//将信息存入
            {
                StoreOrderInfo orderinfo = new StoreOrderInfo();
                orderinfo.SaveOrderID = Convert.ToInt32(SqlHelper.SqlReader["SaveOrderID"]);
                orderinfo.GoodName = lcutstring.CutString(  SqlHelper.SqlReader["GoodName"].ToString(),8);
                orderinfo.TradeStatus = Convert.ToChar(SqlHelper.SqlReader["TradeStatus"]);
                orderinfo.TotalPrices = Convert.ToInt32(SqlHelper.SqlReader["TotalPrices"]);
                orderinfo.SubmitTime = SqlHelper.SqlReader["SubmitTime"].ToString();
                orderinfo.IsEvaluate = Convert.ToChar(SqlHelper.SqlReader["IsEvaluate"]);
                orderinfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                OrderList.Add(orderinfo);
            }
            SqlHelper.ReadDateReadEnd();
            return OrderList;
        }
        /// <summary>
        /// 计算共有多少条记录

        /// </summary>
        /// <returns>记录条数</returns>
        public int PageCount()
        {
            string Sql = "select UserID from StoreUser where UserName='" + this.UserName + "'";//查询userID
            Object obj = SqlHelper.ReadSclar(Sql);
            string Sql1 = "select count(1) OrderID from StoreOrderInfo where UserID='" + obj.ToString() + "'";//改用户下有多少条订单
            Object obj1 = SqlHelper.ReadSclar(Sql1);
            return Convert.ToInt32(obj1);
        }
        /// <summary>
        /// 下一页信息

        /// </summary>
        /// <param name="page">当前页</param>
        /// <returns>下一页信息</returns>
        public List<StoreOrderInfo> nextPage(int page)
        {
            Select lcutstring = new Select();
            List<StoreOrderInfo> OrderList = new List<StoreOrderInfo>();
            string Sql = "select UserID from StoreUser where UserName='" + this.UserName + "'";//查询userID
            Object obj = SqlHelper.ReadSclar(Sql);
            string Sql1 = "select top 5 * from StoreOrderInfo where UserId='" + obj.ToString() + "' and orderID not in (select top ('" + page + "'*5) OrderID from StoreOrderInfo  where UserId='" + obj.ToString() + "' ) order by OrderID asc";//下一页
            SqlHelper.ReadDateReadBegin(Sql1);
            while (SqlHelper.SqlReader.Read())//存入信息
            {
                StoreOrderInfo orderinfo = new StoreOrderInfo();
                orderinfo.SaveOrderID = Convert.ToInt32(SqlHelper.SqlReader["SaveOrderID"]);
                orderinfo.GoodName = lcutstring.CutString( SqlHelper.SqlReader["GoodName"].ToString(),8);
                orderinfo.TradeStatus = Convert.ToChar(SqlHelper.SqlReader["TradeStatus"]);
                orderinfo.TotalPrices = Convert.ToInt32(SqlHelper.SqlReader["TotalPrices"]);
                orderinfo.SubmitTime = SqlHelper.SqlReader["SubmitTime"].ToString();
                orderinfo.IsEvaluate = Convert.ToChar(SqlHelper.SqlReader["IsEvaluate"]);
                orderinfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                OrderList.Add(orderinfo);
            }
            SqlHelper.ReadDateReadEnd();
            return OrderList;
        }
        /// <summary>
        /// 上一页信息

        /// </summary>
        /// <param name="Page">当前页</param>
        /// <returns>上一页信息</returns>
        public List<StoreOrderInfo> upPage(int Page)
        {
            Select lcutstring = new Select(); 
            List<StoreOrderInfo> OrderList = new List<StoreOrderInfo>();
            string Sql = "select UserID from StoreUser where UserName='" + this.UserName + "'";//查询UserID
            Object obj = SqlHelper.ReadSclar(Sql);
            int upPage = Page - 1;
            string Sql1 = "select top 5 * from StoreOrderInfo where UserId='" + obj.ToString() + "' and orderID not in (select top ('" + upPage + "'*5) OrderID from StoreOrderInfo  where UserId='" + obj.ToString() + "' ) order by OrderID asc";//下一页
            SqlHelper.ReadDateReadBegin(Sql1);
            while (SqlHelper.SqlReader.Read())//存入信息
            {
                StoreOrderInfo orderinfo = new StoreOrderInfo();
                orderinfo.SaveOrderID = Convert.ToInt32(SqlHelper.SqlReader["SaveOrderID"]);
                orderinfo.GoodName = lcutstring.CutString( SqlHelper.SqlReader["GoodName"].ToString(),8);
                orderinfo.TradeStatus = Convert.ToChar(SqlHelper.SqlReader["TradeStatus"]);
                orderinfo.TotalPrices = Convert.ToInt32(SqlHelper.SqlReader["TotalPrices"]);
                orderinfo.SubmitTime = SqlHelper.SqlReader["SubmitTime"].ToString();
                orderinfo.IsEvaluate = Convert.ToChar(SqlHelper.SqlReader["IsEvaluate"]);
                orderinfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                OrderList.Add(orderinfo);
            }
            SqlHelper.ReadDateReadEnd();
            return OrderList;
        }
    }
}
