/*
 * 1 功能描述：
 *   商城用户类的函数；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-04-15-58；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 *   修改时间：2012-08-06-10-48；
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
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace Logic
{
    public class StoreUserController
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="User1">用户对象</param>
        /// <returns>该对象生成时是否成功</returns>
        public bool RegistStoreUser(StoreUser User1)
        {
            return User1.CreateStoreUser();
        }
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="User1">用户对象</param>
        /// <returns>用户登陆时是否成功</returns>
        public bool StoreUserLogin(StoreUser User1)
        {
            return User1.UserLogin();
        }
        /// <summary>
        /// 用户名验证
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <returns>用户名是否重复</returns>
        public bool StoreUserNameExam(StoreUser User)
        {
            return User.UserNameExam();
        }
        /// <summary>
        /// 激活验证
        /// </summary>
        /// <param name="User1">用户对象</param>
        /// <returns>返回用户激活状态</returns>
        public bool StoreUserConfirm(StoreUser User1)
        {
            return User1.UserConfirm();
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <returns>返回用户信息数组</returns>
        public string[] GetInfo(StoreUser User)
        {
            return User.UserInfo();
        }
        /// <summary>
        /// 用户信息修改
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <returns>是否修改成功</returns>
        public bool Update(StoreUser User)
        {
            return User.UpdataInfo();
        }
        /// <summary>
        /// 获取用户账户信息
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <returns>用户账户信息</returns>
        public string[] UserCount(StoreUser User)
        {
            return User.UserCount();
        }
        /// <summary>
        /// 获取身份证号
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <returns>身份证号</returns>
        public string Idcard(StoreUser User)
        {
            return User.IdCard();
        }
        /// <summary>
        /// 是否修改身份证号
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <returns>是否修改成功</returns>
        public bool ChangeIdCard(StoreUser User)
        {
            return User.ChangeIdCard();
        }
        /// <summary>
        /// 是否能够重置密码
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <returns>是否能重置密码</returns>
        public bool FindPassword(StoreUser User)
        {
            return User.FindPassword();
        }
        /// <summary>
        /// 查看订单信息
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <param name="orderInfo">orderID</param>
        /// <returns>订单信息</returns>
        public string[] OrderInfo(StoreUser User, string orderInfo)
        {
            return User.OrderInfo(orderInfo);
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <param name="cancelReason"取消理由></param>
        /// <returns>是否取消成功</returns>
        public bool cancelOrder( StoreUser User ,string cancelReason,string orderId)
        {
            return User.CancelOrder(cancelReason,orderId);
        }
        /// <summary>
        /// 订单用户信息
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <returns>对象列表</returns>
        public List<StoreUser> OrderConfirm(StoreUser User)
        {
            return User.ConfrimOrder();
        }
        /// <summary>
        /// 订单更新用户信息
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <returns>是否更新成功</returns>
        public bool OrderUpdateUserinfo(StoreUser User)
        {
            return User.OrderUpdateUserInfo();
        }
    }
}
