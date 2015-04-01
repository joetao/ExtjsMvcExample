using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;

namespace ExjtsMvcExample.DbAccess
{
    public class DataConn
    {

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public DataConn()
        {
            string strSQLConnection = ConfigurationManager.ConnectionStrings["postgis"].ConnectionString;
        }
        #endregion

        #region 数据库连接字符串
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string _strConnectionString = string.Empty;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string strConnectionString
        {
            set { this._strConnectionString = value; }
            get { return this._strConnectionString.Trim(); }
        }
        #endregion

        #region 打开新的数据库连接
        /// <summary>
        /// 打开新的数据库连接
        /// </summary>
        /// <returns></returns>
        private NpgsqlConnection openConnection()
        {
            try
            {
                NpgsqlConnection sqlConnection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgis"].ConnectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 关闭数据库连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="sqlConnection">开启的数据库连接</param>
        private void closeConnection(NpgsqlConnection sqlConnection)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 打开新数据库Command
        /// <summary>
        /// 打开新数据库Command
        /// </summary>
        /// <param name="sqlConnection">数据库连接</param>
        /// <returns></returns>
        private NpgsqlCommand newCommand(NpgsqlConnection sqlConnection)
        {
            try
            {
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.CommandType = CommandType.Text;
                //定义数据库连接
                comm.Connection = sqlConnection;
                return comm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 数据查询
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Select(string sql)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection();
            try
            {
                //打开数据库连接
                sqlConnection = this.openConnection();
                NpgsqlCommand comm = this.newCommand(sqlConnection);
                DataSet ds = new DataSet();

                comm.CommandText = sql;

                NpgsqlDataAdapter sda = new NpgsqlDataAdapter(comm);
                sda.Fill(ds);

                //关闭数据库连接
                this.closeConnection(sqlConnection);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeConnection(sqlConnection);
            }
        }
        #endregion

        #region 数据插入
        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Int32 Insert(string sql)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection();
            try
            {
                //打开数据库连接
                sqlConnection = this.openConnection();
                NpgsqlCommand comm = this.newCommand(sqlConnection);
                comm.CommandText = sql.ToString();

                Int32 i = comm.ExecuteNonQuery();

                //关闭数据库连接
                closeConnection(sqlConnection);

                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeConnection(sqlConnection);
            }
        }
        #endregion

        #region 数据更新
        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Int32 Update(string sql)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection();
            try
            {
                //打开数据库连接
                sqlConnection = this.openConnection();
                NpgsqlCommand comm = this.newCommand(sqlConnection);
                comm.CommandText = sql.ToString();

                Int32 i = comm.ExecuteNonQuery();

                //关闭数据库连接
                closeConnection(sqlConnection);

                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeConnection(sqlConnection);
            }
        }
        #endregion

        #region 数据删除
        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Int32 Delete(string sql)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection();
            try
            {
                //打开数据库连接
                sqlConnection = this.openConnection();
                NpgsqlCommand comm = this.newCommand(sqlConnection);
                comm.CommandText = sql.ToString();

                Int32 i = comm.ExecuteNonQuery();

                //关闭数据库连接
                closeConnection(sqlConnection);

                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeConnection(sqlConnection);
            }
        }
        #endregion
    }
}