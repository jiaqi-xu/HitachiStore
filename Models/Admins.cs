/*
 * 1 功能描述: 管理员类
 * 
 * 2 作者：王晶晶
 * 
 * 3 创建时间：2012/8/3
 * 
 * 4 完成时间
 * 
 * 5 修改记录:1.修改时间:2012-8-6-9-30；2.修改内容：添加了LoginText（）与StaffType（）与 RegistText()三个函数；3.修改人：徐嘉琪.
 *             2.修改时间:2012-8-10-16-30；2.修改内容：修改了CreateAdmin()函数；3.修改人： 郝云浩.
 *             3.修改时间：2012-8-24-9-10；2.修改内容：添加注释3.修改人：郭正肖。
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;

namespace Models
{
    public class Admins
    {
        /// <summary>
        /// staffID
        /// </summary>
        private int staffID;
        public int StaffID
        {
            set { staffID = value; }
            get { return staffID; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        private string userName;
        public string UserName
        {
            set { userName = value; }
            get { return userName; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        private string passWord;
        public string PassWord
        {
            set { passWord = value; }
            get { return passWord; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        private char sex;
        public char Sex
        {
            set { sex = value; }
            get { return sex; }
        }
        /// <summary>
        /// 管理员类别
        /// </summary>
        private char staffType;
        public char StaffType
        {
            set { staffType = value; }
            get { return staffType; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        private string trueName;
        public string TrueName
        {
            set { trueName = value; }
            get { return trueName; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        private string idCardNum;
        public string IdCardNum
        {
            set { idCardNum = value; }
            get { return idCardNum; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        private string age;
        public string Age
        {
            set { age = value; }
            get { return age; }
        }
        /// <summary>
        /// E-mail
        /// </summary>
        private string email;
        public string Email
        {
            set { email = value; }
            get { return email; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        private string phone;
        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }
        /// <summary>
        /// 家庭住址
        /// </summary>
        private string address;
        public string Address
        {
            set { address = value; }
            get { return address; }
        }
        /// <summary>
        /// qq
        /// </summary>
        private string qq;
        public string QQ
        {
            set { qq = value; }
            get { return qq; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        private string addTime;
        public string AddTime
        {
            set { addTime = value; }
            get { return addTime; }
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns>数据库操作是否成功</returns>
        public bool CreateAdmin()
        {
            this.StaffType = '9';
            string SqlString1 = "insert into Admin (Sex,UserName,PassWord,StaffType,TrueName,IdCardNum,AddTime) values('" + this.Sex + "','" + this.UserName + "','" + this.PassWord + "','" + this.StaffType + "',N'" + this.TrueName + "','" + this.idCardNum + "',getdate())";

            if (SqlHelper.ExecuteNonQuery(SqlString1) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 验证登陆的用户名和密码是否正确
        /// 使用方法：你只需将输入的用户名与密码的2个控件的Text传进来即可
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="PassWord">密码</param>
        /// <returns>成功或失败</returns>
        public bool LoginText()
        {

            string sqlstring2 = "select PassWord from Admin where UserName='" + this.UserName  + "'";
            Object PassWord = SqlHelper.ReadSclar(sqlstring2);
            if (PassWord != null)
            {
                if ((SqlHelper.ReadSclar(sqlstring2).ToString() == this.PassWord) && (this.PassWord != ""))
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
        ///  判断管理员类型
        ///  使用方法：你只需将输入的用户名与管理员类型的2个控件的Text传进来即可
        /// </summary>
        /// <returns>管理员类型</returns>
        public string CheckStaffType()
        {

            string sqlstring3 = "select StaffType from Admin where UserName=N'" + this.UserName + "'";
            object obj2 = SqlHelper.ReadSclar(sqlstring3);
            if (obj2 != null)
            {
                return obj2.ToString();
            }
            else
            {
                return "9";
            }

        }
        /// <summary>
        /// 验证用户名是否存在
        /// 使用方法：你只需将输入的用户名的控件的Text传进来即可
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns>成功失败</returns>
        public bool RegistText()
        {
            string sqlstring1 = "select UserName from Admin where UserName=N'" + this.UserName + "'";
            object obj = SqlHelper.ReadSclar(sqlstring1);
            if (obj != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string aStafftype { get; set; }// 为string类型
        /// <summary>
        /// 管理员名字获取StaffID
        /// </summary>
        /// <param name="admin">管理员对象</param>
        /// <returns>StaffID</returns>
        public static int TrueNameGetStaffID(Admins admin)
        {
            string sqlstring = "select StaffID from Admin where UserName=N'" + admin.TrueName  + "' ";
            object obj = SqlHelper.ReadSclar(sqlstring);
            int TempStaffID = (int)obj;
            return TempStaffID;
        }
        /// <summary>
        /// StaffID获取真实姓名
        /// </summary>
        /// <param name="admin">管理员对象</param>
        /// <returns>真实姓名</returns>
        public static string StaffIDGetTrueName(Admins admin)
        {
            string sqlstring = "select TrueName from Admin where UserName=N'" + admin.StaffID + "' ";
            object obj = SqlHelper.ReadSclar(sqlstring);
            string TempTrueName = (string )obj;
            return TempTrueName;
        }
        /// <summary>
        /// 用户名获取StaffID
        /// </summary>
        /// <param name="admin">管理员对象</param>
        /// <returns>StaffID</returns>
        public static int UserNameGetStaffID(Admins admin)
        {
            string sqlstring = "select StaffID from Admin where UserName=N'"+admin.UserName+"'";
            object obj = SqlHelper.ReadSclar(sqlstring);
            int TempStaffID =Convert.ToInt32(obj);
            return TempStaffID;
        }
        /// <summary>
        /// 谁写的？？？赶紧加注释
        /// </summary>
        /// <param name="mUserName"></param>
        /// <returns></returns>
        public int SelectStaffID(string mUserName)
        {
            string gSqlString = "select StaffID from Admin where UserName=N'"+mUserName+"'";
            return Convert.ToInt32(SqlHelper.ReadSclar(gSqlString));
        }
    }
}
