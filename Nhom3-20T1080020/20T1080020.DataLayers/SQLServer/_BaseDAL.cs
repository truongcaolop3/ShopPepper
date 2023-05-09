using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _20T1080020.DataLayers.SQLServer
{
    /// <summary>
    /// Lớp cơ sử cho các lớp cài đặt chức nắng xử lts dữ liệu trên SQL Server
    /// </summary>
    public abstract class _BaseDAL
    {
        /// <summary>
        /// Chuoix tham số kết nối CSDL
        /// </summary>
        protected String _connectionString;
        /// <summary>
        /// Tạo và mở kết nối đến CSDL
        /// </summary>
        /// <param name="connectionString"></param>
        public _BaseDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            
            return connection;
        }
        /// <summary>
        /// Đổi 1 giá trị sang giá trị để tương thích với dữ liệu được lưu cơ sở dữ liệu
        /// (Giải thích: vì giá trị null muốn lưu vào CSDL phải chuyển thành DBNull.Value)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected object ToDBValue(object value)
        {
            if (value != null)
                return value;
            return DBNull.Value;
        }
        /// <summary>
        /// Chuyển giá trị từ trong CSDL sang kiểu Nullable int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected int? DBValueToNullableInt(object value)
        {
            try
            {
                if (value == DBNull.Value)
                    return null;
                return Convert.ToInt32(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Chuyển giá trị từ trong CSDL sang kiểu Nullable DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected DateTime? DBValueToNullableDateTime(object value)
        {
            try
            {
                if (value == DBNull.Value)
                    return null;
                return Convert.ToDateTime(value);
            }
            catch
            {
                return null;
            }
        }
    }
}
