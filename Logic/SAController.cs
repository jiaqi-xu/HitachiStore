/*
 * 1 功能描述: 高级管理员的方法类及方法
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
using Models;

namespace Logic
{
    public class SAController:AdminController
    {
        /// <summary>
        /// 激活管理员
        /// </summary>
        /// <param name="lSa">高级管理员对象</param>
        /// <returns>是否激活成功</returns>
        public bool ActiveAdmin(SA lSa)
        {
            return lSa.UpdateAdmin();
        }
        
        public string[] FindAdmin(SA lSa)
        {
            return lSa.QueryStaffInfo();
        }
        /// <summary>
        /// 高级管理员修改管理员信息
        /// </summary>
        /// <param name="lSa">高级管理员对象</param>
        /// <returns>是否修改成功</returns>
        public bool AlterAdmin(SA lSa)
        {
            return lSa.UpdateAdminInfo();
        }
        /// <summary>
        /// 高级管理员修改个人信息
        /// </summary>
        /// <param name="lSa">高级管理员对象</param>
        /// <returns>是否修改成功</returns>
        public bool AlterSaInfo(SA lSa)
        {
            return lSa.UpdateSaInfo();
        }
        /// <summary>
        /// 从数据库中得到此用户名
        /// </summary>
        /// <param name="lSa"></param>
        /// <returns>用户名</returns>
        public string GetUserName(SA lSa)
        {
            return lSa.SelectUserName();
        }
        /// <summary>
        /// 此用户名是否存在
        /// </summary>
        /// <param name="lSa">高级管理员对象</param>
        /// <returns>存在返回false</returns>
        public bool ExistStoreUser(SA lSa,string mStoreUserName)
        {
            return lSa.SelectStoreUser(mStoreUserName);
        }
        /// <summary>
        /// 搜索StoreUser信息
        /// </summary>
        /// <param name="lSa"></param>
        /// <param name="mStoreUserName"></param>
        /// <returns></returns>
        public string[] GetStoreUserInfo(SA lSa,string mStoreUserName)
        {
            return lSa.SelectStoreUserInfo(mStoreUserName);
        }
        /// <summary>
        /// 得到默认发货地址
        /// </summary>
        public List<ShipAddress> GetAddress(SA lSa, string mStoreUserID)
        {
            return lSa.SelectAddress(mStoreUserID);
        }
        /// <summary>
        /// 判断此EvaluateID是否存在
        /// </summary>
        /// <param name="lSa">高级管理员对象</param>
        /// <param name="mEvaluateID">输入的Evaluate</param>
        /// <returns>存在返回true</returns>
        public bool ExistEvaluateID(SA lSa, string mEvaluateID)
        {
            return lSa.SelectEvaluateID(mEvaluateID);
        }
        /// <summary>
        /// 搜索评价信息
        /// </summary>
        /// <param name="lSa">高级管理员对象</param>
        /// <param name="mEvaluateID">EvaluateID</param>
        /// <returns></returns>
        public string[] GetEvaluateInfo(SA lSa, String mEvaluateID)
        {
            return lSa.SelectEvaluateInfo(mEvaluateID);
        }
        /// <summary>
        /// 判断输入的OrderID是否存在
        /// </summary>
        /// <param name="lSa">高级管理员对象</param>
        /// <param name="mOrderID">输入的OrderID</param>
        /// <returns>存在返回true</returns>
        public bool ExistOrderID(SA lSa, string mOrderID)
        {
            return lSa.SelectOrderID(mOrderID);
        }
        /// <summary>
        /// 删除普通管理员
        /// </summary>
        /// <param name="lSa">高级管理员对象</param>
        /// <param name="GeneralAdminID">普通管理员ID</param>
        /// <returns></returns>
        public bool RemoveGeneralAdmin(SA lSa,string gGeneralAdminUserName)
        {
            return lSa.DeleteGeneralAdmin(gGeneralAdminUserName);
        }
        public string GetAdminType(SA lSa,string gUserName)
        {
            return lSa.SelectAdminType(gUserName);
        }
        /// <summary>
        /// 删除与StaffID 存在外键关系的订单
        /// </summary>
        /// <param name="lSa"></param>
        /// <param name="mAdminID"></param>
        /// <returns></returns>
        public bool RemoveOrder(SA lSa, string mAdminID)
        {
            return lSa.DeleteOrder(mAdminID);
        }
    }
}
