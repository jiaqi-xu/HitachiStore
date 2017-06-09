/*
 * 1 功能描述：
 *   图片信息类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-15-09-15；
 * 4 完成时间：
 *   2012-08-16-21-51;
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
    /// 图片信息类
    /// </summary>
    public class ImgInfo
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
        /// 图片ID
        /// </summary>
        private int imgID;
        public int ImgID
        {
            set { imgID = value; }
            get { return imgID; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        private string imgAddress;
        public string ImgAddress
        {
            set { imgAddress = value; }
            get { return imgAddress; }
        }
        /// <summary>
        /// 商品的标题
        /// </summary>
        private string imgTitle;
        public string ImgTitle
        {
            set { imgTitle = value; }
            get { return imgTitle; }

        }
        /// <summary>
        /// 属性
        /// </summary>
        private string Property;
        public string property
        {
            set { Property = value; }
            get { return Property; }
        }
        /// <summary>
        /// 由商品图片ID获取商品ID
        /// </summary>
        /// <param name="imginfo">商品图片信息对象</param>
        /// <returns>商品ID</returns>
        public static int ImgIDGetGoodID(ImgInfo imginfo)
        {
            string sqlstring = "select GoodID from ImgInfo where ImgID='" + imginfo.ImgID + "' ";
            Object obj = SqlHelper.ReadSclar(sqlstring);
            int TempGoodID = Convert.ToInt32(obj);
            return TempGoodID;
        }
        /// <summary>
        /// 商品ID获取商品图片ID
        /// </summary>
        /// <param name="imginfo">商品图片信息对象</param>
        /// <returns>商品图片ID</returns>
        public static int GoodIDGetImgID(ImgInfo imginfo)
        {
            string sqlstring = "select ImgID from ImgInfo where GoodID='" + imginfo.GoodID + "'";
            Object obj = SqlHelper.ReadSclar(sqlstring);
            int TempImgID = Convert.ToInt32(obj);
            return TempImgID;
        }
        /// <summary>
        /// 使用商品图片地址获取商品ID
        /// </summary>
        /// <param name="imginfo">商品图片信息对象</param>
        /// <returns>商品ID</returns>
        public static int ImgAddressGetGoodID(ImgInfo imginfo)
        {
            string sqlstring = "select GoodID from ImgInfo where ImgAddress= N'" + imginfo.ImgAddress + "'";
            Object obj = SqlHelper.ReadSclar(sqlstring);
            int TempGoodID = Convert.ToInt32(obj);
            return TempGoodID;
        }
        /// <summary>
        /// 由商品表单获取图片信息表单
        /// </summary>
        /// <param name="goodList">商品表</param>
        /// <returns>图片信息表单</returns>
        public static List<ImgInfo> GoodIDGetImgInfo(List<Good> goodList)
        {
            Select Stringcut = new Select();
            List<ImgInfo> lImgInfo = new List<ImgInfo>();
            for (int i = 0; i < goodList.Count; i++)
            {
                string lSqlstring = "select ImgTitle,ImgAddress,GoodPrice  from Good left join Imginfo on Imginfo.GoodID=Good.GoodID where Imginfo.GoodID='" + goodList[i].GoodID + "'";
                SqlHelper.ReadDateReadBegin(lSqlstring);
                while (SqlHelper.SqlReader.Read())
                {
                    ImgInfo Imginfo = new ImgInfo();
                    Imginfo.ImgTitle = Stringcut.CutString(SqlHelper.SqlReader["ImgTitle"].ToString(),10);
                    Imginfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                    Imginfo.Property = SqlHelper.SqlReader["GoodPrice"].ToString();
                    lImgInfo.Add(Imginfo);
                }
                SqlHelper.ReadDateReadEnd();
            }
            return lImgInfo;
        }

        /// <summary>
        /// 得到服装城宣传图片
        /// </summary>
        /// <returns></returns>
        public List<ImgInfo> GetBigImgAddress()
        {
            List<ImgInfo> mBigImgAddress = new List<ImgInfo>();

            string SqlString = "select  ImgAddress from ImgInfo where ImgAddress=N'~/GoodImg/服装城1.png'";
            SqlHelper.ReadDateReadBegin(SqlString);
            while (SqlHelper.SqlReader.Read())
            {
                ImgInfo mImgInfo = new ImgInfo();
                mImgInfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString().Replace("~/", "../../");
                mBigImgAddress.Add(mImgInfo);
            }
            SqlHelper.ReadDateReadEnd();
            return mBigImgAddress;
        }
        /// <summary>
        /// 家具城
        /// </summary>
        /// <param name="goodList">家具城goodid</param>
        /// <returns>家具城信息</returns>
        public static List<ImgInfo> FurnitureCity()
        {
            Select Stringcut = new Select();
            List<ImgInfo> lImgInfo = new List<ImgInfo>();
            string lSqlstring = "select ImgTitle,ImgAddress,GoodPrice  from FurnitureCityProductShow left join Good on  FurnitureCityProductShow.GoodID=Good.GoodID";
            SqlHelper.ReadDateReadBegin(lSqlstring);
            while (SqlHelper.SqlReader.Read())
            {
                ImgInfo Imginfo = new ImgInfo();
                Imginfo.ImgTitle = Stringcut.CutString(SqlHelper.SqlReader["ImgTitle"].ToString(),30);
                Imginfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                Imginfo.Property = SqlHelper.SqlReader["GoodPrice"].ToString();
                lImgInfo.Add(Imginfo);
            }
            SqlHelper.ReadDateReadEnd();
            return lImgInfo;
        }
        /// <summary>
        /// 电器城商品展示
        /// </summary>
        /// <param name="goodList">商品信息</param>
        /// <returns>商品信息</returns>
        public static List<ImgInfo> CircuitCity()
        {
            Select Stringcut = new Select();
            List<ImgInfo> lImgInfo = new List<ImgInfo>();
            string lSqlstring = "select ImgTitle,ImgAddress,GoodPrice from CircuitCityProductShow left join Good on CircuitCityProductShow.GoodID=Good.GoodID ";
            SqlHelper.ReadDateReadBegin(lSqlstring);
            while (SqlHelper.SqlReader.Read())
            {
                ImgInfo Imginfo = new ImgInfo();
                Imginfo.ImgTitle = Stringcut.CutString(SqlHelper.SqlReader["ImgTitle"].ToString(),30);
                Imginfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                Imginfo.Property = SqlHelper.SqlReader["GoodPrice"].ToString();
                lImgInfo.Add(Imginfo);
            }
            SqlHelper.ReadDateReadEnd();
            return lImgInfo;
        }
        /// <summary>
        /// 主页商品展示
        /// </summary>
        /// <param name="goodList"></param>
        /// <returns></returns>
        public static List<ImgInfo> HomePageProductShow()
        {
            Select Stringcut = new Select();
            List<ImgInfo> lImgInfo = new List<ImgInfo>();
            string lSqlstring = "select ImgTitle,ImgAddress,GoodPrice from HomePageProductShow left join Good on HomePageProductShow.GoodID=Good.GoodID";
            SqlHelper.ReadDateReadBegin(lSqlstring);
            while (SqlHelper.SqlReader.Read())
            {
                ImgInfo Imginfo = new ImgInfo();
                Imginfo.ImgTitle = Stringcut.CutString(SqlHelper.SqlReader["ImgTitle"].ToString(),30);
                Imginfo.ImgAddress = SqlHelper.SqlReader["ImgAddress"].ToString();
                Imginfo.Property = SqlHelper.SqlReader["GoodPrice"].ToString();
                lImgInfo.Add(Imginfo);
            }
            SqlHelper.ReadDateReadEnd();
            return lImgInfo;
        }
    }
}
