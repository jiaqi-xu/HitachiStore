using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Logic
{
   public  class OAController
    {
       /// <summary>
       /// 查看订单管理员信息
       /// </summary>
       /// <param name="OAdmin"></param>
       /// <returns></returns>
       public OA  ReadOAInfo(OA OAdmin)
       {
           return OAdmin.OAInfoRead();
       }
       /// <summary>
       /// 修改订单管理员信息
       /// </summary>
       /// <param name="mAlter"></param>
       /// <returns></returns>
       public bool AlterInfo(OA mAlter)
       {
           return mAlter.AlterOAInfo();
       }
       /// <summary>
       /// 查询订单
       /// </summary>
       /// <param name="mOrder"></param>
       /// <param name="order"></param>
       /// <returns></returns>
       public string []  SearchOrder(OA mOrder,SaveOrders  order)
       {
           return mOrder .OrderInfoRead (order);
       }
       /// <summary>
       /// 验证订单号
       /// </summary>
       /// <param name="mExam"></param>
       /// <param name="dOrder"></param>
       /// <returns></returns>
       public bool OrderExamController(OA mExam,SaveOrders dOrder)
       {
           return mExam.OrderExam(dOrder );
       }
       /// <summary>
       /// 订单状态修改
       /// </summary>
       /// <param name="m"></param>
       /// <param name="mStatus"></param>
       /// <returns></returns>
       public bool TradeStatus(OA m, SaveOrders mStatus)
       {
           return m.AlterOrderStatus(mStatus);
       }
       /// <summary>
       /// 获取订单状态时间
       /// </summary>
       /// <param name="hOA"></param>
       /// <param name="Get"></param>
       /// <returns></returns>
       public bool GetTimeCon(OA hOA, SaveOrders Get)
       {
           return hOA.GetTradeTime(Get);
       }
       /// <summary>
       /// 修改处理订单管理员ID
       /// </summary>
       /// <param name="mOa"></param>
       /// <param name="hS"></param>
       /// <returns></returns>
       //public bool AlterStaffIDCon(OA mOa,SaveOrders hS)
       //{
       //    return mOa.AlterStaffID(hS);
       //}
    }
}
