/*
 * 1 功能描述：
 *   属性类目结合类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-08-14-54；
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
    /// 属性类目结合类
    /// </summary>
    public  class PropertyClassDm
    {
        /// <summary>
        /// 三级类目ID
        /// </summary>
        private string thirdClassDmID;
        public string ThirdClassDmID
        {
            set { thirdClassDmID = value; }
            get { return thirdClassDmID; }
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
        /// 由三级类目ID获取属性ID
        /// </summary>
        /// <param name="thirdclassdm">三级类目对象</param>
        /// <returns>对象表</returns>
        public static List<Property> TcIDGetPoID(ThirdClassDm thirdclassdm)
        {
            List<Property> prolist = new List<Property>();
            string Sqlstring = "select PropertyID from PropertyClassDm where ThirdClassDmID='" + thirdclassdm .ThirdClassDmID+ "'";
            SqlHelper.ReadDateReadBegin(Sqlstring);
            while(SqlHelper.SqlReader.Read())
            {
                Property property = new Property();
                property.PropertyID = SqlHelper.SqlReader["PropertyID"].ToString();
                prolist.Add(property);
            }
            SqlHelper.ReadDateReadEnd();
            return prolist;
        }
    }
}
