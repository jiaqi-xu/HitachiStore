using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLHelper
{
    public class DataSource
    {
        #region 数据连接字符

        //DataBase Name.
        public static string DataBaseName = "HitachiStore";

        //User Name.
        public static string UserName ="sa";
        //PassWord.
        public static string PassWord ="123854340";

        //HostAddress.
        public static string HostAddress = ".";


        //整合后的链接字符串.
        public static string ConnectStr = "server =" + HostAddress + ";database=" + DataBaseName +
                ";uid=" + UserName + ";pwd=" + PassWord;    //连接字符串.;

        #endregion
    }
}
