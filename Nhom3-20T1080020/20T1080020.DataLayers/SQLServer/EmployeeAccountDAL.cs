using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20T1080020.DomainModels;
namespace _20T1080020.DataLayers.SQLServer
{
    public class EmployeeAccountDAL : _BaseDAL, IUserAccount
    {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="connectionString"></param>
            public EmployeeAccountDAL(string connectionString) : base(connectionString)
            {
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="userName"></param>
            /// <param name="password"></param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            public UserAccount Authorize(string userName, string password)
            {
                UserAccount data = null;
                using (var connection = OpenConnection())
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Employees WHERE Email=@Email AND Password=@Password";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Email", userName);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (var dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (dbReader.Read())
                        {
                            data = new UserAccount()
                            {
                                UserID = Convert.ToString(dbReader["EmployeeID"]),
                                UserName = Convert.ToString(dbReader["Email"]),
                                FullName = $"{dbReader["FirstName"]} {dbReader["LastName"]}",
                                Email = Convert.ToString(dbReader["Email"]),
                                Photo = Convert.ToString(dbReader["Photo"]),
                                Password = "",
                                RoleNames = ""
                            };
                        }
                        dbReader.Close();
                    };
                    connection.Close();
                };
                return data;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="userName"></param>
            /// <param name="oldPassword"></param>
            /// <param name="newPassword"></param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            public bool ChangePassword(string userName, string oldPassword, string newPassword)
            {
                bool result = false;
                // so sánh mật khẩu cũ trong database
                UserAccount userAccount = Authorize(userName, oldPassword);
                if (userAccount == null) return result;
                using (SqlConnection connection = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    // cập nhật mật khẩu mới
                    cmd.CommandText = @"UPDATE Employees
                                    SET Password = @Password
                                    WHERE Email = @Email";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@Password", newPassword);
                    cmd.Parameters.AddWithValue("@Email", userName);
                    result = cmd.ExecuteNonQuery() > 0;
                    connection.Close();
                };
                return result;
            }
        }
    }
