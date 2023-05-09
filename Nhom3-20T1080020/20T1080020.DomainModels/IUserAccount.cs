using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20T1080020.DomainModels;
namespace _20T1080020.DomainModels
{
    /// <summary>
    /// ddingj nhĩa các phép xử lý dữ liệu liên quan đến tài khoản của người dùng
    /// </summary>
    public interface IUserAccount

    {
        /// <summary>
        /// kiểm tra xem tên đăng nhập và mật khẩu của người dùng có hợp lệ?
        /// nếu hợp lệ thì trả về thông tin người dùng, ngược lại thì trả về null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserAccount Authorize(string userName, string password);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        bool ChangePassword(string UserName, string oldPassword, string newPassword);
    }
}
