using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _19T1021316.DataLayers.SQL_Server
{
    /// <summary>
    /// lớp cơ sở (cha) cho các lớp cài đặt cho các chức năng xử lý dữ liệu trên sql server
    /// </summary>
    public abstract class _BaseDAL
    {
        /// <summary>
        /// chuỗi tham số kết nối đến sql
        /// </summary>
        protected string _connectionString;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="connectionString"></param>
        public _BaseDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// tạo và mở kết nối csdl sql server
        /// </summary>
        /// <returns></returns>
        protected SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
