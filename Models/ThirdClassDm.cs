/*
 * 1 功能描述：
 *   三级级类目类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-07-19-18；
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
    /// 三级类目类
    /// </summary>
    public class ThirdClassDm
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
        /// 三级类目名称
        /// </summary>
        private string thirdClassDmName;
        public string ThirdClassDmName
        {
            set { thirdClassDmName = value; }
            get { return thirdClassDmName; }
        }
        /// <summary>
        /// 对应二级类目的ID
        /// </summary>
        private string secondClassDmID;
        public string SecondClassDmID
        {
            set { secondClassDmID = value; }
            get { return secondClassDmID; }
        }
        /// <summary>
        /// 由二级类目ID获取三级类目的字段
        /// </summary>
        /// <param name="str">传入的二级类目ID</param>
        /// <returns>三级类目表</returns>
        public static List<ThirdClassDm> Getlist(string str)
        {
            List<ThirdClassDm> ThirdClumList = new List<ThirdClassDm>();
            string Sqlstring = "select * from ThirdClassDm where SecondClassDmID='" + str + "'";
            SqlHelper.ReadDateReadBegin(Sqlstring);
            while (SqlHelper.SqlReader.Read())
            {

                ThirdClassDm thirdclassdm = new ThirdClassDm();
                thirdclassdm.ThirdClassDmName = SqlHelper.SqlReader["ThirdClassDmName"].ToString();
                thirdclassdm.ThirdClassDmID = SqlHelper.SqlReader["ThirdClassDmID"].ToString();
                ThirdClumList.Add(thirdclassdm);
            }
            SqlHelper.ReadDateReadEnd();
            return ThirdClumList;
        }
        /// <summary>
        /// 判断输入的三级类目是否存在
        /// </summary>
        /// <returns>不存在返回true</returns>
        public bool SelectThirdClass()
        {
            string SqlString = "select ThirdClassDmName from ThirdClassDm where ThirdClassDmName=N'"+this.ThirdClassDmID+"'";
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
        /// 改变三级类目名
        /// </summary>
        /// <param name="mThirdClassDmName"></param>
        /// <returns>改变成功返回true</returns>
        public bool UpdateThirdClass(String mThirdClassDmName)
        {
            string SqlString = "Update ThirdClassDm set ThirdClassDmName=N'"+mThirdClassDmName+"' where ThirdClassDmName=N'"+this.ThirdClassDmName+"'";
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
        /// 根据三级类目的名字得到三级类目的ID
        /// </summary>
        /// <param name="lThirdClassName"></param>
        /// <returns></returns>
        public string GetThirdClassDmId(String lThirdClassName)
        {
            string SqlString = "select ThirdClassDmID from ThirdClassDm where ThirdClassDmName=N'"+lThirdClassName+"'";
            return SqlHelper.ReadSclar(SqlString).ToString();
        }
        
    }

}
