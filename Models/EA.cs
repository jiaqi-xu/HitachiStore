/*
 * 1 功能描述：
 *      评价管理员个人信息显示
 * 2 作者：
 *   徐嘉琪；
   3 创建时间：
 *   2012-08-07-14-30；
 * 4 完成时间：
 *  
 * 5 修改记录：
 *   修改时间：2012-8-13-16-00；2.修改内容：用datalist实现分页查询和按ID查询在datalist上的显示；3.修改人：郝云浩
 *             2012-8-17-20-00；2.修改内容：修改BUg实现评价分页界面的删除
 *             修改时间：2012-8-24-9-10；2.修改内容：添加注释3.修改人：郭正肖。
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;

namespace Models
{
   public class EA:Admins  
   {
        /// <summary>
     /// 获取数据库中的评价管理员个人信息
     /// </summary>
     /// <returns>个人信息</returns>
        public string[] EAInfoRead()
        {
            string[] EAInfo = new string[7];
            string Sqlstring = "select StaffID,TrueName,PassWord,StaffType,AddTime,UserName,IdCardNum from Admin where UserName='" + this.UserName + "'";
            SqlHelper.ReadDateReadBegin(Sqlstring);
             while (SqlHelper.SqlReader.Read())
            {
                EAInfo[0] = SqlHelper.SqlReader["StaffID"].ToString();
                EAInfo[1] = SqlHelper.SqlReader["TrueName"].ToString();
                EAInfo[2] = SqlHelper.SqlReader["PassWord"].ToString();
                EAInfo[3] = SqlHelper.SqlReader["StaffType"].ToString();
                EAInfo[4] = SqlHelper.SqlReader["AddTime"].ToString();
                EAInfo[5] = SqlHelper.SqlReader["UserName"].ToString();
                EAInfo[6] = SqlHelper.SqlReader["IdCardNum"].ToString();
                               
            }
             SqlHelper.ReadDateReadEnd();
             return EAInfo;
        }
        /// <summary>
        /// 判断对用评价管理员的信息修改是否成功
        /// </summary>
        /// <returns>成功或失败</returns>
        public bool EAInfoUpdate()
        {
            string Sqlstring = "update Admin set TrueName=N'" + this.TrueName + "',IdCardNum='" + this.IdCardNum + "',PassWord='" + this.PassWord + "' where UserName=N'" + this.UserName + "'";
            if (SqlHelper.ExecuteNonQuery(Sqlstring) > 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }


       /// <summary>
       /// 判断该订单评价是否存在
       /// </summary>
       /// <returns>存在或者不存在</returns>
        public bool IsEvaluateExist()
        { 
            string  yEvaluate=this.StaffID.ToString();
            string Sqlstring ="select UserID from GoodEvaluate where EvaluateID='"+yEvaluate+"'";
                object obj=SqlHelper.ReadSclar(Sqlstring);
            if(obj!=null)
            {
              return true;
            }
            else 
            {
              return false;
            }     
        }

       /// <summary>
       /// 查询评价的信息
       /// </summary>
       /// <returns>评价信息</returns>
        public string[] ShowEvaluateInfo()
        {  
            string[]  EInfo=new  string[6]; 
            string  ID=this.StaffID.ToString();
            string Sqlstring = "select EvaluateID,GoodID,EvaluateContent,EvaluateTime,UserID,EvaluateGrade from GoodEvaluate where EvaluateID='" + ID + "'";
          
             SqlHelper.ReadDateReadBegin(Sqlstring);
            while(SqlHelper.SqlReader.Read())
            {
                EInfo[0] = SqlHelper.SqlReader["EvaluateID"].ToString();
                EInfo[1] = SqlHelper.SqlReader["GoodID"].ToString();
                EInfo[2] = SqlHelper.SqlReader["EvaluateContent"].ToString();
                EInfo[3] = SqlHelper.SqlReader["EvaluateTime"].ToString();
                EInfo[4] = SqlHelper.SqlReader["UserID"].ToString();
                EInfo[5] = SqlHelper.SqlReader["EvaluateGrade"].ToString();
            }
            SqlHelper.ReadDateReadEnd();
            return EInfo;
        }
       /// <summary>
       /// 判断是否将评价删除
       /// </summary>
       /// <returns>成功或失败</returns>
        public bool DeleteEvaluate()
        {
            string ID = this.StaffID.ToString();
            string Sqlstring = "delete from GoodEvaluate where EvaluateID='" + ID + "'";
            if (SqlHelper.ExecuteNonQuery(Sqlstring) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        
        }
       /// <summary>
       /// 获取总页数
       /// </summary>
       /// <returns>页数</returns>
        public int GetPages()
        {
            int pagesize = 8;
            string sqlstring = "select count(*) from GoodEvaluate ";
            int temp =Convert .ToInt32 (SqlHelper .ReadSclar (sqlstring ));
            int Pages = (temp % pagesize) == 0 ? (temp / pagesize) : ((temp / pagesize) + 1);
            

            return Pages;
        }
       /// <summary>
       /// 评价的直接和分页查询
       /// </summary>
       /// <param name="CurrentPage"></param>
       /// <param name="Flag"></param>
       /// <param name="mEvaluate"></param>
       /// <returns></returns>
        public List<GoodEvaluate> DivideShow(int CurrentPage, int Flag, GoodEvaluate mEvaluate)
        {
            List<GoodEvaluate> listEvaluate = new List<GoodEvaluate>();
            string sqlstring1 = "select top (8) EvaluateID,GoodID,EvaluateContent,EvaluateTime,UserID,EvaluateGrade from GoodEvaluate where EvaluateID not in(select top(" + CurrentPage * 8 + ")EvaluateID from GoodEvaluate order by EvaluateID asc)order by EvaluateID";
            string sqlstring2 = "select EvaluateID,GoodID,EvaluateContent,EvaluateTime,UserID,EvaluateGrade from GoodEvaluate where EvaluateID='" + mEvaluate.EvaluateID + "'";
            switch (Flag)
            {
                case 1:
                    SqlHelper.ReadDateReadBegin(sqlstring1);
                    break;
                case 2:
                    SqlHelper .ReadDateReadBegin (sqlstring2 );
                    break ;

            }
            while (SqlHelper.SqlReader.Read())
            {
                mEvaluate.EvaluateID = Convert .ToInt32 ( SqlHelper.SqlReader["EvaluateID"]);
                mEvaluate.EvaluateTime = SqlHelper.SqlReader["EvaluateTime"].ToString();
                mEvaluate.EvaluateContent = SqlHelper.SqlReader["EvaluateContent"].ToString();
                mEvaluate.EvaluateGrade = Convert.ToChar(SqlHelper.SqlReader["EvaluateGrade"]);
                mEvaluate.GoodID = Convert.ToInt32(SqlHelper.SqlReader["GoodID"]);
                mEvaluate.UserID = Convert.ToInt32(SqlHelper.SqlReader["UserID"]);
                listEvaluate.Add(mEvaluate);
            }
            SqlHelper.ReadDateReadEnd();
            return listEvaluate;
        }
    }
}
