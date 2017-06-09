/*
 * 1 功能描述: 日志类
 * 
 * 2 作者：王晶晶
 * 
 * 3 创建时间：2012/8/20
 * 
 * 4 完成时间
 * 
 * 5 修改记录
 * 修改时间：2012-8-24-9-10；2.修改内容：添加注释3.修改人：郭正肖。
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;

namespace Models
{
     public class DayBook
    {
         /// <summary>
         /// 操作管理员
         /// </summary>
         private int staffID;
         public int StaffID
         {
             set { staffID = value; }
             get { return staffID; }
         }
         /// <summary>
         /// 操作管理员姓名
         /// </summary>
         private string userName;
         public string UserName
         {
             set { userName = value; }
             get { return userName; }
         }
         /// <summary>
         /// 操作时间
         /// </summary>
         private string handleTime;
         public string HandleTime
         {
             set { handleTime = value; }
             get { return handleTime; }
         }
         /// <summary>
         /// 操作对象
         /// </summary>
         private string handleObjects;
         public string HandleObjects
         {
             set { handleObjects = value; }
             get { return handleObjects; }
         }
         /// <summary>
         /// 操作类型
         /// </summary>
         private String dayBookVersion;
         public String DayBookVersion
         {
             set { dayBookVersion = value; }
             get { return dayBookVersion; }
         }
         /// <summary>
         /// 操作内容
         /// </summary>
         private string handleContent;
         public string HandleContent
         {
             set { handleContent = value; }
             get { return handleContent; }
         }
         /// <summary>
         /// 更新日志表
         /// </summary>
         /// <returns>成功或失败</returns>
         public bool UpdateDayBook()
         {
             string gSqlString = "insert into DayBook (StaffID,UserName,HandleTime,HandleObjects,DayBookVersion) values (" + this.StaffID + ",N'" + this.UserName + "',N'" + this.HandleTime + "',N'" + this.HandleObjects + "','" + this.DayBookVersion + "')";
             if (SqlHelper.ExecuteNonQuery(gSqlString) > 0)
             {
                 return true;
             }
             else
             {
                 return false;

             }
         }
         /// <summary>
         /// 得到每条日志的详细信息
         /// </summary>
         /// <returns>成功或失败</returns>
         public string[] DayBookInfo()
         {
             string[] mDayBookInfo=new string[6];
             string SqlString = "select StaffID,UserName,HandleTime,HandleObjects,DayBookVersion,HandleContent from DayBook where HandleTime='"+this.HandleTime+"'";
             SqlHelper.ReadDateReadBegin(SqlString);
             while (SqlHelper.SqlReader.Read())
             {
                 mDayBookInfo[0]=SqlHelper.SqlReader[0].ToString();
                 mDayBookInfo[1] = SqlHelper.SqlReader[1].ToString();
                 mDayBookInfo[2] = SqlHelper.SqlReader[2].ToString();
                 mDayBookInfo[3] = SqlHelper.SqlReader[3].ToString();
                 mDayBookInfo[5] = SqlHelper.SqlReader[5].ToString();
                 switch (SqlHelper.SqlReader[4].ToString())
                 {
                     case "0":
                         mDayBookInfo[4]= "删除";
                         break;
                     case "1":
                         mDayBookInfo[4]= "激活";
                         break;
                     case "2":
                         mDayBookInfo[4] = "修改";
                         break;
                     default:
                         break;
                 }
             }
             SqlHelper.ReadDateReadEnd();
             return mDayBookInfo;
         }
         /// <summary>
         /// 验证是否存在输入的操作时间
         /// </summary>
         /// <returns>成功或失败</returns>
         public bool SelectHandleTime(String mHandleTime)
         {
             string SqlString = "select HandleTime from DayBook where HandleTime='"+mHandleTime+"'";
             if (SqlHelper.ReadSclar(SqlString) != null)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }
         /// <summary>
         /// 判断是否存在输入的用户名
         /// </summary>
         /// <returns>成功或失败</returns>
         public bool SelectAdmin()
         {
             String SqlString = "select UserName from DayBook where UserName=N'"+this.UserName+"'";
             if (SqlHelper.ReadSclar(SqlString) != null)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }
         /// <summary>
         /// 改变时间格式
         /// </summary>
         /// <returns></returns>
         public string ChangeHandleTime()
         {
             string SqlString = "select Convert(varchar,HandleTime,103) from DayBook where HandleTime='" + this.handleTime + "'";
             return SqlHelper.ReadSclar(SqlString).ToString();
         }
         public int GetPages()
         {
             int pagesize = 8;
             string sqlstring = "select count(*) from DayBook ";
             int temp = Convert.ToInt32(SqlHelper.ReadSclar(sqlstring));
             int Pages = (temp % pagesize) == 0 ? (temp / pagesize) : ((temp / pagesize) + 1);

             return Pages;
         }
    }
}
