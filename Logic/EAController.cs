using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Logic
{
  public  class EAController
    {
        /// <summary>
        /// 获取评价管理员个人信息
        /// </summary>
        /// <param name="UAadmin"></param>
        /// <returns></returns>
      public string[] EAGetInfo(EA EAadmin)
      {
          return EAadmin.EAInfoRead();
      }

        /// <summary>
        /// 更新评价管理员个人信息
        /// </summary>
        /// <param name="UAadmin"></param>
        /// <returns></returns>
      public bool EAUpdateInfo(EA EAadmin)
      {
          return EAadmin.EAInfoUpdate();
      }

      /// <summary>
      /// 判断查看的评价是否存在
      /// </summary>
      /// <param name="EAadmin"></param>
      /// <returns></returns>
      public bool IsEvaluateAlive(EA EAadmin)
      {
          return EAadmin.IsEvaluateExist();
      }

      /// <summary>
      /// 显示评价信息
      /// </summary>
      /// <param name="EAadmin"></param>
      /// <returns></returns>
      public string[] EvaluateInfoShow(EA EAadmin)
      {
          return EAadmin.ShowEvaluateInfo();
      }

      /// <summary>
      /// 删除评价信息
      /// </summary>
      /// <param name="EAadmin"></param>
      /// <returns></returns>
      public bool EA_DeleteEvaluate(EA EAadmin)
      {
          return EAadmin.DeleteEvaluate();
      }
    }
}
