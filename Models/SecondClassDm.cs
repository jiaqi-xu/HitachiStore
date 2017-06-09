/*
 * 1 功能描述：
 *   二级类目类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-07-15-03；
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
    /// 二级类目类
    /// </summary>
    public class SecondClassDm 
    {
        /// <summary>
        /// 二级类目ID
        /// </summary>
        private string secondClassDmID;
        public string SecondClassDmID
        {
            set { secondClassDmID = value; }
            get { return secondClassDmID;}
        }
        /// <summary>
        /// 对应一级类目ID
        /// </summary>
        private string firstClassDmID;
        public string FirstClassDmID
        {
            set { firstClassDmID = value; }
            get { return firstClassDmID; }
        }
        /// <summary>
        /// 二级类目名称
        /// </summary>
        private string secondClassDmName;
        public string SecondClassDmName
        {
            set { secondClassDmName = value; }
            get { return secondClassDmName; }
        }
        /// <summary>
        /// 一级类目名称取二级类目名称
        /// </summary>
        /// <returns>一个对象表</returns>
        public static List<SecondClassDm> Getlist(string str)
        {
            List<SecondClassDm> SecondClumlist = new List<SecondClassDm>();
            string Sqlstring = "select * from SecondClassDm where FirstClassDmID='"+str+"'";
            SqlHelper.ReadDateReadBegin(Sqlstring);
            while (SqlHelper.SqlReader.Read())
            {

                SecondClassDm secondclassdm = new SecondClassDm();
                secondclassdm.SecondClassDmName = SqlHelper.SqlReader["SecondClassDmName"].ToString();
                secondclassdm.SecondClassDmID = SqlHelper.SqlReader["SecondClassDmID"].ToString();
                SecondClumlist.Add(secondclassdm);
            }
            SqlHelper.ReadDateReadEnd();
            return SecondClumlist;
        }
        /// <summary>
        /// 获取二级类目名称
        /// </summary>
        /// <returns>一个对象表</returns>
        public static List<SecondClassDm> Getlist()
        {
            List<SecondClassDm> SecondClumlist = new List<SecondClassDm>();
            string Sqlstring = "select * from SecondClassDm ";
            SqlHelper.ReadDateReadBegin(Sqlstring);
            while (SqlHelper.SqlReader.Read())
            {

                SecondClassDm secondclassdm = new SecondClassDm();
                secondclassdm.SecondClassDmName = SqlHelper.SqlReader["SecondClassDmName"].ToString();
                secondclassdm.SecondClassDmID = SqlHelper.SqlReader["SecondClassDmID"].ToString();
                SecondClumlist.Add(secondclassdm);
            }
            SqlHelper.ReadDateReadEnd();
            return SecondClumlist;
        }
        /// <summary>
        /// 由二级类目名称获取二级类目ID进而获取三级类目名称
        /// </summary>
        /// <param name="thirdclassdm">三级类目对象</param>
        /// <param name="secondclassdm">二级类目对象</param>
        /// <returns>三级类目表</returns>
        public static List<ThirdClassDm> FcShowContent(ThirdClassDm thirdclassdm, SecondClassDm secondclassdm)
        {
            string Sqlstring = "select SecondClassDmID from SecondClassDm where SecondClassDmName=N'" + secondclassdm.SecondClassDmName + "'";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            string str = (string)obj;
            List<ThirdClassDm> thirdClumList = new List<ThirdClassDm>();
            thirdClumList = ThirdClassDm.Getlist(str);
            return thirdClumList;
        }
        /// <summary>
        /// 判断输入的二级类目名是否存在
        /// </summary>
        /// <returns>不存在返回true</returns>
        public bool SelectSecondClass()
        {
            string SqlString = "select SecondClassDmName from SecondClassDm where SecondClassDmName=N'"+this.SecondClassDmName+"'";
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
        /// 改变二级类目名
        /// </summary>
        /// <param name="mSecondClassDmName">二级类目名称</param>
        /// <returns>成功或失败</returns>
        public bool UpdateSecondClass(string mSecondClassDmName)
        {
            string SqlString = "update SecondClassDm set SecondClassDmName=N'"+mSecondClassDmName+"' where SecondClassDmName=N'"+this.SecondClassDmName+"'";
            if (SqlHelper.ExecuteNonQuery(SqlString) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 选出服装城的二级类目
        /// </summary>
        /// <returns>返回服装城的二级类目名</returns>
        public List<SecondClassDm> GetSecondClothes()
        {
            List<SecondClassDm> mSecondNameList=new List<SecondClassDm>();
            string SqlString = "select SecondClassDmName from SecondClassDm where FirstClassDmID='003'";
            SqlHelper.ReadDateReadBegin(SqlString);
            while (SqlHelper.SqlReader.Read())
            {
                SecondClassDm mSecondClassDm = new SecondClassDm();
                mSecondClassDm.SecondClassDmName = SqlHelper.SqlReader["SecondClassDmName"].ToString();
                mSecondNameList.Add(mSecondClassDm);
            }
            SqlHelper.ReadDateReadEnd();
            return mSecondNameList;

        }
    }
}
