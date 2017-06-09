
/*
 * 1 功能描述：
 *     用户管理员
 * 2 作者：
 *   徐嘉琪；
   3 创建时间：
 *   2012-08-06-14-30；
 * 4 完成时间：
 *   2012-08-06-17-00；
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Logic
{
  public  class UAController
    {

      /// <summary>
      /// 获取用户管理员个人信息
      /// </summary>
      /// <param name="UAadmin"></param>
      /// <returns></returns>
      public string[] UAGetInfo(UA UAadmin)
      {
          return UAadmin.UAInfoRead();
      }
      /// <summary>
      /// 更新用户管理员个人信息
      /// </summary>
      /// <param name="UAadmin"></param>
      /// <returns></returns>
      public bool UAUpdateInfo(UA UAadmin)
      {
          return UAadmin.UAInfoUpdate();
      }

      /// <summary>
      /// 查询用户信息
      /// </summary>
      /// <param name="UAadmin"></param>
      /// <returns></returns>
      public string[] UserGetInfo(UA UAadmin)
      {
          return UAadmin.SelectStoreUserInfo();   
      }

      /// <summary>
      /// 判断该用户名是否存在
      /// </summary>
      /// <param name="UAadmin"></param>
      /// <returns></returns>
      public bool IsUserAlive(UA UAadmin)
      {
          return UAadmin.IsUserExist();
      }

      /// <summary>
      /// 获得发货地址
      /// </summary>
      /// <param name="UAadmin"></param>
      /// <returns></returns>
      public List<ShipAddress> GetAddressList(UA UAadmin)
      {
          return UAadmin.GetAddress(); 
      }

      /// <summary>
      /// 删除用户所有信息
      /// </summary>
      /// <param name="UAadmin"></param>
      /// <returns></returns>
      public bool DeleteUser(UA UAadmin)
      {
          return UAadmin.DeleteUserInfo(); 
      }
      /// <summary>
      /// 修改用户类型
      /// </summary>
      /// <returns></returns>
      public bool UpdateUserInfo(UA UAadmin)
      {
          return UAadmin.ChangeUserType();
      }

    }
}
