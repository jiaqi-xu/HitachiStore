/*
 * 1 功能描述：
 *   商品属性类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-06-14-54；
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
    /// 属性类
    /// </summary>
    public class Property
    {
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
        /// 商品属性名
        /// </summary>
        private string propertyName;
        public string PropertyName
        {
            set { propertyName = value; }
            get { return propertyName; }
        }
        /// <summary>
        /// 由属性ID集合返回属性名数组
        /// </summary>
        /// <param name="prolist">属性列表</param>
        /// <returns>属性名字数组</returns>
        public static string[]  PoIDGetPoName(List<Property> prolist)
        {
            string[] str = new string[prolist.Count];
            for (int i = 0; i < prolist.Count; i++)
            {
                string Sqlstring = "select PropertyName from Property where PropertyID='" + prolist[i].PropertyID + "'";
                object obj = SqlHelper.ReadSclar(Sqlstring);
                str[i] = (string)obj;
            }
            return str;
        }
        /// <summary>
        /// 由属性ID获取属性名字
        /// </summary>
        /// <param name="prolist">属性列表</param>
        /// <returns>属性列表含有属性名字</returns>
        public static List<Property> PoIDGetPoNameList(List<Property> prolist)
        {
            List<Property> propertylist = new List<Property>();
            for (int i = 0; i < prolist.Count; i++)
            {
                string Sqlstring = "select PropertyName from Property where PropertyID='" + prolist[i].PropertyID + "'";
                SqlHelper.ReadDateReadBegin(Sqlstring);
                while (SqlHelper.SqlReader.Read())
                {
                    Property property = new Property();
                    property.PropertyName = SqlHelper.SqlReader["PropertyName"].ToString();
                    propertylist.Add(property);
                }
                SqlHelper.ReadDateReadEnd();
            }
            return propertylist;
        }

    }
}
