using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SQLHelper
{
    public class MyCommand
    {
         #region 私有信息
        SqlConnection Connection = null;
        SqlCommand command = null;
        public SqlCommand lCommand
        {
            set { command = value; }
            get { return command; }
        }
        public SqlDataReader SqlReader=null;
        
        public MyCommand()
        { 
            Connection=new SqlConnection(DataSource.ConnectStr);
            lCommand=new SqlCommand();
            lCommand.Connection = Connection;
            lCommand.CommandType = CommandType.Text;
        }
        public void open()
        {
            Connection.Open();
        }
        public void close()
        {
            Connection.Close();
        }
        #endregion
    }
}
