/*
 * 1 功能描述：
 *   一级类目类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-07-10-05；
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
    /// 一级类目类
    /// </summary>
    public class FirstClassDm
    {
        /// <summary>
        /// 商品一级类目ID
        /// </summary>
        private string firstClassDmID;
        public string FirstClassDmID
        {
            set { firstClassDmID = value; }
            get { return firstClassDmID; }
        }
        /// <summary>
        /// 商品一级类目名称
        /// </summary>
        private string firstClassDmName;
        public string FirstClassDmName
        {
            set { firstClassDmName = value; }
            get { return firstClassDmName; }
        }
        /// <summary>
        /// 获取一级类目名称
        /// </summary>
        /// <returns>一个对象表</returns>
        public static List<FirstClassDm> Getlist()
        {
            List<FirstClassDm> lUserlist = new List<FirstClassDm>();
            string Sqlstring = "select * from FirstClassDm";
            SqlHelper.ReadDateReadBegin(Sqlstring);
            while (SqlHelper.SqlReader.Read())
            {

                FirstClassDm firstclum = new FirstClassDm();
                firstclum.FirstClassDmName = SqlHelper.SqlReader["FirstClassDmName"].ToString();
                firstclum.FirstClassDmID = SqlHelper.SqlReader["FirstClassDmID"].ToString();
                lUserlist.Add(firstclum);
            }
            SqlHelper.ReadDateReadEnd();
            return lUserlist;
        }
        /// <summary>
        /// 通过一级类目名称搜索二级类目名称
        /// </summary>
        /// <param name="firstclassdm">一级类目对象</param>
        /// <param name="secondclassdm">二级类目对象</param>
        /// <returns>二级类目名称表</returns>
        public static List<SecondClassDm> FcShowContent(FirstClassDm firstclassdm, SecondClassDm secondclassdm)
        {
            string Sqlstring = "select FirstClassDmID from FirstClassDm where FirstClassDmName=N'" + firstclassdm.FirstClassDmName + "'";
            Object obj = SqlHelper.ReadSclar(Sqlstring);
            string str = (string)obj;
            List<SecondClassDm> secondCluList = new List<SecondClassDm>();
            secondCluList = SecondClassDm.Getlist(str);
            return secondCluList;
        }
        /// <summary>
        /// 一级类目名字获取二级类目名字
        /// </summary>
        /// <param name="firstclassdm">一级类目对象</param>
        /// <returns>二级类目名字表</returns>
        public static List<SecondClassDm> FcNameGetScName(FirstClassDm firstclassdm)
        {
            List<SecondClassDm> Sclist = new List<SecondClassDm>();
            string sqlstring = "select SecondClassDmName from SecondClassDm where FirstClassDmID=(select FirstClassDmID from FirstClassDm where FirstClassDmName=N'" + firstclassdm .FirstClassDmName+ "')";
            SqlHelper.ReadDateReadBegin(sqlstring);
            while (SqlHelper.SqlReader.Read())
            {
                SecondClassDm secondclassdm = new SecondClassDm();
                secondclassdm.SecondClassDmName = SqlHelper.SqlReader["SecondClassDmName"].ToString();
                Sclist.Add(secondclassdm);
            }
            SqlHelper.ReadDateReadEnd();
            return Sclist;
        }
        /// <summary>
        /// 更改一级类目名
        /// </summary>
        /// <param name="mFirstClassDmName"></param>
        /// <returns>更改成功返回true</returns>
        public bool UpdateFirstClass(string mFirstClassDmName)
        {
            string SqlString = "Update FirstClassDm set FirstClassDmName=N'"+mFirstClassDmName+"' where FirstClassDmName=N'"+this.FirstClassDmName+"'";
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
