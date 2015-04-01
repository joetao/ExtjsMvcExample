using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;

namespace ExjtsMvcExample.DbAccess
{
    public class DBHelper
    {
        //新建数据库连接 
        private static string connstr;
        private static NpgsqlCommand cmd;
        private static NpgsqlDataAdapter adapter;
        private static NpgsqlDataReader dr;
        private static DataSet ds = new DataSet();

        /// <summary>
        /// 数据库连接
        /// </summary>
        public static NpgsqlConnection connectionstring
        {
            get
            {
                string str_1 = ConfigurationManager.ConnectionStrings["postgis"].ConnectionString;
                string str_2 = "Server=localhost;Port=5432;Database=extjs_test;User Id=postgres;Password=1234;Encoding=UNICODE;Sslmode=Prefer;Pooling=true;";
                connstr = string.IsNullOrEmpty(str_1) ? str_2 : str_1;
                NpgsqlConnection conn = new NpgsqlConnection(connstr);
                conn.Open();
                return conn;
            }
        }

        /// <summary>
        /// 单向操作,返回受影响的行数(主要用于增,删,改)   
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetExecuteNonQuery(string sql)
        {
            int Result = 0;
            using (cmd = new NpgsqlCommand(sql, DBHelper.connectionstring))
            {
                Result = cmd.ExecuteNonQuery();
                return Result;
            }
        }

        /// <summary> 
        /// 单向操作,返回首行首列(单值).
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetExecuteScalar(string sql)
        {
            int Result = 0;
            using (cmd = new NpgsqlCommand(sql, DBHelper.connectionstring))
            {
                Result = (int)cmd.ExecuteScalar();
                return Result;
            }
        }

        /// <summary>
        /// 返回只读只进的数据流(只要用于单条数据显示(if)，多条数据显示(while))   
        /// </summary>    
        /// <param name="sql"></param>   
        /// <returns></returns>     
        public static NpgsqlDataReader GetDataReader(string sql)
        {
            using (cmd = new NpgsqlCommand(sql, DBHelper.connectionstring))
            {
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
        }

        /// <summary>    
        /// 用于数据显示(DataGrid,ComboBox)，返回时一个DataSet集合   
        /// </summary>    
        /// <param name="sql"></param>   
        /// <param name="tablename"></param>   
        /// <returns></returns>
        public static DataSet GetDataSet(string sql, string tablename)
        {
            using (adapter = new NpgsqlDataAdapter(sql, DBHelper.connectionstring))
            {
                if (ds.Tables[tablename] != null)
                {
                    ds.Tables[tablename].Rows.Clear();
                }
                adapter.Fill(ds, tablename);
                return ds;
            }
        }

        /// <summary>
        /// 调用后记得Close
        /// </summary>
        public void DemoShow()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBHelper.connectionstring.Close();
            }
        }
    }
}