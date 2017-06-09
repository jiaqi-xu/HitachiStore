/*
 * 1 功能描述:商城大图片类
 * 
 * 2 作者：王晶晶
 * 
 * 3 创建时间：2012/9/8
 * 
 * 4 完成时间
 * 
 * 5 修改记录
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;

namespace Models
{
    public class BigImg
    {
        /// <summary>
        /// 添加时间
        /// </summary>
        private  string addTime;
        public string AddTime
        {
            set { addTime = value; }
            get { return addTime; }
        }
        /// <summary>
        /// 大图片所属商城
        /// </summary>
        private string bigImgType;
        public string BigImgType
        {
            set { bigImgType = value; }
            get { return bigImgType; }
        }
        /// <summary>
        /// 大图片路径
        /// </summary>
        private string imgUrl;
        public string ImgUrl
        {
            set { imgUrl = value; }
            get { return imgUrl; }
        }
        /// <summary>
        /// 大图片说明
        /// </summary>
        private string state;
        public string State
        {
            set { state = value; }
            get { return state; }
        }
        /// <summary>
        /// 向数据库中加入新的数据
        /// </summary>
        /// <returns></returns>
        public  bool InsertBigImg()
        {
            string sqlString = "insert into BigImg values('"+this.AddTime+"',N'"+this.BigImgType+"',N'"+this.ImgUrl+"')";
            if(SqlHelper.ExecuteNonQuery(sqlString)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 选出ImgUrl
        /// </summary>
        /// <returns></returns>
        public string SelectBigImgUrl(string CityType)
        {
            string sqlString = "select top 1 ImgUrl from BigImg  where BigImgType=N'" + CityType + "' order by AddTime desc";
            return SqlHelper.ReadSclar(sqlString).ToString();
        }
        /// <summary>
        /// 选出首页ImgUrl
        /// </summary>
        /// <returns></returns>
        public string[] SelectFirstBigImg()
        {
            string[] mBigImg=new string[5];
            string sqlString = "select top 5 ImgUrl from BigImg  where BigImgType=N'首页' order by AddTime desc";
            SqlHelper.ReadDateReadBegin(sqlString);
            int i = 0;
            while(SqlHelper.SqlReader.Read())
            {
                mBigImg[i] = SqlHelper.SqlReader[0].ToString();
                //mBigImg[1] = SqlHelper.SqlReader[1].ToString();
                //mBigImg[2] = SqlHelper.SqlReader[2].ToString();
                //mBigImg[3] = SqlHelper.SqlReader[3].ToString();
                //mBigImg[4] = SqlHelper.SqlReader[4].ToString();
                i++;
            }
            SqlHelper.ReadDateReadEnd();
            return mBigImg;
        }
    }
}
