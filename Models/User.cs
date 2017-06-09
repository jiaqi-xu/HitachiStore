
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;
namespace Models
{
    public class User
    {
       /// <summary>
       /// 用户名
       /// </summary>
        string userName;
        public string UserName
        {
            set { userName = value; }
            get { return userName; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        string passWord;
        public string PassWord
        {
            set { passWord = value; }
            get { return passWord; }
        }

        public bool CreatUser()
        {
            string Sqlstring = "insert into User (UserName,PassWord) values( " + this.UserName + "," + this.PassWord + ") ";
            if(SqlHelper.ExecuteNonQuery(Sqlstring)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<User> Getlist()
        {
            List<User> lUserlist = new List<User>();
            string Sqlstring = "select UserName,PassWord，id from User";
            SqlHelper.ReadDateReadBegin(Sqlstring);
            while (SqlHelper.SqlReader.Read())
            {

                User luser = new User();
                luser.UserName = SqlHelper.SqlReader["UserName"].ToString();
                luser.PassWord = SqlHelper.SqlReader["PassWord"].ToString();
                lUserlist.Add(luser);
            }
            SqlHelper.ReadDateReadEnd();
            return lUserlist;
        }
        public void asdfas()
        {
            MyCommand comm = new MyCommand();
        }

    }
}
