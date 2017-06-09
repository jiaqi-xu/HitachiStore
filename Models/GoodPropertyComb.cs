/*
 * 1 功能描述：
 *   用户实体类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-16-22-49；
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
    /// 商品属性结合表
    /// </summary>
    public class GoodPropertyComb
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        private int goodID;
        public int GoodID
        {
            set { goodID = value; }
            get { return goodID; }
        }
        /// <summary>
        /// 商品属性ID
        /// </summary>
        private string propertyID;
        public string PropertyID
        {
            set { propertyID = value; }
            get { return propertyID; }
        }
        /// <summary>
        /// 商品属性内容
        /// </summary>
        private string propertyContent;
        public string PropertyContent
        {
            set { propertyContent = value; }
            get { return propertyContent; }
        }

    }
}
