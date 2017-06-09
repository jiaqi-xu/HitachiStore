using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;


namespace Logic
{
  public  class EvaluateController
    {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="mGoodEvaluate"></param>
      /// <returns></returns>
        public bool CreateGoodEvaluate(GoodEvaluate mGoodEvaluate)
        {
            return mGoodEvaluate.SubmitGoodEvaluate(); 
        }
      /// <summary>
      /// 商品评价
      /// </summary>
      /// <param name="mEvaluate">商品评价对象</param>
      /// <returns>是否评价成功</returns>
        public bool Evaluat(GoodEvaluate mEvaluate)
        {
            return mEvaluate.OrderEvaluate();
        }
    }
}
