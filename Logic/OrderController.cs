/* 
 * 1 功能描述：

 *     订单实体类函数； 
 * 2 作者：
 *     李霏
 * 3 创建时间：

 *     2012-08-07-19-08；

 * 4 完成时间：

 *   
 * 5 修改记录：

 *     暂无（修改时间、内容、人）；
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace Logic
{
    public class OrderController
    {
        /// <summary>
        /// 新建订单
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <returns>是否创建订单成功</returns>
        public bool CreateOrder(Order order,int addressNumber)
        {
            return order.CreateOrder(addressNumber);
        }
        /// <summary>
        /// 单个商品信息
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <param name="goodID">GoodID</param>
        /// <returns>单个商品信息</returns>
        public List<Good> Goodinfo(Order order, int goodID)
        {
            return order.GoodInfo(goodID);
        }
        /// <summary>
        /// 单个商品图片名称
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <param name="goodID">GoodID</param>
        /// <returns>单个商品图片名称</returns>
        public List<ImgInfo> GoodTitle(Order order, int goodID)
        {
            return order.Goodtile(goodID);
        }
        public DataTable OrderExam(Order order)
        {
            return order.OrderExam();
        }
    }
}
