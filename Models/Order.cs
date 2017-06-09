/* 
 * 1 功能描述：

 *     订单实体类； 
 * 2 作者：
 *     郝云浩
 * 3 创建时间：

 *     2012-08-07-19-08；

 * 4 完成时间：

 *   
 * 5 修改记录：

 *     暂无（修改时间、内容、人）；
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;
using System.Data;
using System.Data.SqlClient;

namespace Models
{
    public class Order
    {
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
        private int userID;
        public int UserID
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
        private double totalPrices;
        public double TotalPrices
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
        /// 是否处理过
        /// </summary>
        private string isDeal;
        public string IsDeal
        {
            set { isDeal = value; }
            get { return isDeal; }
        }
        public string aTradeStatus { get; set; }// 为string类型
        private string receiveStr;
        public string ReceiveStr
        {
            set { receiveStr = value; }
            get { return receiveStr; }
        }

        /// <summary>
        /// 获取OrderID
        /// </summary>
        /// <returns>OrderID</returns>
        public string CreateOrderID()
        {
            string orderID = "select top 1 OrderID from Orders order by OrderID desc";
            string caseNumber = "select CaseNumber from Assist ";
            Object orderID1 = SqlHelper.ReadSclar(orderID);
            Object caseNumber1 = SqlHelper.ReadSclar(caseNumber);
            int count = Convert.ToInt32(caseNumber1);
            string orderID2 = null;
            string now = DateTime.Now.ToShortDateString();//获取当前时间
            string[] data = now.Split('/');
            if (data[1].Length == 1)
            {
                string month = data[1];
                data[1] = "0" + month;
            }
            if (data[2].Length == 1)
            {
                string today = data[2];
                data[2] = "0" + today;
            }
            if (orderID1 == null)
            {
                count = 1;
                string upCount = "insert into Assist (CaseNumber) values ('" + count + "')";
                if (SqlHelper.ExecuteNonQuery(upCount) > 0)
                {
                    orderID2 = data[0] + data[1] + data[2] + count.ToString();
                }
            }
            else
            {
                orderID = orderID1.ToString();
                string a = orderID.Substring(6, 2);
                if (a != data[2])
                {
                    count = 1;
                }
                else
                {
                    count++;
                }
                string upCount = "Update Assist set CaseNumber='" + count + "'";
                if (SqlHelper.ExecuteNonQuery(upCount) > 0)
                {
                    orderID2 = data[0] + data[1] + data[2] + count.ToString();
                }
            }

            return orderID2;
        }
        /// <summary>
        /// 插入订单
        /// </summary>
        /// <returns>是否插入成功</returns>
        public bool CreateOrder(int AddressNumber)
        {
            int lCount = 0;
            string orderID = CreateOrderID();
            string AddressID = "select AddressID,IsDefault from ShipAddress where UserID='" + this.UserID + "'";//查找用户发货地址ID
            SqlHelper.ReadDateReadBegin(AddressID);
            while (SqlHelper.SqlReader.Read())
            {
                if (AddressNumber == lCount)
                {
                    AddressID = SqlHelper.SqlReader["AddressID"].ToString();
                    break;
                }
                lCount++;
            }
            SqlHelper.ReadDateReadEnd();
            string createOrder = "insert into Orders (OrderID,UserID,SingleGoodID,Number,TotalPrices,AddressID,SubmitTime,TradeStatus,IsEvaluate,IsDeal) values ('" + orderID + "','" + this.UserID + "','" + this.SingleGoodID + "','" + this.Number + "','" + this.TotalPrices + "','" + AddressID + "',Getdate(),'0','0','0')";
            string createSaveOrder = "insert into SaveOrders (SaveOrderID,OrderID,UserID,SingleGoodID,Number,TotalPrices,AddressID,SubmitTime,TradeStatus,IsEvaluate,IsDeal) values ('" + orderID + "','" + orderID + "','" + this.UserID + "','" + this.SingleGoodID + "','" + this.Number + "','" + this.TotalPrices + "','" + AddressID + "',Getdate(),'0','0','0')";
            string UpdateSingleGood = "update SingleGoodInfo set IsDeal=1 where SingleGoodID='" + this.SingleGoodID + "'";
            string updateSingleGood = "update SaveSingleGoodInfo set IsDeal=1 where SingleGoodID='" + this.SingleGoodID + "'";
            if (SqlHelper.ExecuteNonQuery(createOrder) > 0 && SqlHelper.ExecuteNonQuery(createSaveOrder) > 0 && SqlHelper.ExecuteNonQuery(updateSingleGood) > 0 && SqlHelper.ExecuteNonQuery(UpdateSingleGood) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 单个商品信息
        /// </summary>
        /// <param name="goodID">GoodID</param>
        /// <returns>单个商品信息</returns>
        public List<Good> GoodInfo(int goodID)
        {
            List<Good> Goodinfo = new List<Good>();
            string goodInfo = "select GoodPrice,GoodName,GoodID,GoodIncentory from Good where GoodId='" + goodID + "'";
            SqlHelper.ReadDateReadBegin(goodInfo);
            while (SqlHelper.SqlReader.Read())
            {
                Good goodinfo = new Good();
                goodinfo.GoodPrice = SqlHelper.SqlReader["GoodPrice"].ToString();
                goodinfo.GoodName = SqlHelper.SqlReader["GoodName"].ToString();
                goodinfo.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                goodinfo.GoodIncentory = Convert.ToInt32(SqlHelper.SqlReader["GoodIncentory"]);
                Goodinfo.Add(goodinfo);
            }
            SqlHelper.ReadDateReadEnd();
            return Goodinfo;
        }
        /// <summary>
        /// 单个商品图片名称
        /// </summary>
        /// <param name="goodID">GoodID</param>
        /// <returns>单个商品图片名称</returns>
        public List<ImgInfo> Goodtile(int goodID)
        {
            List<ImgInfo> goodinfo = new List<ImgInfo>();
            string goodTiele = "select ImgTitle from ImgInfo where GoodID='" + goodID + "'";
            SqlHelper.ReadDateReadBegin(goodTiele);
            while (SqlHelper.SqlReader.Read())
            {
                ImgInfo img = new ImgInfo();
                img.ImgTitle = SqlHelper.SqlReader["ImgTitle"].ToString();
                goodinfo.Add(img);
            }
            SqlHelper.ReadDateReadEnd();
            return goodinfo;
        }
        /// <summary>
        /// 订单查看
        /// </summary>
        /// <returns>订单信息</returns>
        public DataTable OrderExam()
        {
            string GoodInfo = "select * from SaveOrders left join SingleGoodInfo on SaveOrders.SingleGoodID=SingleGoodInfo.SingleGoodID left join Good on Good.GoodID=SingleGoodInfo.GoodID where  SaveOrders.OrderID='" + this.OrderID + "'";
            DataTable Goodinfo = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(GoodInfo, SQLHelper.DataSource.ConnectStr);
            adapter.Fill(Goodinfo);
            return Goodinfo;
        }
    }
}
