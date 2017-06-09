/*
 * 1 功能描述: 日志的操作方法类
 * 
 * 2 作者：王晶晶
 * 
 * 3 创建时间：2012/8/20
 * 
 * 4 完成时间
 * 
 * 5 修改记录
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Logic
{
    public class DayBookController
    {
        /// <summary>
        /// 向日志表中添加记录
        /// </summary>
        /// <param name="mDayBook"></param>
        /// <returns></returns>
        public bool AddDayBook(DayBook mDayBook)
        {
            return mDayBook.UpdateDayBook();
        }
        /// <summary>
        /// 得到每条日志的详细信息
        /// </summary>
        /// <param name="lDayBook"></param>
        /// <returns></returns>
        public string[] GetDayBookInfo(DayBook lDayBook)
        {
            return lDayBook.DayBookInfo();
        }
        /// <summary>
        /// 判断输入的操作时间是否存在
        /// </summary>
        /// <param name="mDayBook"></param>
        /// <param name="mHandleTime"></param>
        /// <returns></returns>
        public bool GetHandleTime(DayBook mDayBook, string mHandleTime)
        {
            return mDayBook.SelectHandleTime(mHandleTime);
        }
        /// <summary>
        /// 改变时间格式
        /// </summary>
        /// <param name="lDayBoook"></param>
        /// <returns></returns>
        public string GetHandleDay(DayBook lDayBoook)
        {
            return lDayBoook.ChangeHandleTime();
        }

    }
}
