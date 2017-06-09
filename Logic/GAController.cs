/*
 * 1 功能描述：
 *   商品管理员函数类；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-06-10-28；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Logic
{
    public class GAController
    {
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="GAdmin">商品管理员类</param>
        /// <returns>一个对象</returns>
        public void  GAGetinfo(GA GAdmin)
        {
             GAdmin.Getinfo();
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="GAdmin">商品管理员对象</param>
        /// <returns>收到影响的行数</returns>
        public int GAAlterinfo(GA GAdmin)
        {
            return GAdmin.Alterinfo();
        }
        /// <summary>
        /// 删除一级类目
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteFirstClass(GA Gadmin,FirstClassDm first)
        {
            return Gadmin.DeleteFirstclassdm(first);
        }
        /// <summary>
        /// 删除二级类目
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteSecondClass(GA Gadmin,SecondClassDm second)
        {
            return Gadmin.DeleteSecondclassdm(second);
        }
        /// <summary>
        /// 删除三级类目
        /// </summary>
        /// <param name="Gadim">商品管理员对象</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteThirdClass(GA Gadim,ThirdClassDm third)
        {
            return Gadim.DeleteThirddm(third);
        }
        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="Gadim">商品管理员</param>
        /// <param name="a">属性ID</param>
        /// <returns>是否删除成功</returns>
        public bool DeletePrperty(GA Gadmin, string a)
        {
            return Gadmin.DeleteProperty(a);
        }
        /// <summary>
        /// 删除属性内容
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <param name="a">属性ID</param>
        /// <returns>是否删除成功</returns>
        public bool DeletePropertycon(GA Gadmin, string a)
        {
            return Gadmin.DeletePropertycon(a);
        }
        /// <summary>
        /// 商品查看
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <param name="thirdClassID">三级类目ID</param>
        /// <returns>商品信息</returns>
        public List<Good> GoodExam(GA Gadmin,string thirdClassID)
        {
            return Gadmin.GoodExaminfo(thirdClassID);
        }
        /// <summary>
        /// 商品查看商品详细信息
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <param name="goodID">GoodID</param>
        /// <returns>商品向信息</returns>
        public List<Good> GoodInfo(GA Gadmin, string goodID)
        {
            return Gadmin.Goodinfo(goodID);
        }
        /// <summary>
        /// 商品查看商品图片详细信息
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <param name="goodID">GoodID</param>
        /// <returns>商品图片详细信息</returns>
        public List<ImgInfo> GoodPictureInfo(GA Gadmin, string goodID)
        {
            return Gadmin.GoodExam(goodID);
        }
        /// <summary>
        /// 商品查看商品信息修改
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <param name="goodInfo">商品图片对象</param>
        /// <param name="goodinfo">商品对象</param>
        /// <returns>是否修改成功</returns>
        public bool UpdateGoodinfo(GA Gadmin, ImgInfo goodInfo, Good goodinfo)
        {
            return Gadmin.UpdateGoodinfo(goodInfo, goodinfo);
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <param name="thirdID">三级类目ID</param>
        /// <param name="page">页数</param>
        /// <returns>下一页信息</returns>
        public List<Good>Nextpage(GA Gadmin,string thirdID,int page)
        {
            return Gadmin.NextPage(thirdID,page);
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <param name="thirdID">三级类目ID</param>
        /// <param name="page">页数</param>
        /// <returns>上一页信息</returns>
        public List<Good> Uppage(GA Gadmin, string thirdID, int page)
        {
            return Gadmin.Uppage(thirdID, page);
        }
        /// <summary>
        ///商品查看总页数
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <param name="thirdID">三级类目ID</param>
        /// <returns>够有多少条记录</returns>
        public int PageCount(GA Gadmin, string thirdID)
        {
            return Gadmin.PageCount(thirdID);
        }
        /// <summary>
        /// 商品管理员对家具城的界面管理
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <param name="firstClassID">一级类目ID</param>
        /// <returns>商品信息</returns>
        public List<ImgInfo> Furniture(GA Gadmin, string firstClassID)
        {
            return Gadmin.Furniture(firstClassID);
        }
        /// <summary>
        /// 商品管理员对家具城的界面管理信息总条数
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <param name="firstClassID">一级类目ID</param>
        /// <returns>信息总条数</returns>
        public int Count(GA Gadmin, string firstClassID)
        {
            return Gadmin.Count(firstClassID);
        }
        /// <summary>
        /// 管理员商品摆放下一页
        /// </summary>
        /// <param name="Gadmin">管理员对象</param>
        /// <param name="firstClassID">一级类目ID</param>
        /// <param name="ccurrentPage">当前页数</param>
        /// <returns>信息</returns>
        public List<ImgInfo> NextPage(GA Gadmin, string firstClassID,int ccurrentPage)
        {
            return Gadmin.Nextpage(firstClassID, ccurrentPage);
        }
        /// <summary>
        /// 修改前台页面是否成功
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <param name="goodID">需要修改的GoodID</param>
        /// <returns>是否成功</returns>
        public bool UpdateInterface(GA Gadmin, string[] goodID,int choose)
        {
           return  Gadmin.UpdateInterface(goodID,choose);
        }
        /// <summary>
        /// 首页商品展示更换商品
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <returns>商品信息</returns>
        public List<ImgInfo> HomePage(GA Gadmin)
        {
            return Gadmin.HomePage();
        }
        /// <summary>
        /// 商品管理员对首页的界面管理信息总条数
        /// </summary>
        /// <param name="Gadmin">商品管理员对象</param>
        /// <returns>信息总条数</returns>
        public int HomeCount(GA Gadmin)
        {
            return Gadmin.HomeCount();
        }
        /// <summary>
        /// 管理员商品摆放下一页
        /// </summary>
        /// <param name="Gadmin">管理员对象</param>
        /// <param name="ccurrentPage">当前页数</param>
        /// <returns>信息</returns>
        public List<ImgInfo> HomeNextPage(GA Gadmin,int ccurrentPage)
        {
            return Gadmin.HomeNextpage(ccurrentPage);
        }
        /// <summary>
        /// 修改单个商品展示
        /// </summary>
        /// <param name="Gadmin">管理员对象</param>
        /// <returns>商品信息</returns>
        public List<ImgInfo> UpdatePictureShow(GA Gadmin,int choose)
        {
            return Gadmin.UpdatePictureShow(choose);
        }
        public bool UpdateProductShow(GA Gadmin, int choose, string url, string goodID)
        {
            return Gadmin.updateProductShow(choose, goodID, url);
        }
    }
}
