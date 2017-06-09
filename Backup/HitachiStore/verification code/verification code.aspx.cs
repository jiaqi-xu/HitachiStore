using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace HitachiStore.verification_code
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateImage(getValidate(4));
        }
        private string getValidate(int count)
        {
            string strchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,g,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            string[] VcArray = strchar.Split(',');
            string VNum = "";
            //记录上次的随机数，尽量避免产生几个相同的随机数

            int temp = -1;
            //采用一个简单的算法
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);
                if (temp == t)
                {
                    return getValidate(count);
                }
                temp = t;
                VNum += VcArray[t];
            }
            Session["Valid"] = VNum;
            return VNum;
        }
        private void CreateImage(string validateCode)
        {

            //图像的宽度，与验证码的的长度成一定比例

            int iwidth = (int)(validateCode.Length * 11.5);
            //创建一个长20，款iwidth的图像对象

            Bitmap image = new Bitmap(iwidth, 20);
            //创建一个新绘图对象
            Graphics a = Graphics.FromImage(image);
            //绘画用的字体和字号

            Font f = new Font("Arial", 10, FontStyle.Bold);
            //绘画用的刷子大小
            SolidBrush b = new SolidBrush(Color.White);
            //清除背景色，并用橄榄绿色填充
            a.Clear(Color.DarkGreen);
            //格式化刷子属性，用指定的刷子颜色等在指定的范围内画图
            a.DrawString(validateCode, f, b, 3, 3);
            //创建铅笔对象
            Pen pen = new Pen(Color.Black, 0);
            //创建随即对象
            Random rand = new Random();
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    int y = rand.Next(image.Height);
                    //用指定的铅笔画线，粗细有参数决定
                    a.DrawLine(pen, 0, y, image.Width, y);
                }
                //输出绘图
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //将图像保存到指定的流
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Response.ClearContent();
                //配置输出类型
                Response.ContentType = "image/Jpeg";
                //输入内容
                Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                //清空不需要的资源
                a.Dispose();
                image.Dispose();
            }
        }
    }
}