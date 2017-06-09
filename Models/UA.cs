/*
 * 1 功能描述：
 *     用户管理员个人信息显示
 * 2 作者：
 *   徐嘉琪；
   3 创建时间：
 *   2012-08-06-14-30；
 * 4 完成时间：
 *   2012-08-06-17-00；
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 *   郭正肖2012-08-21；添加注册发邮件函数
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace Models
{
    public class UA : Admins
    {

        /// <summary>
        /// 获取数据库中的用户管理员个人信息
        /// </summary>
        /// <returns>个人信息数组</returns>
        public string[] UAInfoRead()
        {
            string[] UAInfo = new string[13];
            string Sqlstring = "select StaffID,TrueName,PassWord,Age,Sex,Email,StaffType,AddTime,UserName,Phone,QQ,Address,IdCardNum from Admin where UserName='" + this.UserName + "'";
            SqlHelper.ReadDateReadBegin(Sqlstring);
            while (SqlHelper.SqlReader.Read())
            {
                UAInfo[0] = SqlHelper.SqlReader["StaffID"].ToString();
                UAInfo[1] = SqlHelper.SqlReader["TrueName"].ToString();
                UAInfo[2] = SqlHelper.SqlReader["PassWord"].ToString();
                UAInfo[3] = SqlHelper.SqlReader["Age"].ToString();
                UAInfo[4] = SqlHelper.SqlReader["Sex"].ToString();
                UAInfo[5] = SqlHelper.SqlReader["Email"].ToString();
                UAInfo[6] = SqlHelper.SqlReader["StaffType"].ToString();
                UAInfo[7] = SqlHelper.SqlReader["AddTime"].ToString();
                UAInfo[8] = SqlHelper.SqlReader["UserName"].ToString();
                UAInfo[9] = SqlHelper.SqlReader["Phone"].ToString();
                UAInfo[10] = SqlHelper.SqlReader["Address"].ToString();
                UAInfo[11] = SqlHelper.SqlReader["IdCardNum"].ToString();
                UAInfo[12] = SqlHelper.SqlReader["QQ"].ToString();
            }
            SqlHelper.ReadDateReadEnd();
            return UAInfo;
        }
        /// <summary>
        /// 判断对用户管理员的信息修改是否成功
        /// </summary>
        /// <returns>成功或失败</returns>
        public bool UAInfoUpdate()
        {
            string Sqlstring = "update Admin set TrueName=N'" + this.TrueName + "',IdCardNum='" + this.IdCardNum + "',PassWord='" + this.PassWord + "'where UserName=N'" + this.UserName + "'";
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
        /// 搜索用户信息
        /// </summary>
        /// <returns>用户信息数组</returns>
        public string[] SelectStoreUserInfo()
        {
            string yUserName = this.UserName;
            string Sqlstring = "select UserID from StoreUser where UserName='" + yUserName + "'";
            object obj1 = SqlHelper.ReadSclar(Sqlstring);
            StoreUser mUser = new StoreUser();
            string[] xUserInfo = new string[13];
            string ID = obj1.ToString();
            string Sqlstring1 = "select UserName,PassWord,UserInfo.UserID,UserType,TrueName,IdCardNum,Age,Sex,Email,Phone,RegistTime,QQ,MoneySum from StoreUser left join UserInfo on UserInfo.UserID=StoreUser.UserID where StoreUser.UserID='" + ID + "'";
            SqlHelper.ReadDateReadBegin(Sqlstring1);
            while (SqlHelper.SqlReader.Read())
            {
                xUserInfo[0] = SqlHelper.SqlReader[0].ToString();
                xUserInfo[1] = SqlHelper.SqlReader[1].ToString();
                xUserInfo[2] = SqlHelper.SqlReader[2].ToString();
                xUserInfo[3] = SqlHelper.SqlReader[3].ToString();
                xUserInfo[4] = SqlHelper.SqlReader[4].ToString();
                xUserInfo[5] = SqlHelper.SqlReader[5].ToString();
                xUserInfo[6] = SqlHelper.SqlReader[6].ToString();
                xUserInfo[7] = SqlHelper.SqlReader[7].ToString();
                xUserInfo[8] = SqlHelper.SqlReader[8].ToString();
                xUserInfo[9] = SqlHelper.SqlReader[9].ToString();
                xUserInfo[10] = SqlHelper.SqlReader[10].ToString();
                xUserInfo[11] = SqlHelper.SqlReader[11].ToString();
                xUserInfo[12] = SqlHelper.SqlReader[12].ToString();
            }
            SqlHelper.ReadDateReadEnd();
            return xUserInfo;
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <returns>存在或不存在</returns>
        public bool IsUserExist()
        {
            string yUserName = this.UserName;
            string Sqlstring = "select UserID from StoreUser where UserName='" + yUserName + "'";
            object obj1 = SqlHelper.ReadSclar(Sqlstring);
            if (obj1 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取地址
        /// </summary>
        /// <returns>发货地址表单</returns>
        public List<ShipAddress> GetAddress()
        {
            List<ShipAddress> luserAdreslist = new List<ShipAddress>();
            string yUserName = this.UserName;
            string Sqlstring1 = "select UserID from StoreUser where UserName='" + yUserName + "'";
            object obj1 = SqlHelper.ReadSclar(Sqlstring1);
            string ID = obj1.ToString();
            string Sqlstring2 = "select Address from ShipAddress where UserID='" + ID + "'";
            SqlHelper.ReadDateReadBegin(Sqlstring2);
            while (SqlHelper.SqlReader.Read())
            {
                ShipAddress Uadres = new ShipAddress();
                Uadres.Address = SqlHelper.SqlReader["Address"].ToString();
                luserAdreslist.Add(Uadres);
            }
            SqlHelper.ReadDateReadEnd();
            return luserAdreslist;
        }

        /// <summary>
        /// 判断删除用户信息时是否将其完全删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteUserInfo()
        {
            string yUserName = this.UserName;
            StoreUser mSU = new StoreUser();
            mSU.UserName = yUserName;
            int TempUserID = StoreUser.UserNameGetID(mSU);
            string Sqlstring = "delete from ShipAddress  where UserID='" + TempUserID + "'" + ";delete from UserInfo where UserID='" + TempUserID + "'" + ";delete  from StoreUser where UserName='" + yUserName + "'";
            int temp1 = SqlHelper.ExecuteNonQuery(Sqlstring);
            if (temp1 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// 判断用户类型
        /// </summary>
        /// <returns></returns>
        public bool ChangeUserType()
        {
            string hUserName = this.UserName;
            string UserType = this.StaffType.ToString();
            string Sqlstring = "update StoreUser set UserType='" + UserType + "'  where UserName='" + hUserName + "'";
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
        /// 用户激活时发送邮件
        /// </summary>
        /// <param name="newUser">商城用户</param>
        public void SendEmail(StoreUser newUser)
        {
            
            MailMessage mail = new MailMessage("373922247@qq.com", newUser.Email.ToString());
            mail.Subject = "你好，"+newUser.UserName+" 天外天商城欢迎您！ ";
            mail.IsBodyHtml = true;
            mail.Body = "尊敬的用户，您好~欢迎来到天外天商城。为了确保您的账户安全，我们特设邮箱服务。您可以通过此连接激活账号<a href ='http://localhost:2748/formerstage/UserRegister/Activation.aspx?UserName="+newUser.UserName+"'>点击激活</a>无需回复。";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.qq.com"; 
             smtp.UseDefaultCredentials = false;
             smtp.Credentials = new System.Net.NetworkCredential("373922247@qq.com", "LIFEISHI8229124@");
             smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Send(mail);
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="newUser">商城用户</param>
        public void SendEmail2(StoreUser newUser)
        {
            MailMessage mail = new MailMessage("373922247@qq.com", newUser.Email.ToString());
            mail.Subject = "天外天商城客服（找回密码）";
            mail.IsBodyHtml = true;
            mail.Body = "尊敬的用户，您好。您的申请我们已经收到，点此连接可以重置密码<a href ='http://localhost:2748/formerstage/UserRegister/PassWordReset.aspx?UserName=" + newUser.UserName + "'>点击重置密码</a>无需回复。";
            SmtpClient smpt = new SmtpClient();
            smpt.Host = "smtp.qq.com";
            smpt.UseDefaultCredentials = false;
            smpt.Credentials = new System.Net.NetworkCredential("373922247@qq.com", "LIFEISHI8229124@");
            smpt.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smpt.Send(mail);

        }
        public int GetPage()
        {
            int pagesize = 8;
            string sqlstring = "select count(*) from StoreUser";
            int temp = Convert.ToInt32(SqlHelper.ReadSclar(sqlstring));
            int SumPage = (temp % pagesize) == 0 ? (temp / pagesize) : ((temp / pagesize) + 1);

            return SumPage;
        }
    }
}
