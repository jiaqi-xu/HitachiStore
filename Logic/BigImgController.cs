/*
 * 1 功能描述: 商城大图片方法类
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
using Models;

namespace Logic
{
    public class BigImgController
    {
        /// <summary>
        /// 向数据库中添加大图片信息
        /// </summary>
        /// <returns></returns>
        public bool AddBigImg(BigImg lBigImg)
        {
            return lBigImg.InsertBigImg();
        }
        /// <summary>
        /// 得到ImgUrl
        /// </summary>
        /// <param name="lBigImg"></param>
        /// <returns></returns>
        public string GetImgUrl(BigImg lBigImg,string mCityType)
        {
            return lBigImg.SelectBigImgUrl(mCityType);
        }
        /// <summary>
        /// 得到首页5个ImgUrl
        /// </summary>
        /// <param name="lBigImg"></param>
        /// <returns></returns>
        public string[] GetFirstBigImg(BigImg lBigImg)
        {
            return lBigImg.SelectFirstBigImg();
        }
    }
}
