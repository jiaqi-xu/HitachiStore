/*
 * 1 功能描述：
 *   评价实体类；
 * 2 作者：
 *   徐嘉琪；
   3 创建时间：
 *   2012-08-03-15-00；
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
    public class GoodEvaluate
    {
        /// <summary>
        /// 评价ID号
        /// </summary>
        private int evaluateID;
        public int EvaluateID
        {
            set { evaluateID = value; }
            get { return evaluateID; }
        }

        /// <summary>
        /// 商品ID号
        /// </summary>
        private int goodID;
        public int GoodID
        {
            set { goodID = value; }
            get { return goodID; }
        }

        /// <summary>
        /// 评价时间
        /// </summary>
        private string evaluateTime;
        public string EvaluateTime
        {
            set { evaluateTime = value; }
            get { return evaluateTime; }

        }

        /// <summary>
        /// 用户ID
        /// </summary>
        private int userID;
        public int UserID
        {
            set { userID = value; }
            get { return userID; }
        }

        /// <summary>
        /// 评价等级
        /// </summary>
        private char evaluateGrade;
        public char EvaluateGrade
        {
            set { evaluateGrade = value; }
            get { return evaluateGrade; }
        }
        /// <summary>
        /// 评价内容
        /// </summary>
        private string evaluateContent;
        public string EvaluateContent
        {
            set { evaluateContent = value; }
            get { return evaluateContent; }
        }
        /// <summary>
        /// 订单ID
        /// </summary>
        private string orderID;
        public string OrderID
        {
            set { orderID = value; }
            get { return orderID; }
        }
        /// <summary>
        ///  创建商品评价
        /// </summary>
        public bool SubmitGoodEvaluate()
        {

            string Sqlstring = "insert into GooDEvaluate (EvaluateContent,EvaluateTime,EvaluateGrade,GoodID,UserID) values('" + this.EvaluateContent + "',getdate(),'" + this.EvaluateGrade + "',1,1)";
            if (SqlHelper.ExecuteNonQuery(Sqlstring) > 0)
            {
                return true;
            }
            else
            { return false; }

        }

        public string aEvaluateGrade { get; set; }// 为string类型
        /// <summary>
        /// 评价订单
        /// </summary>
        /// <returns>是否评价成功</returns>
        public bool OrderEvaluate()
        {
            string singleGoodid = "select SingleGoodID from Orders where OrderID='" + this.OrderID + "'";
            SingleGoodInfo single = new SingleGoodInfo();
            single.SingleGoodID = Convert.ToInt32(SqlHelper.ReadSclar(singleGoodid));
            int goodID = SingleGoodInfo.SingleGoodIDGetGoodFromSingleGood(single);
            string lEvaluate = "insert into GoodEvaluate (GoodID,EvaluateContent, EvaluateTime,UserID,EvaluateGrade,OrderID) values ('" + goodID + "',N'" + this.EvaluateContent + "',getdate(),'" + this.userID + "','" + this.EvaluateGrade + "','" + this.OrderID + "')";
            string lIsEvaluate = "update Orders set IsEvaluate='" + 1 + "' where OrderID='" + this.OrderID + "'";
            string lIsevaluate = "update SaveOrders set IsEvaluate='" + 1 + "' where OrderID='" + this.OrderID + "'";
            if (SqlHelper.ExecuteNonQuery(lEvaluate) > 0 && SqlHelper.ExecuteNonQuery(lIsevaluate) > 0 && SqlHelper.ExecuteNonQuery(lIsEvaluate) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
