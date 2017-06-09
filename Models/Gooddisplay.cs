/*
 * 1 功能描述：
 *   商品管理员类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-15-09-06；
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
using Models;

namespace Models
{
    /// <summary>
    /// 商品展示类
    /// </summary>
    public class Gooddisplay
    {
        public static List<ImgInfo> GetImgAdress(ImgInfo imgInfo)
        {
            List<ImgInfo> adressList = new List<ImgInfo>();
            string sqlString = "select * from ImgInfo where GoodID='" + imgInfo.GoodID + "'";
            SqlHelper.ReadDateReadBegin(sqlString);
            while (SqlHelper.SqlReader.Read())
            {
                ImgInfo imginfo = new ImgInfo();
                imginfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                imginfo.ImgTitle = SqlHelper.SqlReader["ImgTitle"].ToString();
                adressList.Add(imginfo);
            }
            SqlHelper.ReadDateReadEnd();
            return adressList;
            
        }
        /// <summary>
        /// 电器城左侧二级类目
        /// </summary>
        /// <returns>二级类目</returns>
        public List<SecondClassDm> SecondclassDm(string firstClassID)
        {
            List<SecondClassDm> lSecondClassDm = new List<SecondClassDm>();
            string lSelectSecClass = "select SecondClassDmName from SecondClassDm where FirstClassDmID='" + firstClassID + "'";
            SqlHelper.ReadDateReadBegin(lSelectSecClass);
            while (SqlHelper.SqlReader.Read())
            {
                SecondClassDm SecondClass = new SecondClassDm();
                SecondClass.SecondClassDmName = SqlHelper.SqlReader["SecondClassDmName"].ToString();
                lSecondClassDm.Add(SecondClass);
            }
            SqlHelper.ReadDateReadEnd();
            return lSecondClassDm;
        }
    }
}
