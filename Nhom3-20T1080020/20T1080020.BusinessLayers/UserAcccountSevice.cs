using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20T1080020.DataLayers;
using _20T1080020.DomainModels;

namespace _20T1080020.BusinessLayers
{
    /// <summary>
    /// các chức năng tác nghiệp liên quan đến tài khoản
    /// 
    /// </summary>
    public static class UserAcccountSevice
    {
        private static IUserAccount employeeAccountDB;
        private static IUserAccount customerAcccountDB;

        static UserAcccountSevice()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            employeeAccountDB = new DataLayers.SQLServer.EmployeeAccountDAL(connectionString);
            customerAcccountDB = new DataLayers.SQLServer.EmployeeAccountDAL(connectionString);
        }

        public static UserAccount Authorize(AccountTypes accountType , string userName, string password)
        {
            if (accountType == AccountTypes.Employee)
                return employeeAccountDB.Authorize(userName, password);
            else
                return customerAcccountDB.Authorize(userName, password);
        }

        public static bool ChangePassword(AccountTypes accountType , string userName, string oldPassword, string newPassword)
        {
            if (accountType == AccountTypes.Employee)
                return employeeAccountDB.ChangePassword(userName, oldPassword, newPassword);
            else
                return customerAcccountDB.ChangePassword(userName, oldPassword, newPassword);
        }
    }
}
