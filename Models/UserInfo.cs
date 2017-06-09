/*
 * 1 功能描述：
 *   用户信息类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-16-22-27；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 用户信息类
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户信息ID
        /// </summary>
        private int userInfoID;
        public int UserInfoID
        {
            set { userInfoID = value; }
            get { return userInfoID; }
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
        /// 用户头像图片地址
        /// </summary>
        private string userPicture;
        public string UserPicture
        {
            set { userPicture = value; }
            get { return userPicture; }
        }
        /// <summary>
        /// 用户昵称
        /// </summary>
        private string nickName;
        public string NickName
        {
            set { nickName = value; }
            get { return nickName; }
        }
        /// <summary>
        /// 用户性别
        /// </summary>
        private string sex;
        public string Sex
        {
            set { sex = value; }
            get { return sex; }
        }
        /// <summary>
        /// 用户年龄
        /// </summary>
        private int age;
        public int Age
        {
            set { age = value; }
            get { return age; }
        }
        /// <summary>
        /// 用户电话
        /// </summary>
        private string phone;
        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }
        /// <summary>
        /// 用户QQ
        /// </summary>
        private string qq;
        public string QQ
        {
            set { qq = value; }
            get { return qq; }
        }
        /// <summary>
        /// 用户消费总和
        /// </summary>
        private string moneySum;
        public string MoneyDum
        {
            set { moneySum = value; }
            get { return moneySum; }
        }
    }
}
