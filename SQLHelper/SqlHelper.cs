using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SQLHelper
{
    public class SqlHelper
    {
        public static SqlDataReader SqlReader = null;
        public static MyCommand mCommand = new MyCommand();
        #region 公有方法
        /// <summary>
        /// 获取该SqlDataReader对象包含查询结果集及结果集行数等信息具体
        /// </summary>
        /// <param name="Sqlstring">sql语句</param>
        /// <returns></returns>
        public static void ReadDateReadBegin(string Sqlstring)
        {
            try
            {
                if (mCommand.lCommand.Connection.State != ConnectionState.Open)
                {
                    mCommand.open();
                }
                mCommand.lCommand.CommandText = Sqlstring;
                SqlReader = mCommand.lCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ReadDateReadEnd()
        {
            try
            {
                if (mCommand.lCommand.Connection.State == ConnectionState.Open)
                {
                    mCommand.close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mCommand.close();
            }
        }
        /// <summary>
        /// 执行查询语句返回首行适用于查询单条语句
        /// </summary>
        /// <param name="Sqlstring"></param>
        /// <returns></returns>
        public static object ReadSclar(string Sqlstring)
        {
            try
            {
                if (mCommand.lCommand.Connection.State != ConnectionState.Open)
                {
                    mCommand.open();
                }
                mCommand.lCommand.CommandText = Sqlstring;
                object lobject = mCommand.lCommand.ExecuteScalar();
                mCommand.close();
                return lobject;
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
                mCommand.close();
            }
        }
        /// <summary>
        /// 执行查询语句返回影响行数 适用于执行删除修改操作
        /// </summary>
        /// <param name="Sqlstring"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string Sqlstring)
        {
            try
            {
                if (mCommand.lCommand.Connection.State != ConnectionState.Open)
                {
                    mCommand.open();
                }
                mCommand.lCommand.CommandText = Sqlstring;
                int lint = mCommand.lCommand.ExecuteNonQuery();
                return lint;
            }
            catch (Exception eee)
            {
                throw eee;
            }
            finally
            {
                mCommand.close();
            }

        }
        #endregion
    }
}
