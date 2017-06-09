/*
 * 1 功能描述：
 *   单个商品类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-21-08-30；
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
    /// 单个商品类
    /// </summary>
    public class SaveSingleGoodInfo
    {
        /// <summary>
        /// 单个商品ID
        /// </summary>
        private int singleGoodID;
        public int SingleGoodID
        {
            set { singleGoodID = value; }
            get { return singleGoodID; }
        }
        /// <summary>
        /// GoodID
        /// </summary>
        private int goodID;
        public int GoodID
        {
            set { goodID = value; }
            get { return goodID; }
        }
        /// <summary>
        /// 添加商品的管理员ID
        /// </summary>
        private int staffID;
        public int StaffID
        {
            set { staffID = value; }
            get { return staffID; }
        }
    }
}
