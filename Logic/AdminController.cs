/*
 * 1 功能描述:管理员的方法类及方法
 * 
 * 2 作者：王晶晶，徐嘉琪
 * 
 * 3 创建时间：2012/8/3
 * 
 * 4 完成时间
 * 
 * 5 修改记录 
 * 1.修改时间:2012-8-6-9-30；2.修改内容：添加验证管理员权限与管理员登录验证与用户注册验证三个函数；3.修改人：徐嘉琪.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Logic
{
   public class AdminController
    {
       /// <summary>
       /// 注册管理员（向数据库中插入数据）
       /// </summary>
       /// <param name="lAdmin">管理员对象</param>
       /// <returns>是否添加成功</returns>
       public bool RegisterAdmin(Admins lAdmin)
       {
           return lAdmin.CreateAdmin();           
       }
       /// <summary>
       /// 验证管理员登录
       /// </summary>
       /// <param name="lAdmin"></param>
       /// <returns></returns>
       public bool AdminLoginText(Admins lAdmin)
       {
           return lAdmin.LoginText();
       }
       /// <summary>
       /// 判断管理员类型
       /// </summary>
       /// <param name="lAdmin">管理员对象</param>
       /// <returns>管理员类型</returns>
       public string AdminStaffType(Admins lAdmin)
       {
           return lAdmin.CheckStaffType();
       }
       /// <summary>
       /// 判断用户名是否存在
       /// </summary>
       /// <param name="lAdmin"></param>
       /// <returns>存在返回false</returns>
       public bool AdminRegistText(Admins lAdmin)
       {
           return lAdmin.RegistText();
       }
       /// <summary>
       /// 根据管理员的用户名得到其StaffID
       /// </summary>
       /// <param name="lAdmin"></param>
       /// <param name="mUserName"></param>
       /// <returns></returns>
       public int GetStaffID(Admins lAdmin, String mUserName)
       {
           return lAdmin.SelectStaffID(mUserName);
       }
      
    }
}
