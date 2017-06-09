/* 
  * 1 功能描述：

  *     保存订单实体类； 
  * 2 作者：
  *     郝云浩
  * 3 创建时间：

  *     2012-08-09-10-24；

  * 4 完成时间：

  *   
  * 5 修改记录：

  *     暂无（修改时间、内容、人）；
  */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
   public  class SaveOrders
    {
        public string aTradeStatus { get; set; }// 为string类型
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
        /// 用户ID
        /// </summary>
        private int  userID;
        public int  UserID
        {
            set { userID = value; }
            get { return userID; }
        }
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
        /// 商品数量
        /// </summary>
        private int number;
        public int Number
        {
            set { number = value; }
            get { return number; }
        }
        /// <summary>
        /// 商品总价
        /// </summary>
        private double  totalPrices;
        public double  TotalPrices
        {
            set { totalPrices = value; }
            get { return totalPrices; }
        }
        /// <summary>
        /// 地址ID
        /// </summary>
        private int addressID;
        public int AddressID
        {
            set { addressID = value; }
            get { return addressID; }
        }
        /// <summary>
        /// 提交时间
        /// </summary>
        private string submitTime;
        public string SubmitTime
        {
            set { submitTime = value; }
            get { return submitTime; }
        }
        /// <summary>
        /// 交易状态
        /// </summary>
        private char tradeStatus;
        public char TradeStatus
        {
            set { tradeStatus = value; }
            get { return tradeStatus; }
        }

        private string calloffReason;
        /// <summary>
        /// 取消理由
        /// </summary>
        public string CalloffReason
        {
            set { calloffReason = value; }
            get { return calloffReason; }
        }
        /// <summary>
        /// 发货时间
        /// </summary>
        private string sendTime;
        public string SendTime
        {
            set { sendTime = value; }
            get { return sendTime; }
        }
        /// <summary>
        /// 交易完成时间
        /// </summary>
        private string endTime;
        public string EndTime
        {
            set { endTime = value; }
            get { return endTime; }
        }
        /// <summary>
        /// 经手管理员ID
        /// </summary>
        private int staffID;
        public int StaffID
        {
            set { staffID = value; }
            get { return staffID; }
        }
       /// <summary>
       /// 保存订单ID
       /// </summary>
        private string saveOrderID;
        public string SaveOrderID
        {
            set { saveOrderID = value; }
            get { return saveOrderID; }

        }
        /// <summary>
        /// 是否处理过
        /// </summary>
        private string isDeal;
        public string IsDeal
        {
            set { isDeal = value; }
            get { return isDeal; }
        }
       /// <summary>
       /// 中转字符串
       /// </summary>
        private string receiveStr;
        public string ReceiveStr
        {
            set { receiveStr = value; }
            get { return receiveStr; }
        }
        /// <summary>
        /// 中转字符串
        /// </summary>
        private string getStr;
        public string Getstr
        {
            set { getStr = value; }
            get { return getStr; }
        }
    }
}
