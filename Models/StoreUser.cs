/*
 * 1 功能描述：
 *   用户实体类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-03-11-14；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 *   修改时间：2012-08-06-10-09；
 *   修改内容：添加获取用户信息；
 *   修改人：李霏
 *   
 *   修改时间：2012-8-6-20-25；
 *   修改内容：添加获取用户账户；
 *   修改人：李霏
 *   
 *   修改时间：2012-8-7-14-10；
 *   修改内容：添加用户修改密码
 *   修改人：李霏
 *   
 *   修改时间：2012-8-7-16-13；
 *   修改内容：添加用户找回密码
 *   修改人：李霏
 *   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SQLHelper;
using System.Data;
using System.Data.SqlClient;
namespace Models
{
    public class StoreUser
    {
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
        /// 用户名
        /// </summary>
        private string userName;
        public string UserName
        {
            set { userName = value; }
            get { return userName; }
        }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        private string userTrueName;
        public string UserTrueName
        {
            set { userTrueName = value; }
            get { return userTrueName; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        private string passWord;
        public string PassWord
        {
            set { passWord = value; }
            get { return passWord; }
        }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        private string email;
        public string Email
        {
            set { email = value; }
            get { return email; }
        }
        /// <summary>
        /// 用户类型 默认0  1为会员
        /// </summary>
        private char userType = '0';
        public char UserType
        {
            set { userType = value; }
            get { return userType; }
        }
        /// <summary>
        /// 是否激活
        /// </summary>
        private char isConfirm = '0';
        public char IsConfim
        {
            set { isConfirm = value; }
            get { return isConfirm; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        private string registTime;
        public string RegistTime
        {
            set { registTime = value; }
            get { return registTime; }
        }
        /// <summary>
        /// 用户身份证号
        /// </summary>
        private string idCardNum;
        public string IdCardNum
        {
            set { idCardNum = value; }
            get { return idCardNum; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        private string nickName;
        public string NickName
        {
            set { nickName = value; }
            get { return nickName; }
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
        /// 性别
        /// </summary>
        private string sex;
        public string Sex
        {
            set { sex = value; }
            get { return sex; }
        }
        /// <summary>
        ///  电话
        /// </summary>
        private string phone;
        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }
        /// <summary>
        /// QQ
        /// </summary>
        private string qq;
        public string QQ
        {
            set { qq = value; }
            get { return qq; }
        }
        /// <summary>
        /// 地址一
        /// </summary>
        private string address1;
        public string Address1
        {
            set { address1 = value; }
            get { return address1; }
        }
        /// <summary>
        /// 地址二
        /// </summary>
        private string address2;
        public string Address2
        {
            set { address2 = value; }
            get { return address2; }
        }
        /// <summary>
        /// 地址三
        /// </summary>
        private string address3;
        public string Address3
        {
            set { address3 = value; }
            get { return address3; }
        }
        /// <summary>
        /// 第一地址是否为默认
        /// </summary>
        private string isdafult1;
        public string IsDafult1
        {
            set { isdafult1 = value; }
            get { return isdafult1; }
        }
        /// <summary>
        /// 第二地址是否为默认
        /// </summary>
        private string isdafult2;
        public string IsDafult2
        {
            set { isdafult2 = value; }
            get { return isdafult2; }
        }
        /// <summary>
        /// 第三地址是否为默认
        /// </summary>
        private string isdafult3;
        public string IsDafult3
        {
            set { isdafult3 = value; }
            get { return isdafult3; }
        }
        /// <summary>
        /// 身份证
        /// </summary>
        private string idCard;
        public string Idcard
        {
            set { idCard = value; }
            get { return idCard; }
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns>是否成功</returns>
        public bool CreateStoreUser()
        {
            StringBuilder lSqlstring = new StringBuilder();
            lSqlstring.Append("insert into StoreUser(UserName,PassWord,Email,UserType,IsConfirm,RegistTime,IdCardNum,TrueName)");
            lSqlstring.Append("values(");
            lSqlstring.Append("'" + this.UserName + "',");
            lSqlstring.Append("'" + this.PassWord + "',");
            lSqlstring.Append("'" + this.Email + "',");
            lSqlstring.Append("'0',");
            lSqlstring.Append("'0',");
            lSqlstring.Append("getdate(),");
            lSqlstring.Append("'" + this.IdCardNum + "',");
            lSqlstring.Append("N'" + this.UserTrueName + "'");
            lSqlstring.Append(")");
            if (SqlHelper.ExecuteNonQuery(lSqlstring.ToString()) > 0)
            {
                int lUserID=StoreUser.UserNameGetID(this);
                string lSqlUserInfo = "insert into UserInfo(UserID,UserPicture,NickName,Sex,Age,Phone,QQ,MoneySum) values('"+lUserID+"','','','',0,'','',0) ";
                string lSqlShipAddress1 = "insert into ShipAddress(UserID,Address,IsDefault) values('"+lUserID+"','','0');";
                string lSqlShipAddress2 = "insert into ShipAddress(UserID,Address,IsDefault) values('" + lUserID + "','','0');";
                string lSqlShipAddress3 = "insert into ShipAddress(UserID,Address,IsDefault) values('" + lUserID + "','','0');";
                if (SqlHelper.ExecuteNonQuery(lSqlUserInfo) > 0 && SqlHelper.ExecuteNonQuery(lSqlShipAddress1) > 0 && SqlHelper.ExecuteNonQuery(lSqlShipAddress2) > 0 && SqlHelper.ExecuteNonQuery(lSqlShipAddress3) > 0)
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
        /// 用户登陆
        /// </summary>
        /// <returns>密码是否一致</returns>
        public bool UserLogin()
        {
            string lSqlstring = "select PassWord from StoreUser where UserName='"+this.UserName+"'";
            Object lobj = SqlHelper.ReadSclar(lSqlstring);
            string lStr;
            lStr = (string)lobj;
            if (lStr == this.PassWord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 用户名验证
        /// </summary>
        /// <returns>是否重复</returns>
        public bool UserNameExam()
        {
            string lSqlstring = "select PassWord from StoreUser where UserName='" + this.UserName + "'";
            Object obj=SqlHelper.ReadSclar(lSqlstring);
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 用户激活状态
        /// </summary>
        /// <returns>是否激活</returns>
        public bool UserConfirm()
        {
            string Sqlstring = "select IsConfirm from StoreUser where UserName='" + this.UserName + "'";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            string str = (string)obj;
            if (str == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns>返回用户信息数组</returns>
        public string[] UserInfo()
        {
            string[] info = new string[12];
            int ID;
            int i = 0;
            //利用UserName查出UserID
            string Sql = "select UserID from StoreUser where UserName='" + this.UserName + "'";
            Object obj = SqlHelper.ReadSclar(Sql);
            //查出TrueName
            string Sql1 = "select TrueName from StoreUser where UserName='" + this.UserName + "'";
            Object obj1 = SqlHelper.ReadSclar(Sql1);
            ID = Convert.ToInt32(obj);
            //联合查询查出用户信息及用户地址并存入数组中
            string Sql2 = "select * from  ShipAddress left join UserInfo on UserInfo.UserID=ShipAddress.UserID where UserInfo.UserID='"+ID+"'";
            SqlHelper.ReadDateReadBegin(Sql2);   
            while (SqlHelper.SqlReader.Read())
            {
                info[3] = SqlHelper.SqlReader[7].ToString();//昵称
                info[4] = SqlHelper.SqlReader[8].ToString();//性别    
                info[5] = SqlHelper.SqlReader[9].ToString();//年龄
                info[6] = SqlHelper.SqlReader[10].ToString();//电话
                info[7] = SqlHelper.SqlReader[11].ToString();//QQ
                info[i] = SqlHelper.SqlReader[2].ToString();//数组前三个位地址
                info[i+8] = SqlHelper.SqlReader[3].ToString();//数组8,9,10为是否为默认
                i++;
                //info=SqlHelper.SqlReader;
            }
            info[11] = obj1.ToString();//用户名
            SqlHelper.SqlReader.Close();//关闭datareader
            SqlHelper.ReadDateReadEnd();
            return info;//返回数组
        }
        /// <summary>
        /// 用户修改信息
        /// </summary>
        /// <returns>是否修改成功</returns>
        public bool UpdataInfo()
        {
            int []a=new int[4];
            int[] addre = new int[4];//存储AddressID
            int i=0;
            //利用UserName查出UserID
            string Sql = "select UserID from StoreUser where UserName='" + this.UserName + "'";
            Object obj = SqlHelper.ReadSclar(Sql);
            int ID = Convert.ToInt32(obj);
            //利用UserID查出AddressID
            string Sql5 = "select AddressID from ShipAddress where UserID='" + ID + "'";
            SqlHelper.ReadDateReadBegin(Sql5);
            while (SqlHelper.SqlReader.Read())
            {
                addre[i] = Convert.ToInt32( SqlHelper.SqlReader[0]);
                i++;
            }
            SqlHelper.SqlReader.Close();
            SqlHelper.ReadDateReadEnd();
            //更新信息
            string Sql1 = "update Userinfo set NickName=N'" + this.NickName + "',Sex='" + this.Sex + "',Age='" + this.Age + "',QQ='" + this.QQ + "',Phone='" + this.Phone + "' where UserID='" + ID + "'";
            a[0] = SqlHelper.ExecuteNonQuery(Sql1);
            if (Address1 != null)
            {
                string Sql2 = "update ShipAddress set Address=N'" + Address1 + "',IsDefault='" + IsDafult1 + "' where AddressID='" + addre[0] + "'";
                a[1] = SqlHelper.ExecuteNonQuery(Sql2);
            }
            if (Address2 != null)
            {
                string Sql3 = "update ShipAddress set Address=N'" + Address2 + "',IsDefault='" + IsDafult2 + "' where AddressID='" + addre[1] + "'";
                a[2] = SqlHelper.ExecuteNonQuery(Sql3);
            }
            if (Address3 != null)
            {
                string Sql4 = "update ShipAddress set Address=N'" + Address3 + "',IsDefault='" + IsDafult3 + "' where AddressID='" + addre[2] + "'";
                a[3] = SqlHelper.ExecuteNonQuery(Sql4);
            }
            if (a[0] > 0 || a[1] > 0 || a[2] > 0 || a[3] > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取用户账户
        /// </summary>
        /// <returns>返回用户账户信息数组</returns>
        public string[] UserCount()
        {
            //利用UserName查出UserID
            string Sql1="select UserID from StoreUser where UserName='" + this.UserName + "' ";
            Object obj=SqlHelper.ReadSclar(Sql1);
            int ID=Convert.ToInt32(obj);
            //查出用户类型
            string Sql2 = "select UserType from StoreUser where UserName='" + this.UserName + "'";
            Object obj2=SqlHelper.ReadSclar(Sql2);
            //查出用户总钱数
            string Sql3 = "select MoneySum from UserInfo where UserID='" + ID + "'";
            Object obj3 = SqlHelper.ReadSclar(Sql3);
            string[] UserCount = new string[2];
            UserCount[0] = obj2.ToString();
            UserCount[1] = obj3.ToString();
            return UserCount;
        }
        /// <summary>
        /// 获取用户身份证信息
        /// </summary>
        /// <returns>用户身份证号</returns>
        public string IdCard()
        {
            //查询身份证
            string Sql = "select IdCardNum from StoreUser where UserName='" + this.UserName + "'";
            Object obj = SqlHelper.ReadSclar(Sql);
            //查询密码
            string Sql1 = "select PassWord from StoreUser where UserName='" + this.UserName + "'";
            Object obj1 = SqlHelper.ReadSclar(Sql1);
            string a = obj.ToString();
            string b = a + "m" + obj1.ToString();
            return b;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns>是否修改成功</returns>
        public bool ChangeIdCard()
        {
            //更新密码
            string Sql = "update StoreUser set PassWord='" + this.PassWord + "' where UserName='" + this.userName + "'";
            int a = SqlHelper.ExecuteNonQuery(Sql);
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是否重置密码
        /// </summary>
        /// <returns>是否能够重置密码</returns>
        public bool FindPassword()
        {
            //查询信息是否错误
            string Sql="select * from StoreUser where UserName='"+this.UserName+"' and Email='"+this.email+"' and IdCardNum='"+this.idCard+"'";
            Object obj = SqlHelper.ReadSclar(Sql);
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查看订单信息
        /// </summary>
        /// <param name="orderID">订单ID</param>
        /// <returns>订单信息数组</returns>
        public string [] OrderInfo (string orderID)
        {
            string[] orderInfo = new string[5];//储存Order信息
            string userID = "select UserID from Orders where OrderID='" + orderID + "'";
            Object obj = SqlHelper.ReadSclar(userID);//用户OrderID
            string addressID = "select AddressID from Orders where OrderID='" + orderID + "'";
            Object addressId = SqlHelper.ReadSclar(addressID);//用户AddressID
            string address = "select Address from ShipAddress where AddressID=N'" + addressId + "'";
            orderInfo[3] = Convert.ToString(SqlHelper.ReadSclar(address));//
            string userInfo = "select TrueName,Email,Phone from UserInfo left Join storeUser on UserInfo.UserID=StoreUser.UserID where UserInfo.UserID='"+obj.ToString()+"'";
            SqlHelper.ReadDateReadBegin(userInfo);
            while (SqlHelper.SqlReader.Read())
            {
                orderInfo[0] = SqlHelper.SqlReader["Email"].ToString();
                orderInfo[1] = SqlHelper.SqlReader["TrueName"].ToString();
                orderInfo[2] = SqlHelper.SqlReader["Phone"].ToString();
            }
            SqlHelper.ReadDateReadEnd();
            return orderInfo;
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="cancelReason">取消理由</param>
        /// <param name="orderId">订单ID</param>
        /// <returns>失败或成功</returns>
        public bool CancelOrder(string cancelReason,string orderId)
        {
            string Update = "Update Orders set CalloffReason=N'" + cancelReason + "',IsDeal='" + 2 + "'where OrderID='" + orderId + "' ";
            string Updata1 = "Update SaveOrders set CalloffReason=N'" + cancelReason + "',IsDeal='" + 2 + "'where OrderID='" + orderId + "' ";
            Object obj1 = SqlHelper.ExecuteNonQuery(Update);//更新信息
            Object obj2 = SqlHelper.ExecuteNonQuery(Updata1);//信息
            if (Convert.ToInt32(obj1) > 0 && Convert.ToInt32(obj2) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string  aUsertype { get; set; }// 为string类型
        /// <summary>
        /// 用用户名获取用户ID
        /// </summary>
        /// <param name="storeuser">用户对象</param>
        /// <returns>ID号</returns>
        public static int  UserNameGetID(StoreUser storeuser)
        {
            //查询UserID
            string sql = "select UserID from StoreUser where UserName='"+storeuser.UserName+"'";
            Object obj=SqlHelper.ReadSclar(sql);
            int temp = Convert.ToInt32(obj);
            return temp;
        }
        /// <summary>
        /// 用户ID获取用户名字
        /// </summary>
        /// <param name="storeuser">用户对象</param>
        /// <returns>用户名字</returns>
        public static string UserIDGetName(StoreUser storeuser)
        {
            string sql = "select UserName from StoreUser where UserID='" + storeuser.UserID + "'";
            Object obj = SqlHelper.ReadSclar(sql);
            string TempUserName = (string)obj;
            return TempUserName;
        }
        /// <summary>
        /// 订单中用户信息
        /// </summary>
        /// <returns>用户对象列表</returns>
        public List<StoreUser> ConfrimOrder()
        {
            List<StoreUser> ConfirmInfo = new List<StoreUser>();
            StoreUser user = new StoreUser();
            user.UserName = this.UserName;
            string[] userInfo = new string[6];
            int lCount=0;
            int lUserID = StoreUser.UserNameGetID(user);
            string trueName = "select TrueName from StoreUser where UserID=N'" + lUserID + "'";
            string phone = "select Phone from UserInfo where UserID='" + lUserID + "'";
            string address = "select Address,IsDefault from ShipAddress where UserID=N'" + lUserID + "'";
            SqlHelper.ReadDateReadBegin(address);
            while (SqlHelper.SqlReader.Read())
            {
                userInfo[lCount] = SqlHelper.SqlReader[0].ToString();
                userInfo[lCount + 3] = SqlHelper.SqlReader[1].ToString();
                lCount++;
            }
            SqlHelper.ReadDateReadEnd();
            StoreUser ConfirmOrderInfo = new StoreUser();
            ConfirmOrderInfo.Phone = SqlHelper.ReadSclar(phone).ToString();
            ConfirmOrderInfo.UserTrueName = SqlHelper.ReadSclar(trueName).ToString();
            ConfirmOrderInfo.Address1 = userInfo[0];
            ConfirmOrderInfo.Address2 = userInfo[1];
            ConfirmOrderInfo.Address3 = userInfo[2];
            ConfirmOrderInfo.IsDafult1 = userInfo[3];
            ConfirmOrderInfo.IsDafult2 = userInfo[4];
            ConfirmOrderInfo.IsDafult3 = userInfo[5];
            ConfirmInfo.Add(ConfirmOrderInfo);
            return ConfirmInfo;
        
        }
        /// <summary>
        /// 用户激活
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>成功或失败</returns>
        public bool Active(StoreUser user)
        {
            string Update = "Update StoreUser set IsConfirm='" + user.IsConfim + "'where UserName='" + user.UserName + "' ";
            Object obj1 = SqlHelper.ExecuteNonQuery(Update);//更新信息
            if (Convert.ToInt32(obj1) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 订单更新信息
        /// </summary>
        /// <returns>是否更新成功</returns>
        public bool OrderUpdateUserInfo()
        {
            int[] a = new int[4];
            int[] addre = new int[4];//存储AddressID
            int i = 0;
            //利用UserName查出UserID
            string Sql = "select UserID from StoreUser where UserName='" + this.UserName + "'";
            Object obj = SqlHelper.ReadSclar(Sql);
            int ID = Convert.ToInt32(obj);
            //利用UserID查出AddressID
            string Sql5 = "select AddressID from ShipAddress where UserID='" + ID + "'";
            SqlHelper.ReadDateReadBegin(Sql5);
            while (SqlHelper.SqlReader.Read())
            {
                addre[i] = Convert.ToInt32(SqlHelper.SqlReader[0]);
                i++;
            }
            SqlHelper.SqlReader.Close();
            SqlHelper.ReadDateReadEnd();
            //更新信息
            string Sql1 = "update Userinfo set Phone='" + this.Phone + "' where UserID='" + ID + "'";
            a[0] = SqlHelper.ExecuteNonQuery(Sql1);
            if (Address1 != null)
            {
                string Sql2 = "update ShipAddress set Address=N'" + Address1 + "' where AddressID='" + addre[0] + "'";
                a[1] = SqlHelper.ExecuteNonQuery(Sql2);
            }
            if (Address2 != null)
            {
                string Sql3 = "update ShipAddress set Address=N'" + Address2 + "' where AddressID='" + addre[1] + "'";
                a[2] = SqlHelper.ExecuteNonQuery(Sql3);
            }
            if (Address3 != null)
            {
                string Sql4 = "update ShipAddress set Address=N'" + Address3 + "' where AddressID='" + addre[2] + "'";
                a[3] = SqlHelper.ExecuteNonQuery(Sql4);
            }
            if (a[0] > 0 || a[1] > 0 || a[2] > 0 || a[3] > 0)
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
