using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20T1080020.DomainModels;

namespace _20T1080020.DataLayers.SQLServer
{
    public class CustomerAccountDAL : _BaseDAL, IUserAccount
    {
        public CustomerAccountDAL(string connectionString) : base(connectionString)
        {
        }

        public UserAccount Authorize(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string UserName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
