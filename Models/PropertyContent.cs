/*
 * 1 功能描述：
 *   属性内容类
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-10-37-08-09；
 * 4 完成时间：
 * 
 * 5 修改记录：王晶晶  2012-8-22 增加属性内容的修改功能
 *   
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;

namespace Models
{
    /// <summary>
    /// 属性内容类
    /// </summary>
    public class PropertyContent
    {
        /// <summary>
        /// 属性名字ID
        /// </summary>
        private string propertyID;
        public string PropertyID
        {
            set { propertyID = value; }
            get { return propertyID; }
        }
        /// <summary>
        /// 属性内容名字
        /// </summary>
        private string propertyContentName;
        public string PropertyContentName
        {
            set { propertyContentName = value; }
            get { return propertyContentName; }
        }
        /// <summary>
        /// 属性ID获取属性内容名字
        /// </summary>
        /// <param name="procontent">属性内容对象</param>
        /// <returns>含有属性名字的表</returns>
        public static List<PropertyContent> PoIDGetPcName(PropertyContent procontent)
        {
            string Sql = "select PropertyContentName from PropertyContent where PropertyID='" + procontent.PropertyID + "'";
            List<PropertyContent> procontentlist = new List<PropertyContent>();
            SqlHelper.ReadDateReadBegin(Sql);
            while (SqlHelper.SqlReader.Read())
            {
                PropertyContent Temp = new PropertyContent();
                Temp.PropertyContentName = SqlHelper.SqlReader["PropertyContentName"].ToString();
                procontentlist.Add(Temp);
            }
            SqlHelper.ReadDateReadEnd();
            return procontentlist;
        }
        /// <summary>
        /// 属性和属性内容关系是否重复
        /// </summary>
        /// <param name="procontent">属性内容对象</param>
        /// <returns>是或否</returns>
        public static bool PcIsRepeat(PropertyContent procontent)
        {
            string Sql = "select PropertyID from PropertyContent where PropertyContentName=N'" + procontent.PropertyContentName + "'and  PropertyID='" + procontent.PropertyID + "'";
            Object obj = SqlHelper.ReadSclar(Sql);
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 此属性内容是否存在
        /// </summary>
        /// <returns>不存在则返回true</returns>
        public bool SelectProCon()
        {
            string SqlString = "select PropertyContent from GoodPropertyComb where PropertyContent=N'"+this.PropertyContentName+"'";
            if (SqlHelper.ReadSclar(SqlString) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改属性内容
        /// </summary>
        /// <param name="mProConName"></param>
        /// <returns>修改成功返回true</returns>
        public bool UpdateProCon(String mProConName)
        {
            string SqlString = "Update PropertyContent set PropertyContentName=N'"+mProConName+"' where PropertyContentName=N'"+this.propertyContentName+"'";
            if (SqlHelper.ExecuteNonQuery(SqlString) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
