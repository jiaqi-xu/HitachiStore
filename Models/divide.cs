/*
 * 1 功能描述：
 *     各种分页，DataList应用
 * 2 作者：
 *   徐嘉琪；
   3 创建时间：
 *   2012-08-13-14-30；
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
using System.Data;
using System.Data.SqlClient;

namespace Models
{
 public   class divide
    {
     //public DataSet divideText(int surrentPage)
     //{
     //    int pageSum = 0;
     //    int pageSize = 10;
     //    string Sqlstring = "select count(*) from Admin";
     //    object obj = SqlHelper.ReadSclar(Sqlstring);
     //    int countInfoSum = Convert.ToInt32(obj);
     //    pageSum = (countInfoSum % pageSize) == 0 ? (countInfoSum / pageSize) : (countInfoSum / pageSize + 1);
     //    string Sqlstring1 = "select top 10 StaffID,UserName,StaffType,TrueName,AddTime from Admin where StaffID not in (select top " + surrentPage + " StaffID from Admin order by StaffID asc) order by StaffID";
     //    DataSet set = new DataSet();
     //    SqlDataAdapter adapter = new SqlDataAdapter(Sqlstring1, DataSource.ConnectStr);
     //    adapter.Fill(set, "Admin");
     //    return set;
     //}


     /// <summary>
     /// 高级管理员查看管理员信息列表
     /// </summary>
     /// <param name="surrentPage"></param>
     /// <returns></returns>
     public List<Admins> AdminShow(int surrentPage)
     {
         
        // int pageSum = 0;
        // int pageSize = 10;
         List<Admins> listAdmin = new List<Admins>();
       //  string Sqlstring = "select count(*) from Admin";
        // object obj = SqlHelper.ReadSclar(Sqlstring);
        // int countInfoSum = Convert.ToInt32(obj);
        // pageSum = (countInfoSum % pageSize) == 0 ? (countInfoSum / pageSize) : (countInfoSum / pageSize + 1);
         string Sqlstring1 = "select top 8 StaffID,UserName,StaffType,TrueName,AddTime from Admin where StaffID not in (select top " + surrentPage*8 + " StaffID from Admin order by StaffID asc) and StaffType!=1 order by StaffID";
         SqlHelper.ReadDateReadBegin(Sqlstring1);
         while (SqlHelper.SqlReader.Read())
         {
             Admins mAdmin = new Admins();
             mAdmin.StaffID = Convert.ToInt32(SqlHelper.SqlReader["StaffID"]);
             mAdmin.UserName = SqlHelper.SqlReader["UserName"].ToString();
             switch (Convert.ToInt32(SqlHelper.SqlReader["StaffType"]))
             { 
                 case 1:
                     mAdmin.aStafftype ="高级管理员";
                     break;
                 case 2:
                     mAdmin.aStafftype = "订单管理员";
                     break;
                 case 3:
                     mAdmin.aStafftype = "评价管理员";
                     break;
                 case 4:
                     mAdmin.aStafftype = "用户管理员";
                     break;
                 case 5:
                     mAdmin.aStafftype = "商品管理员";
                     break;
                 case 9:
                     mAdmin.aStafftype = "未激活账户";
                     break;
             }
             mAdmin.StaffType = Convert.ToChar(SqlHelper.SqlReader["StaffType"]);
             mAdmin.TrueName = SqlHelper.SqlReader["TrueName"].ToString();
             mAdmin.AddTime = SqlHelper.SqlReader["AddTime"].ToString();
             listAdmin.Add(mAdmin);
         }
         SqlHelper.ReadDateReadEnd();
         return listAdmin;
     }

     /// <summary>
     /// 高级管理员查看用户信息列表
     /// </summary>
     /// <param name="surrentPage"></param>
     /// <returns></returns>
     public List<StoreUser> UserShow(int surrentPage)
     {
         List<StoreUser> listUser = new List<StoreUser>();
         string Sqlstring1 = "select top 8 UserID,UserName,UserType,TrueName,RegistTime from StoreUser where UserID not in (select top " + surrentPage * 8 + " UserID from StoreUser order by UserID asc) order by UserID";
         SqlHelper.ReadDateReadBegin(Sqlstring1);
         while (SqlHelper.SqlReader.Read())
         {
             StoreUser mUser = new StoreUser();
             mUser.UserID = Convert.ToInt32(SqlHelper.SqlReader["UserID"]);
             mUser.UserName = SqlHelper.SqlReader["UserName"].ToString();
             switch (Convert.ToInt32(SqlHelper.SqlReader["UserType"]))
             {
                 case 0:
                     mUser.aUsertype = "普通";
                     break;
                 case 1:
                     mUser.aUsertype="会员";
                 break;
             }
             
             mUser.UserTrueName = SqlHelper.SqlReader["TrueName"].ToString();
             mUser.RegistTime= SqlHelper.SqlReader["RegistTime"].ToString();
             listUser.Add(mUser);
         }
         SqlHelper.ReadDateReadEnd();
         return listUser;
     }


     /// <summary>
     /// 高级管理员查看订单信息列表
     /// </summary>
     /// <param name="surrentPage"></param>
     /// <returns></returns>
     public List<SaveOrders> OrderShow(int surrentPage)
     {
         List<SaveOrders> listOrder = new List<SaveOrders>();
         string Sqlstring1 = "select top 8  OrderID,UserID,TotalPrices,SubmitTime,TradeStatus from SaveOrders where OrderID not in (select top " + surrentPage * 8 + " OrderID from SaveOrders order by OrderID asc) order by OrderID";
         SqlHelper.ReadDateReadBegin(Sqlstring1);
         while (SqlHelper.SqlReader.Read())
         {
             SaveOrders morder = new SaveOrders();
             morder.OrderID =SqlHelper.SqlReader["OrderID"].ToString();
             morder.UserID = Convert.ToInt32(SqlHelper.SqlReader["UserID"]);
             morder.TotalPrices = Convert.ToDouble(SqlHelper.SqlReader["TotalPrices"]);
             morder.SubmitTime = SqlHelper.SqlReader["SubmitTime"].ToString();
             switch (Convert.ToChar(SqlHelper.SqlReader["TradeStatus"]))
             { 
                 case '0':
                     morder.aTradeStatus = "买家未付款";
                     break;
                 case '1':
                     morder.aTradeStatus = "买家付款";
                     break;
                 case '2':
                     morder.aTradeStatus = "商城发货";
                     break;
                 case '3':
                     morder.aTradeStatus = "交易完成";
                     break;    
             
             }
             listOrder.Add(morder);
         }
         SqlHelper.ReadDateReadEnd();
         return listOrder;
     }

     /// <summary>
     /// 高级管理员查看评价信息列表
     /// </summary>
     /// <param name="surrentPage"></param>
     /// <returns></returns>
     public List<GoodEvaluate> EvaluateShow(int surrentPage)
     {
         List<GoodEvaluate> listEvaluate = new List<GoodEvaluate>();
         string Sqlstring1 = "select top 8  EvaluateID,StoreUser.UserName,OrderID,EvaluateGrade,EvaluateTime from GoodEvaluate left join StoreUser on StoreUser.UserID=GoodEvaluate.UserID where EvaluateID not in (select top " + surrentPage * 8 + " EvaluateID from GoodEvaluate order by EvaluateID asc) order by EvaluateID";
         SqlHelper.ReadDateReadBegin(Sqlstring1);
         while (SqlHelper.SqlReader.Read())
         {
             GoodEvaluate mEvaluate = new GoodEvaluate();
             mEvaluate.EvaluateID = Convert.ToInt32(SqlHelper.SqlReader["EvaluateID"]);
             mEvaluate.EvaluateContent = SqlHelper.SqlReader["UserName"].ToString() ;
             mEvaluate.OrderID = SqlHelper.SqlReader["OrderID"].ToString();
             switch (Convert.ToChar(SqlHelper.SqlReader["EvaluateGrade"]))
             { 
                 case '1':
                     mEvaluate.aEvaluateGrade = "好评";
                     break;
                 case '2':
                     mEvaluate.aEvaluateGrade = "中评";
                     break;
                 case '3':
                     mEvaluate.aEvaluateGrade= "差评";
                     break;    
             }
             mEvaluate.EvaluateTime = SqlHelper.SqlReader["EvaluateTime"].ToString();
             listEvaluate.Add(mEvaluate);
         }
         SqlHelper.ReadDateReadEnd();
         return listEvaluate;
     }
     /// <summary>
     /// 日志信息列表
     /// </summary>
     /// <param name="surrentPage"></param>
     /// <returns></returns>
     public List<DayBook> DayBookShow(int surrentPage)
     {
         List<DayBook> listDayBook=new List<DayBook>();
         string SqlString = "select top 8 * from DayBook left join Admin on Admin.StaffID=DayBook.StaffID where HandleTime not in (select top " + surrentPage * 8 + " HandleTime from DayBook order by HandleTime asc) order by HandleTime asc";
         SqlHelper.ReadDateReadBegin(SqlString);
         while (SqlHelper.SqlReader.Read())
         {
             DayBook mDayBook=new DayBook();
             mDayBook.StaffID=Convert.ToInt32( SqlHelper.SqlReader["StaffID"]);
             mDayBook.UserName = SqlHelper.SqlReader["UserName"].ToString();
             mDayBook.HandleTime = SqlHelper.SqlReader["HandleTime"].ToString();
             mDayBook.HandleObjects=SqlHelper.SqlReader["HandleObjects"].ToString();
             mDayBook.HandleContent=SqlHelper.SqlReader["HandleContent"].ToString();
             switch (SqlHelper.SqlReader["DayBookVersion"].ToString())
             {
                 case "0":
                     mDayBook.DayBookVersion = "删除";
                     break;
                 case "1":
                     mDayBook.DayBookVersion = "激活";
                     break;
                 case "2":
                     mDayBook.DayBookVersion = "修改";
                     break;
                 default:
                     break;
             }
             listDayBook.Add(mDayBook);
         }
         SqlHelper.ReadDateReadEnd();
         return listDayBook;
     }
     /// <summary>
     /// 每日日志信息列表
     /// </summary>
     /// <param name="surrentPage"></param>
     /// <returns></returns>
     public List<DayBook> DayBookDateShow(int surrentPage,string mDate)
     {
         List<DayBook> listDayBookDate = new List<DayBook>();
         string SqlString = "select top 8 * from (select DayBook.HandleTime ,DayBook.HandleObjects,DayBook.DayBookVersion,DayBook.StaffID,DayBook.UserName,DayBook.HandleContent From DayBook left join Admin on Admin.StaffID=DayBook.StaffID  where Convert(Varchar,HandleTime,103)='" + mDate + "')TEMP1 where HandleTime not in (select top " + surrentPage * 8 + " HandleTime from (select DayBook.HandleTime ,DayBook.HandleObjects,DayBook.DayBookVersion,DayBook.StaffID,DayBook.UserName,DayBook.HandleContent From DayBook left join Admin on Admin.StaffID=DayBook.StaffID  where Convert(Varchar,HandleTime,103)='" + mDate + "')TEMP2 order by HandleTime asc) order by HandleTime asc";
         SqlHelper.ReadDateReadBegin(SqlString);
         while (SqlHelper.SqlReader.Read())
         {
             DayBook mDayBook = new DayBook();
             mDayBook.StaffID = Convert.ToInt32(SqlHelper.SqlReader["StaffID"]);
             mDayBook.UserName = SqlHelper.SqlReader["UserName"].ToString();
             mDayBook.HandleTime = SqlHelper.SqlReader["HandleTime"].ToString();
             mDayBook.HandleObjects = SqlHelper.SqlReader["HandleObjects"].ToString();
             mDayBook.HandleContent = SqlHelper.SqlReader["HandleContent"].ToString();
             switch (SqlHelper.SqlReader["DayBookVersion"].ToString())
             {
                 case "0":
                     mDayBook.DayBookVersion = "删除";
                     break;
                 case "1":
                     mDayBook.DayBookVersion = "激活";
                     break;
                 case "2":
                     mDayBook.DayBookVersion = "修改";
                     break;
                 default:
                     break;
             }
             listDayBookDate.Add(mDayBook);
         }
         SqlHelper.ReadDateReadEnd();
         return listDayBookDate;
     }
     /// <summary>
     /// 返回数据库中评价信息总条数
     /// </summary>
     /// <returns></returns>
     public int PageSumEvaluate()
     {
         int pageSum = 0;
         int pageSize = 8;
         string Sqlstring = "select count(*) from GoodEvaluate";
         object obj = SqlHelper.ReadSclar(Sqlstring);
         int countInfoSum = Convert.ToInt32(obj);
         pageSum = (countInfoSum % pageSize) == 0 ? (countInfoSum / pageSize) : (countInfoSum / pageSize + 1);
         return pageSum;
     }
     
     /// <summary>
     /// 返回数据库中订单信息总条数
     /// </summary>
     /// <returns></returns>
     public int PageSumOrder()
     {
         int pageSum = 0;
         int pageSize = 8;
         string Sqlstring = "select count(*) from SaveOrders";
         object obj = SqlHelper.ReadSclar(Sqlstring);
         int countInfoSum = Convert.ToInt32(obj);
         pageSum = (countInfoSum % pageSize) == 0 ? (countInfoSum / pageSize) : (countInfoSum / pageSize + 1);
         return pageSum;
     }
 
     /// <summary>
     /// 返回数据库中管理员信息总条数
     /// </summary>
     /// <returns></returns>
     public int PageSumAdmin()
     {
         int pageSum = 0;
         int pageSize = 8;
         string Sqlstring = "select count(*) from Admin";
         object obj = SqlHelper.ReadSclar(Sqlstring);
         int countInfoSum = Convert.ToInt32(obj);
         pageSum = (countInfoSum % pageSize) == 0 ? (countInfoSum / pageSize) : (countInfoSum / pageSize + 1);
         return pageSum;
     }

     /// <summary>
     /// 返回数据库中用户信息总条数
     /// </summary>
     /// <returns></returns>
     public int PageSumUser()
     {
         int pageSum = 0;
         int pageSize = 8;
         string Sqlstring = "select count(*) from StoreUser";
         object obj = SqlHelper.ReadSclar(Sqlstring);
         int countInfoSum = Convert.ToInt32(obj);
         pageSum = (countInfoSum % pageSize) == 0 ? (countInfoSum / pageSize) : (countInfoSum / pageSize + 1);
         return pageSum;
     }
     /// <summary>
     /// 返回日志记录总页数
     /// </summary>
     /// <returns></returns>
     public int PageSumDayBook()
     {
         int pageSum = 0;
         int pageSize = 8;
         string SqlString = "select count(*) from DayBook";
         int sumItem = Convert.ToInt32(SqlHelper.ReadSclar(SqlString));
         pageSum=(sumItem%pageSize==0)?(sumItem/pageSize):(sumItem/pageSize+1);
         return pageSum;
     }
     /// <summary>
     /// 每日日志总页数
     /// </summary>
     /// <param name="mDate"></param>
     /// <returns></returns>
     public int PageSumDayBookDate(string mDate)
     {
         int pageSum = 0;
         int pageSize = 8;
         String SqlString = "select count(*) from (select DayBook.HandleTime ,DayBook.HandleObjects,DayBook.DayBookVersion,DayBook.StaffID,DayBook.UserName,DayBook.HandleContent From DayBook where Convert(Varchar,HandleTime,103)='" + mDate + "')temp1 ";
         int sumItem = Convert.ToInt32(SqlHelper.ReadSclar(SqlString));
         pageSum=(sumItem%pageSize==0)?(sumItem/pageSize):(sumItem/pageSize+1);
         return pageSum;
     }
    }
}
