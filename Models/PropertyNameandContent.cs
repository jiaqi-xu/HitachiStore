using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;
using Models;

namespace Models
{
     public class PropertyNameandContent
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
        /// 属性内容名字
        /// </summary>
        private string propertyContentName;
        public string PropertyContentName
        {
            set { propertyContentName = value; }
            get { return propertyContentName; }
        }
       /// <summary>
        /// 得到属性名字与属性内容
       /// </summary>
       /// <param name="lPropertyID">属性ID</param>
       /// <returns></returns>
       public  List<PropertyNameandContent> GetPropertyAll(List<Property> lPropertyID)
       {
           List<PropertyNameandContent> mPropertyList = new List<PropertyNameandContent>();
           //string SqlString2 = "select PropertyContentName from PropertyContent where PropertyID='" + lPropertyID + "'";
           int i=0;
           while(i<lPropertyID.Count)
           {
               string mPropertyID = lPropertyID[i].PropertyID.ToString();
               string SqlString1 = "select distinct PropertyName,PropertyContentName from Property left join PropertyContent on Property.PropertyID=PropertyContent.PropertyID  where Property.PropertyID='" + mPropertyID + "'";
               SqlHelper.ReadDateReadBegin(SqlString1);
               while(SqlHelper.SqlReader.Read())
              {
               PropertyNameandContent mProNaandCon = new PropertyNameandContent();
               mProNaandCon.PropertyName = SqlHelper.SqlReader["PropertyName"].ToString();
               mProNaandCon.propertyContentName=SqlHelper.SqlReader["PropertyContentName"].ToString();
               mPropertyList.Add(mProNaandCon);
              }
               i++;
               SqlHelper.ReadDateReadEnd();
           }
           return mPropertyList;
       }
    }
}
