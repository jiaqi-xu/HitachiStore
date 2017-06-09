/*
 * 1 功能描述: 高级管理员类
 * 
 * 2 作者：王晶晶
 * 
 * 3 创建时间：2012/8/7
 * 
 * 4 完成时间
 * 
 * 5 修改记录:
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;

namespace Models
{
    public class SA:Admins
    {
        /// <summary>
        /// 激活
        /// </summary>
        /// <returns>数据库操作是否成功</returns>
        public bool UpdateAdmin()
        {
            string Sqlstring = "update Admin set staffType='" + this.StaffType + "' where UserName=N'" + this.UserName + "'";
            if (SqlHelper.ExecuteNonQuery(Sqlstring) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public string[] QueryStaffInfo()
        {
            //管理员信息数组
            string[] StaffInfo = new string[13];
            string SqlString = "select * from Admin where UserName=N'" + this.UserName + "'";
            SqlHelper.ReadDateReadBegin(SqlString);
            while (SqlHelper.SqlReader.Read())
            {
                //通过循环获取Staff的信息
                StaffInfo[0] = SqlHelper.SqlReader[0].ToString();
                StaffInfo[1] = SqlHelper.SqlReader[1].ToString();
                StaffInfo[2] = SqlHelper.SqlReader[2].ToString();
                StaffInfo[3] = SqlHelper.SqlReader[3].ToString();               
                StaffInfo[5] = SqlHelper.SqlReader[5].ToString();              
                StaffInfo[7] = SqlHelper.SqlReader[7].ToString();
                StaffInfo[8] = SqlHelper.SqlReader[8].ToString();
                StaffInfo[9] = SqlHelper.SqlReader[9].ToString();
                StaffInfo[10] = SqlHelper.SqlReader[10].ToString();
                StaffInfo[11] = SqlHelper.SqlReader[11].ToString();
                StaffInfo[12] = SqlHelper.SqlReader[12].ToString();
                //判断管理员类型
                switch ( SqlHelper.SqlReader[6].ToString())
                {
                    case "1":
                        StaffInfo[6] = "高级管理员";
                        break;
                    case "2":
                        StaffInfo[6]="订单管理员";
                        break;                  
                    case "3":
                        StaffInfo[6]="评价管理员";
                        break;
                    case "4":
                        StaffInfo[6] = "用户管理员";
                        break;
                    case "5":
                        StaffInfo[6] = "商品管理员";
                        break;
                    case "9":
                        StaffInfo[6] = "未激活";
                        break;
                    default:
                        break;
                }
                //判断性别
                switch (SqlHelper.SqlReader[4].ToString())
                {
                    case "0":
                        StaffInfo[4] = "男";
                        break;
                    case "1":
                        StaffInfo[4] = "女";
                        break;
                    default:
                        break;                           
                }
            }
            //关闭SqlDataRead
            SqlHelper.ReadDateReadEnd();
            return StaffInfo;
        }
        /// <summary>
        /// 高级管理员修改管理员信息
        /// </summary>
        /// <returns>是否修改成功</returns>
        public bool UpdateAdminInfo()
        {
            string Sqlstring = "update Admin set StaffType='" + this.StaffType+"',PassWord=N'"+this.PassWord+"'  where UserName=N'" + this.UserName + "'";
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
        /// 高级管理员修改个人信息
        /// </summary>
        /// <returns>是否修改成功</returns>
        public bool UpdateSaInfo()
        {
            string Sqlstring = "update Admin set PassWord=N'" + this.PassWord + "',TrueName=N'"+this.TrueName+"',IdCardNum='"+this.IdCardNum+"',Age='"+this.Age+"',Email='"+this.Email+"',Phone='"+this.Phone+"',Address='"+this.Address+"',QQ='"+this.QQ+"'  where UserName=N'" + this.UserName + "'";
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
        ///  从数据库中得到此用户名
        /// </summary>
        /// <returns>用户名</returns>
        public string SelectUserName()
        {

            string SqlString = "select UserName from Admin where UserName=N'" + this.UserName + "'";
            object obj2 = SqlHelper.ReadSclar(SqlString);
            return obj2.ToString();
        }
        /// <summary>
        /// 判断数据库中是否存在此用户名
        /// </summary>
        /// <returns>存在返回false</returns>
        public bool SelectStoreUser(string mStoreUserName)
        {
            string SqlString = "select UserName from StoreUser where UserName=N'" + mStoreUserName + "'";
            if (SqlHelper.ReadSclar(SqlString) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 搜索用户信息
        /// </summary>
        /// <returns></returns>
        public string[] SelectStoreUserInfo(string mStoreName)
        {
            string[] mUserInfo = new string[14];
            string Sqlstring = "select UserName,PassWord,StoreUser.UserID,UserType,TrueName,IdCardNum,Age,Sex,Email,Phone,RegistTime,QQ,MoneySum,UserPicture from StoreUser left join UserInfo on UserInfo.UserID=StoreUser.UserID where UserName=N'" + mStoreName + "'";
            SqlHelper.ReadDateReadBegin(Sqlstring);
            while (SqlHelper.SqlReader.Read())
            {
                mUserInfo[0] = SqlHelper.SqlReader[0].ToString();
                mUserInfo[1] = SqlHelper.SqlReader[1].ToString();
                mUserInfo[2] = SqlHelper.SqlReader[2].ToString();
                mUserInfo[4] = SqlHelper.SqlReader[4].ToString();
                mUserInfo[5] = SqlHelper.SqlReader[5].ToString();
                mUserInfo[6] = SqlHelper.SqlReader[6].ToString();
                mUserInfo[8] = SqlHelper.SqlReader[8].ToString();
                mUserInfo[9] = SqlHelper.SqlReader[9].ToString();
                mUserInfo[10] = SqlHelper.SqlReader[10].ToString();
                mUserInfo[11] = SqlHelper.SqlReader[11].ToString();
                mUserInfo[12] = SqlHelper.SqlReader[12].ToString();
                mUserInfo[13] = SqlHelper.SqlReader[13].ToString();
                //StoreUser类别的判断
                if (SqlHelper.SqlReader[3].ToString() == "0")
                {
                    mUserInfo[3] = "否";
                }
                else
                {
                    mUserInfo[3] = "是";
                }
                //性别的判断
                switch(SqlHelper.SqlReader[7].ToString())
                {
                    case "0":
                        mUserInfo[7] = "男";
                        break;
                    case "1":
                        mUserInfo[7] = "女";
                        break;
                    default:
                        mUserInfo[7] = "";
                        break;
                }

            }
            SqlHelper.ReadDateReadEnd();
            return mUserInfo;
        }
        /// <summary>
        /// 搜索收货地址
        /// </summary>
        /// <returns></returns>
        public List<ShipAddress> SelectAddress(string mStoreUserID)
        {
            List<ShipAddress> luserAdreslist = new List<ShipAddress>();

            string Sqlstring = "select * from ShipAddress where UserID='" + mStoreUserID + "'";
            SqlHelper.ReadDateReadBegin(Sqlstring);
            int i = 0;
            while (SqlHelper.SqlReader.Read())
            {
                ShipAddress mUserAddress = new ShipAddress();  
                mUserAddress.AddressID = (int)SqlHelper.SqlReader[0];
                mUserAddress.Address = SqlHelper.SqlReader[2].ToString();
                if (SqlHelper.SqlReader[3].ToString() == "0")
                {
                    mUserAddress.IsDefault = '否';
                }
                else
                {
                    mUserAddress.IsDefault = '是';
                }
                luserAdreslist.Add(mUserAddress);
            }           
            SqlHelper.ReadDateReadEnd();
            return luserAdreslist;
        }
        /// <summary>
        /// 判断该商品评价是否存在
        /// </summary>
        /// <returns>存在返回true</returns>
        public bool SelectEvaluateID(string mOrderID)
        {
            string SqlString = "select EvaluateID from GoodEvaluate where EvaluateID='" + mOrderID + "'";
            if (SqlHelper.ReadSclar(SqlString) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 查询评价的信息
        /// </summary>
        /// <returns>返回评价信息</returns>
        public string[] SelectEvaluateInfo(string mEvaluateID)
        {
            string[] EvaluateInfo = new string[6];
            string ID = this.StaffID.ToString();
            string SqlString = "select EvaluateID,GoodID,EvaluateContent,EvaluateTime,UserID,EvaluateGrade from GoodEvaluate where EvaluateID='" + mEvaluateID + "'";
            SqlHelper.ReadDateReadBegin(SqlString);
            while (SqlHelper.SqlReader.Read())
            {
                EvaluateInfo[0] = SqlHelper.SqlReader[0].ToString();
                EvaluateInfo[1] = SqlHelper.SqlReader[1].ToString();
                EvaluateInfo[2] = SqlHelper.SqlReader[2].ToString();
                EvaluateInfo[3] = SqlHelper.SqlReader[3].ToString();
                EvaluateInfo[4] = SqlHelper.SqlReader[4].ToString();
                switch(SqlHelper.SqlReader[5].ToString())
                {
                    case "1":
                        EvaluateInfo[5]="好评";
                        break;
                    case "2":
                        EvaluateInfo[5]="好评";
                        break;
                    case "3":
                        EvaluateInfo[5]="差评";
                        break;
                    default:
                        break;
                }
            }
            SqlHelper.ReadDateReadEnd();
            return EvaluateInfo;
        }
        /// <summary>
        /// 判断此订单是否存在
        /// </summary>
        /// <returns>存在返回true</returns>
        public bool SelectOrderID(string mOrderID)
        {
            string SqlString = "select OrderID from Orders where OrderID='" + mOrderID + "'";
            if (SqlHelper.ReadSclar(SqlString) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 删除普通管理员
        /// </summary>
        /// <returns>删除成功返回true</returns>
        public bool DeleteGeneralAdmin(String gGeneralAdmminUserName)
        {
            string SqlString = "delete Admin where UserName=N'"+gGeneralAdmminUserName+"'";
            if (SqlHelper.ExecuteNonQuery(SqlString) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 得到管理员的类型
        /// </summary>
        /// <param name="gUserName"></param>
        /// <returns>管理员类型</returns>
        public string SelectAdminType(string gUserName)
        {
            String SqlString = "select StaffType from Admin where UserName=N'"+gUserName+"'";
            return SqlHelper.ReadSclar(SqlString).ToString();
        }
        public int NotActSum()
        {
            string sqlstring = "select count(*) from Admin where StaffType=9";
            int Sum = Convert.ToInt32(SqlHelper.ReadSclar(sqlstring));
            return Sum;

        }
        /// <summary>
        /// 删除与Admin存在外键关系的订单
        /// </summary>
        /// <param name="mAdminID"></param>
        /// <returns></returns>
        public bool DeleteOrder(String mAdminID)
        {
            string SqlString = "delete Oders where StaffID='"+mAdminID+"'";
            if (SqlHelper.ExecuteNonQuery(SqlString) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetPage()
        {
            int pagesize = 8;
            string sqlstring = "select count(*) from Admin";
            int temp = Convert.ToInt32(SqlHelper.ReadSclar(sqlstring));
            int SumPage = (temp % pagesize) == 0 ? (temp / pagesize) : ((temp / pagesize) + 1);
                
            return SumPage;
        }
    }
}
