/*
 * 1 功能描述：
 *   实现订单管理员的相应功能
 *   管理员实体类；
 * 2 作者：
 *   郝云浩；
   3 创建时间：
 *   2012-08-03-11-7；
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
    public class OA : Admins
    {

        /// <summary>
        /// 数据读取并赋值给对象的共有属性
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns>OAdmin</returns>
        public OA OAInfoRead()
        {
            OA OAdmin = new OA();
            string sqlstring1 = "select StaffID,Password,TrueName,StaffType,AddTime,UserName,IdCardNum from Admin where UserName='" + this.UserName + "'";
            SqlHelper.ReadDateReadBegin(sqlstring1);
            while (SqlHelper.SqlReader.Read())
            {
                OAdmin.StaffID = Convert.ToInt32(SqlHelper.SqlReader["StaffID"]);
                OAdmin.PassWord = SqlHelper.SqlReader["PassWord"].ToString();
                OAdmin.TrueName = SqlHelper.SqlReader["TrueName"].ToString();
                OAdmin.StaffType = Convert.ToChar(SqlHelper.SqlReader["StaffType"]);
                OAdmin.AddTime = SqlHelper.SqlReader["AddTime"].ToString();
                OAdmin.IdCardNum = SqlHelper.SqlReader["IdCardNum"].ToString();



            }
            SqlHelper.ReadDateReadEnd();


            return OAdmin;
        }
        /// <summary>
        /// 对订单管理员数据的修改
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public bool AlterOAInfo()
        {
            OA OAdmin = new OA();

            string sqlstring = "update Admin set TrueName=N'" + this.TrueName + "',IdCardNum='" + this.IdCardNum + "',PassWord='" + this.PassWord + "'where UserName =N'" + this.UserName + "'";
            if (SqlHelper.ExecuteNonQuery(sqlstring) > 0)
            {
                return true;

            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 从数据库中调取订单信息
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        string[] arr = new string[13];
        public string[] OrderInfoRead(SaveOrders Order)
        {

            string sqlstring1 = "select StoreUser.UserName,ShipAddress.Address,SingleGoodID,Number,TotalPrices,SubmitTime,TradeStatus,CalloffReason,SendTime,EndTime,Admin.TrueName,SaveOrders.IsDeal from SaveOrders left join StoreUser on StoreUser.UserID=SaveOrders.UserID left Join Admin on Admin.StaffID=SaveOrders.StaffID left join ShipAddress on SaveOrders.AddressID=ShipAddress.AddressID where SaveOrders.OrderID=N'" + Order.OrderID + "'";

            SqlHelper.ReadDateReadBegin(sqlstring1);
            while (SqlHelper.SqlReader.Read())
            {
                arr[0] = SqlHelper.SqlReader["UserName"].ToString();
                arr[1] = SqlHelper.SqlReader["Address"].ToString();
                arr[2] = SqlHelper.SqlReader["Number"].ToString();
                arr[3] = SqlHelper.SqlReader["TotalPrices"].ToString();
                arr[5] = SqlHelper.SqlReader["SubmitTime"].ToString();
                arr[6] = SqlHelper.SqlReader["TradeStatus"].ToString();
                arr[7] = SqlHelper.SqlReader["CalloffReason"].ToString();
                arr[8] = SqlHelper.SqlReader["SendTime"].ToString();
                arr[9] = SqlHelper.SqlReader["EndTime"].ToString();
                arr[10] = SqlHelper.SqlReader["TrueName"].ToString();
                arr[12] = SqlHelper.SqlReader["IsDeal"].ToString();
                arr[4] = SqlHelper.SqlReader["SingleGoodID"].ToString();

            }
            SqlHelper.ReadDateReadEnd();
            return arr;
        }
        /// <summary>
        /// 验证输入的订单号是否存在
        /// </summary>
        /// <param name="mOrder"></param>
        /// <returns></returns>
        public bool OrderExam(SaveOrders mOrder)
        {

            string sqlstring = "select UserID from SaveOrders where OrderID='" + mOrder.OrderID + "'";


            if (SqlHelper.ReadSclar(sqlstring) != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        /// <summary>
        /// 对订单的修改
        /// </summary>
        /// <returns></returns>
        public bool AlterOrderStatus(SaveOrders alter)
        {

            string sqlstring = "update Orders set TradeStatus ='" + alter.TradeStatus + "'" + "where OrderID='" + alter.OrderID + "'" + ";update SaveOrders set TradeStatus ='" + alter.TradeStatus + "'" + "where OrderID='" + alter.OrderID + "'" + ";update SaveOrders set IsDeal ='" + alter.IsDeal + "'" + "where OrderID='" + alter.OrderID + "'" + ";update Orders set IsDeal ='" + alter.IsDeal + "'" + "where OrderID='" + alter.OrderID + "'" + ";update SaveOrders set StaffID='" + alter.StaffID + "'" + "where OrderID='" + alter.OrderID + "'" + ";update Orders set StaffID='" + alter.StaffID + "'" + "where OrderID='" + alter.OrderID + "'";
            string sqlstring2 = "select UserInfo.MoneySum from StoreUser left join UserInfo on UserInfo.UserID=StoreUser.UserID where UserName='" + alter.ReceiveStr + "'";
            StoreUser mStore = new StoreUser();
            mStore.UserName = alter.ReceiveStr;
            int TempUserID = StoreUser.UserNameGetID(mStore);
            int Money = Convert.ToInt32(SqlHelper.ReadSclar(sqlstring2)) + Convert.ToInt32(alter.TotalPrices);
            string sqlstring3 = "update UserInfo set MoneySum ='" + Money + "'" + "where UserID='" + TempUserID + "'";
            if (alter.TradeStatus == '3' && alter.Number != 0)
            {
                string sqlstring4 = "select Good.SalesVolume from SaveOrders left join SaveSingleGoodInfo on SaveOrders.SingleGoodID=SaveSingleGoodInfo.SingleGoodID left join Good on SaveSingleGoodInfo.GoodID=Good.GoodID  where OrderID='" + alter.OrderID + "'";
                string sqlstring5 = "select GoodID from SaveOrders left join SaveSingleGoodInfo on SaveOrders.SingleGoodID=SaveSingleGoodInfo.SingleGoodID where OrderID='" + alter.OrderID + "'";
                int SalesVolume=(Convert .ToInt32 (SqlHelper .ReadSclar (sqlstring4 ))+alter .Number );
                int GoodID =Convert .ToInt32( SqlHelper .ReadSclar (sqlstring5));
                string sqlstring6 = "update Good set SalesVolume='" + SalesVolume +"'"+ " where GoodID='" + GoodID + "'";
                string sqlstring8 = "select Good.GoodIncentory from SaveOrders left join SaveSingleGoodInfo on SaveOrders.SingleGoodID=SaveSingleGoodInfo.SingleGoodID left join Good on SaveSingleGoodInfo.GoodID=Good.GoodID  where OrderID='" + alter.OrderID + "'";
                int GoodIncentory = (Convert.ToInt32(SqlHelper.ReadSclar(sqlstring8)) - alter.Number);
                string sqlstring7 = "update Good set GoodIncentory='" + GoodIncentory + "'" + " where GoodID='" + GoodID + "'";
                SingleGoodInfo mSingleGoodInfo = new SingleGoodInfo();
                mSingleGoodInfo.SingleGoodID = alter.SingleGoodID;
                int TempGoodID = SingleGoodInfo.SingleGoodIDGetGood(mSingleGoodInfo);
                string sqlstring1 = "delete top(" + alter.Number + ") from SaveSingleGoodInfo  where GoodID='" + TempGoodID + "'";
                if (SqlHelper.ExecuteNonQuery(sqlstring) > 0 && SqlHelper.ExecuteNonQuery(sqlstring1) > 0 && SqlHelper.ExecuteNonQuery(sqlstring3) > 0&&SqlHelper.ExecuteNonQuery (sqlstring6 )>0&&SqlHelper.ExecuteNonQuery (sqlstring7 )>0)
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
                if (SqlHelper.ExecuteNonQuery(sqlstring) > 0)
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
        /// 修改处理订单管理员ID
        /// </summary>
        /// <param name="alter"></param>
        /// <returns></returns>
        //public bool AlterStaffID(SaveOrders alter)
        //{
        //    string sqlstr="update Orders set StaffID ='"+alter .StaffID +"'"+" where OrderID='"+alter .StaffID +"'"+";update SaveOrders set StaffID ='"+alter .StaffID +"'"+" where OrderID='"+alter .StaffID +"'";
        //    if (SqlHelper.ExecuteNonQuery(sqlstr) > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        /// <summary>
        /// 时间获取
        /// </summary>
        /// <param name="GetTime"></param>
        /// <returns></returns>
        public bool GetTradeTime(SaveOrders GetTime)
        {
            string sqlstring = "";

            switch (GetTime.TradeStatus.ToString())
            {
                case "1":
                    sqlstring = "update  SaveOrders  set SubmitTime = getdate() where OrderID='" + GetTime.OrderID + "'" + ";update Orders set SubmitTime = getdate() where OrderID='" + GetTime.OrderID + "'"; ;
                    break;
                case "2":
                    sqlstring = "update  SaveOrders  set SendTime = getdate() where OrderID='" + GetTime.OrderID + "'" + ";update Orders set SendTime = getdate() where OrderID='" + GetTime.OrderID + "'";
                    break;
                case "3":
                    sqlstring = "update SaveOrders set  EndTime = getdate() where OrderID='" + GetTime.OrderID + "'" + "; update Orders set EndTime = getdate() where OrderID='" + GetTime.OrderID + "'";
                    break;
            }
            if (GetTime.TradeStatus.ToString() != "0")
            {
                if (SqlHelper.ExecuteNonQuery(sqlstring) > 0)
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
                return false;
            }
        }
        /// <summary>
        /// 订单分页查询
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <returns></returns>
        public List<SaveOrders> DivideShow(int CurrentPage)
        {
            List<SaveOrders> ListOrder = new List<SaveOrders>();
            string Sqlstring1 = "select top (8) StoreUser.UserName,Good.GoodName,OrderID,TotalPrices,SaveOrders.IsDeal from  SaveOrders left join SingleGoodInfo on SaveOrders.SingleGoodID=SingleGoodInfo.SingleGoodID left join StoreUser on  StoreUser.UserID=SaveOrders.UserID  left join Good on SingleGoodInfo.GoodID=Good.GoodID where OrderID not in (select top (" + CurrentPage * 8 + ") OrderID from SaveOrders order by OrderID asc)order by OrderID";
            SqlHelper.ReadDateReadBegin(Sqlstring1);
            while (SqlHelper.SqlReader.Read())
            {
                SaveOrders mOrder = new SaveOrders();
                mOrder.ReceiveStr = SqlHelper.SqlReader["UserName"].ToString();
                mOrder.Getstr = SqlHelper.SqlReader["GoodName"].ToString();
                mOrder.OrderID = SqlHelper.SqlReader["OrderID"].ToString();
                mOrder.TotalPrices = Convert.ToInt32(SqlHelper.SqlReader["TotalPrices"]);
                string str = SqlHelper.SqlReader["IsDeal"].ToString();
                switch (str)
                {
                    case "0":
                        mOrder.IsDeal = "未处理";
                        break;
                    case "1":
                        mOrder.IsDeal = "已处理";
                        break;
                    case "2":
                        mOrder.IsDeal = "已取消";
                        break;
                }
                ListOrder.Add(mOrder);
            }
            SqlHelper.ReadDateReadEnd();
            return ListOrder;
        }
        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        public int GetPages()
        {
            int pagesize = 8;
            string sqlstring = "select count(*) from SaveOrders ";
            int temp = Convert.ToInt32(SqlHelper.ReadSclar(sqlstring));
            int Pages = (temp % pagesize) == 0 ? (temp / pagesize) : ((temp / pagesize) + 1);

            return Pages;
        }
        /// <summary>
        /// 获取未处理订单数目
        /// </summary>
        /// <returns></returns>
        public int GetNotDeal()
        {
            string sqlstring = "select count(*) from SaveOrders where IsDeal=0";
            int Sum = Convert.ToInt32(SqlHelper.ReadSclar(sqlstring));
            return Sum;
        }
        public bool DeleteOrder(SaveOrders mSaveOrder)
        {
            string sqlstring = "delete from SaveOrders where OrderID='" + mSaveOrder.OrderID + "'";
            if (SqlHelper.ExecuteNonQuery(sqlstring) > 0)
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




