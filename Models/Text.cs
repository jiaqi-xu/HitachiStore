/*
 * 1 功能描述：
 *    验证用户名是否重复，验证登陆密码是否正确.
 * 2 作者：
 *   徐嘉琪；
   3 创建时间：
 *   2012-08-04-14-30；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;

namespace Models
{

    /// <summary>
    /// 验证的实体类，包含多种验证方法
    /// </summary>
  public class Text
    {
      /// <summary>
      /// 验证用户名是否重复的方法
      /// 使用方法：你只需将输入的用户名的控件的Text传进来即可
      /// </summary>
      /// <param name="UserName"></param>
      /// <returns></returns>
      public bool RegistText(string UserName)
      { 
          string sqlstring1 ="select PassWord from StoreUser where UserName='"+UserName+"'";
          object obj= SqlHelper.ReadSclar(sqlstring1);
          if (obj != null)
          {
              return false;
          }
          else 
          {
              return true;
          } 
      }
      /// <summary>
      /// 验证登陆的用户名和密码是否正确
      /// 使用方法：你只需将输入的用户名与密码的2个控件的Text传进来即可
      /// </summary>
      /// <param name="UserName"></param>
      /// <param name="PassWord"></param>
      /// <returns></returns>
      public bool LoginText(string UserName,string PassWord)
      {
          
          string sqlstring2 = "select PassWord from Admin where UserName='"+UserName+"'";
          object obj1 = SqlHelper.ReadSclar(sqlstring2);
          if (obj1.ToString() == PassWord)
          {
              return true;
          }
          else { return false; }
      }
      
      /// <summary>
      /// 验证管理员权限
      ///  使用方法：你只需将输入的用户名与管理员类型的2个控件的Text传进来即可
      /// </summary>
      /// <param name="UserName"></param>
      /// <param name="StaffTypeNum"></param>
      /// <returns></returns>
      public string StaffType(string UserName)
      {
          { 
            string sqlstring3="select StaffType from Admin where UserName='"+UserName+"'";
                object obj2=SqlHelper.ReadSclar(sqlstring3);
                return obj2.ToString();
          }

      }
    }



}
